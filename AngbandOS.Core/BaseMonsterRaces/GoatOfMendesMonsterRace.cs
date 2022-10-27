using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class GoatOfMendesMonsterRace : MonsterRace
    {
        public override char Character => 'q';
        public override Colour Colour => Colour.Red;
        public override string Name => "Goat of Mendes";

        public override int ArmourClass => 66;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Gaze, new TerrifyAttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Butt, new HurtAttackEffect(), 6, 6),
            new MonsterAttack(AttackType.Bite, new Exp40AttackEffect(), 0, 0),
            new MonsterAttack(AttackType.Bite, new LoseConAttackEffect(), 0, 0)
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override bool ColdBall => true;
        public override bool Confuse => true;
        public override bool Demon => true;
        public override string Description => "It is a demonic creature from the lowest hell, vaguely resembling a large black he-goat.";
        public override bool DrainMana => true;
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override bool Forget => true;
        public override int FreqInate => 4;
        public override int FreqSpell => 4;
        public override string FriendlyName => "Goat of Mendes";
        public override int Hdice => 18;
        public override int Hside => 111;
        public override bool HurtByLight => true;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 50;
        public override int Mexp => 6666;
        public override bool MoveBody => true;
        public override bool NetherBall => true;
        public override bool Nonliving => true;
        public override int NoticeRange => 30;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override bool Powerful => true;
        public override int Rarity => 3;
        public override bool Scare => true;
        public override int Sleep => 40;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    Goat    ";
        public override string SplitName2 => "     of     ";
        public override string SplitName3 => "   Mendes   ";
        public override bool SummonDemon => true;
        public override bool SummonUndead => true;
    }
}
