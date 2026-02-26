// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents a set of non-deterministic item characteristics that can be merged with another other IItemCharacterstics.  These objects are used by <see cref="RareItem"/> objects and the random 
/// artifact creation process.
/// </summary>
[Serializable]
internal sealed class ItemEnhancement : IGetKey, IToJson, IItemEnhancement
{
    #region Constructors
    public ItemEnhancement(Game game, ItemEnhancementGameConfiguration itemEnhancementGameConfiguration)
    {
        Game = game;
        Key = itemEnhancementGameConfiguration.Key ?? itemEnhancementGameConfiguration.GetType().Name;

        SumAttributeAndExpressionBindings = itemEnhancementGameConfiguration.SumAttributeAndExpressionBindings;
        BoolAttributeAndExpressionBindings = itemEnhancementGameConfiguration.BoolAttributeAndExpressionBindings;
        OrAttributeAndExpressionBindings = itemEnhancementGameConfiguration.OrAttributeAndExpressionBindings;

        ActivationName = itemEnhancementGameConfiguration.ActivationName;
        AdditionalItemEnhancementWeightedRandomBindingKey = itemEnhancementGameConfiguration.AdditionalItemEnhancementWeightedRandomBindingKey;
        ApplicableItemFactoryBindingKeys = itemEnhancementGameConfiguration.ApplicableItemFactoryBindingKeys;
        ArtifactBiasWeightedRandomBindingKey = itemEnhancementGameConfiguration.ArtifactBiasWeightedRandomBindingKey;
        FriendlyName = itemEnhancementGameConfiguration.FriendlyName;
    }
    #endregion

    #region API
    private readonly Game Game;

    /// <summary>
    /// Returns this <see cref="ItemEnhancement"/> object itself.  This method allows the <see cref="ItemEnhancement"/> and <see cref="ItemEnhancementWeightedRandom"/> to be specified in the <see cref="MappedItemEnhancement.ItemEnhancements"/>.
    /// </summary>
    /// <returns></returns>
    public ItemEnhancement? GetItemEnhancement() => this;

    private (string AttributeName, string Expression)[]? SumAttributeAndExpressionBindings { get; }
    public (Attribute Attribute, Expression Expression)[] SumAttributeAndExpressions { get; private set; }
    private (string AttributeName, string BooleanExpression)[]? BoolAttributeAndExpressionBindings { get; }
    public (Attribute Attribute, Expression BooleanExpression)[] BoolAttributeAndExpressions { get; private set; }
    private (string AttributeName, string BooleanExpression)[]? OrAttributeAndExpressionBindings { get; }
    public (Attribute Attribute, Expression BooleanExpression)[] OrAttributeAndExpressions { get; private set; }

    /// <summary>
    /// Returns an immutable and fixed value set of item characteristics specified by this <see cref="ItemEnhancement"/> by computing fixed values from the expressions defined in these enhancements.
    /// </summary>
    /// <returns></returns>
    public ReadOnlyAttributeSet GenerateAttributeSet()
    {
        // Since we are squashing all of the values into a read-only set, we can use the Set.
        EffectiveAttributeSet itemCharacteristics = new EffectiveAttributeSet(Game);
        foreach ((Attribute attribute, Expression expression) in SumAttributeAndExpressions)
        {
            int appendValue = Game.ComputeIntegerExpression(expression).Value;
            itemCharacteristics.Get<SumEffectiveAttributeValue>(attribute).Append(appendValue);
        }
        foreach ((Attribute attribute, Expression expression) in BoolAttributeAndExpressions)
        {
            bool setValue = Game.ComputeBooleanExpression(expression).Value;
            itemCharacteristics.Get<BoolSetEffectiveAttributeValue>(attribute).Set(setValue);
        }
        foreach ((Attribute attribute, Expression expression) in OrAttributeAndExpressions)
        {
            bool setValue = Game.ComputeBooleanExpression(expression).Value;
            itemCharacteristics.Get<OrEffectiveAttributeValue>(attribute).Set(setValue);
        }

        itemCharacteristics.ArtifactBias = ArtifactBiasWeightedRandom?.ChooseOrDefault();

        if (Activation is not null)
        {
            itemCharacteristics.Activation = Activation;
        }
        itemCharacteristics.FriendlyName = FriendlyName;
        return itemCharacteristics.ToReadOnly();
    }

