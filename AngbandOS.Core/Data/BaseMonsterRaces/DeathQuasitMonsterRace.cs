using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeathQuasitMonsterRace : Base2MonsterRace
    {
        public override char Character => 'u';
        public override string Name => "Death quasit";

        public override int ArmourClass => 80;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.LoseDex;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool Blindness => true;
        public override bool CauseCriticalWounds => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "It is a demon of small stature, but its armoured frame moves with lightning speed and its powers make it a tornado of death and destruction.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Death quasit";
        public override int Hdice => 44;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 40;
        public override int Mexp => 1000;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override bool Scare => true;
        public override int Sleep => 0;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Death    ";
        public override string SplitName3 => "   quasit   ";
        public override bool SummonDemon => true;
    }
}
