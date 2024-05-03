// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightAndDarknessResistanceRingItemFactory : RingItemFactory
{
    private LightAndDarknessResistanceRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Light and Darkness Resistance";

    public override int Cost => 3000;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Light and Darkness Resistance";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 2)
    };
    public override bool ResDark => true;
    public override bool ResLight => true;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(Game, this);
}
