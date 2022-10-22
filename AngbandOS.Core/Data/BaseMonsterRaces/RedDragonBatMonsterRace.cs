using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RedDragonBatMonsterRace : Base2MonsterRace
    {
        public override char Character => 'b';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Red dragon bat";

        public override bool Animal => true;
        public override int ArmourClass => 28;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override BaseAttackEffect? Attack1Effect => new FireAttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override BaseAttackEffect? Attack2Effect => null;
        public override AttackType Attack2Type => AttackType.Nothing;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override string Description => "It is a sharp-tailed bat, wreathed in fire.";
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Red dragon bat";
        public override int Hdice => 3;
        public override int Hside => 8;
        public override bool ImmuneFire => true;
        public override int Level => 23;
        public override int Mexp => 60;
        public override int NoticeRange => 12;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 50;
        public override int Speed => 130;
        public override string SplitName1 => "    Red     ";
        public override string SplitName2 => "   dragon   ";
        public override string SplitName3 => "    bat     ";
    }
}
