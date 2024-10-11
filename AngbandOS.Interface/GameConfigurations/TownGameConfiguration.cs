// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”


namespace AngbandOS.Core.Interface;

[Serializable]
public class TownGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual char Char { get; set; }
    public virtual int HousePrice { get; set; }
    public virtual string Name { get; set; }
    public virtual string[] StoreFactoryNames { get; set; }
    public virtual bool CanBeEscortedHere { get; set; } = true;

    public virtual bool AllowStartupTown { get; set; } = true;

    public virtual string DungeonName { get; set; }

    public virtual bool UnusedStoreLotsAreGraveyards { get; set; } = false;

    //public bool IsValid()
    //{
    //    if (Key == null || HousePrice == null || Name == null || Char == null || StoreFactoryNames == null || DungeonName == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
    //}
}
