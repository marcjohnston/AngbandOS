// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureAllScript : Script, IScript
{
    private CureAllScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the cure all script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.RemoveAllCurse();
        SaveGame.RestoreAbilityScore(Ability.Strength);
        SaveGame.RestoreAbilityScore(Ability.Intelligence);
        SaveGame.RestoreAbilityScore(Ability.Wisdom);
        SaveGame.RestoreAbilityScore(Ability.Constitution);
        SaveGame.RestoreAbilityScore(Ability.Dexterity);
        SaveGame.RestoreAbilityScore(Ability.Charisma);
        SaveGame.RunScript(nameof(RestoreLevelScript));
        SaveGame.Health = SaveGame.MaxHealth;
        SaveGame.FractionalHealth = 0;
        SaveGame.Mana = SaveGame.MaxMana;
        SaveGame.FractionalMana = 0;
        SaveGame.TimedBlindness.ResetTimer();
        SaveGame.TimedConfusion.ResetTimer();
        SaveGame.TimedPoison.ResetTimer();
        SaveGame.TimedFear.ResetTimer();
        SaveGame.TimedParalysis.ResetTimer();
        SaveGame.TimedHallucinations.ResetTimer();
        SaveGame.TimedStun.ResetTimer();
        SaveGame.TimedBleeding.ResetTimer();
        SaveGame.TimedSlow.ResetTimer();
        SaveGame.SetFood(Constants.PyFoodMax - 1);
        SaveGame.DoCmdRedraw();
    }
}
