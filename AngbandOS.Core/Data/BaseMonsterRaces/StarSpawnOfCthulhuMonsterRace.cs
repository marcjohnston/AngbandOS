using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class StarSpawnOfCthulhuMonsterRace : Base2MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Star-spawn of Cthulhu";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 30;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 30;
        public override BaseAttackEffect? Attack2Effect => new AcidAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override BaseAttackEffect? Attack3Effect => new UnPowerAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 33;
        public override BaseAttackEffect? Attack4Effect => new UnBonusAttackEffect();
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool BashDoor => true;
        public override bool BrainSmash => true;
        public override bool BreatheAcid => true;
        public override bool BreatheFire => true;
        public override bool BreatheNether => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override string Description => "The last remnants of sanity threaten to leave your brain as you behold this titanic bat-winged, octopus-headed unholy abomination.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Star-spawn of Cthulhu";
        public override int Hdice => 75;
        public override bool Heal => true;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool KillItem => true;
        public override int Level => 86;
        public override int Mexp => 44000;
        public override bool MindBlast => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override bool RadiationBall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 90;
        public override int Speed => 130;
        public override string SplitName1 => " Star-spawn ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "  Cthulhu   ";
        public override bool SummonCthuloid => true;
        public override bool SummonMonsters => true;
        public override bool SummonUndead => true;
        public override bool TeleportSelf => true;
    }
}
