﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class GlovesArmorItemFactory : ArmourItemFactory
{
    public GlovesArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override int PackSort => 26;
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HandsInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Gloves;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override Colour Colour => Colour.BrightBrown;

    public override int? SubCategory => null; // No longer being used
}