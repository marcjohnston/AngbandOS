using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UltraEliteFanaticMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override string Name => "Ultra-elite fanatic";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 12;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 12;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "Fighting for a good cause, and they consider you an agent of evil.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Ultra-elite fanatic";
        public override bool Friends => true;
        public override bool Good => true;
        public override int Hdice => 70;
        public override bool Heal => true;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool ImmuneStun => true;
        public override int Level => 45;
        public override bool Male => true;
        public override int Mexp => 1200;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override bool Reflecting => true;
        public override bool ResistDisenchant => true;
        public override bool ResistNether => true;
        public override bool ResistNexus => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "Ultra-elite ";
        public override string SplitName3 => "  fanatic   ";
    }
}
