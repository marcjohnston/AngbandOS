﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class BowWeaponItemFactory : WeaponItemClass // TODO: Should be renamed to RangedWeaponItemClass
{
    public BowWeaponItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<BowsItemClass>();
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<RangedWeaponInventorySlot>();
    /// <summary>
    /// Returns a damage multiplier when the missile weapon is used.
    /// </summary>
    public virtual int MissileDamageMultiplier => 1;

    public override int PackSort => 32;
    public abstract ItemTypeEnum AmmunitionItemCategory { get; }

    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bow;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    public override ColourEnum Colour => ColourEnum.Brown;

    public override bool CanApplyArtifactBiasSlaying => false;
}