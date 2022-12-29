using System.Reflection;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Print the version number and build info of the game
    /// </summary>
    [Serializable]
    internal class VersionCommand : ICommand
    {
        private VersionCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'V';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
            Version version = assembly.Version;
            DateTime CompileTime = new DateTime(2000, 1, 1).AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build).AddSeconds(Assembly.GetExecutingAssembly().GetName().Version.Revision * 2);
            saveGame.MsgPrint($"You are playing {Constants.VersionName} {version}.");
            saveGame.MsgPrint($"(Build time: {CompileTime})");
        }

    }
}
