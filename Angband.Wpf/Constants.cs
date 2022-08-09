using System;
using System.Reflection;

namespace Angband.Wpf
{
    internal static class Constants
    {
        public static readonly int VersionMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
        public static readonly int VersionMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
        public static readonly string VersionName = Assembly.GetExecutingAssembly().GetName().Name;
        public static readonly string VersionStamp = $"Version {VersionMajor}.{VersionMinor}";
    }
}