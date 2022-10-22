using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OlogMonsterRace : Base2MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.Green;
        public override string Name => "Olog";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override string Description => "It is a massive intelligent troll with needle sharp fangs.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Olog";
        public override bool Friends => true;
        public override int Hdice => 42;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 35;
        public override int Mexp => 400;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Olog    ";
        public override bool Troll => true;
    }
}
