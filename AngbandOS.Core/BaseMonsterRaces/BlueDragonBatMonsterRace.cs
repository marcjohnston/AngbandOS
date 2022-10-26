using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlueDragonBatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Blue dragon bat";

        public override bool Animal => true;
        public override int ArmourClass => 26;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new ElectricityAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Sting, new ElectricityAttackEffect(), 1, 3),
        };
        public override bool BashDoor => true;
        public override bool BreatheLightning => true;
        public override string Description => "It is a glowing blue bat with a sharp tail.";
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Blue dragon bat";
        public override int Hdice => 4;
        public override int Hside => 4;
        public override bool ImmuneLightning => true;
        public override int Level => 21;
        public override int Mexp => 54;
        public override int NoticeRange => 12;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 130;
        public override string SplitName1 => "    Blue    ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    bat     ";
    }
}
