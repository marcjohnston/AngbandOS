using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class EarthSpiritMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.BrightBrown;
        public override string Name => "Earth spirit";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool ColdBlood => true;
        public override string Description => "A whirling form of sentient rock.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Earth spirit";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool HurtByRock => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 17;
        public override int Mexp => 64;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Earth    ";
        public override string SplitName3 => "   spirit   ";
    }
}
