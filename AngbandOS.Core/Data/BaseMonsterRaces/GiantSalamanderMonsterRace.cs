using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantSalamanderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'R';
        public override Colour Colour => Colour.Red;
        public override string Name => "Giant salamander";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Bite;
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
        public override bool BreatheFire => true;
        public override string Description => "A large black and yellow lizard. You'd better run away!";
        public override bool ForceSleep => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Giant salamander";
        public override int Hdice => 6;
        public override int Hside => 7;
        public override bool ImmuneFire => true;
        public override int Level => 8;
        public override int Mexp => 50;
        public override int NoticeRange => 6;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Giant    ";
        public override string SplitName3 => " salamander ";
    }
}
