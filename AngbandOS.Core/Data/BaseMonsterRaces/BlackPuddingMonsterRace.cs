using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackPuddingMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Black;
        public override string Name => "Black pudding";

        public override int ArmourClass => 18;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Acid;
        public override AttackType Attack1Type => AttackType.Touch;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Acid;
        public override AttackType Attack2Type => AttackType.Touch;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Acid;
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 10;
        public override AttackEffect Attack4Effect => AttackEffect.Acid;
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "A lump of rotting black flesh that slurrrrrrrps across the dungeon floor.";
        public override bool Drop_1D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool EmptyMind => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Black pudding";
        public override bool Friends => true;
        public override int Hdice => 40;
        public override int Hside => 10;
        public override bool ImmuneAcid => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 37;
        public override int Mexp => 36;
        public override int NoticeRange => 12;
        public override bool OpenDoor => true;
        public override int Rarity => 5;
        public override int Sleep => 1;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "  pudding   ";
        public override bool Stupid => true;
        public override bool TakeItem => true;
    }
}
