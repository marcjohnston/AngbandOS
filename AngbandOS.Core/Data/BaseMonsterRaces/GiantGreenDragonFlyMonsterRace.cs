using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantGreenDragonFlyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'F';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Giant green dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
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
        public override bool BashDoor => true;
        public override bool BreathePoison => true;
        public override string Description => "A vast, foul-smelling dragonfly.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Giant green dragon fly";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int Level => 16;
        public override int Mexp => 70;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "Giant green ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
