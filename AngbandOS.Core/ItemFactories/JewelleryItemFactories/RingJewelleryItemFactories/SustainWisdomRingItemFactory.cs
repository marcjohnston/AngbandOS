// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SustainWisdomRingItemFactory : RingItemFactory
{
    private SustainWisdomRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Sustain Wisdom";

    public override int Cost => 600;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Sustain Wisdom";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 1)
    };
    public override bool SustWis => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
