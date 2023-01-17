using System.Reflection;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Print the version number and build info of the game
    /// </summary>
    [Serializable]
    internal class VersionCommand : Command
    {
        private VersionCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'V';

        public override bool Execute()
        {
            SaveGame.DoCmdVersion();
            return false;
        }
    }
}
