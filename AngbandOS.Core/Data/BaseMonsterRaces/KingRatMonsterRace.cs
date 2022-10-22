using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KingRatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'r';
        public override Colour Colour => Colour.Brown;
        public override string Name => "King Rat";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "A large brown rat. He's the leader of the pack.";
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "King Rat";
        public override int Hdice => 5;
        public override int Hside => 5;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 2;
        public override int Mexp => 32;
        public override int NoticeRange => 30;
        public override int Rarity => 1;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    King    ";
        public override string SplitName3 => "    Rat     ";
        public override bool Unique => true;
    }
}
