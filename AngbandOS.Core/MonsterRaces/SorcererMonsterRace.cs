using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SorcererMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Sorcerer";

        public override bool AcidBolt => true;
        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Blink => true;
        public override bool CauseCriticalWounds => true;
        public override bool ColdBall => true;
        public override bool Confuse => true;
        public override bool CreateTraps => true;
        public override string Description => "A human figure in robes, he moves with magically improved speed, and his hands are ablur with spell casting.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Sorcerer";
        public override int Hdice => 52;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 40;
        public override bool Male => true;
        public override int Mexp => 2150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Sorcerer  ";
        public override bool SummonDragon => true;
        public override bool SummonMonster => true;
        public override bool SummonUndead => true;
        public override bool TeleportTo => true;
    }
}