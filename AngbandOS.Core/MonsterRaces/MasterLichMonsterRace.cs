using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MasterLichMonsterRace : MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Master lich";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new Exp80AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new LoseDexAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Touch, new LoseDexAttackEffect(), 2, 12)
        };
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
        public override int LevelFound => 41;
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