using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class JubjubBirdMonsterRace : MonsterRace
    {
        protected JubjubBirdMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override char Character => 'B';
        public override Colour Colour => Colour.Pink;
        public override string Name => "Jubjub bird";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 8, 12),
            new MonsterAttack(AttackType.Hit, new ElectricityAttackEffect(), 12, 12),
        };
        public override bool BashDoor => true;
        public override string Description => "A vast legendary bird, its iron talons rake the most impenetrable of surfaces and its screech echoes through the many winding dungeon corridors.";
        public override int FreqInate => 0;
        public override int FreqSpell => 0;
        public override string FriendlyName => "Jubjub bird";
        public override int Hdice => 80;
        public override int Hside => 13;
        public override bool ImmuneLightning => true;
        public override int LevelFound => 40;
        public override int Mexp => 1000;
        public override int NoticeRange => 20;
        public override int Rarity => 3;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "   Jubjub   ";
        public override string SplitName3 => "    bird    ";
    }
}
