using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class WerewormMonsterRace : Base2MonsterRace
    {
        public override char Character => 'w';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Wereworm";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new Exp20AttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new AcidAttackEffect();
        public override AttackType Attack2Type => AttackType.Crawl;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new PoisonAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override string Description => "A huge wormlike shape dripping acid, twisted by evil sorcery into a foul monster that breeds on death.";
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Wereworm";
        public override int Hdice => 100;
        public override int Hside => 11;
        public override bool ImmuneAcid => true;
        public override int Level => 25;
        public override int Mexp => 300;
        public override int NoticeRange => 15;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "  Wereworm  ";
    }
}
