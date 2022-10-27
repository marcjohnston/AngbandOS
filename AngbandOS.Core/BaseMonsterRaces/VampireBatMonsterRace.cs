using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class VampireBatMonsterRace : MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.Black;
        public override string Name => "Vampire bat";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new Exp40AttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new Exp40AttackEffect(), 1, 4),
        };
        public override bool ColdBlood => true;
        public override string Description => "An undead bat that flies at your neck hungrily.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Vampire bat";
        public override int Hdice => 9;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 24;
        public override int Mexp => 150;
        public override int NoticeRange => 12;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Vampire   ";
        public override string SplitName3 => "    bat     ";
        public override bool Undead => true;
    }
}
