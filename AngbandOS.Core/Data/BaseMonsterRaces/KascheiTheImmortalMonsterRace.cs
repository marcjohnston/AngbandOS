using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KascheiTheImmortalMonsterRace : Base2MonsterRace
    {
        public override char Character => 'L';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Kaschei the Immortal";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.UnBonus;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.UnBonus;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 5;
        public override int Attack3DSides => 5;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 5;
        public override int Attack4DSides => 5;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "A stench of corruption and decay surrounds this sorcerer, who has clearly risen from the grave to continue his foul plots and schemes.";
        public override bool DreadCurse => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool FireBall => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Kaschei the Immortal";
        public override int Hdice => 60;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 90;
        public override bool Male => true;
        public override bool ManaBall => true;
        public override bool ManaBolt => true;
        public override int Mexp => 45000;
        public override int NoticeRange => 100;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "  Kaschei   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "  Immortal  ";
        public override bool SummonDemon => true;
        public override bool SummonHiUndead => true;
        public override bool SummonMonsters => true;
        public override bool TeleportSelf => true;
        public override bool Undead => true;
        public override bool Unique => true;
    }
}
