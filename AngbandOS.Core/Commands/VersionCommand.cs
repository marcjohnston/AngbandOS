using AngbandOS.Core;
using System;
using System.Reflection;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Print the version number and build info of the game
    /// </summary>
    [Serializable]
    internal class VersionCommand : ICommand
    {
        public char Key => 'V';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
            Version version = assembly.Version;
            saveGame.MsgPrint($"You are playing {Constants.VersionName} {version}.");
            saveGame.MsgPrint($"(Build time: {Constants.CompileTime})");
        }

    }
}
