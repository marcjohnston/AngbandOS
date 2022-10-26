using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GreatStormWyrmMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightTurquoise;
        public override string Name => "Great storm wyrm";

        public override int ArmourClass => 150;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 12),
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 5, 14)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheLightning => true;
        public override bool Confuse => true;
        public override string Description => "A vast dragon of power. Storms and lightning crash around its titanic form. Deep blue scales reflect the flashes and highlight the creature's great muscles. It regards you with contempt.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Great storm wyrm";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneLightning => true;
        public override bool ImmuneSleep => true;
        public override int Level => 51;
        public override bool LightningAura => true;
        public override int Mexp => 17000;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 80;
        public override int Speed => 120;
        public override string SplitName1 => "   Great    ";
        public override string SplitName2 => "   storm    ";
        public override string SplitName3 => "    wyrm    ";
    }
}
