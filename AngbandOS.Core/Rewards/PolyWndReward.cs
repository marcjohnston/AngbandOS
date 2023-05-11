namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class PolyWndReward : Reward
    {
        private PolyWndReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"You feel the power of {patron.ShortName} touch you.");
            SaveGame.Player.PolymorphWounds();
        }
    }
}