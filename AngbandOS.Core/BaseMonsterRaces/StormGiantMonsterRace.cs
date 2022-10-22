using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class StormGiantMonsterRace : Base2MonsterRace
    {
        public override char Character => 'P';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Storm giant";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new ElectricityAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 8;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool Confuse => true;
        public override string Description => "It is a twenty-five foot tall giant wreathed in lighting.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Storm giant";
        public override bool Giant => true;
        public override int Hdice => 38;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneLightning => true;
        public override int Level => 32;
        public override bool LightningAura => true;
        public override bool LightningBall => true;
        public override bool LightningBolt => true;
        public override bool Male => true;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Storm    ";
        public override string SplitName3 => "   giant    ";
        public override bool TakeItem => true;
        public override bool TeleportTo => true;
    }
}
