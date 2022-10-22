using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ChimeraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'H';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Chimera";

        public override int ArmourClass => 15;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Fire;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Butt;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "It is a strange concoction of lion, dragon and goat. It looks very odd but very avoidable.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Chimera";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 20;
        public override int Mexp => 200;
        public override int NoticeRange => 12;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Chimera   ";
    }
}
