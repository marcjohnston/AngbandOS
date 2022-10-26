using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IronLichMonsterRace : Base2MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Iron lich";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Butt, new ColdAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Butt, new FireAttackEffect(), 3, 6),
            new MonsterAttack(AttackType.Butt, new ElectricityAttackEffect(), 3, 6),
        };
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheFire => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a huge, twisted grey skull floating through the air. Its cold eyes burn with hatred towards all who live.";
        public override bool DrainMana => true;
        public override bool Drop60 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Iron lich";
        public override int Hdice => 28;
        public override int Hside => 100;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 42;
        public override bool LightningBall => true;
        public override int Mexp => 4000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Iron    ";
        public override string SplitName3 => "    lich    ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
        public override bool WaterBall => true;
    }
}
