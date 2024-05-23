// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LargeSteelChestItemFactory : ChestItemFactory
{
    private LargeSteelChestItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Large steel chest";

    public override int Cost => 250;
    public override int DamageDice => 2;
    public override int DamageSides => 6;
    public override string CodedName => "& Large steel chest~";
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 1)
    };
    public override int Weight => 1000;
    public override bool IsSmall => false;
    public override int NumberOfItemsContained => 6;
}
