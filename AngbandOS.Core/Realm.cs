// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;
using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal class Realm : IGetKey
{
    #region Constructor
    public Realm(Game game, RealmGameConfiguration realmGameConfiguration)
    {
        Game = game;
        Key = realmGameConfiguration.Key ?? realmGameConfiguration.GetType().Name;
        SpellBookNames = realmGameConfiguration.SpellBookNames;
        Info = realmGameConfiguration.Info;
        Name = realmGameConfiguration.Name;
        ResistantToHolyAndHellProjectiles = realmGameConfiguration.ResistantToHolyAndHellProjectiles;
        SusceptibleToHolyAndHellProjectiles = realmGameConfiguration.SusceptibleToHolyAndHellProjectiles;
    }
    #endregion

    #region Api Methods
    protected readonly Game Game;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        RealmGameConfiguration definition = new RealmGameConfiguration()
        {
            Key = Key,
            SpellBookNames = SpellBookNames,
            Info = Info,
            Name = Name,
            ResistantToHolyAndHellProjectiles = ResistantToHolyAndHellProjectiles,
            SusceptibleToHolyAndHellProjectiles = SusceptibleToHolyAndHellProjectiles
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string GetKey => Key;
    public void Bind()
    {
        SpellBooks = Game.SingletonRepository.Get<ItemFactory>(SpellBookNames);
    }

    /// <summary>
    /// Adds the first book to the players inventory to outfit players that choose this realm with a starting book.
    /// </summary>
    public void OutfitPlayer()
    {
        // Get the first level book.
        ItemFactory outfitItem = SpellBooks[0];

        // Create an item from the factory.
        Item item = outfitItem.GenerateItem();

        Game.OutfitPlayerWithItem(item);
    }

    /// <summary>
    /// Initialize the spells for the character that the player has chosen.  This process occurs during the confirmation birth stage.  Only the
    /// spells that belong to the primary and secondary realms are initialized.
    /// </summary>
    public void InitializeSpells()
    {
        int bookIndex = 0;
        int spellIndex = 0;
        int? spellFirst = null;
        foreach (ItemFactory itemFactory in SpellBooks)
        {
            itemFactory.SetBookIndex(this, bookIndex);
            bookIndex++;
            foreach (Spell spell in itemFactory.Spells)
            {
                spell.Initialize(itemFactory, spellIndex);
                spellIndex++;


                // Check to see if the first spell for the character needs to be lowered.
                if (spellFirst == null || spell.CharacterClassSpell.Level < spellFirst)
                {
                    spellFirst = spell.CharacterClassSpell.Level;
                }
            }
        }
        FirstSpellLevel = spellFirst;
    }
    #endregion

    #region Bound Properties
    /// <summary>
    /// Returns the spells books that belong to the realm.
    /// </summary>
    public ItemFactory[] SpellBooks { get; private set; }
    #endregion

    #region State Data
    /// <summary>
    /// Returns the level of the first spell for this realm.  If there are no books or spells, null is returned.
    /// </summary>
    public int? FirstSpellLevel { get; private set; }
    #endregion

    #region Light-weight Virtuals and Abstracts
    public virtual string Key { get; }
    protected virtual string[] SpellBookNames { get; }

    public virtual string[] Info { get; }

    public virtual string Name { get; }

    /// <summary>
    /// Returns true, if a player subscribing to the realm gains resistance to hellfire projectiles.  The resistance offers a 50% reduction in damage.  Returns false, by default.  The Death realm, returns true.
    /// </summary>
    /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
    public virtual bool ResistantToHolyAndHellProjectiles { get; } = false;

    /// <summary>
    /// Returns true, if a player subscribing to the realm gains is more susceptible to hellfire projectiles.  The susceptibility costs an additional 50% increase in damage.  Returns false, by default.  The Life realm, returns true.
    /// </summary>
    /// <value><c>true</c> if [resistant to hell fire]; otherwise, <c>false</c>.</value>
    public virtual bool SusceptibleToHolyAndHellProjectiles { get; } = false;

    public virtual string ClassSubname { get; }
    #endregion
}
