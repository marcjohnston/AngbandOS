using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class JabberwockMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Jabberwock";

        public override bool Animal => true;
        public override int ArmourClass => 125;
        public override int Attack1DDice => 10;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 10;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 10;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool BreatheChaos => true;
        public override bool CauseMortalWounds => true;
        public override string Description => "'Beware the Jabberwock, my son!The jaws that bite, the claws that catch!'";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Jabberwock";
        public override int Hdice => 32;
        public override int Hside => 100;
        public override int Level => 65;
        public override int Mexp => 19000;
        public override int NoticeRange => 35;
        public override bool OnlyDropItem => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 255;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Jabberwock ";
    }
}
