using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RedweedMonsterRace : Base2MonsterRace
    {
        public override char Character => 'm';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Redweed";

        public override int ArmourClass => 3;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 1;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Touch;
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
        public override bool Blink => true;
        public override string Description => "A strange fibrous growth springing up everywhere.";
        public override bool EmptyMind => true;
        public override int FreqInate => 20;
        public override int FreqSpell => 20;
        public override string FriendlyName => "Redweed";
        public override bool Friends => true;
        public override int Hdice => 1;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneFear => true;
        public override int Level => 1;
        public override int Mexp => 1;
        public override bool Multiply => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 10;
        public override int Rarity => 4;
        public override int Sleep => 10;
        public override int Speed => 100;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Redweed   ";
        public override bool Stupid => true;
    }
}
