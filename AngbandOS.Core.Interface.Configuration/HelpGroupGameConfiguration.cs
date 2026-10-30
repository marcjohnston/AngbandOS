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
    [ConfigurationMetadata(Title = "Sort Index", Summary = "The order in which the help group is displayed.", DataType = "int")]
    public virtual int SortIndex { get; set; }

    [ConfigurationMetadata(Title = "Title", Summary = "The title of the help group.", DataType = "string")]
    public virtual string Title { get; set; }
}