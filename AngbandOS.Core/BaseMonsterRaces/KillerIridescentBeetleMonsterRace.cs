using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerIridescentBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Killer iridescent beetle";

        public override bool Animal => true;
        public override int ArmourClass => 60;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new ElectricityAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new ElectricityAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new ParalyzeAttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "It is a giant beetle, whose carapace shimmers with vibrant energies.";
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer iridescent beetle";
        public override int Hdice => 25;
        public override int Hside => 10;
        public override bool ImmuneLightning => true;
        public override int Level => 37;
        public override bool LightningAura => true;
        public override int Mexp => 850;
        public override int NoticeRange => 16;
        public override int Rarity => 2;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => " iridescent ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
