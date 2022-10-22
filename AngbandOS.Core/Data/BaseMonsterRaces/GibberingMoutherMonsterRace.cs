using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GibberingMoutherMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Gibbering mouther";

        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Crawl;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BreatheLight => true;
        public override bool Confuse => true;
        public override string Description => "A chaotic mass of pulsating flesh, mouths and eyes.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Gibbering mouther";
        public override int Hdice => 8;
        public override int Hside => 6;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override int Level => 14;
        public override int Mexp => 20;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 15;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Gibbering  ";
        public override string SplitName3 => "  mouther   ";
    }
}
