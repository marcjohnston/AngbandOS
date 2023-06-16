namespace AngbandOS.Core.Rewards;

[Serializable]
internal class MassGenReward : Reward
{
    private MassGenReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} rings out:");
        SaveGame.MsgPrint("'Let me relieve thee of thine oppressors!'");
        SaveGame.MassCarnage(false);
    }
}