using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class DarkElvenThaumaturgeMonsterRace : MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Red;
        public override string Name => "Dark elven thaumaturge";

        public override bool AcidBolt => true;
        public override int ArmourClass => 70;
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
        public override bool Darkness => true;
        public override string Description => "A dark elven figure, dressed in deepest black. Power seems to crackle from her slender frame.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Dark elven thaumaturge";
        public override int Hdice => 80;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 41;
        public override bool MagicMissile => true;
        public override int Mexp => 3000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "thaumaturge ";
        public override bool SummonDemon => true;
        public override bool SummonMonster => true;
        public override bool SummonUndead => true;
        public override bool TeleportTo => true;
    }
}
