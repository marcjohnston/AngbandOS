namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal abstract class BaseRealm
    {
        protected SaveGame SaveGame { get; }
        protected BaseRealm(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        /// <summary>
        /// Returns the spells books that belong to the realm.
        /// </summary>
        public abstract BookItemFactory[] SpellBooks { get; }

        public abstract string[] Info { get; }

        public abstract string Name { get; }

        /// <summary>
        /// Returns the spell book item category that represents the realm.
        /// </summary>
        /// <param name="realm"> The realm of magic </param>
        /// <returns> The spell book item category </returns>
        public abstract ItemTypeEnum SpellBookItemCategory { get; }

        protected Spell[] GetGenerateSpellList()
        {
            List<Spell> spellList = new List<Spell>();
            foreach (BookItemFactory bookItemFactory in  SpellBooks)
            {
                spellList.AddRange(bookItemFactory.Spells);
            }

            return spellList.ToArray();
        }

        public Spell[] SpellList(BaseCharacterClass characterClass)
        {
            Spell[] spells = GetGenerateSpellList();
            foreach (Spell spell in spells)
            {
                spell.Initialize(characterClass);
            }
            return spells;
        }

        /// <summary>
        /// Returns true, if a player subscribing to the realm gains resistance to hellfire projectiles.  The resistance offers a 50% reduction in damage.  Returns false, by default.  The Death realm, returns true.
        /// </summary>
        /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
        public virtual bool ResistantToHolyAndHellProjectiles => false;

        /// <summary>
        /// Returns true, if a player subscribing to the realm gains is more susceptible to hellfire projectiles.  The susceptibility costs an additional 50% increase in damage.  Returns false, by default.  The Life realm, returns true.
        /// </summary>
        /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
        public virtual bool SusceptibleToHolyAndHellProjectiles => false;
    }
}
