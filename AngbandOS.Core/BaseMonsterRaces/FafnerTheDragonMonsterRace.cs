using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal class FafnerTheDragonMonsterRace : MonsterRace
    {
        public override char Character => 'D';
        public override Colour Colour => Colour.BrightGreen;
        public override string Name => "Fafner the Dragon";

        public override int ArmourClass => 100;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 10),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 4, 10),
            new MonsterAttack(AttackType.Bite, new FireAttackEffect(), 14, 6),
            new MonsterAttack(AttackType.Bite, new PoisonAttackEffect(), 14, 6)
        };
        public override bool BashDoor => true;
        public override bool BreatheFire => true;
        public override bool BreathePoison => true;
        public override bool CauseCriticalWounds => true;
        public override bool Confuse => true;
        public override string Description => "The mighty dragon of the Norse myth, Fafner was a giant who slew his brother to win a treasure hoard, and then transformed himself into a dragon, greedily watching over his hoard.";
        public override bool Dragon => true;
        public override bool Drop_3D2 => true;
        public override bool Drop_4D2 => true;
        public override bool Drop60 => true;
        public override bool Drop90 => true;
        public override bool DropGood => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 3;
        public override int FreqSpell => 3;
        public override string FriendlyName => "Fafner the Dragon";
        public override int Hdice => 25;
        public override int Hside => 110;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFire => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 47;
        public override bool Male => true;
        public override int Mexp => 25000;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool Powerful => true;
        public override int Rarity => 4;
        public override bool Scare => true;
        public override int Sleep => 70;
        public override int Speed => 120;
        public override string SplitName1 => "   Fafner   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "   Dragon   ";
        public override bool Unique => true;
    }
}
