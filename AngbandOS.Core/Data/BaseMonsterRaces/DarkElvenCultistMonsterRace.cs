using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class DarkElvenCultistMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Turquoise;
        public override string Name => "Dark elven cultist";

        public override int ArmourClass => 75;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 7;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 7;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "A powerful dark elf, with mighty nature-controlling enchantments.";
        public override bool Drop_1D2 => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Dark elven cultist";
        public override int Hdice => 20;
        public override bool Heal => true;
        public override int Hside => 20;
        public override bool HurtByLight => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 25;
        public override bool MagicMissile => true;
        public override int Mexp => 500;
        public override int NoticeRange => 15;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    Dark    ";
        public override string SplitName2 => "   elven    ";
        public override string SplitName3 => "  cultist   ";
        public override bool SummonMonster => true;
        public override bool SummonSpider => true;
    }
}
