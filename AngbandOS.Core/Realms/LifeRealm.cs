namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal class LifeRealm : BaseRealm
    {
        protected SaveGame SavedGame { get; }
        private LifeRealm(SaveGame savedGame) : base(savedGame) { }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public override Realm ID => Realm.Life;
        public override string[] Info => new string[] {
            "The Life realm is devoted to healing and buffing, with some", 
            "offensive capability against undead and demons. It is the", 
            "most defensive of the realms."
        };

        public override string Name => "Life";

        public override ItemTypeEnum SpellBookItemCategory => ItemTypeEnum.LifeBook;

        protected override Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();

            // Book of Common Prayer
            spellList.Add(new LifeSpellDetectEvil());
            spellList.Add(new LifeSpellCureLightWounds());
            spellList.Add(new LifeSpellBless());
            spellList.Add(new LifeSpellRemoveFear());
            spellList.Add(new LifeSpellCallLight());
            spellList.Add(new LifeSpellDetectTrapsAndSecretDoors());
            spellList.Add(new LifeSpellCureMediumWounds());
            spellList.Add(new LifeSpellSatisfyHunger());
            // High Mass
            spellList.Add(new LifeSpellRemoveCurse());
            spellList.Add(new LifeSpellCurePoison());
            spellList.Add(new LifeSpellCureCriticalWounds());
            spellList.Add(new LifeSpellSenseUnseen());
            spellList.Add(new LifeSpellHolyOrb());
            spellList.Add(new LifeSpellProtectionFromEvil());
            spellList.Add(new LifeSpellHealing());
            spellList.Add(new LifeSpellElderSign());
            // Dhol Chants
            spellList.Add(new LifeSpellExorcism());
            spellList.Add(new LifeSpellDispelCurse());
            spellList.Add(new LifeSpellDispelUndeadAndDemons());
            spellList.Add(new LifeSpellDayOfTheDove());
            spellList.Add(new LifeSpellDispelEvil());
            spellList.Add(new LifeSpellBanish());
            spellList.Add(new LifeSpellHolyWord());
            spellList.Add(new LifeSpellWardingTrue());
            // Ponape Scriptures
            spellList.Add(new LifeSpellHeroism());
            spellList.Add(new LifeSpellPrayer());
            spellList.Add(new LifeSpellBlessWeapon());
            spellList.Add(new LifeSpellRestoration());
            spellList.Add(new LifeSpellHealingTrue());
            spellList.Add(new LifeSpellHolyVision());
            spellList.Add(new LifeSpellDivineIntervention());
            spellList.Add(new LifeSpellHolyInvulnerability());

            return spellList.ToArray();
        }
    }
}
