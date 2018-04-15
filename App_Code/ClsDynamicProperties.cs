//
// Author: James Nies (23/05/2005)
// Contributor: Tobias Hertkorn (31/05/2006) - Generics support.
// Contributor: Omer van Kloeten (21/06/2006) - CodeDom instead of pure IL.
// Description: The GenericPropertyAccessor class provides fast dynamic access
//		to a property of a specified target class.
//
// *** This code was written by James Nies and has been provided to you, ***
// *** free of charge, for your use.  I assume no responsibility for any ***
// *** undesired events resulting from the use of this code or the		 ***
// *** information that has been provided with it .						 ***
//

using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;
using System.Collections;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

namespace FastDynamicPropertyAccessor
{
    /// <summary>
    /// The GenericPropertyAccessor class provides fast dynamic access
    /// to a property of a specified target class.
    /// </summary>
    public class GenericPropertyAccessor<T, V> : IGenericPropertyAccessor<T, V>
    {
        /// <summary>
        /// Creates a new property accessor.
        /// </summary>
        /// <param name="property">Property name.</param>
        public GenericPropertyAccessor(string property)
        {
            this.mTargetType = typeof(T);
            this.mProperty = property;

            PropertyInfo propertyInfo =
                this.mTargetType.GetProperty(property);

            //
            // Make sure the property exists
            //
            if (propertyInfo == null)
            {
                throw new PropertyAccessorException(
                    string.Format("Property \"{0}\" does not exist for type "
                    + "{1}.", property, this.mTargetType));
            }
            else
            {
                this.mCanRead = propertyInfo.CanRead;
                this.mCanWrite = propertyInfo.CanWrite;
                this.mPropertyType = propertyInfo.PropertyType;
            }
        }

        /// <summary>
        /// Gets the property value from the specified target.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <returns>Property value.</returns>
        public V Get(T target)
        {
            if (mCanRead)
            {
                if (this.mEmittedPropertyAccessor == null)
                {
                    this.Init();
                }

                return this.mEmittedPropertyAccessor.Get(target);
            }
            else
            {
                throw new PropertyAccessorException(
                    string.Format("Property \"{0}\" does not have a get method.",
                    mProperty));
            }
        }

        /// <summary>
        /// Sets the property for the specified target.
        /// </summary>
        /// <param name="target">Target object.</param>
        /// <param name="value">Value to set.</param>
        public void Set(T target, V value)
        {
            if (mCanWrite)
            {
                if (this.mEmittedPropertyAccessor == null)
                {
                    this.Init();
                }

                //
                // Set the property value
                //
                this.mEmittedPropertyAccessor.Set(target, value);
            }
            else
            {
                throw new PropertyAccessorException(
                    string.Format("Property \"{0}\" does not have a set method.",
                    mProperty));
            }
        }

        /// <summary>
        /// Whether or not the Property supports read access.
        /// </summary>
        public bool CanRead
        {
            get
            {
                return this.mCanRead;
            }
        }

        /// <summary>
        /// Whether or not the Property supports write access.
        /// </summary>
        public bool CanWrite
        {
            get
            {
                return this.mCanWrite;
            }
        }

        /// <summary>
        /// The Type of object this property accessor was
        /// created for.
        /// </summary>
        public Type TargetType
        {
            get
            {
                return this.mTargetType;
            }
        }

        /// <summary>
        /// The Type of the Property being accessed.
        /// </summary>
        public Type PropertyType
        {
            get
            {
                return this.mPropertyType;
            }
        }

        private Type mTargetType;
        private string mProperty;
        private Type mPropertyType;
        private IGenericPropertyAccessor<T, V> mEmittedPropertyAccessor;
        private bool mCanRead;
        private bool mCanWrite;

        /// <summary>
        /// This method generates creates a new assembly containing
        /// the Type that will provide dynamic access.
        /// </summary>
        private void Init()
        {
            // Create the assembly and an instance of the 
            // property accessor class.
            Assembly assembly = EmitAssembly();

            this.mEmittedPropertyAccessor =
                assembly.CreateInstance("FastDynamicPropertyAccessor.Property") as IGenericPropertyAccessor<T, V>;

            if (this.mEmittedPropertyAccessor == null)
            {
                throw new Exception("Unable to create property accessor.");
            }
        }

        /// <summary>
        /// Create an assembly that will provide the get and set methods.
        /// </summary>
        private Assembly EmitAssembly()
        {
            PropertyInfo pi = typeof(T).GetProperty(this.mProperty);
            bool hasGet = (pi.GetGetMethod() != null), hasSet = (pi.GetSetMethod() != null);

            // Create the type
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace("FastDynamicPropertyAccessor");
            CodeTypeDeclaration propertyAccessor = new CodeTypeDeclaration("Property");
            propertyAccessor.Attributes |= MemberAttributes.Final | MemberAttributes.Public;
            propertyAccessor.BaseTypes.Add(typeof(IGenericPropertyAccessor<T, V>));

            //
            // Generate Get method
            //
            CodeMemberMethod get = new CodeMemberMethod();
            get.Name = "Get";
            get.ReturnType = new CodeTypeReference(typeof(V));
            get.Parameters.Add(new CodeParameterDeclarationExpression(typeof(T), "target"));
            get.Attributes &= ~MemberAttributes.AccessMask;
            get.Attributes |= MemberAttributes.Public;

            if (hasGet)
            {
                get.Statements.Add(new CodeMethodReturnStatement(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("target"), this.mProperty)));
            }
            else
            {
                get.Statements.Add(new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(MissingMethodException))));
            }

            propertyAccessor.Members.Add(get);

            //
            // Generate Set method
            //
            CodeMemberMethod set = new CodeMemberMethod();
            set.Name = "Set";
            set.Parameters.Add(new CodeParameterDeclarationExpression(typeof(T), "target"));
            set.Parameters.Add(new CodeParameterDeclarationExpression(typeof(V), "value"));
            set.Attributes &= ~MemberAttributes.AccessMask;
            set.Attributes |= MemberAttributes.Public;

            if (hasSet)
            {
                set.Statements.Add(new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("target"), this.mProperty), new CodeVariableReferenceExpression("value")));
            }
            else
            {
                set.Statements.Add(new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(MissingMethodException))));
            }

            propertyAccessor.Members.Add(set);

            ns.Types.Add(propertyAccessor);
            compileUnit.Namespaces.Add(ns);

            // Reference assemblies (for the original type, return value and the IGenericPropertyAccessor)
            CompilerParameters parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add(typeof(IGenericPropertyAccessor<T, V>).Assembly.Location);
            parameters.ReferencedAssemblies.Add(typeof(T).Assembly.Location);
            parameters.ReferencedAssemblies.Add(typeof(V).Assembly.Location);

            // Generation in memory means that no temporary file will be created.
            parameters.GenerateInMemory = true;

            // Compile the assembly
            CompilerResults cr = CSharpCodeProvider.CreateProvider("C#").CompileAssemblyFromDom(parameters, compileUnit);

            if (cr.Errors.Count > 0)
            {
                throw new PropertyAccessorException("Errors have been encountered while creating the dynamic assembly.");
            }

            return cr.CompiledAssembly;
        }
    }
}
