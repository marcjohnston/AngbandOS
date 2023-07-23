// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class DiggingItemClass : WeaponItemClass
{
    public DiggingItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Diggers";
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<DiggerInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Digging;
    public override int PackSort => 31;
    public override ColourEnum Colour => ColourEnum.Grey;

}
