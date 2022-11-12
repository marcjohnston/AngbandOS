using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;

using AngbandOS.Core.AttackEffects;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class CultHighPriestMonsterRace : MonsterRace
    {
        public override char Character => 'p';
        public override Colour Colour => Colour.Diamond;
        public override string Name => "Cult high priest";

        public override int ArmourClass => 60;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 4),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 3, 5),
        };
        public override bool BashDoor => true;
        public override bool Blindness => true;
        public override bool BrainSmash => true;
        public override bool CauseMortalWounds => true;
        public override string Description => "A dark priest of the highest order. Powerful and evil, beware his many spells.";
        public override bool Drop_4D2 => true;
        public override bool Drop90 => true;
        public override bool Evil => true;
        public override bool ForceMaxHp => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 2;
        public override int FreqSpell => 2;
        public override string FriendlyName => "Cult high priest";
        public override int Hdice => 80;
        public override bool Heal => true;
        public override bool Hold => true;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 44;
        public override bool Male => true;
        public override int Mexp => 5000;
        public override int NoticeRange => 20;
        public override bool OnlyDropItem => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override bool Smart => true;
        public override int Speed => 120;
        public override string SplitName1 => "    Cult    ";
        public override string SplitName2 => "    high    ";
        public override string SplitName3 => "   priest   ";
        public override bool SummonCthuloid => true;
        public override bool SummonMonsters => true;
        public override bool SummonUndead => true;
    }
}
