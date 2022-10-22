using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MagmaElementalMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Magma elemental";

        public override int ArmourClass => 70;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 7;
        public override BaseAttackEffect? Attack2Effect => new FireAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 7;
        public override BaseAttackEffect? Attack3Effect => new FireAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override string Description => "It is a towering glowing form of molten hate.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool FireBall => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Magma elemental";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillBody => true;
        public override bool KillItem => true;
        public override int Level => 37;
        public override int Mexp => 950;
        public override int NoticeRange => 10;
        public override bool PassWall => true;
        public override bool PlasmaBolt => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Magma    ";
        public override string SplitName3 => " elemental  ";
    }
}
