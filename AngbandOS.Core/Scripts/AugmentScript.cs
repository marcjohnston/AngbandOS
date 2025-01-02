// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AugmentScript : Script, IIdentifiedScript
{
    private AugmentScript(Game game) : base(game) { }

    /// <summary>
    /// Augments all ability scores and returns true, if any ability score was increased; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteIdentifiedScript()
    {
        bool isIdentified = false;

        // Augmentation increases all ability scores
        IdentifiedResult identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Strength);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Intelligence);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Wisdom);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Dexterity);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Constitution);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(AbilityEnum.Charisma);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }
}
