﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Trader.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Trader.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The Trader program is designed to be very similiar to the game called Taipan. You may buy and sell items, attempting to profit. However, you can be attacked by various enemies, or even have a chance at winning the lottery.
        ///
        ///Version: 1.0
        ///
        ///Copyright (C) 2012 Miguel Martin..
        /// </summary>
        internal static string About {
            get {
                return ResourceManager.GetString("About", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Eat a pineapple.
        ///
        ///
        ///----
        ///Game Preferences file format:
        ///
        ///SYNTAX:
        ///	To make a comment, prefix the line with the &apos;#&apos; character. 
        /// 	To define something, put the appropriate identifier on one line, followed by a colon.
        /// 	e.g.
        /// 	Item:
        /// 	appropriate properties
        ///
        ///	NOTE: Identifiers are NOT case sensitive
        /// 
        /// The recommended file format is the following:
        /// VERSION NUMBER (REQUIRED)
        /// A list locations
        /// A list of items
        /// A list of enemy names
        ///
        /// INFORMATION ON IDENTIFIERS AND 
        ///
        /// VERSION 1:
        ///
        /// Identifie [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string How_To_Play {
            get {
                return ResourceManager.GetString("How_To_Play", resourceCulture);
            }
        }
    }
}
