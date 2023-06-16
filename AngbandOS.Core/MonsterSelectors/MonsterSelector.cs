// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal abstract class MonsterSelector
{
    /// <summary>
    /// Returns true, if a monster matches the selector.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="rPtr">The monster race to check.</param>
    /// <returns></returns>
    public abstract bool Matches(SaveGame saveGame, MonsterRace rPtr);

    public static MonsterSelector RandomBizarre()
    {
        switch (Program.Rng.DieRoll(6))
        {
            case 1:
                return new Bizarre1MonsterSelector();
            case 2:
                return new Bizarre2MonsterSelector();
            case 3:
                return new Bizarre3MonsterSelector();
            case 4:
                return new Bizarre4MonsterSelector();
            case 5:
                return new Bizarre5MonsterSelector();
            default:
                return new Bizarre6MonsterSelector();
        }
    }
}
