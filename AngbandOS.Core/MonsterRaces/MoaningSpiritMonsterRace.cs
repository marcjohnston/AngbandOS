using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class MoaningSpiritMonsterRace : MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Moaning spirit";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new LoseDexAttackEffect(), 1, 8),
        };
        public override bool ColdBlood => true;
        public override string Description => "A ghostly apparition that shrieks horribly.";
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Moaning spirit";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 12;
        public override int Mexp => 44;
        public override int NoticeRange => 14;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Moaning   ";
        public override string SplitName3 => "   spirit   ";
        public override bool TeleportSelf => true;
        public override bool Undead => true;
    }
}