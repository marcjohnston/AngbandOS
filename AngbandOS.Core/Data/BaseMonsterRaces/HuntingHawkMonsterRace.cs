using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HuntingHawkMonsterRace : Base2MonsterRace
    {
        public override char Character => 'B';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Hunting hawk";

        public override bool Animal => true;
        public override int ArmourClass => 25;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 4;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "Trained to hunt and kill without fear.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hunting hawk";
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneFear => true;
        public override int Level => 8;
        public override int Mexp => 22;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Hunting   ";
        public override string SplitName3 => "    hawk    ";
    }
}
