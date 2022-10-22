using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GhostMonsterRace : Base2MonsterRace
    {
        public override char Character => 'G';
        public override string Name => "Ghost";

        public override int ArmourClass => 30;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override AttackEffect Attack1Effect => AttackEffect.Terrify;
        public override AttackType Attack1Type => AttackType.Wail;
        public override int Attack2DDice => 0;
        public override int Attack2DSides => 0;
        public override AttackEffect Attack2Effect => AttackEffect.Exp20;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.LoseInt;
        public override AttackType Attack3Type => AttackType.Claw;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 6;
        public override AttackEffect Attack4Effect => AttackEffect.LoseWis;
        public override AttackType Attack4Type => AttackType.Claw;
        public override bool Blindness => true;
        public override bool ColdBlood => true;
        public override string Description => "You don't believe in them.";
        public override bool DrainMana => true;
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Evil => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 16;
        public override int FreqSpell => 16;
        public override string FriendlyName => "Ghost";
        public override int Hdice => 13;
        public override bool Hold => true;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 31;
        public override int Mexp => 350;
        public override int NoticeRange => 20;
        public override bool PassWall => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Ghost    ";
        public override bool TakeItem => true;
        public override bool Undead => true;
    }
}
