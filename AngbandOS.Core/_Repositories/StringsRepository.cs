// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections;
using System.Text.Json;

namespace AngbandOS.Core.Repositories;

/// <summary>
/// Represents a ListRepository where all of the entities are strings.  This abstract class handles the string serialization for the repository entities.
/// </summary>
[Serializable]
internal class StringsRepository : IEnumerable<string>
{
    public void PersistEntities()
    {
        List<string> values = new List<string>();
        foreach (string entity in this)
        {
            values.Add(entity);
        }
        string json = JsonSerializer.Serialize(values);
        Game.CorePersistentStorage.PersistEntity(Name, json);
    }
    private List<string> list = new List<string>();

    /// <summary>
    /// Returns a WeightedRandom object used to choose an item from the repository.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public WeightedRandom<string> ToWeightedRandom(Func<string, bool>? predicate = null) => new WeightedRandom<string>(Game, this, predicate);

    protected readonly Game Game;

    public StringsRepository(Game game, string name, string[]? strings)
    {
        Game = game;
        Name = name;
        if (strings != null)
        {
            list.AddRange(strings);
        }
    }

    /// <summary>
    /// Processes the load phase for the configuration repository items.  This phase creates instances of all objects that have a private constructor.  An instance of the Game is
    /// sent to the constructor for every configuration repository item created.  The configuration repository item cannot assume other repository items are available during this phase.
    /// </summary>
    public void Load(GameConfiguration gameConfiguration) { }

    /// <summary>
    /// Processes the bind phase for configuration repository items.  This phase allows each object to bind to other configuration repository objects.  Does nothing, by
    /// default.  ListRepositoriess won't handle this phase.  DictionaryRepositories will pass this event the members of that collection.
    /// </summary>
    public virtual void Bind() { }

    public IEnumerator<string> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return list.GetEnumerator();
    }

    public string Name { get; }
}
