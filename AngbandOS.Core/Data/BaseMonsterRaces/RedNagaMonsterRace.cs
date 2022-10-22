using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RedNagaMonsterRace : Base2MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Red naga";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Crush;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new LoseStrAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A large red snake with a woman's torso.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Red naga";
        public override int Hdice => 11;
        public override int Hside => 8;
        public override int Level => 7;
        public override int Mexp => 40;
        public override int NoticeRange => 20;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 120;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Red     ";
        public override string SplitName3 => "    naga    ";
        public override bool TakeItem => true;
    }
}
