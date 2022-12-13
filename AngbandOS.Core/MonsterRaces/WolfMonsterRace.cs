using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class WolfMonsterRace : MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wolf";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "It howls and snaps at you.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Wolf";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 6;
        public override int LevelFound => 10;
        public override int Mexp => 30;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Wolf    ";
    }
}
