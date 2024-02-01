// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.DynamicMonsterFilters;

[Serializable]
internal class PlaceOkayDynamicMonsterFilter : IMonsterFilter
{
    private readonly SaveGame SaveGame;
    private int _placeMonsterIdx;
    public PlaceOkayDynamicMonsterFilter(SaveGame saveGame, int placeMonsterIdx)
    {
        _placeMonsterIdx = placeMonsterIdx;
        SaveGame = saveGame;
    }

    public bool Matches(MonsterRace rPtr)
    {
        MonsterRace pPtr = SaveGame.SingletonRepository.MonsterRaces[_placeMonsterIdx];
        if (rPtr.Symbol.Character != pPtr.Symbol.Character)
        {
            return false;
        }
        if (rPtr.Level > pPtr.Level)
        {
            return false;
        }
        if (rPtr.Unique)
        {
            return false;
        }
        if (_placeMonsterIdx == rPtr.Index)
        {
            return false;
        }
        return true;
    }
}
