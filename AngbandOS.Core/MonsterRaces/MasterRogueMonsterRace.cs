using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class MasterRogueMonsterRace : MonsterRace
    {
        protected MasterRogueMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'p';
        public override Colour Colour => Colour.Black;
        public override string Name => "Master rogue";

        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new HurtAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Hit, new EatGoldAttackEffect(), 4, 4),
        };
        public override bool BashDoor => true;
        public override string Description => "A thief of great power and shifty speed.";
        public override bool Drop_2D2 => true;
        public override bool Evil => true;
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Master rogue";
        public override int Hdice => 15;
        public override int Hside => 9;
        public override int LevelFound => 23;
        public override bool Male => true;
        public override int Mexp => 110;
        public override int NoticeRange => 20;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 40;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Master   ";
        public override string SplitName3 => "   rogue    ";
        public override bool TakeItem => true;
    }
}
