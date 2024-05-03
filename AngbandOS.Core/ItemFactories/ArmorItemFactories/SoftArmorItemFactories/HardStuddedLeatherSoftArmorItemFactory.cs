// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HardStuddedLeatherSoftArmorItemFactory : SoftArmorItemFactory
{
    private HardStuddedLeatherSoftArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenParenthesisSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Hard Studded Leather";

    public override int Ac => 7;
    public override int Cost => 200;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Hard Studded Leather~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int ToH => -1;
    public override int Weight => 110;
    public override Item CreateItem() => new Item(Game, this);
}
