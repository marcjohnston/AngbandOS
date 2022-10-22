using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DarkElvenWarriorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Black;
        public override string Name => "Dark elven warrior";

        public override int ArmourClass => 16;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 8;
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
        public override string Description => "A dark elven figure in armour and ready with his sword.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 12;
        public override int FreqSpell => 12;
        public override string FriendlyName => "Dark elven warrior";
        public override int Hdice => 10;
        public override int Hside => 11;
        public override bool HurtByLight => true;
        public override int Level => 10;
        public override bool MagicMissile => true;
        public override bool Male => true;
        public override int Mexp => 50;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "  warrior   ";
    }
}
