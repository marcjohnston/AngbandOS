// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

namespace AngbandOS
{
    [Serializable]
    internal class TvalDescriptionPair
    {
        public static readonly TvalDescriptionPair[] Tvals =
        {
            new TvalDescriptionPair(ItemTypeEnum.Hafted, "Hafted Weapons"),
            new TvalDescriptionPair(ItemTypeEnum.Polearm, "Polearms"),
            new TvalDescriptionPair(ItemTypeEnum.Sword, "Swords"),
            new TvalDescriptionPair(ItemTypeEnum.Bow, "Bows"),
            new TvalDescriptionPair(ItemTypeEnum.Arrow, "Arrows"),
            new TvalDescriptionPair(ItemTypeEnum.Bolt, "Bolts"),
            new TvalDescriptionPair(ItemTypeEnum.Shot, "Shots"),
            new TvalDescriptionPair(ItemTypeEnum.Digging, "Diggers"),
            new TvalDescriptionPair(ItemTypeEnum.Light, "Light Sources"),
            new TvalDescriptionPair(ItemTypeEnum.Chest, "Chests"),
            new TvalDescriptionPair(ItemTypeEnum.SoftArmor, "Soft Armours"),
            new TvalDescriptionPair(ItemTypeEnum.HardArmor, "Hard Armours"),
            new TvalDescriptionPair(ItemTypeEnum.DragArmor, "Dragon Scale Mails"),
            new TvalDescriptionPair(ItemTypeEnum.Cloak, "Cloaks"),
            new TvalDescriptionPair(ItemTypeEnum.Shield, "Shields"),
            new TvalDescriptionPair(ItemTypeEnum.Crown, "Crowns"),
            new TvalDescriptionPair(ItemTypeEnum.Helm, "Helms"),
            new TvalDescriptionPair(ItemTypeEnum.Gloves, "Gloves"),
            new TvalDescriptionPair(ItemTypeEnum.Boots, "Boots"),
            new TvalDescriptionPair(ItemTypeEnum.Amulet, "Amulets"),
            new TvalDescriptionPair(ItemTypeEnum.Potion, "Potions"),
            new TvalDescriptionPair(ItemTypeEnum.Ring, "Rings"),
            new TvalDescriptionPair(ItemTypeEnum.Rod, "Rods"),
            new TvalDescriptionPair(ItemTypeEnum.Scroll, "Scrolls"),
            new TvalDescriptionPair(ItemTypeEnum.Staff, "Staffs"),
            new TvalDescriptionPair(ItemTypeEnum.Wand, "Wands"),
            new TvalDescriptionPair(ItemTypeEnum.ChaosBook, "Chaos Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.CorporealBook, "Corporeal Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.DeathBook, "Death Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.FolkBook, "Folk Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.LifeBook, "Life Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.NatureBook, "Nature Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.SorceryBook, "Sorcery Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.TarotBook, "Tarot Spellbooks"),
            new TvalDescriptionPair(ItemTypeEnum.Bottle, "Bottles"),
            new TvalDescriptionPair(ItemTypeEnum.Flask, "Flasks"),
            new TvalDescriptionPair(ItemTypeEnum.Food, "Food"),
            new TvalDescriptionPair(ItemTypeEnum.Junk, "Junk"),
            new TvalDescriptionPair(ItemTypeEnum.Skeleton, "Skeletons"),
            new TvalDescriptionPair(ItemTypeEnum.Spike, "Spikes"),
            new TvalDescriptionPair(0, null)
        };

        public readonly string Desc;
        public readonly ItemTypeEnum Tval;

        private TvalDescriptionPair(ItemTypeEnum tval, string desc)
        {
            Tval = tval;
            Desc = desc;
        }
    }
}