namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class TarotRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private TarotRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Tarot;
        public static bool IsOf(BaseRealm? realm)
        {
            return realm != null && typeof(TarotRealm).IsAssignableFrom(realm.GetType());
        }
        public override string[] Info => new string[] {
            "The Tarot realm is one of the most specialised realms of", 
            "all, almost exclusively containing summoning and transport", 
            "spells."
       };
        public override string Name => "Tarot";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.TarotBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Conjurings and Tricks
            spellList.Add(new TarotSpellPhaseDoor());
            spellList.Add(new TarotSpellMindBlast());
            spellList.Add(new TarotSpellTarotDraw());
            spellList.Add(new TarotSpellResetRecall());
            spellList.Add(new TarotSpellTeleport());
            spellList.Add(new TarotSpellDimensionDoor());
            spellList.Add(new TarotSpellAstralSpying());
            spellList.Add(new TarotSpellTeleportAway());
            // Card Mastery
            spellList.Add(new TarotSpellSummonObject());
            spellList.Add(new TarotSpellSummonAnimal());
            spellList.Add(new TarotSpellPhantasmalServant());
            spellList.Add(new TarotSpellSummonMonster());
            spellList.Add(new TarotSpellConjureElemental());
            spellList.Add(new TarotSpellTeleportLevel());
            spellList.Add(new TarotSpellWordOfRecall());
            spellList.Add(new TarotSpellBanish());
            // Eltdown Shards
            spellList.Add(new TarotSpellTheFool());
            spellList.Add(new TarotSpellSummonSpiders());
            spellList.Add(new TarotSpellSummonReptiles());
            spellList.Add(new TarotSpellSummonHounds());
            spellList.Add(new TarotSpellAstralBranding());
            spellList.Add(new TarotSpellExtradimensionalBeing());
            spellList.Add(new TarotSpellDeathDealing());
            spellList.Add(new TarotSpellSummonReaver());
            // Celeano Fragments
            spellList.Add(new TarotSpellEtherealDivination());
            spellList.Add(new TarotSpellAstralLore());
            spellList.Add(new TarotSpellSummonUndead());
            spellList.Add(new TarotSpellSummonDragon());
            spellList.Add(new TarotSpellMassSummons());
            spellList.Add(new TarotSpellSummonDemon());
            spellList.Add(new TarotSpellSummonAncientDragon());
            spellList.Add(new TarotSpellSummonGreaterUndead());

            return spellList.ToArray();
        }
    }
}
