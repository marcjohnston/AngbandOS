namespace AngbandOS.Core.Rewards;

[Serializable]
internal class AugmAblReward : Reward
{
    private AugmAblReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Receive this modest gift from me!'");
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.Player.TryIncreasingAbilityScore(dummy);
        }
    }
}