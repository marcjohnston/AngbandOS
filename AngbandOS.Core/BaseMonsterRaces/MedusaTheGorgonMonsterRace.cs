using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MedusaTheGorgonMonsterRace : Base2MonsterRace
    {
        public override char Character => 'n';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Medusa, the Gorgon";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect Attack1Effect => new Exp80AttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect Attack2Effect => new ParalyzeAttackEffect();
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 8;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 8;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool CauseCriticalWounds => true;
        public override string Description => "Her face could sink a thousand ships.";
        public override bool Drop_1D2 => true;
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool FireBolt => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Medusa, the Gorgon";
        public override int Hdice => 24;
        public override bool Hold => true;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 40;
        public override int Mexp => 9000;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override bool PoisonBall => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 5;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Medusa   ";
        public override bool SummonHydra => true;
        public override bool Unique => true;
    }
}
