using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DracoliskMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Dracolisk";

        public override bool Animal => true;
        public override int ArmourClass => 120;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 8;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Paralyze;
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override bool BreatheNether => true;
        public override string Description => "A mixture of dragon and basilisk, the dracolisk stares at you with deep piercing eyes, its evil breath burning the ground where it stands.";
        public override bool Dragon => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Dracolisk";
        public override int Hdice => 35;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 46;
        public override int Mexp => 14000;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Dracolisk  ";
    }
}
