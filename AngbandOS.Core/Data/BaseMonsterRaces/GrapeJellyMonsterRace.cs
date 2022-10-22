using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GrapeJellyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Grape jelly";

        public override int ArmourClass => 1;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Exp10;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It is a pulsing mound of glowing flesh.";
        public override bool DrainMana => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Grape jelly";
        public override int Hdice => 52;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 12;
        public override int Mexp => 60;
        public override bool NeverMove => true;
        public override int NoticeRange => 2;
        public override int Rarity => 3;
        public override int Sleep => 99;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Grape    ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
    }
}
