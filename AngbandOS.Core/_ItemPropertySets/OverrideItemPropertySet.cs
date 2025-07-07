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
    public bool? IsCursed // TODO: This should simply be CurseRemoved
    {
        get
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            return RwNullableValueItemProperty.Value;
        }
        set
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.IsCursed];
            RwNullableValueItemProperty.Value = value;
        }
    }
    public bool? HeavyCurse // This should simply be HeavyCurseRemoved
    {
        get
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            return RwNullableValueItemProperty.Value;
        }
        set
        {
            NullableValueItemProperty<bool> RwNullableValueItemProperty = (NullableValueItemProperty<bool>)ItemProperties[(int)ItemPropertiesEnum.HeavyCurse];
            RwNullableValueItemProperty.Value = value;
        }
    }
    #endregion
}
