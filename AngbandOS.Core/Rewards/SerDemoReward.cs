namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class SerDemoReward : Reward
    {
        private SerDemoReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"{patron.ShortName} rewards you with a demonic servant!");
            if (!SaveGame.Level.SummonSpecificFriendly(SaveGame.Player.MapY, SaveGame.Player.MapX, SaveGame.Difficulty, new DemonMonsterSelector(), false))
            {
                SaveGame.MsgPrint("Nobody ever turns up...");
            }
        }
    }
}