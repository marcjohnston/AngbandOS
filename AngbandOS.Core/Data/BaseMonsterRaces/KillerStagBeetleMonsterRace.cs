using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class KillerStagBeetleMonsterRace : Base2MonsterRace
    {
        public override char Character => 'K';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Killer stag beetle";

        public override bool Animal => true;
        public override int ArmourClass => 55;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 12;
        public override BaseAttackEffect? Attack1Effect => new HurtAttackEffect();
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 12;
        public override BaseAttackEffect? Attack2Effect => new HurtAttackEffect();
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override BaseAttackEffect? Attack3Effect => null;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override BaseAttackEffect? Attack4Effect => null;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override string Description => "It is a giant beetle with vicious claws.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Killer stag beetle";
        public override int Hdice => 20;
        public override int Hside => 8;
        public override int Level => 22;
        public override int Mexp => 80;
        public override int NoticeRange => 12;
        public override bool RandomMove25 => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "   Killer   ";
        public override string SplitName2 => "    stag    ";
        public override string SplitName3 => "   beetle   ";
        public override bool WeirdMind => true;
    }
}
