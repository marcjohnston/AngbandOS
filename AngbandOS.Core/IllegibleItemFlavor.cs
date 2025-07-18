﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemFlavors;

[Serializable]
internal class IllegibleItemFlavor : Flavor
{
    public override Symbol Symbol { get; protected set; }
    public override ColorEnum Color { get; }
    public override string Name { get; }
    public IllegibleItemFlavor(Game game, Symbol symbol, ColorEnum color, string name) : base(game)
    {
        Symbol = symbol;
        Color = color;
        Name = name;
    }
}
