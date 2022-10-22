using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GiantWhiteDragonFlyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'F';
        public override string Name => "Giant white dragon fly";

        public override bool Animal => true;
        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Cold;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Nothing;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheCold => true;
        public override string Description => "It is a large fly that drips frost.";
        public override bool ForceSleep => true;
        public override int FreqInate => 10;
        public override int FreqSpell => 10;
        public override string FriendlyName => "Giant white dragon fly";
        public override int Hdice => 5;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override int Level => 14;
        public override int Mexp => 60;
        public override int NoticeRange => 20;
        public override bool RandomMove50 => true;
        public override int Rarity => 3;
        public override int Sleep => 50;
        public override int Speed => 110;
        public override string SplitName1 => "Giant white ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    fly     ";
        public override bool WeirdMind => true;
    }
}
