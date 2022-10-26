using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MatureRedDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Red;
        public override string Name => "Mature red dragon";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override bool Confuse => true;
        public override string Description => "A large dragon, scales tinted deep red.";
        public override bool Dragon => true;
        public override bool Drop_1D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Mature red dragon";
        public override int Hdice => 48;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 37;
        public override int Mexp => 1400;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Mature   ";
        public override string SplitName2 => "    red     ";
        public override string SplitName3 => "   dragon   ";
    }
}
