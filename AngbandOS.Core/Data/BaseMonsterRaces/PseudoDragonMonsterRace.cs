using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class PseudoDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "Pseudo dragon";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheDark => true;
        public override bool BreatheLight => true;
        public override bool Confuse => true;
        public override string Description => "A small relative of the dragon that inhabits dark caves.";
        public override bool Dragon => true;
        public override bool Drop60 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Pseudo dragon";
        public override int Hdice => 20;
        public override int Hside => 10;
        public override int Level => 10;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Pseudo   ";
        public override string SplitName3 => "   dragon   ";
    }
}
