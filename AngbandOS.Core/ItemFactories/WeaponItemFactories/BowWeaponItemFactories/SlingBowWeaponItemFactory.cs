// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlingBowWeaponItemFactory : BowWeaponItemFactory
{
    private SlingBowWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(CloseBracketSymbol));
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Sling";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 5;
    public override string FriendlyName => "& Sling~";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 5;
    public override int MissileDamageMultiplier => 2;
    public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Shot;
    public override Item CreateItem() => new Item(Game, this);
}
