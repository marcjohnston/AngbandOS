using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class HoundOfTindalosMonsterRace : Base2MonsterRace
    {
        public override char Character => 'C';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Hound of Tindalos";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new LoseWisAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new LoseWisAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new LoseWisAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool Blink => true;
        public override bool BreatheNether => true;
        public override bool BreatheTime => true;
        public override bool Cthuloid => true;
        public override string Description => "'They are lean and athirst!'";
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Hound of Tindalos";
        public override bool Friends => true;
        public override int Hdice => 60;
        public override int Hside => 15;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 54;
        public override int Mexp => 8000;
        public override int NoticeRange => 30;
        public override bool PassWall => true;
        public override int Rarity => 3;
        public override bool ResistNether => true;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "   Hound    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "  Tindalos  ";
        public override bool TeleportTo => true;
    }
}
