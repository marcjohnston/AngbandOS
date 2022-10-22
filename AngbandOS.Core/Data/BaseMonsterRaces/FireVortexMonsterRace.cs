using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FireVortexMonsterRace : Base2MonsterRace
    {
        public override char Character => 'v';
        public override Colour Colour => Colour.Red;
        public override string Name => "Fire vortex";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Engulf;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "A whirling maelstrom of fire.";
        public override bool EmptyMind => true;
        public override bool FireAura => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Fire vortex";
        public override int Hdice => 9;
        public override int Hside => 9;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 21;
        public override int Mexp => 100;
        public override bool Nonliving => true;
        public override int NoticeRange => 100;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Fire    ";
        public override string SplitName3 => "   vortex   ";
    }
}
