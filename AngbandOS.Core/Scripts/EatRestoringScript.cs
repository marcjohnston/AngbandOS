// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EatRestoringScript : Script, IIdentifiedScript
{
    private EatRestoringScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        bool isIdentified = false;
        if (Game.TryRestoringAbilityScore(AbilityEnum.Strength))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Intelligence))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Wisdom))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Dexterity))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Constitution))
        {
            isIdentified = true;
        }
        if (Game.TryRestoringAbilityScore(AbilityEnum.Charisma))
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }
}
