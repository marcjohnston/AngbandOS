// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class LightSourceItemFactory : ItemFactory
{
    public LightSourceItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(LightSourcesItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(LightsourceInventorySlot));

    public override int PackSort => 18;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
    public override bool HatesFire => true;
    public override ColourEnum Colour => ColourEnum.BrightYellow;

    public virtual void Refill(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your light cannot be refilled.");
    }

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston => null;

    /// <summary>
    /// Returns the number of turns of light that consumeds for each world turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate => 0;

    /// <summary>
    /// Returns the radius that the light source illuminates.  Default radius is 2.
    /// </summary>
    public virtual int Radius => 2;
}
