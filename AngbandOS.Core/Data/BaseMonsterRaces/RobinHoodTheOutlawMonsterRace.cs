using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RobinHoodTheOutlawMonsterRace : Base2MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.BrightChartreuse;
        public override string Name => "Robin Hood, the Outlaw";

        public override int ArmourClass => 30;
        public override bool Arrow3D6 => true;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 5;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 5;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => new EatGoldAttackEffect();
        public override AttackType Attack3Type => AttackType.Touch;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => new EatItemAttackEffect();
        public override AttackType Attack4Type => AttackType.Touch;
        public override bool BashDoor => true;
        public override bool CreateTraps => true;
        public override string Description => "The legendary archer steals from the rich (you qualify). ";
        public override bool Drop_1D2 => true;
        public override bool DropGood => true;
        public override bool DropGreat => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Robin Hood, the Outlaw";
        public override int Hdice => 14;
        public override bool Heal => true;
        public override int Hside => 12;
        public override int Level => 8;
        public override bool Male => true;
        public override int Mexp => 150;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Robin    ";
        public override string SplitName3 => "    Hood    ";
        public override bool TakeItem => true;
        public override bool Unique => true;
    }
}
