// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace AngbandOS
{
    [Serializable]
    internal class ItemTypeArray : List<ItemType>
    {
        private readonly SaveGame SaveGame;

        public ItemTypeArray(SaveGame saveGame)
        {
            SaveGame = saveGame;
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Check to see if the type implements the IItemCategory interface and is not an abstract class.
                if (!type.IsAbstract && typeof(BaseItemCategory).IsAssignableFrom(type))
                {
                    // Load the item.
                    BaseItemCategory itemCategory = (BaseItemCategory)Activator.CreateInstance(type);
                    Add(new ItemType(itemCategory));
                }
            }
        }

        public void ResetStompability()
        {
            foreach (ItemType itemType in this)
            {
                if (itemType.HasQuality())
                {
                    itemType.BaseItemCategory.Stompable[0] = true;
                    itemType.BaseItemCategory.Stompable[1] = false;
                    itemType.BaseItemCategory.Stompable[2] = false;
                    itemType.BaseItemCategory.Stompable[3] = false;
                }
                else
                {
                    itemType.BaseItemCategory.Stompable[0] = itemType.BaseItemCategory.Cost <= 0;
                    itemType.BaseItemCategory.Stompable[1] = false;
                    itemType.BaseItemCategory.Stompable[2] = false;
                    itemType.BaseItemCategory.Stompable[3] = false;
                }
            }
        }
    }
}