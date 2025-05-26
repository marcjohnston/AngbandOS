// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AugmentScript : Script, IEatOrQuaffScript
{
    private AugmentScript(Game game) : base(game) { }

    /// <summary>
    /// Augments all ability scores and returns true, if any ability score was increased; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // Augmentation increases all ability scores
        IdentifiedResult identifiedResult = Game.TryIncreasingAbilityScore(Game.StrengthAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(Game.IntelligenceAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(Game.WisdomAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(Game.DexterityAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(Game.ConstitutionAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        identifiedResult = Game.TryIncreasingAbilityScore(Game.CharismaAbility);
        if (identifiedResult.IsIdentified)
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }
}
