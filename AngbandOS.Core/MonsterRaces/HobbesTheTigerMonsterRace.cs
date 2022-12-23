using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class HobbesTheTigerMonsterRace : MonsterRace
    {
        protected HobbesTheTigerMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'f';
        public override Colour Colour => Colour.BrightYellow;
        public override string Name => "Hobbes the Tiger";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 11),
            new MonsterAttack(AttackType.Claw, new HurtAttackEffect(), 1, 11),
            new MonsterAttack(AttackType.Bite, new HurtAttackEffect(), 1, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "Fast-moving, with a taste for tuna sandwiches.";
        public override bool ForceMaxHp => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Hobbes the Tiger";
        public override int Hdice => 10;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 10;
        public override bool Male => true;
        public override int Mexp => 45;
        public override int NoticeRange => 40;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 120;
        public override string SplitName1 => "   Hobbes   ";
        public override string SplitName2 => "    the     ";
        public override string SplitName3 => "   Tiger    ";
        public override bool Unique => true;
    }
}
