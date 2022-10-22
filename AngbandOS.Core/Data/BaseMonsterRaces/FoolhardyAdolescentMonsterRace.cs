using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class FoolhardyAdolescentMonsterRace : Base2MonsterRace
    {
        public override char Character => 't';
        public override Colour Colour => Colour.Blue;
        public override string Name => "Foolhardy adolescent";

        public override int ArmourClass => 15;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 6;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Hit;
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
        public override string Description => "He wants to kill a hero to prove that he's hard.";
        public override bool Drop90 => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Foolhardy adolescent";
        public override int Hdice => 3;
        public override int Hside => 6;
        public override int Level => 0;
        public override bool Male => true;
        public override int Mexp => 0;
        public override int NoticeRange => 50;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 4;
        public override int Sleep => 4;
        public override int Speed => 109;
        public override string SplitName1 => "            ";
        public override string SplitName2 => " Foolhardy  ";
        public override string SplitName3 => " adolescent ";
        public override bool TakeItem => true;
    }
}
