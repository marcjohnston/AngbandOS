﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFilters;

/// <summary>
/// Represents an item filter for sorcery books that have value.
/// </summary>
[Serializable]
internal class SorceryBooksOfValueItemFilter : ItemFilter<SorceryBookItemFactory>
{
    private SorceryBooksOfValueItemFilter(Game game) : base(game) { } // This object is a singleton.
    public override bool? HasValue => true;
}