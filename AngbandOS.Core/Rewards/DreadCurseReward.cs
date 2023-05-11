namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class DreadCurseReward : Reward
    {
        private DreadCurseReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} thunders:");
            SaveGame.MsgPrint("'Thou art growing arrogant, mortal.'");
            SaveGame.ActivateDreadCurse();
        }
    }
}