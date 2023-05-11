namespace AngbandOS.Core.Rewards
{
    [Serializable]
    internal class CurseWpReward : Reward
    {
        private CurseWpReward(SaveGame saveGame) : base(saveGame) { }
        public override void GetReward(Patron patron)
        {
            SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
            SaveGame.MsgPrint("'Thou reliest too much on thine weapon.'");
            SaveGame.CurseWeapon();
        }
    }
}