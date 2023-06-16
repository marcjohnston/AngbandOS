namespace AngbandOS.Core.Rewards;

[Serializable]
internal class IgnoreReward : Reward
{
    private IgnoreReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"{patron.ShortName} ignores you.");
    }
}