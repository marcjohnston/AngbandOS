﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Properties;

/// <summary>
/// Represents a base class for any value that participates in change tracking.  Various types of value data types are built using derived classes; <see cref="IntProperty"/>.
/// </summary>
[Serializable]
internal abstract class Property : IGetKey, IChangeTracker
{
    protected readonly Game Game;
    protected Property(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Sets the change flag to true to indicate that the value has changed.  This should only be performed by derived classes when the internal value changes.
    /// </summary>
    protected void SetChangedFlag()
    {
        IsChanged = true;
    }

    /// <summary>
    /// Removes the change flag to indicate that the change has been processed.  This method is public because the consuming application needs to process the change.
    /// </summary>
    public void ClearChangedFlag()
    {
        IsChanged = false;
    }

    public bool IsChanged { get; private set; }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public override string ToString()
    {
        throw new Exception($"ToString override missing for {GetType().Name}.");
    }

    public void Bind() { }

}
