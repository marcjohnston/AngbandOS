namespace AngbandOS.Core.Rewards;

[Serializable]
internal class DestructReward : Reward
{
    private DestructReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Death and destruction! This pleaseth me!'");
        SaveGame.DestroyArea(SaveGame.Player.MapY, SaveGame.Player.MapX, 25);
    }
}