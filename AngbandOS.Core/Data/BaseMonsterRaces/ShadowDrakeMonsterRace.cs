using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ShadowDrakeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'd';
        public override Colour Colour => Colour.Black;
        public override string Name => "Shadow drake";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Cold;
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Cold;
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Cold;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool Confuse => true;
        public override bool Darkness => true;
        public override string Description => "It is a dragon-like form wrapped in shadow. Glowing red eyes shine out in the dark.";
        public override bool Dragon => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Shadow drake";
        public override bool Haste => true;
        public override int Hdice => 20;
        public override int Hside => 10;
        public override bool ImmuneCold => true;
        public override bool Invisible => true;
        public override int Level => 30;
        public override int Mexp => 700;
        public override int NoticeRange => 25;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 2;
        public override bool Scare => true;
        public override int Sleep => 30;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Shadow   ";
        public override string SplitName3 => "   drake    ";
        public override bool TakeItem => true;
    }
}
