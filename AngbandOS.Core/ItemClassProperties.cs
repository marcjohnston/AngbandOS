using AngbandOS.Core.Interface;

namespace AngbandOS.Core
{
    [Serializable]
    /// <summary>
    /// Represents the properties for the class of the item.  These are singleton properties that belong to an ItemClass.
    /// </summary>
    internal class ItemClassProperties
    {
        /// <summary>
        /// Returns true, if items of this type are stompable (based on the known "feeling" of (Broken, Average, Good & Excellent)).
        /// Use StompableType enum to address each index.
        /// </summary>
        public readonly bool[] Stompable = new bool[4];

        /// <summary>
        /// The special flavor of the item has been identified. (e.g. of "seeing")
        /// </summary>
        public bool FlavourAware;

        /// <summary>
        /// Returns the character to be displayed for items of this type.  This character is initially set from the BaseItemCategory, but item categories
        /// that have flavor may override this character and replace it with a different character from the flavor.
        /// </summary>
        public char FlavorCharacter;

        /// <summary>
        /// Returns the color to be used for items of this type.  This color is initially set from the BaseItemCategory, but item categories
        /// that have flavor may override this color and replace it with a different color from the flavor.
        /// </summary>
        public Colour FlavorColour;

        /// <summary>
        /// Returns true, if the player has attempted/tried an item of the item class.
        /// </summary>
        public bool Tried;
    }
}
