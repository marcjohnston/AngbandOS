namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class SorceryRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private SorceryRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Sorcery;
        public static bool IsOf(BaseRealm? realm)
        {
            return realm != null && typeof(SorceryRealm).IsAssignableFrom(realm.GetType());
        }

        public override string[] Info => new string[] {
            "The Sorcery realm contains spells dealing with raw magic",
            "itself, for example spells dealing with magical items.",
            "It is the premier source of miscellaneous non-combat", 
            "utility spells."
        };
        public override string Name => "Sorcery";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.SorceryBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Beginner's Handbook
            spellList.Add(new SorcerySpellDetectMonsters());
            spellList.Add(new SorcerySpellPhaseDoor());
            spellList.Add(new SorcerySpellDetectDoorsAndTraps());
            spellList.Add(new SorcerySpellLightArea());
            spellList.Add(new SorcerySpellConfuseMonster());
            spellList.Add(new SorcerySpellTeleport());
            spellList.Add(new SorcerySpellSleepMonster());
            spellList.Add(new SorcerySpellRecharging());
            // Master Sorcerer's Handbook
            spellList.Add(new SorcerySpellMagicMapping());
            spellList.Add(new SorcerySpellIdentify());
            spellList.Add(new SorcerySpellSlowMonster());
            spellList.Add(new SorcerySpellMassSleep());
            spellList.Add(new SorcerySpellTeleportAway());
            spellList.Add(new SorcerySpellHasteSelf());
            spellList.Add(new SorcerySpellDetectionTrue());
            spellList.Add(new SorcerySpellIdentifyTrue());
            // Unaussprechlichen Kulten
            spellList.Add(new SorcerySpellDetectObjectsAndTreasure());
            spellList.Add(new SorcerySpellDetectEnchantment());
            spellList.Add(new SorcerySpellCharmMonster());
            spellList.Add(new SorcerySpellDimensionDoor());
            spellList.Add(new SorcerySpellSenseMinds());
            spellList.Add(new SorcerySpellSelfKnowledge());
            spellList.Add(new SorcerySpellTeleportLevel());
            spellList.Add(new SorcerySpellWordOfRecall());
            // Liber Ivonis
            spellList.Add(new SorcerySpellStasis());
            spellList.Add(new SorcerySpellTelekinesis());
            spellList.Add(new SorcerySpellYellowSign());
            spellList.Add(new SorcerySpellClairvoyance());
            spellList.Add(new SorcerySpellEnchantWeapon());
            spellList.Add(new SorcerySpellEnchantArmour());
            spellList.Add(new SorcerySpellAlchemy());
            spellList.Add(new SorcerySpellGlobeOfInvulnerability());

            return spellList.ToArray();
        }
    }
}
