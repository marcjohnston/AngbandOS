using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathSwordMonsterRace : Base2MonsterRace
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Death sword";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 5;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 5;
        public override int Attack4DSides => 5;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A bloodthirsty blade lurking for prey. Beware! ";
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Death sword";
        public override int Hdice => 6;
        public override int Hside => 6;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 6;
        public override int Mexp => 30;
        public override bool NeverMove => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override int Rarity => 5;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "   sword    ";
        public override bool Stupid => true;
    }
}
