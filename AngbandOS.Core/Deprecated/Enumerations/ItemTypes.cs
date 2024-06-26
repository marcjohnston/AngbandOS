// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

/// <summary>
/// The category of an item
/// </summary>
internal enum ItemTypeEnum // THESE ARE ITEMCLASSES
{
    None = 0,
    Shot = 16,
    Arrow = 17,
    Bolt = 18,
    Hafted = 21,
    Polearm = 22,
    Sword = 23,
    Boots = 30,
    Gloves = 31,
    Helm = 32,
    Crown = 33,
    Shield = 34,
    Cloak = 35,
    SoftArmor = 36,
    HardArmor = 37,
    DragArmor = 38,
    Light = 39,
    Amulet = 40,
    Ring = 45,
    Staff = 55,
    Wand = 65,
    Rod = 66,
    Scroll = 70,
    Potion = 75,
    Flask = 77,
    Food = 80,
    LifeBook = 90,
    SorceryBook = 91,
    NatureBook = 92,
    ChaosBook = 93,
    DeathBook = 94,
    TarotBook = 95,
    FolkBook = 96,
    CorporealBook = 97,
}