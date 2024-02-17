// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.ItemFactories;

namespace AngbandOS.Core.Realms;

[Serializable]
internal abstract class Realm : IGetKey<string>
{
    protected SaveGame SaveGame { get; }
    protected Realm(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Adds the first book to the players inventory to outfit players that choose this realm with a starting book.
    /// </summary>
    public void OutfitPlayer()
    {
        // Get the first level book.
        ItemFactory outfitItem = SpellBooks[0];

        // Create an item from the factory.
        Item item = outfitItem.CreateItem();

        SaveGame.OutfitPlayerWithItem(item);
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
        foreach (BookItemFactory bookItemFactory in SpellBooks)
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
