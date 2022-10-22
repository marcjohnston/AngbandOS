using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class YoungGreenDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Green;
        public override string Name => "Young green dragon";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreathePoison => true;
        public override string Description => "It has a form that legends are made of. Its still-tender scales are a deep green in hue. Foul gas seeps through its scales.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Young green dragon";
        public override int Hdice => 27;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 29;
        public override int Mexp => 290;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override int Speed => 110;
        public override string SplitName1 => "   Young    ";
        public override string SplitName2 => "   green    ";
        public override string SplitName3 => "   dragon   ";
    }
}
