using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DisenchanterWormMassMonsterRace : Base2MonsterRace
    {
        public override char Character => 'w';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Disenchanter worm mass";

        public override bool Animal => true;
        public override int ArmourClass => 5;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crawl, new UnBonusAttackEffect(), 1, 4),
        };
        public override bool AttrMulti => true;
        public override bool BashDoor => true;
        public override string Description => "It is a strange mass of squirming worms. Magical energy crackles around its disgusting form.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Disenchanter worm mass";
        public override int Hdice => 10;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int Level => 40;
        public override int Mexp => 30;
        public override bool Multiply => true;
        public override int NoticeRange => 7;
        public override bool RandomMove50 => true;
        public override int Rarity => 3;
        public override bool ResistDisenchant => true;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "Disenchanter";
        public override string SplitName2 => "    worm    ";
        public override string SplitName3 => "    mass    ";
        public override bool Stupid => true;
        public override bool WeirdMind => true;
    }
}
