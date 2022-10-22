using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheInsaneCrusaderMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "The Insane Crusader";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 3;
        public override int Attack3DSides => 8;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 3;
        public override int Attack4DSides => 8;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool BashDoor => true;
        public override string Description => "Once a powerful adventurer, this poor fighter has seen a few too many eldritch horrors in his time. Any shred of lucidity is long gone, but he still remains dangerous. He wanders aimlessly through the dungeon randomly stiking at foes both real and imagined, all the while screaming out at the world which caused his condition.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "The Insane Crusader";
        public override int Hdice => 18;
        public override int Hside => 100;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 36;
        public override bool Male => true;
        public override int Mexp => 1200;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override bool Shriek => true;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "   Insane   ";
        public override string SplitName3 => "  Crusader  ";
        public override bool TeleportTo => true;
        public override bool Unique => true;
    }
}
