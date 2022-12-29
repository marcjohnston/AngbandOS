using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.MonsterSpells;

namespace AngbandOS.Core.MonsterRaces
{
    [Serializable]
    internal class FourHeadedHydraMonsterRace : MonsterRace
    {
        protected FourHeadedHydraMonsterRace(SaveGame saveGame) : base(saveGame) { }
 
        public override MonsterSpellList Spells => new MonsterSpellList(
            new ScareMonsterSpell());
        public override char Character => 'M';
        public override Colour Colour => Colour.Chartreuse;
        public override string Name => "4-headed hydra";

        public override bool Animal => true;
        public override int ArmourClass => 70;
        public override MonsterAttack[]? Attacks => new MonsterAttack[] {
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6),
            new MonsterAttack(new BiteAttackType(), new HurtAttackEffect(), 2, 6)
        };
        public override bool BashDoor => true;
        public override string Description => "A strange reptilian hybrid with four heads, guarding its hoard.";
        public override bool Drop_4D2 => true;
        public override bool ForceSleep => true;
        public override int FreqInate => 7;
        public override int FreqSpell => 7;
        public override string FriendlyName => "4-headed hydra";
        public override int Hdice => 100;
        public override int Hside => 6;
        public override int LevelFound => 24;
        public override int Mexp => 350;
        public override bool MoveBody => true;
        public override int NoticeRange => 20;
        public override bool OnlyDropGold => true;
        public override bool OpenDoor => true;
        public override int Rarity => 2;
        public override int Sleep => 20;
        public override int Speed => 120;
        public override string SplitName1 => "            ";
        public override string SplitName2 => "  4-headed  ";
        public override string SplitName3 => "   hydra    ";
    }
}