    public string GetKey => Key;
    public bool AppliesTo(ItemFactory itemFactory) // TODO: This is only being used to apply slaying item enhancements.
    {
        if (ApplicableItemFactories == null)
        {
            return true;
        }
        return ApplicableItemFactories.Contains(itemFactory);
    }
    public void Bind()
    {
        // We are using a dictionary because we do not want to support duplicate attributes.
        Dictionary<Attribute, Expression> sumAttributeAndExpressionList = new Dictionary<Attribute, Expression>();
        if (SumAttributeAndExpressionBindings is not null)
        {
            foreach ((string attributeName, string expression) in SumAttributeAndExpressionBindings)
            {
                Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
                Expression numericExpression = Game.ParseNumericExpression(expression);
                sumAttributeAndExpressionList.Add(attribute, numericExpression);
            }
        }
        SumAttributeAndExpressions = sumAttributeAndExpressionList.Select(_attributeAndExpression => (_attributeAndExpression.Key, _attributeAndExpression.Value)).ToArray();

        // We are using a dictionary because we do not want to support duplicate attributes.
        Dictionary<Attribute, Expression> boolAttributeAndExpressionList = new Dictionary<Attribute, Expression>();
        if (BoolAttributeAndExpressionBindings is not null)
        {
            foreach ((string attributeName, string expression) in BoolAttributeAndExpressionBindings)
            {
                Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
                Expression numericExpression = Game.ParseBooleanExpression(expression);
                boolAttributeAndExpressionList.Add(attribute, numericExpression);
            }
        }
        BoolAttributeAndExpressions = boolAttributeAndExpressionList.Select(_attributeAndExpression => (_attributeAndExpression.Key, _attributeAndExpression.Value)).ToArray();

        // We are using a dictionary because we do not want to support duplicate attributes.
        Dictionary<Attribute, Expression> orAttributeAndExpressionList = new Dictionary<Attribute, Expression>();
        if (OrAttributeAndExpressionBindings is not null)
        {
            foreach ((string attributeName, string expression) in OrAttributeAndExpressionBindings)
            {
                Attribute attribute = Game.SingletonRepository.Get<Attribute>(attributeName);
                Expression numericExpression = Game.ParseBooleanExpression(expression);
                orAttributeAndExpressionList.Add(attribute, numericExpression);
            }
        }
        OrAttributeAndExpressions = orAttributeAndExpressionList.Select(_attributeAndExpression => (_attributeAndExpression.Key, _attributeAndExpression.Value)).ToArray();

        Activation = Game.SingletonRepository.GetNullable<Activation>(ActivationName);

        AdditionalItemEnhancementWeightedRandom = Game.SingletonRepository.GetNullable<ItemEnhancementWeightedRandom>(AdditionalItemEnhancementWeightedRandomBindingKey);
        ArtifactBiasWeightedRandom = Game.SingletonRepository.GetNullable<ArtifactBiasWeightedRandom>(ArtifactBiasWeightedRandomBindingKey);
        ApplicableItemFactories = Game.SingletonRepository.GetNullable<ItemFactory>(ApplicableItemFactoryBindingKeys);
    }

    public string ToJson()
    {
        ItemEnhancementGameConfiguration itemEnhancementDefinition = new()
        {
            Key = Key,

            SumAttributeAndExpressionBindings = SumAttributeAndExpressionBindings,
            BoolAttributeAndExpressionBindings = BoolAttributeAndExpressionBindings,
            OrAttributeAndExpressionBindings = OrAttributeAndExpressionBindings,

            ActivationName = ActivationName,
            AdditionalItemEnhancementWeightedRandomBindingKey = AdditionalItemEnhancementWeightedRandomBindingKey,
            ApplicableItemFactoryBindingKeys = ApplicableItemFactoryBindingKeys,
            ArtifactBiasWeightedRandomBindingKey = ArtifactBiasWeightedRandomBindingKey,
            FriendlyName = FriendlyName,
        };
        return JsonSerializer.Serialize(itemEnhancementDefinition, Game.GetJsonSerializerOptions());
    }
    #endregion

    #region Bound Properties
    /// <inheritdoc />
    private Activation? Activation { get; set; }

    private ItemEnhancementWeightedRandom? AdditionalItemEnhancementWeightedRandom { get; set; }

    /// <inheritdoc />
    private ArtifactBiasWeightedRandom? ArtifactBiasWeightedRandom { get; set; }

    private ItemFactory[]? ApplicableItemFactories { get; set; } // TODO: This is contrary to the ItemEnhancement for ItemFactories.
    #endregion

    #region Unique ItemEnhancement Light-weight & Abstract Properties
    private string Key { get; }

    /// <summary>
    /// Returns the <see cref="ItemFactory"/> objects that this <see cref="ItemEnhancement"/> applies to; or null, if this <see cref="ItemEnhancement"/> can
    /// be applied to all <see cref="ItemFactory"/> objects.  This property is used to bind the <see cref="ApplicableItemFactories"/> property.
    /// </summary>
    private string[]? ApplicableItemFactoryBindingKeys { get; } = null;

    private string? AdditionalItemEnhancementWeightedRandomBindingKey { get; } = null;
    #endregion

    #region ItemPropertySet Light-weight & Abstract Properties

    /// <summary>
    /// Returns the name of the rare item characteristics to append to the description of the original item, or null, to not modify the name.  Returns null, by default.
    /// </summary>
    private string? FriendlyName { get; }

    /// <summary>
    /// Returns then name of an <see cref="Activation "/>, if the item can be activated; or null, if the item cannot be activated.  Dragon scale mail, rings of ice, acid and flames, the planar weapon, fixed artifacts and
    /// random artifacts may have an <see cref="Activation"/>.  Returns null, by default.  This property is used to bind the <see cref="Activation"/> property during the bind phase.
    /// </summary>
    /// <inheritdoc />
    private string? ActivationName { get; }

    private string? ArtifactBiasWeightedRandomBindingKey { get; }       
    #endregion
}
