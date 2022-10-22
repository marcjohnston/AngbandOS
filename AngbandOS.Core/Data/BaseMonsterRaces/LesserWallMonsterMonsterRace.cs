using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class LesserWallMonsterMonsterRace : Base2MonsterRace
    {
        public override char Character => '#';
        public override string Name => "Lesser wall monster";

        public override int ArmourClass => 75;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 2;
        public override int Attack3DSides => 6;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool CharMulti => true;
        public override bool ColdBlood => true;
        public override string Description => "A sentient, moving section of wall.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Lesser wall monster";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool HurtByRock => true;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int Level => 28;
        public override int Mexp => 600;
        public override bool Multiply => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 20;
        public override bool RandomMove50 => true;
        public override int Rarity => 4;
        public override int Sleep => 40;
        public override int Speed => 110;
        public override string SplitName1 => "   Lesser   ";
        public override string SplitName2 => "    wall    ";
        public override string SplitName3 => "  monster   ";
    }
}
