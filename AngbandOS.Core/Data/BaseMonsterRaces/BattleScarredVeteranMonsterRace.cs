using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BattleScarredVeteranMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Red;
        public override string Name => "Battle scarred veteran";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
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
        public override string Description => "He doesn't take to strangers kindly.";
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Battle scarred veteran";
        public override int Hdice => 7;
        public override int Hside => 8;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 250;
        public override int Speed => 110;
        public override string SplitName1 => "   Battle   ";
        public override string SplitName2 => "  scarred   ";
        public override string SplitName3 => "  veteran   ";
        public override bool TakeItem => true;
    }
}
