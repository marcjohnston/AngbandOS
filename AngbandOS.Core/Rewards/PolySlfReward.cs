namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class PolySlfReward : Reward
    {
        private PolySlfReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Thou needst a new form, mortal!'");
            SaveGame.Player.PolymorphSelf(SaveGame);
        }
    }
}