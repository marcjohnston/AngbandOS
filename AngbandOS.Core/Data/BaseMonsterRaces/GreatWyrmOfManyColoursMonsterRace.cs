using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreatWyrmOfManyColoursMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Great Wyrm of Many Colours";

        public override int ArmourClass => 170;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 6;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 9;
        public override int Attack4DSides => 14;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheAcid => true;
        public override bool BreatheCold => true;
        public override bool BreatheFire => true;
        public override bool BreatheLightning => true;
        public override bool BreathePoison => true;
        public override bool Confuse => true;
        public override string Description => "A huge dragon whose scales shimmer in myriad hues.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool FireAura => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Great Wyrm of Many Colours";
        public override int Hdice => 52;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 68;
        public override bool LightningAura => true;
        public override int Mexp => 31000;
        public override bool MoveBody => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override int Speed => 120;
        public override string SplitName1 => " Great Wyrm ";
        public override string SplitName2 => "  of Many   ";
        public override string SplitName3 => "  Colours   ";
    }
}
