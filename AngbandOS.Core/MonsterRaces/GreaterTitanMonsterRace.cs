using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GreaterTitanMonsterRace : MonsterRace
    {
        public override char Character => 'P';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Greater titan";

        public override int ArmourClass => 125;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 12, 12),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 12, 12),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 12, 12),
            new MonsterAttack(AttackType.Hit, new ConfuseAttackEffect(), 12, 12)
        };
        public override bool BashDoor => true;
        public override string Description => "A forty foot tall humanoid that shakes the ground as it walks. The power radiating from its frame shakes your courage, its hatred inspired by your defiance.";
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Greater titan";
        public override bool Giant => true;
        public override int Hdice => 38;
        public override bool Heal => true;
        public override int Hside => 100;
        public override int LevelFound => 46;
        public override bool Male => true;
        public override int Mexp => 13500;
        public override bool MoveBody => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 15;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Greater   ";
        public override string SplitName3 => "   titan    ";
        public override bool SummonMonsters => true;
        public override bool TakeItem => true;
        public override bool TeleportTo => true;
    }
}