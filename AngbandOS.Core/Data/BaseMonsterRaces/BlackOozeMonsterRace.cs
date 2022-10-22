using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackOozeMonsterRace : Base2MonsterRace
    {
        public override char Character => 'j';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Black ooze";

        public override int ArmourClass => 6;
        public override int Attack1DDice => 2;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new AcidAttackEffect();
        public override AttackType Attack1Type => AttackType.Touch;
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
        public override bool BashDoor => true;
        public override string Description => "It is a strangely moving puddle.";
        public override bool DrainMana => true;
        public override bool Drop60 => true;
        public override bool EmptyMind => true;
        public override int FreqInate => 11;
        public override int FreqSpell => 11;
        public override string FriendlyName => "Black ooze";
        public override int Hdice => 6;
        public override int Hside => 8;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool KillBody => true;
        public override int Level => 23;
        public override int Mexp => 7;
        public override bool Multiply => true;
        public override int NoticeRange => 10;
        public override bool OpenDoor => true;
        public override bool RandomMove50 => true;
        public override int Rarity => 1;
        public override int Sleep => 1;
        public override int Speed => 90;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "    ooze    ";
        public override bool Stupid => true;
        public override bool TakeItem => true;
    }
}
