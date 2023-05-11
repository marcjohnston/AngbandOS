namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class LoseExpReward : Reward
    {
        private LoseExpReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Thou didst not deserve that, slave.'");
            SaveGame.Player.LoseExperience(SaveGame.Player.ExperiencePoints / 6);
        }
    }
}