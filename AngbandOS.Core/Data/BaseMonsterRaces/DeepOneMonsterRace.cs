using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DeepOneMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Green;
        public override string Name => "Deep One";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
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
        public override bool Blindness => true;
        public override bool Confuse => true;
        public override bool Cthuloid => true;
        public override string Description => "A batrachian humanoid with large eyes and a scaly skin suggestive of fishskin, hopping irregularly and casting spells with a croaking, baying voice.";
        public override bool Drop_2D2 => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Deep One";
        public override int Hdice => 30;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 26;
        public override bool MagicMissile => true;
        public override int Mexp => 220;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 6;
        public override bool Scare => true;
        public override int Sleep => 255;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Deep    ";
        public override string SplitName3 => "    One     ";
        public override bool TakeItem => true;
    }
}
