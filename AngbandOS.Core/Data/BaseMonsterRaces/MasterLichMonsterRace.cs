using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MasterLichMonsterRace : Base2MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Master lich";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Exp80;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.UnPower;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.LoseDex;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 12;
        public override AttackEffect Attack4Effect => AttackEffect.LoseDex;
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool BrainSmash => true;
        public override bool CauseCriticalWounds => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override string Description => "A skeletal form wrapped in robes. Powerful magic crackles along its bony fingers.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Master lich";
        public override int Hdice => 18;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 41;
        public override int Mexp => 10000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 50;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "    lich    ";
        public override bool SummonUndead => true;
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}
