// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Pocos;

internal class HelpGroupPoco : IToDefinition<HelpGroupDefinition>
{
    public string? Key { get; set; }
    public int? SortIndex { get; set; }
    public string? Title { get; set; }

    public HelpGroupDefinition? ToDefinition()
    {
        if (Key == null || SortIndex == null || Title == null)
            return null;

        return new HelpGroupDefinition()
        {
            Key = Key,
            SortIndex = SortIndex.Value,
            Title = Title
        };
    }
}