using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ElevenHeadedHydraMonsterRace : Base2MonsterRace
    {
        public override char Character => 'M';
        public override Colour Colour => Colour.Green;
        public override string Name => "11-headed hydra";

        public override bool Animal => true;
        public override int ArmourClass => 100;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Fire;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Fire;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 12;
        public override AttackEffect Attack3Effect => AttackEffect.Fire;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 12;
        public override AttackEffect Attack4Effect => AttackEffect.Fire;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "A strange reptilian hybrid with eleven smouldering heads.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool FireBall => true;
        public override bool FireBolt => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "11-headed hydra";
        public override int Hdice => 100;
        public override int Hside => 18;
        public override bool ImmuneFire => true;
        public override int Level => 44;
        public override int Mexp => 6000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override bool PlasmaBolt => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " 11-headed  ";
        public override string SplitName3 => "   hydra    ";
    }
}
