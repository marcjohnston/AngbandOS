using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WaterHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Water hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Acid;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Acid;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override string Description => "Liquid footprints follow this hound as it pads around the dungeon. An acrid smell of acid rises from the dog's pelt.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Water hound";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override int Level => 20;
        public override int Mexp => 200;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Water    ";
        public override string SplitName3 => "   hound    ";
    }
}
