namespace AngbandOS.Core.Rewards;

[Serializable]
internal class DoHavocReward : Reward
{
    private DoHavocReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} whispers out:");
        SaveGame.MsgPrint("'Death and destruction! This pleaseth me!'");
        SaveGame.CallChaos();
    }
}