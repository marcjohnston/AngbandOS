using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantGoldDragonFlyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'F';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Giant gold dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
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
        public override bool BreatheSound => true;
        public override string Description => "Large beating wings support this dazzling insect. A loud buzzing noise pervades the air.";
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Giant gold dragon fly";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 19;
        public override int Mexp => 78;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => " Giant gold ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
