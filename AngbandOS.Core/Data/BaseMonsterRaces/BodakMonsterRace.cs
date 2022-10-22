using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BodakMonsterRace : Base2MonsterRace
    {
        public override char Character => 'u';
        public override Colour Colour => Colour.Black;
        public override string Name => "Bodak";

        public override int ArmourClass => 68;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new FireAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new FireAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new Exp20AttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Demon => true;
        public override string Description => "It is a humanoid form composed of flames and hatred.";
        public override bool Evil => true;
        public override bool FireAura => true;
        public override bool FireBall => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Bodak";
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 36;
        public override int Mexp => 750;
        public override bool Nonliving => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 90;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Bodak    ";
        public override bool SummonDemon => true;
        public override bool TakeItem => true;
    }
}
