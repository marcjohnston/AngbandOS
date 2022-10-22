using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SarumanOfManyColoursMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Saruman of Many Colours";

        public override bool AcidBall => true;
        public override int ArmourClass => 100;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new UnBonusAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new UnBonusAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 5;
        public override int Attack4DSides => 5;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool Confuse => true;
        public override bool CreateTraps => true;
        public override string Description => "Originally known as the White, Saruman fell prey to Sauron's wiles. He searches forever for the One Ring, to become a mighty Sorcerer-King of the world.";
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Saruman of Many Colours";
        public override bool Haste => true;
        public override int Hdice => 50;
        public override bool Heal => true;
        public override int Hside => 100;
        public override bool IceBolt => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 60;
        public override bool Male => true;
        public override int Mexp => 35000;
        public override bool MindBlast => true;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Reflecting => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Saruman   ";
        public override string SplitName2 => "  of Many   ";
        public override string SplitName3 => "  Colours   ";
        public override bool SummonDemon => true;
        public override bool SummonDragon => true;
        public override bool SummonUndead => true;
        public override bool TeleportAway => true;
        public override bool TeleportSelf => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
