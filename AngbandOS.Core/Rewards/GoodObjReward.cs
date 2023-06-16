namespace AngbandOS.Core.Rewards;

[Serializable]
internal class GoodObjReward : Reward
{
    private GoodObjReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} whispers:");
        SaveGame.MsgPrint("'Use my gift wisely.'");
        SaveGame.Level.Acquirement(SaveGame.Player.MapY, SaveGame.Player.MapX, 1, false);
    }
}