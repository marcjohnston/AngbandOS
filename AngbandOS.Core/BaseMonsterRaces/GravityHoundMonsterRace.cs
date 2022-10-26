using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GravityHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Gravity hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override bool BreatheGravity => true;
        public override string Description => "Unfettered by the usual constraints of gravity, these unnatural creatures are walking on the walls and even the ceiling! The earth suddenly feels rather less solid as you see gravity warp all round the monsters.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Gravity hound";
        public override bool Friends => true;
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 35;
        public override int Mexp => 500;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Gravity   ";
        public override string SplitName3 => "   hound    ";
    }
}
