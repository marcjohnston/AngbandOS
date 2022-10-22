using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantCockroachMonsterRace : Base2MonsterRace
    {
        public override char Character => 'I';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Giant cockroach";

        public override bool Animal => true;
        public override int ArmourClass => 25;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
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
        public override string Description => "Oh no! They are everywhere!";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant cockroach";
        public override int Hdice => 2;
        public override int Hside => 2;
        public override bool ImmunePoison => true;
        public override int Level => 14;
        public override int Mexp => 4;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override bool ResistDisenchant => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => " cockroach  ";
        public override bool TakeItem => true;
        public override bool WeirdMind => true;
    }
}
