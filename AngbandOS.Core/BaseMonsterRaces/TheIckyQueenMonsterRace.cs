using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheIckyQueenMonsterRace : Base2MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "The Icky Queen";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Crawl;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new EatFoodAttackEffect();
        public override AttackType Attack2Type => AttackType.Crawl;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 5;
        public override BaseAttackEffect? Attack3Effect => new AcidAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 5;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool Confuse => true;
        public override string Description => "And you thought her offspring were icky!";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "The Icky Queen";
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override int Level => 20;
        public override int Mexp => 400;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 5;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "    Icky    ";
        public override string SplitName3 => "   Queen    ";
        public override bool TakeItem => true;
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
