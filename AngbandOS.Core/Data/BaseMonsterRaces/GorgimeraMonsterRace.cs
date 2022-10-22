using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GorgimeraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Gorgimera";

        public override int ArmourClass => 55;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Paralyze;
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 3;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Butt;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "It has 3 heads - gorgon, goat and dragon - all attached to a lion's body.";
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Gorgimera";
        public override int Hdice => 25;
        public override int Hside => 20;
        public override bool ImmuneFire => true;
        public override int Level => 27;
        public override int Mexp => 200;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Gorgimera  ";
    }
}
