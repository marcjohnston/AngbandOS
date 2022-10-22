using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AirHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Air hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool BreathePoison => true;
        public override string Description => "Swirling vapours surround this beast as it floats towards you, seemingly walking on air. Noxious gases sting your throat.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Air hound";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool ImmunePoison => true;
        public override int Level => 20;
        public override int Mexp => 200;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Air     ";
        public override string SplitName3 => "   hound    ";
    }
}
