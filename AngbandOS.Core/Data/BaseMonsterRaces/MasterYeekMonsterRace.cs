using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MasterYeekMonsterRace : Base2MonsterRace
    {
        public override char Character => 'y';
        public override Colour Colour => Colour.Green;
        public override string Name => "Master yeek";

        public override bool Animal => true;
        public override int ArmourClass => 24;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 8;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
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
        public override bool Blindness => true;
        public override bool Blink => true;
        public override string Description => "A small humanoid that radiates some power.";
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Master yeek";
        public override int Hdice => 12;
        public override int Hside => 9;
        public override bool ImmuneAcid => true;
        public override int Level => 12;
        public override int Mexp => 28;
        public override int NoticeRange => 18;
        public override bool OpenDoor => true;
        public override bool PoisonBall => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "    yeek    ";
        public override bool SummonMonster => true;
        public override bool TeleportSelf => true;
    }
}
