using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WarTrollMonsterRace : Base2MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.Red;
        public override string Name => "War troll";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 5;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A massive troll, equipped with a scimitar and heavy armour.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "War troll";
        public override bool Friends => true;
        public override int Hdice => 50;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 40;
        public override int Mexp => 800;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool Regenerate => true;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    War     ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}
