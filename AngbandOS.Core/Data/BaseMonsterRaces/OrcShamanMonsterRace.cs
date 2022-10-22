using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OrcShamanMonsterRace : Base2MonsterRace
    {
        public override char Character => 'o';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Orc shaman";

        public override int ArmourClass => 15;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
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
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override string Description => "An orc dressed in skins who gestures wildly.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Orc shaman";
        public override int Hdice => 9;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override int Level => 9;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 30;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Orc => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Orc     ";
        public override string SplitName3 => "   shaman   ";
    }
}
