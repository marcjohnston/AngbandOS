using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MandorMasterOfChaosMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Mandor, Master of Chaos";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new UnPowerAttackEffect(), 5, 5),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 5, 5)
        };
        public override bool BashDoor => true;
        public override bool ChaosBall => true;
        public override bool ColdBolt => true;
        public override bool CreateTraps => true;
        public override string Description => "Mandor is one of the greatest chaos Masters, a formidable magician.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Mandor, Master of Chaos";
        public override int Hdice => 88;
        public override bool Heal => true;
        public override bool Hold => true;
        public override int Hside => 11;
        public override bool IceBolt => true;
        public override int LevelFound => 38;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 1600;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 5;
        public override bool ResistTeleport => true;
        public override int Sleep => 40;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Mandor   ";
        public override bool SummonMonster => true;
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}