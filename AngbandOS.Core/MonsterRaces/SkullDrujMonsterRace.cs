using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class SkullDrujMonsterRace : MonsterRace
    {
        public override char Character => 's';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Skull druj";

        public override int ArmourClass => 120;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Bite, new Exp80AttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Bite, new ParalyzeAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Bite, new LoseIntAttackEffect(), 4, 4),
            new MonsterAttack(AttackType.Bite, new LoseWisAttackEffect(), 4, 4)
        };
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
        public override int LevelFound => 55;
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
