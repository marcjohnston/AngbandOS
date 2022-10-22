using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class BlackReaverMonsterRace : Base2MonsterRace
    {
        public override char Character => 'U';
        public override Colour Colour => Colour.Brown;
        public override string Name => "Black reaver";

        public override int ArmourClass => 90;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 50;
        public override AttackEffect Attack1Effect => AttackEffect.Hurt;
        public override AttackType Attack1Type => AttackType.Hit;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 50;
        public override AttackEffect Attack2Effect => AttackEffect.Hurt;
        public override AttackType Attack2Type => AttackType.Hit;
        public override int Attack3DDice => 1;
        public override int Attack3DSides => 50;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Hit;
        public override int Attack4DDice => 1;
        public override int Attack4DSides => 50;
        public override AttackEffect Attack4Effect => AttackEffect.Hurt;
        public override AttackType Attack4Type => AttackType.Hit;
        public override bool Demon => true;
        public override string Description => "Clicking metal steps announce the arrival of this creature, A powerful undead warrior possessed by a major demon, it is unstoppable.";
        public override bool Drop_2D2 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Black reaver";
        public override int Hdice => 70;
        public override int Hside => 101;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override int Level => 77;
        public override int Mexp => 30000;
        public override bool Nonliving => true;
        public override int NoticeRange => 90;
        public override bool OnlyDropItem => true;
        public override bool RandomMove25 => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 90;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Black    ";
        public override string SplitName3 => "   reaver   ";
        public override bool Undead => true;
    }
}
