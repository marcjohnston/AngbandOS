namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class GreaObsReward : Reward
    {
        private GreaObsReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Behold, mortal, how generously I reward thy loyalty.'");
            SaveGame.Level.Acquirement(SaveGame.Player.MapY, SaveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, true);
        }
    }
}