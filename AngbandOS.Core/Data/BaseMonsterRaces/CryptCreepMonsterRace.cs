using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CryptCreepMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.Black;
        public override string Name => "Crypt creep";

        public override int ArmourClass => 12;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 2;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Crush;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 3;
        public override AttackEffect Attack3Effect => AttackEffect.Poison;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool CauseLightWounds => true;
        public override bool ColdBlood => true;
        public override string Description => "Frightening skeletal figures in black robes. ";
        public override bool Evil => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Crypt creep";
        public override bool Friends => true;
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 7;
        public override int Mexp => 25;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override int Sleep => 14;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Crypt    ";
        public override string SplitName3 => "   creep    ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
    }
}
