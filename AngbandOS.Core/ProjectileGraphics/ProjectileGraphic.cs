// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    [Serializable]
    internal abstract class ProjectileGraphic
    {
        /// <summary>
        /// The column from which to take the graphical tile.
        /// </summary>
        public abstract char Character { get; }

        /// <summary>
        /// The row from which to take the graphical tile
        /// </summary>
        public virtual Colour Colour => Colour.White; // TODO: Inject the color ... we have 3 variations of every object because of this.

        /// <summary>
        /// A unique identifier for the entity.  
        /// </summary>
        public abstract string Name { get; } // TODO: Are we actually using this?
    }
}