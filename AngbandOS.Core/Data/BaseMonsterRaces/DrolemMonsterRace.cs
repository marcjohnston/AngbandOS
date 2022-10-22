using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DrolemMonsterRace : Base2MonsterRace
    {
        public override char Character => 'g';
        public override Colour Colour => Colour.Green;
        public override string Name => "Drolem";

        public override int ArmourClass => 130;
        public override bool Arrow5D6 => true;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 8;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 8;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 3;
        public override BaseAttackEffect? Attack3Effect => new PoisonAttackEffect();
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 3;
        public override BaseAttackEffect? Attack4Effect => new PoisonAttackEffect();
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BreathePoison => true;
        public override bool ColdBlood => true;
        public override bool Confuse => true;
        public override string Description => "A constructed dragon, the drolem has massive strength. Powerful spells weaved during its creation make it a fearsome adversary. Its eyes show little intelligence, but it has been instructed to destroy all it meets.";
        public override bool Dragon => true;
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Drolem";
        public override int Hdice => 30;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 44;
        public override int Mexp => 12000;
        public override bool Nonliving => true;
        public override int NoticeRange => 25;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Drolem   ";
    }
}
