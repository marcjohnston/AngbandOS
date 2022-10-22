using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WhiteWolfMonsterRace : Base2MonsterRace
    {
        public override char Character => 'C';
        public override string Name => "White wolf";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A large and muscled wolf from the northern wastes. Its breath is cold and icy and its fur coated in frost.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "White wolf";
        public override bool Friends => true;
        public override int Hdice => 7;
        public override int Hside => 7;
        public override bool ImmuneCold => true;
        public override int Level => 12;
        public override int Mexp => 30;
        public override int NoticeRange => 30;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   White    ";
        public override string SplitName3 => "    wolf    ";
    }
}
