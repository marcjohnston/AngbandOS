﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class SoftArmorItemFactory : ArmourItemFactory
{
    public SoftArmorItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<SoftArmorsItemClass>();
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<BodyInventorySlot>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SoftArmor;
    public override int PackSort => 21;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColourEnum Colour => ColourEnum.Grey;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;
    public override bool CanApplyArtifactBiasResistance => true;
}