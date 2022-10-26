using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class AncientBlackDragonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.Black;
        public override string Name => "Ancient black dragon";

        public override int ArmourClass => 90;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 9),
            new MonsterAttack(AttackType.Bite, new AcidAttackEffect(), 5, 10),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreatheAcid => true;
        public override bool Confuse => true;
        public override string Description => "A huge draconic form. Pools of acid melt the floor around it.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Ancient black dragon";
        public override int Hdice => 72;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 39;
        public override int Mexp => 2500;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool Powerful => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "  Ancient   ";
        public override string SplitName2 => "   black    ";
        public override string SplitName3 => "   dragon   ";
    }
}
