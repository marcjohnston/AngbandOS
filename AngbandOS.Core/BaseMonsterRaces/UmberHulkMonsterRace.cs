using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class UmberHulkMonsterRace : Base2MonsterRace
    {
        public override char Character => 'x';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Umber hulk";

        public override bool Animal => true;
        public override int ArmourClass => 50;
        public override int Attack1DDice => 0;
        public override int Attack1DSides => 0;
        public override BaseAttackEffect? Attack1Effect => new ConfuseAttackEffect();
        public override AttackType Attack1Type => AttackType.Gaze;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 2;
        public override int Attack4DSides => 6;
        public override BaseAttackEffect? Attack4Effect => new HurtAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "This bizarre creature has glaring eyes and large mandibles capable of slicing through rock.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Umber hulk";
        public override int Hdice => 20;
        public override int Hside => 10;
        public override bool HurtByRock => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override bool KillWall => true;
        public override int Level => 16;
        public override int Mexp => 75;
        public override int NoticeRange => 20;
        public override int Rarity => 1;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Umber    ";
        public override string SplitName3 => "    hulk    ";
    }
}
