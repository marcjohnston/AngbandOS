using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class YigFatherOfSerpentsMonsterRace : Base2MonsterRace
    {
        public override char Character => 'J';
        public override Colour Colour => Colour.Green;
        public override string Name => "Yig, Father of Serpents";

        public override int ArmourClass => 185;
        public override int Attack1DDice => 5;
        public override int Attack1DSides => 10;
        public override AttackEffect Attack1Effect => AttackEffect.Poison;
        public override AttackType Attack1Type => AttackType.Claw;
        public override int Attack2DDice => 5;
        public override int Attack2DSides => 10;
        public override AttackEffect Attack2Effect => AttackEffect.Poison;
        public override AttackType Attack2Type => AttackType.Claw;
        public override int Attack3DDice => 20;
        public override int Attack3DSides => 10;
        public override AttackEffect Attack3Effect => AttackEffect.Hurt;
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 5;
        public override int Attack4DSides => 12;
        public override AttackEffect Attack4Effect => AttackEffect.UnBonus;
        public override AttackType Attack4Type => AttackType.Crush;
        public override bool BashDoor => true;
        public override bool BreatheAcid => true;
        public override bool BreatheDisenchant => true;
        public override bool BreathePoison => true;
        public override string Description => "A humanoid snake, Yig is one of the most poisonous entities in existance.";
        public override bool Drop_2D2 => true;
        public override bool Drop_4D2 => true;
        public override bool DropGood => true;
        public override bool Escorted => true;
        public override bool EscortsGroup => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Yig, Father of Serpents";
        public override bool GreatOldOne => true;
        public override int Hdice => 85;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 84;
        public override int Mexp => 35000;
        public override bool MoveBody => true;
        public override int NoticeRange => 50;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 2;
        public override bool ResistDisenchant => true;
        public override bool ResistPlasma => true;
        public override bool ResistTeleport => true;
        public override int Sleep => 20;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "    Yig     ";
        public override bool Unique => true;
    }
}
