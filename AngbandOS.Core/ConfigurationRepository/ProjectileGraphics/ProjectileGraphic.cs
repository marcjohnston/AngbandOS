﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal abstract class ProjectileGraphic : IConfigurationRepository
{
    protected SaveGame SaveGame;
    protected ProjectileGraphic(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }

    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    /// <summary>
    /// The column from which to take the graphical tile.
    /// </summary>
    public abstract char Character { get; }

    /// <summary>
    /// The row from which to take the graphical tile
    /// </summary>
    public virtual ColourEnum Colour => ColourEnum.White; // TODO: Inject the color ... we have 3 variations of every object because of this.

    /// <summary>
    /// A unique identifier for the entity.  
    /// </summary>
    public abstract string Name { get; } // TODO: Are we actually using this?
}