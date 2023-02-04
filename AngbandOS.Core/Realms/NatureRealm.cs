namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class NatureRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private NatureRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Nature;
        public override string[] Info => new string[] {
            "The Nature realm has a large number of summoning spells and",
            "miscellaneous spells, but little in the way of offensive", 
            "and defensive capabilities."
      };
        public override string Name => "Nature";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.NatureBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Call of the Wild
            spellList.Add(new NatureSpellDetectCreatures());
            spellList.Add(new NatureSpellFirstAid());
            spellList.Add(new NatureSpellDetectDoorsAndTraps());
            spellList.Add(new NatureSpellForaging());
            spellList.Add(new NatureSpellDaylight());
            spellList.Add(new NatureSpellAnimalTaming());
            spellList.Add(new NatureSpellResistEnvironment());
            spellList.Add(new NatureSpellCureWoundsAndPoison());
            // Nature Mastery
            spellList.Add(new NatureSpellStoneToMud());
            spellList.Add(new NatureSpellLightningBolt());
            spellList.Add(new NatureSpellNatureAwareness());
            spellList.Add(new NatureSpellFrostBolt());
            spellList.Add(new NatureSpellRayOfSunlight());
            spellList.Add(new NatureSpellEntangle());
            spellList.Add(new NatureSpellSummonAnimal());
            spellList.Add(new NatureSpellHerbalHealing());
            // Revelations of Glaaki
            spellList.Add(new NatureSpellDoorCreation());
            spellList.Add(new NatureSpellStairBuilding());
            spellList.Add(new NatureSpellStoneSkin());
            spellList.Add(new NatureSpellResistanceTrue());
            spellList.Add(new NatureSpellAnimalFriendship());
            spellList.Add(new NatureSpellStoneTell());
            spellList.Add(new NatureSpellWallOfStone());
            spellList.Add(new NatureSpellProtectFromCorrosion());
            // Cthaat Aquadingen
            spellList.Add(new NatureSpellEarthquake());
            spellList.Add(new NatureSpellWhirlwindAttack());
            spellList.Add(new NatureSpellBlizzard());
            spellList.Add(new NatureSpellLightningStorm());
            spellList.Add(new NatureSpellWhirlpool());
            spellList.Add(new NatureSpellCallSunlight());
            spellList.Add(new NatureSpellElementalBranding());
            spellList.Add(new NatureSpellNaturesWrath());

            return spellList.ToArray();
        }
    }
}
