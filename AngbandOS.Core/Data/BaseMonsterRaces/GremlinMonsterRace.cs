using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GremlinMonsterRace : Base2MonsterRace
    {
        public override char Character => 'u';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Gremlin";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.EatFood;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.EatFood;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.EatFood;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool Demon => true;
        public override string Description => "Don't feed them after midnight!";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Gremlin";
        public override int Hdice => 5;
        public override int Hside => 5;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int Level => 8;
        public override int Mexp => 6;
        public override bool Multiply => true;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Gremlin   ";
        public override bool TakeItem => true;
    }
}
