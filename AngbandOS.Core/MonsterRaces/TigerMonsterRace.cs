using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class TigerMonsterRace : MonsterRace
    {
        public override char Character => 'f';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Tiger";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "One of the largest of its species, a sleek orange and black shape creeps towards you, ready to pounce.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Tiger";
        public override int Hdice => 12;
        public override int Hside => 10;
        public override int LevelFound => 12;
        public override int Mexp => 40;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Tiger    ";
    }
}
