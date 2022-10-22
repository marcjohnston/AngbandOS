using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NightMareMonsterRace : Base2MonsterRace
    {
        public override char Character => 'q';
        public override Colour Colour => Colour.Black;
        public override string Name => "Night mare";

        public override int ArmourClass => 85;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Exp80;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 8;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 6;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.Confuse;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A fearsome skeletal horse with glowing eyes, that watch you with little more than a hatred of all that lives.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Night mare";
        public override int Hdice => 15;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 39;
        public override int Mexp => 2900;
        public override int NoticeRange => 30;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Night    ";
        public override string SplitName3 => "    mare    ";
        public override bool Undead => true;
    }
}
