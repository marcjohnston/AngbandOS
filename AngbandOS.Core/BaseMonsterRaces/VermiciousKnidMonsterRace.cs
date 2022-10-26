using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class VermiciousKnidMonsterRace : Base2MonsterRace
    {
        public override char Character => 'A';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Vermicious Knid";

        public override int ArmourClass => 55;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Touch, new TerrifyAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Crawl, new HurtAttackEffect(), 4, 6),
            new MonsterAttack(AttackType.Engulf, new HurtAttackEffect(), 4, 6),
        };
        public override bool ColdBlood => true;
        public override string Description => "An amorphous shape that looks like wet grey clay with two pale eyes. It is totally silent as it oozes towards you.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Vermicious Knid";
        public override bool Friends => true;
        public override int Hdice => 90;
        public override int Hside => 10;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFear => true;
        public override int Level => 43;
        public override int Mexp => 2100;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 100;
        public override bool Smart => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Vermicious ";
        public override string SplitName3 => "    Knid    ";
        public override bool WeirdMind => true;
    }
}
