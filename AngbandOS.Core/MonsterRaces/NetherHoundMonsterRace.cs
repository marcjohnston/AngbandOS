using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class NetherHoundMonsterRace : MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Black;
        public override string Name => "Nether hound";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 2, 12),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override bool BreatheNether => true;
        public override string Description => "You feel a soul-tearing chill upon viewing this beast, a ghostly form of darkness in the shape of a large dog.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Nether hound";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 51;
        public override int Mexp => 5000;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool ResistNether => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Nether   ";
        public override string SplitName3 => "   hound    ";
    }
}