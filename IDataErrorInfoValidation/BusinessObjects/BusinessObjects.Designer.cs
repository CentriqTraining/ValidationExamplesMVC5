﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObjects {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class BusinessObjects {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal BusinessObjects() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BusinessObjects.BusinessObjects", typeof(BusinessObjects).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First name cannot exceed 11 characters.
        /// </summary>
        public static string InvalidFirstNameLength {
            get {
                return ResourceManager.GetString("InvalidFirstNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Termination date cannot be in the future.
        /// </summary>
        public static string InvalidFutureTerminationDate {
            get {
                return ResourceManager.GetString("InvalidFutureTerminationDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hire date cannot be in the future.
        /// </summary>
        public static string InvalidHireDate {
            get {
                return ResourceManager.GetString("InvalidHireDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last name cannot exceed 11 characters.
        /// </summary>
        public static string InvalidLastNameLength {
            get {
                return ResourceManager.GetString("InvalidLastNameLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Position set to an invalid value.
        /// </summary>
        public static string InvalidPosition {
            get {
                return ResourceManager.GetString("InvalidPosition", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Salary outside the predefined range.
        /// </summary>
        public static string InvalidSalary {
            get {
                return ResourceManager.GetString("InvalidSalary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Termination date cannot be before hire date.
        /// </summary>
        public static string InvalidTerminationDate {
            get {
                return ResourceManager.GetString("InvalidTerminationDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to First name is required.
        /// </summary>
        public static string MissingFirstName {
            get {
                return ResourceManager.GetString("MissingFirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hire date must be provided.
        /// </summary>
        public static string MissingHireDate {
            get {
                return ResourceManager.GetString("MissingHireDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last name is required.
        /// </summary>
        public static string MissingLastName {
            get {
                return ResourceManager.GetString("MissingLastName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Position not set.
        /// </summary>
        public static string PositionNotSet {
            get {
                return ResourceManager.GetString("PositionNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Salary must be provided.
        /// </summary>
        public static string SalaryMissing {
            get {
                return ResourceManager.GetString("SalaryMissing", resourceCulture);
            }
        }
    }
}