﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiteFx.Context.NHibernate.Properties {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LiteFx.Context.NHibernate.Properties.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can call ConfigurationManager.Initialize only once..
        /// </summary>
        internal static string YouCanCallConfigurationManagerInitializeOnlyOnce {
            get {
                return ResourceManager.GetString("YouCanCallConfigurationManagerInitializeOnlyOnce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You can call SessionFactoryManager.Initialize only once..
        /// </summary>
        internal static string YouCanCallSessionFactoryManagerInitializeOnlyOnce {
            get {
                return ResourceManager.GetString("YouCanCallSessionFactoryManagerInitializeOnlyOnce", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have to call ConfigurationManager.Initialize at LiteFxWebNHibernate.Start..
        /// </summary>
        internal static string YouHaveToCallConfigurationManagerInitializeAtLiteFxWebNHibernateStart {
            get {
                return ResourceManager.GetString("YouHaveToCallConfigurationManagerInitializeAtLiteFxWebNHibernateStart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You have to call SessionFactoryManager.Initialize at LiteFxWebNHibernate.Start..
        /// </summary>
        internal static string YouHaveToCallSessionFactoryManagerInitializeAtLiteFxWebNHibernateStart {
            get {
                return ResourceManager.GetString("YouHaveToCallSessionFactoryManagerInitializeAtLiteFxWebNHibernateStart", resourceCulture);
            }
        }
    }
}