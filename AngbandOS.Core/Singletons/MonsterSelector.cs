// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal abstract class MonsterSelector : IMonsterSelector, IGetKey
{
    protected Game Game { get; }
    protected MonsterSelector(Game game) // This object is a singleton
    {
        Game = game;
    }

    public string GetKey => GetType().Name;

    public void Bind(RestoreGameState? restoreGameState) { }

    public abstract MonsterRaceFilter GetMonsterFilter(MonsterRace monsterRace);

}