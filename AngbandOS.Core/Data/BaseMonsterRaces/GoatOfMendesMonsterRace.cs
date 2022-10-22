using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GoatOfMendesMonsterRace : Base2MonsterRace
    {
        public override char Character => 'q';
        public override Colour Colour => Colour.Red;
        public override string Name => "Goat of Mendes";

        public override int ArmourClass => 66;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new TerrifyAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Butt;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new Exp40AttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new LoseConAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "It is a demonic creature from the lowest hell, vaguely resembling a large black he-goat.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Goat of Mendes";
        public override int Hdice => 18;
        public override int Hside => 111;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 50;
        public override int Mexp => 6666;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    Goat    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "   Mendes   ";
        public override bool SummonDemon => true;
        public override bool SummonUndead => true;
    }
}
