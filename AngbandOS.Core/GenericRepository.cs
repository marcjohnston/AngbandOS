// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// Represents a repository that is both a dictionary and a list.  Singletons are stored in both a dictionary with a string key and a list.
/// </summary>
[Serializable]
internal class GenericRepository // TODO: Rename this as simply Repository
{
    public Dictionary<string, object> Dictionary = new Dictionary<string, object>(); // TODO: Make this private
    public List<object> List = new List<object>(); // TODO: Make this private
    public void Add(string key, object singleton)
    {
        Dictionary.Add(key, singleton);
        List.Add(singleton);
    }
    public T[] Get<T>()
    {
        List<T> resultList = new List<T>();
        foreach (object singleton in List)
        {
            resultList.Add((T)singleton);
        }
        return resultList.ToArray();
    }
}
