// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


using System.Diagnostics;

[Serializable]
internal abstract class Function : IGetKey<string>, IIntChangeTracking
{
    protected readonly SaveGame SaveGame;
    protected Function(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract int Value { get; }

    public bool IsChanged => Dependencies == null ? false : Dependencies.Any(_dependency => _dependency.IsChanged);
    //{
    //    get
    //    {
    //        if (Dependencies == null)
    //        {
    //            return false;
    //        }
    //        bool changed = Dependencies.Any(_dependency => _dependency.IsChanged);
    //        Debug.Print($"Changed {changed}");
    //        return changed;
    //    }
    //}

    /// <summary>
    /// Does nothing, because functions are not sinks for tracking.
    /// </summary>
    public void ClearChangedFlag() { }

    public void Bind()
    {
        if (DependencyNames == null)
        {
            Dependencies = null;
        }
        else
        {
            List<IChangeTracking> conditionalList = new();
            foreach (string dependencyName in DependencyNames)
            {
                Property property = SaveGame.SingletonRepository.Properties.Get(dependencyName);
                conditionalList.Add(property);
            }
            Dependencies = conditionalList.ToArray();
        }

    }

    public string ToJson()
    {
        return "";
    }

    protected IChangeTracking[]? Dependencies { get; private set; }
    public virtual string[]? DependencyNames => null;

    public string Key => GetType().Name;

    public string GetKey => Key;
}
