using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GrishnakhTheHillOrcMonsterRace : MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Grishnakh, the Hill Orc";

        public override int ArmourClass => 20;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 12),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 10)
        };
        public override bool BashDoor => true;
        public override string Description => "He is a cunning and devious orc with a chaotic nature.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grishnakh, the Hill Orc";
        public override int Hdice => 23;
        public override int Hside => 10;
        public override bool ImmunePoison => true;
        public override int LevelFound => 10;
        public override bool Male => true;
        public override int Mexp => 160;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Grishnakh  ";
        public override bool Unique => true;
    }
}
