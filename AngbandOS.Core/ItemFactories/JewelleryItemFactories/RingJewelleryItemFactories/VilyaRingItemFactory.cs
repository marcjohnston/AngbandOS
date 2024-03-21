// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class VilyaRingItemFactory : RingItemFactory
{
    private VilyaRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override string Name => "Vilya";

    public override int Cost => 300000;
    public override string FriendlyName => "& Ring~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 100;
    public override int Weight => 2;
    public override Item CreateItem() => new Item(SaveGame, this);
}
