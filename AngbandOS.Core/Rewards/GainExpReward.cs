namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class GainExpReward : Reward
    {
        private GainExpReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Well done, mortal! Lead on!'");
            if (SaveGame.Player.ExperiencePoints < Constants.PyMaxExp)
            {
                int ee = (SaveGame.Player.ExperiencePoints / 2) + 10;
                if (ee > 100000)
                {
                    ee = 100000;
                }
                SaveGame.MsgPrint("You feel more experienced.");
                SaveGame.Player.GainExperience(ee);
            }
        }
    }
}