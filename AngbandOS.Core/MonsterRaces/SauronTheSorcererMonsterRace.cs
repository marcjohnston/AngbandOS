using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SauronTheSorcererMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Sauron, the Sorcerer";

        public override int ArmourClass => 160;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 12),
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 10, 12),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new UnPowerAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool Confuse => true;
        public override bool DarkBall => true;
        public override string Description => "Mighty in spells and enchantments,he created the One Ring. His eyes glow with power and his gaze seeks to destroy your soul. He has many servants, and rarely fights without them.";
        public override bool DreadCurse => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Sauron, the Sorcerer";
        public override int Hdice => 105;
        public override int Hside => 100;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 98;
        public override bool Male => true;
        public override bool ManaBall => true;
        public override bool ManaBolt => true;
        public override int Mexp => 50000;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 1;
        public override bool Reflecting => true;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Sauron   ";
        public override bool SummonDemon => true;
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonMonsters => true;
        public override bool TeleportLevel => true;
        public override bool TeleportSelf => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
