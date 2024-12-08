// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFlavors;

[Serializable]
internal class BeigeScrollItemFlavor : ItemFlavor
{
    private BeigeScrollItemFlavor(Game game) : base(game) { } // This object is a singleton.
    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override ColorEnum Color => ColorEnum.Beige;

    public override string Name => "Beige";
}
