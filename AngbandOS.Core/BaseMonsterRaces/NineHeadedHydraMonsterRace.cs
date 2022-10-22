using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NineHeadedHydraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'M';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "9-headed hydra";

        public override bool Animal => true;
        public override int ArmourClass => 95;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new FireAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new FireAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new FireAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new FireAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "A strange reptilian hybrid with nine smouldering heads.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "9-headed hydra";
        public override int Hdice => 100;
        public override int Hside => 12;
        public override bool ImmuneFire => true;
        public override int Level => 40;
        public override int Mexp => 3000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  9-headed  ";
        public override string SplitName3 => "   hydra    ";
    }
}
