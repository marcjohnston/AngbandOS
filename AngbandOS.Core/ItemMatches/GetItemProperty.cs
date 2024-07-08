﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal abstract class GetItemProperty<T> : IDebugDescription
{
    protected readonly Game Game;
    protected GetItemProperty(Game game)
    {
        Game = game;
    }

    public abstract string DebugDescription { get; }
    public abstract T Get(Item item);
}

