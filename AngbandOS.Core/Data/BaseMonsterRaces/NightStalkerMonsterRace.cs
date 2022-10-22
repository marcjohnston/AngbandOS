using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class NightStalkerMonsterRace : Base2MonsterRace
    {
        public override char Character => 'E';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Night stalker";

        public override int ArmourClass => 46;
        public override int Attack1DDice => 6;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 6;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
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
        public override bool ColdBlood => true;
        public override string Description => "It is impossible to define its form but its violence is legendary.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Night stalker";
        public override int Hdice => 20;
        public override int Hside => 13;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool Invisible => true;
        public override int Level => 34;
        public override int Mexp => 310;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 3;
        public override int Sleep => 20;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Night    ";
        public override string SplitName3 => "  stalker   ";
        public override bool Undead => true;
    }
}
