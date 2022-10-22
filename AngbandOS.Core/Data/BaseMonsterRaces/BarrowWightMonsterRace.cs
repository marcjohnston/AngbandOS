using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BarrowWightMonsterRace : Base2MonsterRace
    {
        public override char Character => 'W';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Barrow wight";

        public override int ArmourClass => 40;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Exp40;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool CauseSeriousWounds => true;
        public override bool ColdBlood => true;
        public override bool Darkness => true;
        public override string Description => "It is a ghostly nightmare of a entity.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Barrow wight";
        public override bool Friends => true;
        public override int Hdice => 15;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 33;
        public override int Mexp => 375;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Barrow   ";
        public override string SplitName3 => "   wight    ";
        public override bool Undead => true;
    }
}
