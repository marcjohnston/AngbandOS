using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class TheEmperorQuylthulgMonsterRace : Base2MonsterRace
    {
        public override char Character => 'Q';
        public override Colour Colour => Colour.BrightPink;
        public override string Name => "The Emperor Quylthulg";

        public override bool Animal => true;
        public override int ArmourClass => 1;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => null;
        public override AttackType Attack1Type => AttackType.Nothing;
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
        public override bool BrainSmash => true;
        public override string Description => "A huge seething mass of flesh with a rudimentary intelligence, the Emperor Quylthulg changes colours in front of your eyes. Pulsating first one colour then the next, it knows only it must bring help to protect itself.";
        public override bool Drop_4D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "The Emperor Quylthulg";
        public override int Hdice => 50;
        public override int Hside => 100;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 78;
        public override int Mexp => 20000;
        public override bool NeverAttack => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override int Rarity => 3;
        public override bool ResistTeleport => true;
        public override int Sleep => 0;
        public override int Speed => 130;
        public override string SplitName1 => "    The     ";
        public override string SplitName2 => "  Emperor   ";
        public override string SplitName3 => " Quylthulg  ";
        public override bool SummonHiDragon => true;
        public override bool SummonHiUndead => true;
        public override bool Unique => true;
    }
}
