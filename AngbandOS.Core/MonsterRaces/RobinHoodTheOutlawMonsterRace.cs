using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class RobinHoodTheOutlawMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Robin Hood, the Outlaw";

        public override int ArmourClass => 30;
        public override bool Arrow3D6 => true;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 5),
            new MonsterAttack(AttackType.Touch, new EatGoldAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Touch, new EatItemAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool CreateTraps => true;
        public override string Description => "The legendary archer steals from the rich (you qualify). ";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Robin Hood, the Outlaw";
        public override int Hdice => 14;
        public override bool Heal => true;
        public override int Hside => 12;
        public override int LevelFound => 8;
        public override bool Male => true;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Robin    ";
        public override string SplitName3 => "    Hood    ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}