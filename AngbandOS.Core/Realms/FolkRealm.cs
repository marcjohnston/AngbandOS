namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class FolkRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private FolkRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Folk;
        public override string[] Info => new string[] {
            "The Folk realm is the least specialised of all the realms.",
            "Folk magic is capable of doing any effect that is possible", 
            "in other realms - but usually less effectively than the", 
            "specialist realms."
        };
        public override string Name => "Folk";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.FolkBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Cantrips for Beginners
            spellList.Add(new FolkSpellZap());
            spellList.Add(new FolkSpellWizardLock());
            spellList.Add(new FolkSpellDetectInvisibility());
            spellList.Add(new FolkSpellDetectMonsters());
            spellList.Add(new FolkSpellBlink());
            spellList.Add(new FolkSpellLightArea());
            spellList.Add(new FolkSpellTrapAndDoorDestruction());
            spellList.Add(new FolkSpellCureLightWounds());
            // Minor Magicks
            spellList.Add(new FolkSpellDetectDoorsAndTraps());
            spellList.Add(new FolkSpellPhlogiston());
            spellList.Add(new FolkSpellDetectTreasure());
            spellList.Add(new FolkSpellDetectEnchantment());
            spellList.Add(new FolkSpellDetectObjects());
            spellList.Add(new FolkSpellCurePoison());
            spellList.Add(new FolkSpellResistCold());
            spellList.Add(new FolkSpellResistFire());
            // Major Magicks
            spellList.Add(new FolkSpellResistLightning());
            spellList.Add(new FolkSpellResistAcid());
            spellList.Add(new FolkSpellCureMediumWounds());
            spellList.Add(new FolkSpellTeleport());
            spellList.Add(new FolkSpellStoneToMud());
            spellList.Add(new FolkSpellRayOfLight());
            spellList.Add(new FolkSpellSatisfyHunger());
            spellList.Add(new FolkSpellSeeInvisible());
            // Magicks of Mastery
            spellList.Add(new FolkSpellRecharging());
            spellList.Add(new FolkSpellTeleportLevel());
            spellList.Add(new FolkSpellIdentify());
            spellList.Add(new FolkSpellTeleportAway());
            spellList.Add(new FolkSpellElementalBall());
            spellList.Add(new FolkSpellDetection());
            spellList.Add(new FolkSpellWordOfRecall());
            spellList.Add(new FolkSpellClairvoyance());

            return spellList.ToArray();
        }
    }
}
