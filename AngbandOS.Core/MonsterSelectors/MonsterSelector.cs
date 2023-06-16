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
