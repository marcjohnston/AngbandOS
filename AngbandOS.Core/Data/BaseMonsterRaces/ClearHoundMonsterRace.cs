using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ClearHoundMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Z';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Clear hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool AttrClear => true;
        public override bool BashDoor => true;
        public override string Description => "A completely translucent hound.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Clear hound";
        public override bool Friends => true;
        public override int Hdice => 10;
        public override int Hside => 6;
        public override bool Invisible => true;
        public override int Level => 15;
        public override int Mexp => 50;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Clear    ";
        public override string SplitName3 => "   hound    ";
    }
}
