using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FlyingSkullMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Flying skull";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 1, 3),
            new MonsterAttack(AttackType.Bite, new LoseStrAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A skullpack animated by necromantic spells.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Flying skull";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Flying   ";
        public override string SplitName3 => "   skull    ";
        public override bool Undead => true;
        public override bool WeirdMind => true;
    }
}
