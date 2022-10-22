using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FlyingSkullMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Flying skull";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new LoseStrAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A skullpack animated by necromantic spells.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Flying skull";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Flying   ";
        public override string SplitName3 => "   skull    ";
        public override bool Undead => true;
        public override bool WeirdMind => true;
    }
}
