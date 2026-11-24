// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class HelpGroupGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("int",
        Title = "Sort Index",
        Description = "The order in which the help group is displayed.")]
    public virtual int SortIndex { get; set; }

    [ConfigurationProperty("string",
        Title = "Title",
        Description = "The title of the help group.")]
    public virtual string Title { get; set; }
}