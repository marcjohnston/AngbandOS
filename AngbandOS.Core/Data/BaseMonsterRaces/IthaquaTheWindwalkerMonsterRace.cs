using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class IthaquaTheWindwalkerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'X';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Ithaqua the Windwalker";

        public override int ArmourClass => 125;
        public override int Attack1DDice => 12;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new ColdAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 12;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new ColdAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 12;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Crush;
        public override int Attack4DDice => 12;
        public override int Attack4DSides => 12;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool BashDoor => true;
        public override bool BreatheCold => true;
        public override bool CauseMortalWounds => true;
        public override bool ChaosBall => true;
        public override bool Demon => true;
        public override string Description => "The Wendigo, moving so fast that you can see little except two glowing eyes burning with hatred.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool EldritchHorror => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Ithaqua the Windwalker";
        public override bool GreatOldOne => true;
        public override int Hdice => 55;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 82;
        public override bool LightningAura => true;
        public override bool LightningBall => true;
        public override bool LightningBolt => true;
        public override bool ManaBolt => true;
        public override int Mexp => 32500;
        public override bool MindBlast => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 40;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 140;
        public override string SplitName1 => "  Ithaqua   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => " Windwalker ";
        public override bool SummonCthuloid => true;
        public override bool SummonHiUndead => true;
        public override bool SummonKin => true;
        public override bool Unique => true;
        public override bool WaterBall => true;
    }
}
