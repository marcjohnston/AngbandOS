
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using Timer = AngbandOS.Core.Timers.Timer;

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
                Property? property = Game.SingletonRepository.Properties.TryGet(dependencyName);
                if (property != null)
                {
                    conditionalList.Add(property);
                }
                else
                {
                    Function? function = Game.SingletonRepository.Functions.TryGet(dependencyName);
                    if (function != null)
                    {
                        conditionalList.Add(function);
                    }
                    else
                    {
                        Timer? timer = Game.SingletonRepository.Timers.TryGet(dependencyName);
                        if (timer != null)
                        {
                            conditionalList.Add(timer);
                        }
                        else
                        {
                            throw new Exception($"{dependencyName} dependency not found as {nameof(Property)}, {nameof(Timer)} or {nameof(Function)}.");
                        }
                    }
                }
            }
            Dependencies = conditionalList.ToArray();
        }

    }
}
