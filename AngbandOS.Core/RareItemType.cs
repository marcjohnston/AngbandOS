// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Enumerations;

namespace AngbandOS
{
    [Serializable]
    internal class RareItemType
    {
        public readonly ItemCharacteristics RareItemCharacteristics = new ItemCharacteristics();
        public int Cost;
        public int Level;
        public int MaxPval;
        public int MaxToA;
        public int MaxToD;
        public int MaxToH;
        public string Name;
        public int Rarity;
        public int Rating;
        public int Slot;
        public readonly Base2RareItemType BaseRareItemType;

        public RareItemType(Base2RareItemType baseRareItemType)
        {
            BaseRareItemType = baseRareItemType;
            Cost = baseRareItemType.Cost;
            Level = baseRareItemType.Level;
            MaxPval = baseRareItemType.MaxPval;
            MaxToA = baseRareItemType.MaxToA;
            MaxToD = baseRareItemType.MaxToD;
            MaxToH = baseRareItemType.MaxToH;
            Name = baseRareItemType.FriendlyName;
            Rarity = baseRareItemType.Rarity;
            Rating = baseRareItemType.Rating;
            Slot = baseRareItemType.Slot;
            RareItemCharacteristics.Merge(baseRareItemType);
        }
    }
}