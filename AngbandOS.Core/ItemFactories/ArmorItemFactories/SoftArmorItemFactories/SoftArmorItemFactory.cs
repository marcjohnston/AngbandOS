// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class SoftArmorItemFactory : ArmorItemFactory
{
    /// <summary>
    /// Returns the on-body inventory slot for soft armor.
    /// </summary>
    public override int WieldSlot => InventorySlot.OnBody;


    /// <summary>
    /// Applies standard magic to soft armor.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power != 0)
        {
            // Apply the standard armor characteristics.
            base.ApplyMagic(item, level, power, null);

            if (power > 1)
            {
                ApplyRandomGoodRareCharacteristics(item);
            }
        }
    }

    public SoftArmorItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(SoftArmorsItemClass));
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(OnBodyInventorySlot));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SoftArmor;
    public override int PackSort => 21;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;

    public override ColorEnum Color => ColorEnum.Grey;

    public override bool CanProvideSheathOfElectricity => true;

    public override bool CanProvideSheathOfFire => true;
    public override bool CanApplyArtifactBiasResistance => true;
}
