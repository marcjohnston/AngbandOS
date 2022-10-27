using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GlaakiMonsterRace : MonsterRace
    {
        public override char Character => 'X';
        public override string Name => "Glaaki";

        public override bool AcidBolt => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 15),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 10, 15),
            new MonsterAttack(AttackType.Hit, new LoseConAttackEffect(), 10, 15),
        };
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool CauseCriticalWounds => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool Confuse => true;
        public override bool CreateTraps => true;
        public override bool Darkness => true;
        public override string Description => "Oval bodied with countless thin spines, and three baleful yellow eyes on thin stalks.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Glaaki";
        public override bool GreatOldOne => true;
        public override int Hdice => 59;
        public override bool Heal => true;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 78;
        public override bool Male => true;
        public override bool ManaBolt => true;
        public override int Mexp => 35500;
        public override bool NetherBall => true;
        public override bool NetherBolt => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 1;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 15;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Glaaki   ";
        public override bool SummonMonster => true;
        public override bool SummonUndead => true;
        public override bool TeleportAway => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
        public override bool WaterBolt => true;
    }
}
