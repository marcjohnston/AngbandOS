using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GremlinMonsterRace : MonsterRace
    {
        public override char Character => 'u';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Gremlin";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new EatFoodAttackEffect(), 1, 2),
            new MonsterAttack(AttackType.Claw, new EatFoodAttackEffect(), 1, 2),
            new MonsterAttack(AttackType.Bite, new EatFoodAttackEffect(), 1, 3),
        };
        public override bool Demon => true;
        public override string Description => "Don't feed them after midnight!";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Gremlin";
        public override int Hdice => 5;
        public override int Hside => 5;
        public override bool HurtByLight => true;
        public override bool ImmunePoison => true;
        public override int LevelFound => 8;
        public override int Mexp => 6;
        public override bool Multiply => true;
        public override int NoticeRange => 30;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Gremlin   ";
        public override bool TakeItem => true;
    }
}