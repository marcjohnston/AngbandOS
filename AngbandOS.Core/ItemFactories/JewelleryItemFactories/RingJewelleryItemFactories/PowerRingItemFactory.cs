// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PowerRingItemFactory : RingItemFactory
{
    private PowerRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override ColorEnum Color => ColorEnum.Yellow;
    public override string Name => "Power";

    public override void Bind()
    {
        base.Bind();
        Flavor = Game.SingletonRepository.Get<RingReadableFlavor>(nameof(PlainGoldRingReadableFlavor));
    }

    public override int Cost => 5000000;
    public override string FriendlyName => "Power";
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 110;
    public override int Weight => 2;
}
