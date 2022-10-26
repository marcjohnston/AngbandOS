using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LichMonsterRace : Base2MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.BrightBeige;
        public override string Name => "Lich";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new LoseDexAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Touch, new LoseDexAttackEffect(), 2, 8)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool BrainSmash => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a skeletal form dressed in robes. It radiates vastly evil power.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Lich";
        public override int Hdice => 30;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 34;
        public override int Mexp => 800;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 60;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Lich    ";
        public override bool TeleportAway => true;
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}
