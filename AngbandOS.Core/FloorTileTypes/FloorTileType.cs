﻿// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core
{
    [Serializable]
    internal abstract class FloorTileType
    {
        public abstract char Character { get; }
        public virtual Colour Colour => Colour.White;
        public abstract string Name { get; }

        /// <summary>
        /// The action to be taken when this tile is altered.
        /// </summary>
        public abstract FloorTileAlterAction AlterAction { get; }

        /// <summary>
        /// The the tile this one should appear to be when looked at.
        /// </summary>
        public abstract string AppearAs { get; }

        /// <summary>
        /// The tile blocks line of sight.
        /// </summary>
        public virtual bool BlocksLos => false;

        /// <summary>
        /// The category of this tile.
        /// </summary>
        public abstract FloorTileTypeCategory Category { get; }

        /// <summary>
        /// A text description of the tile.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// The the tile this one should appear to be when looked at.
        /// </summary>
        public virtual bool DimsOutsideLOS => false;

        /// <summary>
        /// The tile is a basic (not permanent) dungeon wall.
        /// </summary>
        public virtual bool IsBasicWall => false;

        /// <summary>
        /// The tile is a closed door (not including a secret door.
        /// </summary>
        public virtual bool IsClosedDoor => false;

        /// <summary>
        /// The tile is 'interesting' and should be noticed when the player looks around.
        /// </summary>
        public virtual bool IsInteresting => false;

        /// <summary>
        /// The tile is open floor safe to drop items on.
        /// </summary>
        public virtual bool IsOpenFloor => false;

        /// <summary>
        /// A text description of the tile.
        /// </summary>
        public virtual bool IsPassable => false;

        /// <summary>
        /// A text description of the tile.
        /// </summary>
        public virtual bool IsPermanent => false;

        /// <summary>
        /// The tile is a shop entrance.
        /// </summary>
        public virtual bool IsShop => false;

        /// <summary>
        /// The tile is a known trap.
        /// </summary>
        public virtual bool IsTrap => false;

        /// <summary>
        /// The tile is a wall (not including a secret door).
        /// </summary>
        public virtual bool IsWall => false;

        /// <summary>
        /// The priority on the map.
        /// </summary>
        public abstract int MapPriority { get; }

        /// <summary>
        /// The player will run past the tile rather than stopping at it.
        /// </summary>
        public virtual bool RunPast => false;

        /// <summary>
        /// The the tile this one should appear to be when looked at.
        /// </summary>
        public virtual bool YellowInTorchlight => false;
    }
}