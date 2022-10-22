using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShadowCreatureMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Shadow creature";

        public override int ArmourClass => 12;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 7;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 7;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A humanoid creature with extra joints in its extremities.";
        public override bool Drop60 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Shadow creature";
        public override bool Friends => true;
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 10;
        public override bool Male => true;
        public override int Mexp => 35;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 16;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "  creature  ";
    }
}
