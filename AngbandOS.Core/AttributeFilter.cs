
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class AttributeFilter : IGetKey, IToJson
{
    private readonly Game Game;
    public AttributeFilter(Game game, AttributeFilterGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        ActivationAttributeNonNull = gameConfiguration.ActivationAttributeNonNull;
        ArtifactBiasAttributeNonNull = gameConfiguration.ArtifactBiasAttributeNonNull;
        BoolAttributeFiltersBindings = gameConfiguration.BoolAttributeFilterBindings;
        OrAttributeFiltersBindings = gameConfiguration.OrAttributeFilterBindings;
        SumAttributeFilterBindings = gameConfiguration.SumAttributeFilterBindings;
    }

    public bool? ActivationAttributeNonNull { get; }
    public bool? ArtifactBiasAttributeNonNull { get; }
    private (string AttributeKey, bool?[] Value)[]? BoolAttributeFiltersBindings { get; }
    public (BoolAttribute Attribute, bool?[] Value)[] BoolAttributeFilters { get; private set; }
    private (string AttributeKey, bool Value)[]? OrAttributeFiltersBindings { get; }
    public (OrAttribute Attribute, bool Value)[] OrAttributeFilters { get; private set; }
    private (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings { get; }
    public (SumAttribute Attribute, int? StartingValue, int? EndingValue)[] SumAttributeFilters { get; private set; }

    public string ToJson()
    {
        AttributeFilterGameConfiguration gameConfiguration = new AttributeFilterGameConfiguration()
        {
            Key = Key,
            ActivationAttributeNonNull = ActivationAttributeNonNull,
            ArtifactBiasAttributeNonNull = ArtifactBiasAttributeNonNull,
            BoolAttributeFilterBindings = BoolAttributeFiltersBindings,
            OrAttributeFilterBindings = OrAttributeFiltersBindings,
            SumAttributeFilterBindings = SumAttributeFilterBindings,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        List<(BoolAttribute, bool?[])> boolAttributeList = new List<(BoolAttribute, bool?[])>();
        if (BoolAttributeFiltersBindings is not null)
        {
            foreach ((string attributeKey, bool?[] values) in BoolAttributeFiltersBindings)
            {
                BoolAttribute attribute = Game.SingletonRepository.Get<BoolAttribute>(attributeKey);
                boolAttributeList.Add((attribute, values));
            }
        }
        BoolAttributeFilters = boolAttributeList.ToArray();

        List<(OrAttribute, bool)> orAttributeList = new List<(OrAttribute, bool)>();
        if (OrAttributeFiltersBindings is not null)
        {
            foreach ((string attributeKey, bool value) in OrAttributeFiltersBindings)
            {
                OrAttribute attribute = Game.SingletonRepository.Get<OrAttribute>(attributeKey);
                orAttributeList.Add((attribute, value));
            }
        }
        OrAttributeFilters = orAttributeList.ToArray();

        List<(SumAttribute, int?, int?)> sumAttributeList = new List<(SumAttribute, int?, int?)>();
        if (SumAttributeFilterBindings is not null)
        {
            foreach ((string attributeKey, int? startingValue, int? endingValue) in SumAttributeFilterBindings)
            {
                SumAttribute attribute = Game.SingletonRepository.Get<SumAttribute>(attributeKey);
                sumAttributeList.Add((attribute, startingValue, endingValue));
            }
        }
        SumAttributeFilters = sumAttributeList.ToArray();
    }

    public bool Test(EffectiveAttributeSet effectiveAttributeSet)
    {
        if (ActivationAttributeNonNull.HasValue)
        {
            Activation? activation = effectiveAttributeSet.Get<ActivationEffectiveAttributeValue>(nameof(ActivationAttribute)).Get();
            if (ActivationAttributeNonNull.Value && activation is null)
            {
                return false;
            }
            if (!ActivationAttributeNonNull.Value && activation is not null)
            {
                return false;
            }
        }
        if (ArtifactBiasAttributeNonNull.HasValue)
        {
            ArtifactBias? artifactBias = effectiveAttributeSet.Get<ArtifactBiasEffectiveAttributeValue>(nameof(ArtifactBiasAttribute)).Get();
            if (ArtifactBiasAttributeNonNull.Value && artifactBias is null)
            {
                return false;
            }
            if (!ArtifactBiasAttributeNonNull.Value && artifactBias is not null)
            {
                return false;
            }
        }

        foreach ((BoolAttribute attribute, bool?[] values) in BoolAttributeFilters)
        {
            bool? effectiveAttributeSetValue = effectiveAttributeSet.Get<BoolSetEffectiveAttributeValue>(attribute).Get();
            if (!values.Any(_value => _value == effectiveAttributeSetValue))
            {
                return false;
            }
        }

        foreach ((OrAttribute attribute, bool value) in OrAttributeFilters)
        {
            bool? effectiveAttributeSetValue = effectiveAttributeSet.Get<OrEffectiveAttributeValue>(attribute).Get();
            if (effectiveAttributeSetValue != value)
            {
                return false;
            }
        }

        foreach ((SumAttribute attribute, int? startingValue, int? endingValue) in SumAttributeFilters)
        {
            int effectiveAttributeSetValue = effectiveAttributeSet.Get<SumEffectiveAttributeValue>(attribute).Get();
            if (startingValue.HasValue && effectiveAttributeSetValue < startingValue.Value)
            {
                return false;
            }
            if (endingValue.HasValue && effectiveAttributeSetValue > endingValue.Value)
            {
                return false;
            }
        }
        return true;
    }
}
