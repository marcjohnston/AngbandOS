// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RuinedChestItemFactory : ChestItemFactory
{
    private RuinedChestItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Ruined chest";

    public override string FriendlyName => "& Ruined chest~";
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (75, 1)
    };
    public override int Weight => 250;
    public override bool IsSmall => true;
    public override int NumberOfItemsContained => 0;
    public override Item CreateItem() => new Item(Game, this);
}
