// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class HelmItemClass : ArmourItemFactory
{
    public HelmItemClass(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(HelmsItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(HeadInventorySlot));
    public override int PackSort => 25;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Helm;
    public override bool HatesAcid => true;

    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override bool CanReflectBoltsAndArrows => true;
}
