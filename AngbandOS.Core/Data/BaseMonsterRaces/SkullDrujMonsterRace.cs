using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    internal class SkullDrujMonsterRace : Base2MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Skull druj";

        public override int ArmourClass => 120;
        public override int Attack1DDice => 4;
        public override int Attack1DSides => 4;
        public override BaseAttackEffect? Attack1Effect => new Exp80AttackEffect();
        public override AttackType Attack1Type => AttackType.Bite;
        public override int Attack2DDice => 4;
        public override int Attack2DSides => 4;
        public override BaseAttackEffect? Attack2Effect => new ParalyzeAttackEffect();
        public override AttackType Attack2Type => AttackType.Bite;
        public override int Attack3DDice => 4;
        public override int Attack3DSides => 4;
        public override BaseAttackEffect? Attack3Effect => new LoseIntAttackEffect();
        public override AttackType Attack3Type => AttackType.Bite;
        public override int Attack4DDice => 4;
        public override int Attack4DSides => 4;
        public override BaseAttackEffect? Attack4Effect => new LoseWisAttackEffect();
        public override AttackType Attack4Type => AttackType.Bite;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBlood => true;
        public override bool CreateTraps => true;
        public override string Description => "A glowing skull possessed by sorcerous power. It need not move, but merely blast you with mighty magic.";
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 1;
        public override int FreqSpell => 1;
        public override string FriendlyName => "Skull druj";
        public override int Hdice => 14;
        public override int Hside => 100;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int Level => 55;
        public override int Mexp => 25000;
        public override bool MindBlast => true;
        public override bool NetherBolt => true;
        public override bool NeverMove => true;
        public override int NoticeRange => 20;
        public override bool PlasmaBolt => true;
        public override int Rarity => 4;
        public override bool ResistTeleport => true;
        public override int Sleep => 10;
        public override bool Slow => true;
        public override bool Smart => true;
        public override int Speed => 130;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Skull    ";
        public override string SplitName3 => "    druj    ";
        public override bool SummonUndead => true;
        public override bool Undead => true;
        public override bool WaterBall => true;
    }
}
