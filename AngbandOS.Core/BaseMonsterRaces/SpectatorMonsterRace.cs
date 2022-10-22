using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SpectatorMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Spectator";

        public override int ArmourClass => 1;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new ParalyzeAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new ConfuseAttackEffect();
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new UnBonusAttackEffect();
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool CauseSeriousWounds => true;
        public override string Description => "It has three small eyestalks and a large central eye.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 6;
        public override int FreqSpell => 6;
        public override string FriendlyName => "Spectator";
        public override int Hdice => 10;
        public override bool Hold => true;
        public override int Hside => 13;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneSleep => true;
        public override int Level => 32;
        public override int Mexp => 150;
        public override int NoticeRange => 30;
        public override int Rarity => 3;
        public override int Sleep => 5;
        public override bool Slow => true;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => " Spectator  ";
        public override bool Stupid => true;
    }
}
