﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reversi {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Reversi.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Black.
        /// </summary>
        public static string black_color {
            get {
                return ResourceManager.GetString("black_color", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Board Size: {0}x{0} (Click to increase).
        /// </summary>
        public static string choose_board_size {
            get {
                return ResourceManager.GetString("choose_board_size", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to draw.
        /// </summary>
        public static string draw {
            get {
                return ResourceManager.GetString("draw", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It&apos;s a draw!.
        /// </summary>
        public static string end_game_draw {
            get {
                return ResourceManager.GetString("end_game_draw", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Won!! ({1},{2}) ({3}/{4}).
        /// </summary>
        public static string end_game_winner_string_1 {
            get {
                return ResourceManager.GetString("end_game_winner_string_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Would you like another round?.
        /// </summary>
        public static string end_game_winner_string_2 {
            get {
                return ResourceManager.GetString("end_game_winner_string_2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Othello - {0}&apos;s Turn.
        /// </summary>
        public static string form_title_turn {
            get {
                return ResourceManager.GetString("form_title_turn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Othello.
        /// </summary>
        public static string game_basic_title {
            get {
                return ResourceManager.GetString("game_basic_title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Do you want to play again? press Y/N.
        /// </summary>
        public static string play_again {
            get {
                return ResourceManager.GetString("play_again", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Play against the computer.
        /// </summary>
        public static string play_against_computer {
            get {
                return ResourceManager.GetString("play_against_computer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Play against your friend.
        /// </summary>
        public static string play_against_player {
            get {
                return ResourceManager.GetString("play_against_player", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Thank you for playing, Hope to see you soon!.
        /// </summary>
        public static string player_quit_game {
            get {
                return ResourceManager.GetString("player_quit_game", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Othello - Game Settings.
        /// </summary>
        public static string setting_title {
            get {
                return ResourceManager.GetString("setting_title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to White.
        /// </summary>
        public static string white_color {
            get {
                return ResourceManager.GetString("white_color", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The winner is {0} !.
        /// </summary>
        public static string winner_declaration {
            get {
                return ResourceManager.GetString("winner_declaration", resourceCulture);
            }
        }
    }
}
