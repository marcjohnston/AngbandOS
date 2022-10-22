using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class StairwayToHellMonsterRace : Base2MonsterRace
    {
        public override char Character => '>';
        public override Colour Colour => Colour.Red;
        public override string Name => "Stairway to hell";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new UnBonusAttackEffect();
        public override AttackType Attack1Type => AttackType.Wail;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => new Exp20AttackEffect();
        public override AttackType Attack2Type => AttackType.Wail;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new EatGoldAttackEffect();
        public override AttackType Attack3Type => AttackType.Wail;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new EatItemAttackEffect();
        public override AttackType Attack4Type => AttackType.Wail;
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
        public override int Level => 28;
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
