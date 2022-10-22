using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class VampireBatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.Black;
        public override string Name => "Vampire bat";

        public override bool Animal => true;
        public override int ArmourClass => 40;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new Exp40AttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new Exp40AttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool ColdBlood => true;
        public override string Description => "An undead bat that flies at your neck hungrily.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Vampire bat";
        public override int Hdice => 9;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 24;
        public override int Mexp => 150;
        public override int NoticeRange => 12;
        public override bool RandomMove50 => true;
        public override int Rarity => 2;
        public override bool Regenerate => true;
        public override int Sleep => 50;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Vampire   ";
        public override string SplitName3 => "    bat     ";
        public override bool Undead => true;
    }
}
