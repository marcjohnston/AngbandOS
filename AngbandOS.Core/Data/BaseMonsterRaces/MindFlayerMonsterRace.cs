using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class MindFlayerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'h';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Mind flayer";

        public override int ArmourClass => 60;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.LoseInt;
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.LoseWis;
        public override AttackType Attack2Type => AttackType.Gaze;
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
        public override bool BrainSmash => true;
        public override string Description => "A humanoid form with a gruesome head, tentacular mouth, and piercing eyes. Claws reach out for you and you feel a presence invade your mind.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 8;
        public override int FreqSpell => 8;
        public override string FriendlyName => "Mind flayer";
        public override int Hdice => 15;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int Level => 28;
        public override int Mexp => 200;
        public override bool MindBlast => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override bool Scare => true;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Mind    ";
        public override string SplitName3 => "   flayer   ";
    }
}
