using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class RottingCorpseMonsterRace : Base2MonsterRace
    {
        public override char Character => 'z';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Rotting corpse";

        public override int ArmourClass => 20;
        public override int Attack1DDice => 1;
        public override int Attack1DSides => 3;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 1;
        public override int Attack2DSides => 3;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 0;
        public override int Attack3DSides => 0;
        public override AttackEffect Attack3Effect => AttackEffect.Nothing;
        public override AttackType Attack3Type => AttackType.Nothing;
        public override int Attack4DDice => 0;
        public override int Attack4DSides => 0;
        public override AttackEffect Attack4Effect => AttackEffect.Nothing;
        public override AttackType Attack4Type => AttackType.Nothing;
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "Corpses awakened from their sleep by dark sorceries. ";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Rotting corpse";
        public override bool Friends => true;
        public override int Hdice => 8;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 7;
        public override int Mexp => 15;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 20;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Rotting   ";
        public override string SplitName3 => "   corpse   ";
        public override bool Undead => true;
    }
}
