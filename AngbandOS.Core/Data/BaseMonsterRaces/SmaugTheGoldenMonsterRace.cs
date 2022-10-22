using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SmaugTheGoldenMonsterRace : Base2MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightRed;
        public override string Name => "Smaug the Golden";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 6;
        public override int Attack4DSides => 14;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override bool CauseCriticalWounds => true;
        public override bool Confuse => true;
        public override string Description => "Smaug is one of the Uruloki that still survive, a fire-drake of immense cunning and intelligence. His speed through air is matched by few other dragons and his dragonfire is what legends are made of.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Smaug the Golden";
        public override int Hdice => 20;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int Level => 45;
        public override bool Male => true;
        public override int Mexp => 19000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool Reflecting => true;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => "   Smaug    ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "   Golden   ";
        public override bool Unique => true;
    }
}
