// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Runtime.Serialization;

namespace AngbandOS
{
    [Serializable]
    internal class RareItemTypeArray : Dictionary<RareItemTypeEnum, RareItemType>
    {
        public RareItemTypeArray(SaveGame saveGame)
        {
            foreach (KeyValuePair<string, Base2RareItemType> pair in ObjectRepository.RareItemTypes)
            {
                Add(pair.Value.RareItemType, new RareItemType(pair.Value));
            }
        }

        public RareItemTypeArray(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Needed for serialising a dictionary
        }
    }
}