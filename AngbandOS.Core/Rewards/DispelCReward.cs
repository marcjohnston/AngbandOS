namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class DispelCReward : Reward
    {
        private DispelCReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"You can feel the power of {patron.ShortName} assault your enemies!");
            SaveGame.DispelMonsters(SaveGame.Player.Level * 4);
        }
    }
}