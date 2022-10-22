using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShadowlordMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Shadowlord";

        public override int ArmourClass => 150;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new Exp40AttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new Exp40AttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new LoseStrAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 4;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new TerrifyAttackEffect();
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "An aura of hatred, cowardice and falsehood surrounds you as this cloaked figure floats towards you.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Shadowlord";
        public override int Hdice => 30;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 62;
        public override int Mexp => 22500;
        public override bool NetherBall => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override bool Shriek => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Shadowlord ";
        public override bool SummonUndead => true;
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
        public override bool Undead => true;
    }
}
