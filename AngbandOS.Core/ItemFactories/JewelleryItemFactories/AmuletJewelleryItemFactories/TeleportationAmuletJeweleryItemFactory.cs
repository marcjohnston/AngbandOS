// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TeleportationAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private TeleportationAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Teleportation";

    public override int Cost => 250;
    public override bool Cursed => true;
    public override bool EasyKnow => true;
    public override string CodedName => "Teleportation";
    public override int LevelNormallyFound => 15;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (15, 1)
    };
    public override bool Teleport => true;
    public override int Weight => 3;
}
