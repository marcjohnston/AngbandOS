using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GrooTheWandererMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightOrange;
        public override string Name => "Groo the Wanderer";

        public override int ArmourClass => 70;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 5;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 5;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 6;
        public override int Attack3DSides => 1;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "He who laughs at Groo's brains will find there is nothing to laugh about... erm, nobody laughs at Groo and lives.";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Groo the Wanderer";
        public override int Hdice => 11;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmunePoison => true;
        public override int Level => 33;
        public override bool Male => true;
        public override int Mexp => 2000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 7;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "    Groo    ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "  Wanderer  ";
        public override bool Troll => true;
        public override bool Unique => true;
        public override bool WeirdMind => true;
    }
}
