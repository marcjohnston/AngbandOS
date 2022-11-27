using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterSelectors
{
    [Serializable]
    internal class DragonAuxMonsterSelector : MonsterSelector
    {
        private uint _vaultAuxDragonMask4;
        public DragonAuxMonsterSelector(uint vaultAuxDragonMask4)
        {
            _vaultAuxDragonMask4 = vaultAuxDragonMask4;
        }

        public override bool Matches(SaveGame saveGame, MonsterRace rPtr)
        {
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
            {
                return false;
            }
            if (!"Dd".Contains(rPtr.Character.ToString()))
            {
                return false;
            }
            if (rPtr.Flags4 != _vaultAuxDragonMask4)
            {
                return false;
            }
            return true;
        }
    }
}
