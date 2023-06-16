namespace AngbandOS.Core.Rewards;

[Serializable]
internal class CurseArReward : Reward
{
    private CurseArReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Thou reliest too much on thine equipment.'");
        SaveGame.CurseArmour();
    }
}