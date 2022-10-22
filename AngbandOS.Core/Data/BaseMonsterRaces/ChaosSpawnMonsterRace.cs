using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ChaosSpawnMonsterRace : Base2MonsterRace
    {
        public override char Character => 'e';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Chaos spawn";

        public override int ArmourClass => 50;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Paralyze;
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.UnBonus;
        public override AttackType Attack2Type => AttackType.Gaze;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Exp40;
        public override AttackType Attack3Type => AttackType.Gaze;
        public override int Attack4DDice => 10;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Gaze;
        public override bool BashDoor => true;
        public override string Description => "It has two eyestalks and a large central eye. Its gaze can kill.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Chaos spawn";
        public override int Hdice => 20;
        public override int Hside => 18;
        public override int Level => 36;
        public override int Mexp => 600;
        public override int NoticeRange => 20;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Chaos    ";
        public override string SplitName3 => "   spawn    ";
    }
}
