﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RingItemFactory : JewelleryItemFactory
{
    public override bool IsWearableOrWieldable => true;

    /// <summary>
    /// Returns either the right or left hand inventory slot for rings.
    /// </summary>
    public override int WieldSlot
    {
        get
        {
            if (Game.GetInventoryItem(InventorySlot.RightHand) == null)
            {
                return InventorySlot.RightHand;
            }
            return InventorySlot.LeftHand;
        }
    }

    /// <summary>
    /// Returns true, because rings are magical and should be detected with the detect magic scroll.
    /// </summary>
    public override bool IsMagical => true;

    public RingItemFactory(Game game) : base(game) { }
    protected override string ItemClassName => nameof(RingsItemClass);

    public override BaseInventorySlot BaseWieldSlot
    {
        get
        {
            BaseInventorySlot rightHand = Game.SingletonRepository.Get<BaseInventorySlot>(nameof(RightHandInventorySlot));
            if (rightHand.Count == 0)
            {
                return rightHand;
            }
            return Game.SingletonRepository.Get<BaseInventorySlot>(nameof(LeftHandInventorySlot));
        }
    }
    public override int PackSort => 16;
    public override int BaseValue => 45;
    public override bool HatesElectricity => true;
    public override ColorEnum Color => ColorEnum.Gold;
}
