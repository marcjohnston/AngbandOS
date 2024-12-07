// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AugmentScript : Script, INoticeableScript
{
    private AugmentScript(Game game) : base(game) { }

    /// <summary>
    /// Augments all ability scores and returns true, if any ability score was increased; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        bool identified = false;

        // Augmentation increases all ability scores
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Strength))
        {
            identified = true;
        }
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Intelligence))
        {
            identified = true;
        }
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Wisdom))
        {
            identified = true;
        }
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Dexterity))
        {
            identified = true;
        }
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Constitution))
        {
            identified = true;
        }
        if (Game.TryIncreasingAbilityScore(AbilityEnum.Charisma))
        {
            identified = true;
        }
        return identified;
    }
}
