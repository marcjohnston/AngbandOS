// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterFilters;

[Serializable]
internal abstract class MonsterFilter : IGetKey<string>, IMonsterFilter
{
    protected readonly SaveGame SaveGame;

    protected MonsterFilter(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public void Bind() { }

    /// <summary>
    /// Returns true, if a monster matches the selector.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <param name="rPtr">The monster race to check.</param>
    /// <returns></returns>
    public abstract bool Matches(MonsterRace rPtr);
}
