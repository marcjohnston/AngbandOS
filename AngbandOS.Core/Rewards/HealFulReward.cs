namespace AngbandOS.Core.Rewards;

[Serializable]
internal class HealFulReward : Reward
{
    private HealFulReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Rise, my servant!'");
        SaveGame.Player.RestoreLevel();
        SaveGame.Player.TimedPoison.ResetTimer();
        SaveGame.Player.TimedBlindness.ResetTimer();
        SaveGame.Player.TimedConfusion.ResetTimer();
        SaveGame.Player.TimedHallucinations.ResetTimer();
        SaveGame.Player.TimedStun.ResetTimer();
        SaveGame.Player.TimedBleeding.ResetTimer();
        SaveGame.Player.RestoreHealth(5000);
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.Player.TryRestoringAbilityScore(dummy);
        }
    }
}