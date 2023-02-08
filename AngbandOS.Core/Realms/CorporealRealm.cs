namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class CorporealRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private CorporealRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Corporeal;
        public static bool IsOf(BaseRealm? realm)
        {
            return realm != null && typeof(CorporealRealm).IsAssignableFrom(realm.GetType());
        }

        public override string[] Info => new string[] {
            "The Corporeal realm contains spells that exclusively affect",
            "the caster's body, although some spells also indirectly",
            "affect other creatures or objects. The corporeal realm is",
            "particularly good at sensing spells."
       };
        public override string Name => "Corporeal";
        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.CorporealBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Basic Chi Flow
            spellList.Add(new CorporealSpellCureLightWounds());
            spellList.Add(new CorporealSpellBlink());
            spellList.Add(new CorporealSpellBravery());
            spellList.Add(new CorporealSpellBatsSense());
            spellList.Add(new CorporealSpellEaglesVision());
            spellList.Add(new CorporealSpellMindVision());
            spellList.Add(new CorporealSpellCureMediumWounds());
            spellList.Add(new CorporealSpellSatisfyHunger());
            // Yogic Mastery
            spellList.Add(new CorporealSpellBurnResistance());
            spellList.Add(new CorporealSpellDetoxify());
            spellList.Add(new CorporealSpellCureCriticalWounds());
            spellList.Add(new CorporealSpellSeeInvisible());
            spellList.Add(new CorporealSpellTeleport());
            spellList.Add(new CorporealSpellHaste());
            spellList.Add(new CorporealSpellHealing());
            spellList.Add(new CorporealSpellResistTrue());
            // De Vermis Mysteriis
            spellList.Add(new CorporealSpellHorrificVisage());
            spellList.Add(new CorporealSpellSeeMagic());
            spellList.Add(new CorporealSpellStoneSkin());
            spellList.Add(new CorporealSpellMoveBody());
            spellList.Add(new CorporealSpellMutateBody());
            spellList.Add(new CorporealSpellKnowSelf());
            spellList.Add(new CorporealSpellTeleportLevel());
            spellList.Add(new CorporealSpellWordOfRecall());
            // Pnakotic Manuscript
            spellList.Add(new CorporealSpellHeroism());
            spellList.Add(new CorporealSpellWraithform());
            spellList.Add(new CorporealSpellAttunement());
            spellList.Add(new CorporealSpellRestoreBody());
            spellList.Add(new CorporealSpellHealingTrue());
            spellList.Add(new CorporealSpellHypnoticEyes());
            spellList.Add(new CorporealSpellRestoreSoul());
            spellList.Add(new CorporealSpellInvulnerability());

            return spellList.ToArray();
        }
    }
}
