using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class LostSoulMonsterRace : MonsterRace
    {
        public override char Character => 'G';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Lost soul";

        public override int ArmourClass => 10;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 2),
            new MonsterAttack(AttackType.Touch, new LoseWisAttackEffect(), 0, 0),
        };
        public override bool ColdBlood => true;
        public override string Description => "It is almost insubstantial.";
        public override bool DrainMana => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Lost soul";
        public override int Hdice => 2;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int LevelFound => 7;
        public override int Mexp => 18;
        public override int NoticeRange => 12;
        public override bool PassWall => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Lost    ";
        public override string SplitName3 => "    soul    ";
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
        public override bool Undead => true;
    }
}