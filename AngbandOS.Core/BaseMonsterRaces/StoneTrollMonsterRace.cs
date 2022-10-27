using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class StoneTrollMonsterRace : MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.Black;
        public override string Name => "Stone troll";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 6),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 3, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "He is a giant troll with scabrous black skin.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Stone troll";
        public override bool Friends => true;
        public override int Hdice => 23;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool HurtByRock => true;
        public override int LevelFound => 25;
        public override bool Male => true;
        public override int Mexp => 85;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Stone    ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}
