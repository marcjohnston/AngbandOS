namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class DeathRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private DeathRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Death;
        public override string[] Info => new string[] {
            "The Death realm has a combination of life-draining spells,",
            "curses, and undead summoning. Like chaos, it is a very",
            "offensive realm."
        };
        public override string Name => "Death";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.DeathBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Black Prayers
            spellList.Add(new DeathSpellDetectUnlife());
            spellList.Add(new DeathSpellMalediction());
            spellList.Add(new DeathSpellDetectEvil());
            spellList.Add(new DeathSpellStinkingCloud());
            spellList.Add(new DeathSpellBlackSleep());
            spellList.Add(new DeathSpellResistPoison());
            spellList.Add(new DeathSpellHorrify());
            spellList.Add(new DeathSpellEnslaveUndead());
            // Black Mass
            spellList.Add(new DeathSpellOrbOfEntropy());
            spellList.Add(new DeathSpellNetherBolt());
            spellList.Add(new DeathSpellTerror());
            spellList.Add(new DeathSpellVampiricDrain());
            spellList.Add(new DeathSpellPoisonBranding());
            spellList.Add(new DeathSpellDispelGood());
            spellList.Add(new DeathSpellCarnage());
            spellList.Add(new DeathSpellRestoreLife());
            // Cultes des Goules
            spellList.Add(new DeathSpellBerserk());
            spellList.Add(new DeathSpellInvokeSpirits());
            spellList.Add(new DeathSpellDarkBolt());
            spellList.Add(new DeathSpellBattleFrenzy());
            spellList.Add(new DeathSpellVampirismTrue());
            spellList.Add(new DeathSpellVampiricBranding());
            spellList.Add(new DeathSpellDarknessStorm());
            spellList.Add(new DeathSpellMassCarnage());
            // Necronomicon
            spellList.Add(new DeathSpellDeathRay());
            spellList.Add(new DeathSpellRaiseTheDead());
            spellList.Add(new DeathSpellEsoteria());
            spellList.Add(new DeathSpellWordOfDeath());
            spellList.Add(new DeathSpellEvocation());
            spellList.Add(new DeathSpellHellfire());
            spellList.Add(new DeathSpellAnnihilation());
            spellList.Add(new DeathSpellWraithform());

            return spellList.ToArray();
        }
        public override bool ResistantToHolyAndHellProjectiles => true;
    }
}
