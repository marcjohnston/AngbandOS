using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngbandOS.Core.MonsterSelectors
{
    internal class SummonSpecificOkayMonsterSelector : MonsterSelector
    {
        private int _summonSpecificType;
        private char? _summonKinType;
        public SummonSpecificOkayMonsterSelector(int summonSpecificType, char? summonKinType)
        {
            _summonSpecificType = summonSpecificType;
            _summonKinType = summonKinType;
        }

        public override bool Matches(SaveGame saveGame, int rIdx)
        {
            MonsterRace rPtr = saveGame.MonsterRaces[rIdx];
            bool okay = false;
            switch (_summonSpecificType)
            {
                case 0:
                    okay = true;
                    break;
                case Constants.SummonAnt:
                    okay = rPtr.Character == 'a' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonSpider:
                    okay = rPtr.Character == 'S' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHound:
                    okay = (rPtr.Character == 'C' || rPtr.Character == 'Z') && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHydra:
                    okay = rPtr.Character == 'M' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonCthuloid:
                    okay = (rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonDemon:
                    okay = (rPtr.Flags3 & MonsterFlag3.Demon) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonUndead:
                    okay = (rPtr.Flags3 & MonsterFlag3.Undead) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonDragon:
                    okay = (rPtr.Flags3 & MonsterFlag3.Dragon) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHiUndead:
                    okay = rPtr.Character == 'L' || rPtr.Character == 'V' || rPtr.Character == 'W';
                    break;
                case Constants.SummonHiDragon:
                    okay = rPtr.Character == 'D';
                    break;
                case Constants.SummonGoo:
                    okay = (rPtr.Flags3 & MonsterFlag3.GreatOldOne) != 0;
                    break;
                case Constants.SummonUnique:
                    okay = (rPtr.Flags1 & MonsterFlag1.Unique) != 0;
                    break;
                case Constants.SummonOrc:
                    okay = rPtr.Character == 'o' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonKobold:
                    okay = rPtr.Character == 'k' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonYeek:
                    okay = rPtr.Character == 'y' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHuman:
                    okay = rPtr.Character == 'p' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre1:
                    okay = rPtr.Character == 'm' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre2:
                    okay = rPtr.Character == 'b' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre3:
                    okay = rPtr.Character == 'Q' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre4:
                    okay = rPtr.Character == 'v' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre5:
                    okay = rPtr.Character == '$' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonBizarre6:
                    okay = (rPtr.Character == '!' || rPtr.Character == '?' || rPtr.Character == '=' || rPtr.Character == '$' ||
                            rPtr.Character == '|') && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonReaver:
                    okay = rPtr.Name == "Black reaver" && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonKin:
                    okay = rPtr.Character == _summonKinType && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonAvatar:
                    okay = rPtr.Name == "Avatar of Nyarlathotep" && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonAnimal:
                    okay = (rPtr.Flags3 & MonsterFlag3.Animal) != 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonAnimalRanger:
                    okay = (rPtr.Flags3 & MonsterFlag3.Animal) != 0 &&
                            "abcflqrwBCIJKMRS".Contains(rPtr.Character.ToString()) &&
                            (rPtr.Flags3 & MonsterFlag3.Dragon) == 0 && (rPtr.Flags3 & MonsterFlag3.Evil) == 0 &&
                            (rPtr.Flags3 & MonsterFlag3.Undead) == 0 && (rPtr.Flags3 & MonsterFlag3.Demon) == 0 &&
                            (rPtr.Flags3 & MonsterFlag3.Cthuloid) == 0 && rPtr.Flags4 == 0 && rPtr.Flags5 == 0 &&
                            rPtr.Flags6 == 0 && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHiUndeadNoUniques:
                    okay = (rPtr.Character == 'L' || rPtr.Character == 'V' || rPtr.Character == 'W') &&
                            (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonHiDragonNoUniques:
                    okay = rPtr.Character == 'D' && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonNoUniques:
                    okay = (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonPhantom:
                    okay = rPtr.Name.Contains("Phantom") && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
                case Constants.SummonElemental:
                    okay = rPtr.Name.Contains("lemental") && (rPtr.Flags1 & MonsterFlag1.Unique) == 0;
                    break;
            }
            return okay;
        }
    }
}
