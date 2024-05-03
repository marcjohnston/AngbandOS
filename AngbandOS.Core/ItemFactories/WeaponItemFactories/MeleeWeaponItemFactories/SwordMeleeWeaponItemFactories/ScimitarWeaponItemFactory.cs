// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ScimitarWeaponItemFactory : SwordWeaponItemFactory
{
    private ScimitarWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Scimitar";

    public override int Cost => 250;
    public override int Dd => 2;
    public override int Ds => 5;
    public override string FriendlyName => "& Scimitar~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 130;
    public override Item CreateItem() => new Item(Game, this);
}
