// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class MonsterRaceFilter : IMonsterSelector, IGetKey
{
    protected readonly Game Game;

    protected MonsterRaceFilter(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>

    public void Bind() { }

    public MonsterRaceFilter GetMonsterFilter(MonsterRace monsterRace) => this;

    /// <summary>
    /// Returns true, if a monster matches the selector.
    /// </summary>
    /// <param name="game"></param>
    /// <param name="rPtr">The monster race to check.</param>
    /// <returns></returns>
    public abstract bool Matches(MonsterRace rPtr);
}
