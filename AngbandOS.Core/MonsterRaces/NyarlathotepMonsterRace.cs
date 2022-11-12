using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class NyarlathotepMonsterRace : MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.Red;
        public override string Name => "Nyarlathotep";

        public override int ArmourClass => 165;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new UnBonusAttackEffect(), 12, 12),
            new MonsterAttack(AttackType.Hit, new UnPowerAttackEffect(), 12, 12),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 10, 2),
            new MonsterAttack(AttackType.Hit, new BlindAttackEffect(), 3, 2)
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ChaosBall => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "The Crawling Chaos in it's most monstrous form. It will do all in its power to keep you away from its master, Azathoth.";
        public override bool DreadCurse => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Nyarlathotep";
        public override bool GreatOldOne => true;
        public override int Hdice => 99;
        public override int Hside => 111;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 99;
        public override bool LightningAura => true;
        public override bool ManaBall => true;
        public override bool ManaBolt => true;
        public override int Mexp => 65000;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Reflecting => true;
        public override bool Regenerate => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 145;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "Nyarlathotep";
        public override bool SummonCthuloid => true;
        public override bool SummonDemon => true;
        public override bool SummonGreatOldOne => true;
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonMonsters => true;
        public override bool SummonReaver => true;
        public override bool TeleportAway => true;
        public override bool TeleportLevel => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
