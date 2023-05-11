namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class GoodObsReward : Reward
    {
        private GoodObsReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Thy deed hath earned thee a worthy reward.'");
            SaveGame.Level.Acquirement(SaveGame.Player.MapY, SaveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, false);
        }
    }
}