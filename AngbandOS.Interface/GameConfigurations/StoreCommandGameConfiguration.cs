// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.ComponentModel.DataAnnotations;

namespace AngbandOS.Core.Interface;


[Serializable]
public class StoreCommandGameConfiguration
{
    public virtual string Key { get; set; }
    public virtual char KeyChar { get; set; }
    public virtual string Description { get; set; }
    public virtual string[]? ValidStoreFactoryNames { get; set; }
    public virtual string? ExecuteScriptName { get; set; }

    //public bool IsValid()
    //{
    //    if (Key == null || KeyChar == null || Description == null)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}