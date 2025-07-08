// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class OverrideItemPropertySet : ItemPropertySet
{
    public OverrideItemPropertySet()
    {
        // Create nullable item characteristics for every property.
        foreach (ItemPropertyFactory itemCharacteristicFactory in ItemPropertyFactories)
        {
            ItemProperties[itemCharacteristicFactory.Index] = itemCharacteristicFactory.InstantiateNullable();
        }
    }

    private OverrideItemPropertySet(ItemProperty[] itemCharacteristics) : base(itemCharacteristics) { }

    /// <summary>
    /// Returns a cloned set of item properties.
    /// </summary>
    /// <remarks>
    /// This override version of the clone is used to clone the <see cref="Item.OverrideItemCharacteristics"/> when cloning an <see cref="Item"/>.
    /// </remarks>
    /// <returns></returns>
    public OverrideItemPropertySet Clone()
    {
        ItemProperty[] clonedItemCharacteristics = CloneAllItemProperties();
        return new OverrideItemPropertySet(clonedItemCharacteristics);
    }

    /// <summary>
    /// Returns a read-only effective item property set by applying an override process from the nullable values in this property set with an incoming read-only item property set.
    /// </summary>
    /// <param name="roItemPropertySet"></param>
    /// <returns></returns>
    public RoItemPropertySet Override(RoItemPropertySet roItemPropertySet)
    {
        ItemProperty[] overriddenItemProperties = OverrideAllItemProperties(roItemPropertySet);
        return new RoItemPropertySet(overriddenItemProperties);
    }

    #region Properties
    ///// <summary>
    ///// Returns a final armor class that is applied to the item; or null, if there is no overriding armor class and the effective armor class is used instead.
    ///// </summary>
    //public int? BonusArmorClass
    //{
    //    get
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
    //        return RwNullableValueItemProperty.Value;
    //    }
    //    set
    //    {
    //        NullableValueItemProperty<int> RwNullableValueItemProperty = (NullableValueItemProperty<int>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
    //        RwNullableValueItemProperty.Value = value;
    //    }
    //}

    /// <summary>
    /// Resets the curse removed state back to default.  This is used when applying a curse on an item so that the item shows as cursed.
    /// </summary>
    public void ResetCurse()
    {
        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
        RwNullableValueItemProperty.Value = null;
    }

    /// <summary>
    /// Removes the curse from an item.  This overrides the curse state of an item; as false.
    /// </summary>
    public void RemoveCurse()
    {
        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
        RwNullableValueItemProperty.Value = false;
    }

    /// <summary>
    /// Resets the heavy curse removed state back to default.  This is used when applying a heavy curse on an item so that the item shows as cursed.
    /// </summary>
    public void ResetHeavyCurse()
    {
        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
        RwNullableValueItemProperty.Value = null;
    }

    /// <summary>
    /// Removes the heavy curse from an item.  This overrides the heavy curse state of an item; as false.
    /// </summary>
    public void RemoveHeavyCurse()
    {
        NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
        RwNullableValueItemProperty.Value = false;
    }
    #endregion
}
