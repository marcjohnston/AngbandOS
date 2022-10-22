using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class CreepingAdamantiteCoinsMonsterRace : Base2MonsterRace
    {
        public override char Character => '$';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "Creeping adamantite coins";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override int Attack1DDice => 3;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new PoisonAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 3;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new PoisonAttackEffect();
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 12;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 12;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a pile of coins, slithering forward on thousands of tiny legs.";
        public override bool Drop_2D2 => true;
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Creeping adamantite coins";
        public override int Hdice => 20;
        public override int Hside => 25;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 27;
        public override int Mexp => 45;
        public override int NoticeRange => 5;
        public override bool OnlyDropGold => true;
        public override int Rarity => 4;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "  Creeping  ";
        public override string SplitName2 => " adamantite ";
        public override string SplitName3 => "   coins    ";
    }
}
