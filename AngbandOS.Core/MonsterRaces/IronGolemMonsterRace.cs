using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class IronGolemMonsterRace : MonsterRace
    {
        protected IronGolemMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new SlowMonsterSpell());
        public override char Character => 'g';
        public override Colour Colour => Colour.BrightGrey;
        public override string Name => "Iron golem";

        public override int ArmourClass => 80;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new HitAttackType(), new HurtAttackEffect(), 1, 12),
        };
        public override bool BashDoor => true;
        public override bool ColdBlood => true;
        public override string Description => "It is a massive metal statue that moves steadily towards you.";
        public override bool EmptyMind => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "Iron golem";
        public override int Hdice => 80;
        public override int Hside => 12;
        public override bool ImmuneCold => true;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneFear => true;
        public override bool ImmuneFire => true;
        public override bool ImmuneLightning => true;
        public override bool ImmunePoison => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 22;
        public override int Mexp => 160;
        public override bool Nonliving => true;
        public override int NoticeRange => 12;
        public override int Rarity => 2;
        public override int Sleep => 10;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "    Iron    ";
        public override string SplitName3 => "   golem    ";
    }
}
