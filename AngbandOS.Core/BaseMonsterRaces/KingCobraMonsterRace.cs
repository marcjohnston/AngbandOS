using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KingCobraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "King cobra";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override BaseAttackEffect? Attack1Effect => new BlindAttackEffect();
        public override AttackType Attack1Type => AttackType.Spit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a large snake with a hooded face.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "King cobra";
        public override int Hdice => 8;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int Level => 9;
        public override int Mexp => 28;
        public override int NoticeRange => 8;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    King    ";
        public override string SplitName3 => "   cobra    ";
    }
}
