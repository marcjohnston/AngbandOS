using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MaliciousLeprechaunMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Malicious leprechaun";

        public override int ArmourClass => 13;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.EatGold;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.EatItem;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool Blink => true;
        public override bool CauseLightWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "This little creature has a fiendish gleam in its eyes.";
        public override bool Evil => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Malicious leprechaun";
        public override int Hdice => 4;
        public override int Hside => 5;
        public override bool HurtByLight => true;
        public override bool Invisible => true;
        public override int Level => 35;
        public override bool Male => true;
        public override int Mexp => 85;
        public override bool Multiply => true;
        public override int NoticeRange => 8;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 4;
        public override int Sleep => 8;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Malicious  ";
        public override string SplitName3 => " leprechaun ";
        public override bool TakeItem => true;
        public override bool TeleportSelf => true;
        public override bool TeleportTo => true;
    }
}
