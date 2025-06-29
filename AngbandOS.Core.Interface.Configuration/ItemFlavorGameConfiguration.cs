﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

/// <entity-name-property-name>Name</entity-name-property-name>
[Serializable]
public class ItemFlavorGameConfiguration
{
    public virtual string? Key { get; set; } = null;
    /// <foreign-collection-name>Symbols</foreign-collection-name>
    public virtual string SymbolName { get; set; }
    public virtual ColorEnum Color { get; set; }
    public virtual string Name { get; set; }
    public virtual bool CanBeAssigned { get; set; }
}
