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
    private CureAllScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the cure all script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(RemoveAllCurseScript));
        Game.RestoreAbilityScore(AbilityEnum.Strength);
        Game.RestoreAbilityScore(AbilityEnum.Intelligence);
        Game.RestoreAbilityScore(AbilityEnum.Wisdom);
        Game.RestoreAbilityScore(AbilityEnum.Constitution);
        Game.RestoreAbilityScore(AbilityEnum.Dexterity);
        Game.RestoreAbilityScore(AbilityEnum.Charisma);
        Game.RunScript(nameof(RestoreLevelScript));
        Game.Health.IntValue = Game.MaxHealth.IntValue;
        Game.FractionalHealth = 0;
        Game.Mana.IntValue = Game.MaxMana.IntValue;
        Game.FractionalMana = 0;
        Game.BlindnessTimer.ResetTimer();
        Game.ConfusedTimer.ResetTimer();
        Game.PoisonTimer.ResetTimer();
        Game.FearTimer.ResetTimer();
        Game.ParalysisTimer.ResetTimer();
        Game.HallucinationsTimer.ResetTimer();
        Game.StunTimer.ResetTimer();
        Game.BleedingTimer.ResetTimer();
        Game.SlowTimer.ResetTimer();
        Game.SetFood(Constants.PyFoodMax - 1);
        Game.RunScript(nameof(RedrawScript));
    }
}
