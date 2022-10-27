using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class StairwayToHellMonsterRace : MonsterRace
    {
        public override char Character => '>';
        public override Colour Colour => Colour.Red;
        public override string Name => "Stairway to hell";

        public override int ArmourClass => 40;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Wail, new UnBonusAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Wail, new Exp20AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Wail, new EatGoldAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Wail, new EatItemAttackEffect(), 0, 0)
        };
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "Often found in graveyards.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Stairway to hell";
        public override int Hdice => 15;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 28;
        public override int Mexp => 125;
        public override bool NeverMove => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override int Rarity => 5;
        public override bool Shriek => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "  Stairway  ";
        public override string SplitName2 => "     to     ";
        public override string SplitName3 => "    hell    ";
        public override bool SummonDemon => true;
        public override bool Undead => true;
    }
}
