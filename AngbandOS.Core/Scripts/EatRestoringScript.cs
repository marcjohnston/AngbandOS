// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatRestoringScript : Script, IEatScript
{
    private EatRestoringScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteIdentifiedScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        bool ident = false;
        if (Game.TryRestoringAbilityScore(AbilityEnum.Strength))
        {
            ident = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Intelligence))
        {
            ident = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Wisdom))
        {
            ident = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Dexterity))
        {
            ident = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Constitution))
        {
            ident = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Charisma))
        {
            ident = true;
        }
        return ident;
    }
}
