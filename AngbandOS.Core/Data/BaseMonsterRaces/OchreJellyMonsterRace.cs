using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class OchreJellyMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Ochre jelly";

        public override int ArmourClass => 18;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override AttackEffect Attack1Effect => AttackEffect.Acid;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 2;
        public override int Attack2DSides => 6;
        public override AttackEffect Attack2Effect => AttackEffect.Acid;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Acid;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A fast moving highly acidic jelly thing, that is eating away the floor it rests on.";
        public override bool EmptyMind => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Ochre jelly";
        public override int Hdice => 13;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 13;
        public override int Mexp => 40;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 3;
        public override int Sleep => 1;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Ochre    ";
        public override string SplitName3 => "   jelly    ";
        public override bool Stupid => true;
        public override bool TakeItem => true;
    }
}
