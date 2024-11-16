// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class CloneSystemMonsterFilter : MonsterFilter
{
    private MonsterRace _race;

    public CloneSystemMonsterFilter(Game game, MonsterRace race) : base(game)
    {
        _race = race;
    }

    public override bool Matches(MonsterRace rPtr)
    {
        return rPtr == _race;
    }
}
