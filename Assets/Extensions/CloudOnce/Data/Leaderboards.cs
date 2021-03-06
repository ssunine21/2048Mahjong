// <copyright file="Leaderboards.cs" company="Jan Ivar Z. Carlsen, Sindri Jóelsson">
// Copyright (c) 2016 Jan Ivar Z. Carlsen, Sindri Jóelsson. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace CloudOnce
{
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Provides access to leaderboards registered via the CloudOnce Editor.
    /// This file was automatically generated by CloudOnce. Do not edit.
    /// </summary>
    public static class Leaderboards
    {
        private static readonly UnifiedLeaderboard s_score3x3 = new UnifiedLeaderboard("Score3x3",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQAQ"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQAQ"
#else
            "Score3x3"
#endif
            );

        public static UnifiedLeaderboard Score3x3
        {
            get { return s_score3x3; }
        }

        private static readonly UnifiedLeaderboard s_score4x4 = new UnifiedLeaderboard("Score4x4",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQAg"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQAg"
#else
            "Score4x4"
#endif
            );

        public static UnifiedLeaderboard Score4x4
        {
            get { return s_score4x4; }
        }

        private static readonly UnifiedLeaderboard s_score5x5 = new UnifiedLeaderboard("Score5x5",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQAw"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQAw"
#else
            "Score5x5"
#endif
            );

        public static UnifiedLeaderboard Score5x5
        {
            get { return s_score5x5; }
        }

        private static readonly UnifiedLeaderboard s_score6x6 = new UnifiedLeaderboard("Score6x6",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQBA"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQBA"
#else
            "Score6x6"
#endif
            );

        public static UnifiedLeaderboard Score6x6
        {
            get { return s_score6x6; }
        }

        private static readonly UnifiedLeaderboard s_score7x7 = new UnifiedLeaderboard("Score7x7",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQBQ"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQBQ"
#else
            "Score7x7"
#endif
            );

        public static UnifiedLeaderboard Score7x7
        {
            get { return s_score7x7; }
        }

        private static readonly UnifiedLeaderboard s_score8x8 = new UnifiedLeaderboard("Score8x8",
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
            "CgkImujK958PEAIQBg"
#elif !UNITY_EDITOR && UNITY_ANDROID && CLOUDONCE_GOOGLE
            "CgkImujK958PEAIQBg"
#else
            "Score8x8"
#endif
            );

        public static UnifiedLeaderboard Score8x8
        {
            get { return s_score8x8; }
        }

        public static string GetPlatformID(string internalId)
        {
            return s_leaderboardDictionary.ContainsKey(internalId)
                ? s_leaderboardDictionary[internalId].ID
                : string.Empty;
        }

        private static readonly Dictionary<string, UnifiedLeaderboard> s_leaderboardDictionary = new Dictionary<string, UnifiedLeaderboard>
        {
            { "Score3x3", s_score3x3 },
            { "Score4x4", s_score4x4 },
            { "Score5x5", s_score5x5 },
            { "Score6x6", s_score6x6 },
            { "Score7x7", s_score7x7 },
            { "Score8x8", s_score8x8 }
        };
    }
}
