using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class ForestTrollMonsterRace : MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Forest troll";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 4),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 6),
        };
        public override bool BashDoor => true;
        public override string Description => "He is green skinned and ugly.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Forest troll";
        public override bool Friends => true;
        public override int Hdice => 20;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override int LevelFound => 17;
        public override bool Male => true;
        public override int Mexp => 70;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Forest   ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}