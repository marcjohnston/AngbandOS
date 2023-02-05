namespace AngbandOS.Core.Commands
{
    /// <summary>
    /// Tunnel into the wall (or whatever is in front of us
    /// </summary>
    [Serializable]
    internal class TunnelCommand : Command
    {
        private TunnelCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Key => 'T';

        public override int? Repeat => 99;

        public override bool Execute()
        {
            return SaveGame.DoCmdTunnel();
        }
    }
}
