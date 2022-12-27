using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterSpells;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class InertiaHoundMonsterRace : MonsterRace
    {
        protected InertiaHoundMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new BreatheInertiaMonsterSpell());
        public override char Character => 'Z';
        public override Colour Colour => Colour.Orange;
        public override string Name => "Inertia hound";

        public override bool Animal => true;
        public override int ArmourClass => 30;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 12),
            new MonsterAttack(new ClawAttackType(), new HurtAttackEffect(), 3, 3)
        };
        public override bool BashDoor => true;
        public override string Description => "Bizarrely, this hound seems to be hardly moving at all, yet it approaches you with deadly menace. It makes you tired just to look at it.";
        public override bool ForceSleep => true;
        public override int FreqInate => 5;
        public override int FreqSpell => 5;
        public override string FriendlyName => "Inertia hound";
        public override bool Friends => true;
        public override int Hdice => 35;
        public override int Hside => 10;
        public override bool ImmuneConfusion => true;
        public override bool ImmuneSleep => true;
        public override int LevelFound => 35;
        public override int Mexp => 500;
        public override int NoticeRange => 30;
        public override int Rarity => 2;
        public override int Sleep => 0;
        public override int Speed => 110;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  Inertia   ";
        public override string SplitName3 => "   hound    ";
    }
}
