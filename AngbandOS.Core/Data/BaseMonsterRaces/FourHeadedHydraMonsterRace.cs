using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FourHeadedHydraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'M';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "4-headed hydra";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override string Description => "A strange reptilian hybrid with four heads, guarding its hoard.";
        public override bool Drop_4D2 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "4-headed hydra";
        public override int Hdice => 100;
        public override int Hside => 6;
        public override int Level => 24;
        public override int Mexp => 350;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  4-headed  ";
        public override string SplitName3 => "   hydra    ";
    }
}
