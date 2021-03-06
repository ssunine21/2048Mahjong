// <copyright file="CloudIDs.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
#if (UNITY_ANDROID || UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
    using Internal;
    using UnityEngine;
#endif
    /// <summary>
    /// Provides access to achievement- and leaderboard IDs registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class CloudIDs
    {
        /// <summary>
        /// Contains properties that retrieves achievement IDs for the current platform.
        /// </summary>
        public static class AchievementIDs
        {
            public static string Tile2048
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQBw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQBw";
#elif UNITY_EDITOR
                    return "Tile2048";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile4096
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQCA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQCA";
#elif UNITY_EDITOR
                    return "Tile4096";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile8192
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQCQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQCQ";
#elif UNITY_EDITOR
                    return "Tile8192";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile16384
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQCg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQCg";
#elif UNITY_EDITOR
                    return "Tile16384";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile32768
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQCw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQCw";
#elif UNITY_EDITOR
                    return "Tile32768";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile65536
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQDA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQDA";
#elif UNITY_EDITOR
                    return "Tile65536";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Tile131072
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQDQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQDQ";
#elif UNITY_EDITOR
                    return "Tile131072";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points5000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQDg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQDg";
#elif UNITY_EDITOR
                    return "Points5000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points10000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQDw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQDw";
#elif UNITY_EDITOR
                    return "Points10000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points25000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQEA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQEA";
#elif UNITY_EDITOR
                    return "Points25000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points50000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQEQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQEQ";
#elif UNITY_EDITOR
                    return "Points50000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points100000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQEg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQEg";
#elif UNITY_EDITOR
                    return "Points100000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points200000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQEw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQEw";
#elif UNITY_EDITOR
                    return "Points200000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points300000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQFA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQFA";
#elif UNITY_EDITOR
                    return "Points300000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points400000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQFQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQFQ";
#elif UNITY_EDITOR
                    return "Points400000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points600000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQFg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQFg";
#elif UNITY_EDITOR
                    return "Points600000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points800000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQFw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQFw";
#elif UNITY_EDITOR
                    return "Points800000";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Points1000000
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQGA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQGA";
#elif UNITY_EDITOR
                    return "Points1000000";
#else
                    return string.Empty;
#endif
                }
            }
        }

        /// <summary>
        /// Contains properties that retrieves leaderboard IDs for the current platform.
        /// </summary>
        public static class LeaderboardIDs
        {
            public static string Score3x3
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQAQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQAQ";
#elif UNITY_EDITOR
                    return "Score3x3";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Score4x4
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQAg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQAg";
#elif UNITY_EDITOR
                    return "Score4x4";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Score5x5
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQAw";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQAw";
#elif UNITY_EDITOR
                    return "Score5x5";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Score6x6
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQBA";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQBA";
#elif UNITY_EDITOR
                    return "Score6x6";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Score7x7
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQBQ";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQBQ";
#elif UNITY_EDITOR
                    return "Score7x7";
#else
                    return string.Empty;
#endif
                }
            }

            public static string Score8x8
            {
                get
                {
#if UNITY_ANDROID && !UNITY_EDITOR
#if CLOUDONCE_GOOGLE
                    return "CgkImujK958PEAIQBg";
#else
                    return string.Empty;
#endif
#elif (UNITY_IOS || UNITY_TVOS) && !UNITY_EDITOR
                    return "CgkImujK958PEAIQBg";
#elif UNITY_EDITOR
                    return "Score8x8";
#else
                    return string.Empty;
#endif
                }
            }
        }
    }
}
