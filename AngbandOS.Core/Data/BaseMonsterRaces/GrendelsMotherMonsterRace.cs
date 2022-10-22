using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class GrendelsMotherMonsterRace : Base2MonsterRace
    {
        public override char Character => 'O';
        public override Colour Colour => Colour.Green;
        public override string Name => "Grendel's mother";

        public override int ArmourClass => 100;
        public override int Attack1DDice => 8;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 8;
        public override int Attack2DSides => 6;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 8;
        public override int Attack3DSides => 6;
        public override BaseAttackEffect? Attack3Effect => new HurtAttackEffect();
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "She taught her son everything he knows.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool Evil => true;
        public override bool Female => true;
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Grendel's mother";
        public override bool Giant => true;
        public override int Hdice => 25;
        public override int Hside => 100;
        public override bool ImmunePoison => true;
        public override int Level => 28;
        public override int Mexp => 1500;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Grendel's  ";
        public override string SplitName3 => "   mother   ";
        public override bool Unique => true;
    }
}
