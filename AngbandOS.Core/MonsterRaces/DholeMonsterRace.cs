using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class DholeMonsterRace : MonsterRace
    {
        protected DholeMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheAcidMonsterSpell());
        public override char Character => 'A';
        public override Colour Colour => Colour.Beige;
        public override string Name => "Dhole";

        public override bool Animal => true;
        public override int ArmourClass => 64;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(AttackType.Spit, new AcidAttackEffect(), 1, 8),
            new MonsterAttack(AttackType.Engulf, new AcidAttackEffect(), 2, 8),
            new MonsterAttack(AttackType.Crush, new HurtAttackEffect(), 4, 8),
        };
        public override bool Cthuloid => true;
        public override string Description => "A gigantic worm dripping with acid.";
        public override bool EldritchHorror => true;
        public override bool Evil => true;
        public override int FreqInate => 9;
        public override int FreqSpell => 9;
        public override string FriendlyName => "Dhole";
        public override int Hdice => 65;
        public override int Hside => 8;
        public override bool ImmuneAcid => true;
        public override bool KillWall => true;
        public override int LevelFound => 29;
        public override int Mexp => 500;
        public override int NoticeRange => 14;
        public override int Rarity => 4;
        public override int Sleep => 25;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "            ";
        public override string SplitName3 => "   Dhole    ";
    }
}
