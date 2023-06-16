namespace AngbandOS.Core.Rewards;

[Serializable]
internal class CarnageReward : Reward
{
    private CarnageReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Let me relieve thee of thine oppressors!'");
        SaveGame.Carnage(false);
    }
}