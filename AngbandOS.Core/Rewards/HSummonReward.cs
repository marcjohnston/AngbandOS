namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class HSummonReward : Reward
    {
        private HSummonReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Thou needst worthier opponents!'");
            SaveGame.ActivateHiSummon();
        }
    }
}