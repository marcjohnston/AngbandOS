﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.HelpGroups;

[Serializable]
internal class GenericHelpGroup : HelpGroup
{
    public GenericHelpGroup(SaveGame saveGame, HelpGroupDefinition helpGroupDefinition) : base(saveGame)
    {
        Key = helpGroupDefinition.Key;
        SortIndex = helpGroupDefinition.SortIndex;
        Title = helpGroupDefinition.Title;
    }

    public override string Key { get; }
    public override string Title { get; }
    public override int SortIndex { get; }
}