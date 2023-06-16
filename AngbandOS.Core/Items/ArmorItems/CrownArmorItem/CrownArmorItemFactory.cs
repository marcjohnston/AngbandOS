// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class CrownArmorItemFactory : ArmourItemFactory
{
    public CrownArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HeadInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Crown;
    public override bool HatesAcid => true;

    public override int PackSort => 24;
    public override Colour Colour => Colour.BrightBrown;
    public override int? SubCategory => null; // No longer used.
}
