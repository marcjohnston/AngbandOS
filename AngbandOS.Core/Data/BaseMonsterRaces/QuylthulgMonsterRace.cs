using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class QuylthulgMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Quylthulg";

        public override int ArmourClass => 1;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Nothing;
        public override AttackType Attack1Type => AttackType.Nothing;
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
        public override bool Blink => true;
        public override string Description => "It is a strange pulsing mound of flesh.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Quylthulg";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 20;
        public override int Mexp => 250;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 10;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Quylthulg  ";
        public override bool SummonMonster => true;
    }
}
