using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class VecnaTheEmperorLichMonsterRace : Base2MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Vecna, the Emperor Lich";

        public override int ArmourClass => 85;
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
        public override bool CreateTraps => true;
        public override string Description => "He is a highly cunning, extremely magical being, spoken of in legends. This ancient shadow of death wilts any living thing it passes.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Vecna, the Emperor Lich";
        public override int Hdice => 50;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 72;
        public override bool Male => true;
        public override bool ManaBall => true;
        public override bool ManaBolt => true;
        public override int Mexp => 30000;
        public override bool NetherBall => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 50;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Vecna    ";
        public override bool SummonKin => true;
        public override bool SummonMonsters => true;
        public override bool SummonUndead => true;
        public override bool TeleportTo => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
