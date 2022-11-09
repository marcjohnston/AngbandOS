using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class CaveTrollMonsterRace : MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Cave troll";

        public override int ArmourClass => 50;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8)
        };
        public override bool BashDoor => true;
        public override string Description => "He is a vicious monster, feared for his ferocity.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Cave troll";
        public override bool Friends => true;
        public override int Hdice => 24;
        public override int Hside => 12;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 33;
        public override bool Male => true;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Cave    ";
        public override string SplitName3 => "   troll    ";
        public override bool Troll => true;
    }
}
