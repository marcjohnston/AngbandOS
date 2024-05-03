// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FearResistanceRingItemFactory : RingItemFactory
{
    private FearResistanceRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Fear Resistance";

    public override int Cost => 300;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Fear Resistance";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 2)
    };
    public override bool ResFear => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
