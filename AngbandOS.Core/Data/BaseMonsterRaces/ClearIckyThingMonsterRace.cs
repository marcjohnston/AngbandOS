using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class ClearIckyThingMonsterRace : Base2MonsterRace
    {
        public override char Character => 'i';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Clear icky thing";

        public override int ArmourClass => 6;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 2;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Touch;
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
        public override bool AttrClear => true;
        public override string Description => "It is a smallish, slimy, icky, blobby creature.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Clear icky thing";
        public override int Hdice => 2;
        public override int Hside => 5;
        public override bool Invisible => true;
        public override int Level => 1;
        public override int Mexp => 1;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "   Clear    ";
        public override string SplitName2 => "    icky    ";
        public override string SplitName3 => "   thing    ";
    }
}
