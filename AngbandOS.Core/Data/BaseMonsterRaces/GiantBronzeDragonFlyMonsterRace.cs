using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantBronzeDragonFlyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'F';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Giant bronze dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => null;
        public override AttackType Attack1Type => AttackType.Nothing;
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
        public override bool BreatheConfusion => true;
        public override string Description => "This vast gleaming bronze fly has wings which beat mesmerically fast.";
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Giant bronze dragon fly";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 23;
        public override int Mexp => 70;
        public override bool NeverAttack => true;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "Giant bronze";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
