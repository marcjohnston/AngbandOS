// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ShovelDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private ShovelDiggingWeaponItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(BackSlashSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Shovel";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 10;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "& Shovel~";
    public override int Level => 1;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 1;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 60;
    public override Item CreateItem() => new Item(SaveGame, this);
}
