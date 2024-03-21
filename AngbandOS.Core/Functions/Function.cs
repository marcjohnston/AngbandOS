
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal abstract class Function : IGetKey, IChangeTracking
{
    protected readonly Game Game;
    protected Function(Game game)
    {
        Game = game;
    }
    public bool IsChanged => Dependencies == null ? false : Dependencies.Any(_dependency => _dependency.IsChanged);

    /// <summary>
    /// Does nothing, because functions are not sinks for tracking.
    /// </summary>
    public void ClearChangedFlag() { }

    public string ToJson()
    {
        return "";
    }

    protected IChangeTracking[]? Dependencies { get; private set; }
    public virtual string[]? DependencyNames => null;

    public string Key => GetType().Name;

    public string GetKey => Key;

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
                Property property = Game.SingletonRepository.Properties.Get(dependencyName);
                conditionalList.Add(property);
            }
            Dependencies = conditionalList.ToArray();
        }

    }
}
