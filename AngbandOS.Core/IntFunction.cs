﻿
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

[Serializable]
internal abstract class IntFunction : IChangeTracker, IGetKey, IIntValue
{
    protected readonly Game Game;
    protected IntFunction(Game game)
    {
        Game = game;
    }
    /// <summary>
    /// Returns true, if there are no dependencies or if any the change tracking on any dependency is flagged as changed.
    /// </summary>
    public bool IsChanged => Dependencies == null ? true : Dependencies.Any(_dependency => _dependency.IsChanged);

    /// <summary>
    /// Does nothing, because functions are not sinks for tracking.
    /// </summary>
    public void ClearChangedFlag() { }

    protected IChangeTracker[]? Dependencies { get; private set; }
    public string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        Dependencies = Game.SingletonRepository.GetNullable<IChangeTracker>(DependencyNames);
    }

    public virtual string[]? DependencyNames => null;

    public abstract int Value { get; }

    public int IntValue => Value;
}
