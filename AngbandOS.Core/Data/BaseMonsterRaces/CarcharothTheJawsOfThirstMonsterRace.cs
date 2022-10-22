using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CarcharothTheJawsOfThirstMonsterRace : Base2MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.Black;
        public override string Name => "Carcharoth, the Jaws of Thirst";

        public override bool Animal => true;
        public override int ArmourClass => 110;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Poison;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 4;
        public override int Attack4DSides => 4;
        public override AttackEffect Attack4Effect => AttackEffect.Poison;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheFire => true;
        public override string Description => "The first guard of Angband, Carcharoth, also known as 'The Red Maw', is the largest wolf to ever walk the earth. He is highly intelligent and a deadly opponent in combat.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Carcharoth, the Jaws of Thirst";
        public override int Hdice => 75;
        public override bool Heal => true;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 92;
        public override bool Male => true;
        public override int Mexp => 40000;
        public override bool MoveBody => true;
        public override int NoticeRange => 80;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Carcharoth ";
        public override bool SummonHound => true;
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
