using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class SkeletonHumanMonsterRace : MonsterRace
    {
        protected SkeletonHumanMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 's';
        public override Colour Colour => Colour.BrightBeige;
        public override string Name => "Skeleton human";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 1, 8),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is an animated human skeleton.";
        public override bool EmptyMind => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Skeleton human";
        public override int Hdice => 10;
        public override int Hside => 8;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 12;
        public override int Mexp => 38;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 1;
        public override int Sleep => 30;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Skeleton  ";
        public override string SplitName3 => "   human    ";
        public override bool Undead => true;
    }
}
