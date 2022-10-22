using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WhiteHarpyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override string Name => "White harpy";

        public override bool Animal => true;
        public override int ArmourClass => 17;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 1;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 2;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "A flying, screeching bird with a woman's face.";
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White harpy";
        public override int Hdice => 2;
        public override int Hside => 5;
        public override int Level => 2;
        public override int Mexp => 5;
        public override int NoticeRange => 16;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "   harpy    ";
    }
}
