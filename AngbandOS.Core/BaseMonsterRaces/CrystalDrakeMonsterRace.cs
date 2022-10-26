using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CrystalDrakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Crystal drake";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 5),
        };
        public override bool BashDoor => true;
        public override bool BreatheShards => true;
        public override bool Confuse => true;
        public override string Description => "A dragon of strange crystalline form. Light shines through it, dazzling your eyes with spectrums of colour.";
        public override bool Dragon => true;
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Crystal drake";
        public override int Hdice => 50;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 37;
        public override int Mexp => 1500;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Reflecting => true;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Crystal   ";
        public override string SplitName3 => "   drake    ";
    }
}
