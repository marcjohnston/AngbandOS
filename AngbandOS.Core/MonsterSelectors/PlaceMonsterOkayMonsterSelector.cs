// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSelectors;

[Serializable]
internal class PlaceMonsterOkayMonsterSelector : MonsterSelector
{
    private int _placeMonsterIdx;
    public PlaceMonsterOkayMonsterSelector(int placeMonsterIdx)
    {
        _placeMonsterIdx = placeMonsterIdx;
    }

    public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
    {
        MonsterRace pPtr = saveGame.SingletonRepository.MonsterRaces[_placeMonsterIdx];
        if (rPtr.Character != pPtr.Character)
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
