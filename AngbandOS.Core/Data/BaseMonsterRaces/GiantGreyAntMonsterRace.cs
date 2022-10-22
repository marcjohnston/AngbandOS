using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantGreyAntMonsterRace : Base2MonsterRace
    {
        public override char Character => 'a';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Giant grey ant";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is an ant encased in shaggy grey fur.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Giant grey ant";
        public override int Hdice => 19;
        public override int Hside => 8;
        public override bool KillBody => true;
        public override int Level => 26;
        public override int Mexp => 90;
        public override int NoticeRange => 10;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Giant    ";
        public override string SplitName2 => "    grey    ";
        public override string SplitName3 => "    ant     ";
        public override bool WeirdMind => true;
    }
}
