using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantArmyAntMonsterRace : Base2MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Giant army ant";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
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
        public override bool BashDoor => true;
        public override string Description => "An armoured form moving with purpose. Powerful on its own, flee when hordes of them march.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant army ant";
        public override bool Friends => true;
        public override int Hdice => 19;
        public override int Hside => 6;
        public override bool KillBody => true;
        public override int Level => 30;
        public override int Mexp => 90;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 3;
        public override int Sleep => 40;
        public override int Speed => 120;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    army    ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
