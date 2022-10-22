using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TrollThaumaturgistMonsterRace : Base2MonsterRace
    {
        public override char Character => 'T';
        public override Colour Colour => Colour.BrightPurple;
        public override string Name => "Troll thaumaturgist";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 4;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override bool Darkness => true;
        public override string Description => "A troll who is so bright he knows how to read.";
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Troll thaumaturgist";
        public override int Hdice => 30;
        public override int Hside => 10;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 25;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 100;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Troll    ";
        public override string SplitName3 => "thaumaturgis";
        public override bool Troll => true;
    }
}
