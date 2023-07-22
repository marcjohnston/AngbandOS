// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class HealFulReward : Reward
{
    private HealFulReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Rise, my servant!'");
        SaveGame.RestoreLevel();
        SaveGame.TimedPoison.ResetTimer();
        SaveGame.TimedBlindness.ResetTimer();
        SaveGame.TimedConfusion.ResetTimer();
        SaveGame.TimedHallucinations.ResetTimer();
        SaveGame.TimedStun.ResetTimer();
        SaveGame.TimedBleeding.ResetTimer();
        SaveGame.RestoreHealth(5000);
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.TryRestoringAbilityScore(dummy);
        }
    }
}