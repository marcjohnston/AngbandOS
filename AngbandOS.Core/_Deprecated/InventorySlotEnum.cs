// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal static class InventorySlotEnum
{
    public const int Arm = 36; // DONE
    public const int OnBody = 34; // DONE
    public const int AboutBody = 35; // DONE
    public const int Digger = 29; // DONE
    public const int Feet = 39; // DONE
    public const int Hands = 38; // DONE
    public const int Head = 37; // DONE
    public const int LeftHand = 30; // DONE
    public const int Lightsource = 33; // DONE
    public const int Neck = 32; // DONE
    public const int RightHand = 31; // DONE
    public const int Pack = -1;  // DONE
    public const int RangedWeapon = 28; // DONE

    //WIP
    public const int MeleeWeapon = 27; // This is start inventory slot where the equipment items are stored.
    public const int PackCount = 26; // This is the last pack item slot.
    public const int Total = 40; // This is the end of the inventory slots.  This slot is not used.
}