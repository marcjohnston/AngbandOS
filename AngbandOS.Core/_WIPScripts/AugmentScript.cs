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
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // Augmentation increases all ability scores
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            IdentifiedResultEnum identifiedResult = Game.TryIncreasingAbilityScore(ability);
            if (identifiedResult == IdentifiedResultEnum.True)
            {
                isIdentified = true;
            }
        }
        return isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}
