// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightCrossbowBowWeaponItemFactory : BowWeaponItemFactory
{
    private LightCrossbowBowWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBracketSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Light Crossbow";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 140;
    public override string FriendlyName => "& Light Crossbow~";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 110;
    public override int MissileDamageMultiplier => 3;
    public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Bolt;
    public override Item CreateItem() => new Item(SaveGame, this);
}