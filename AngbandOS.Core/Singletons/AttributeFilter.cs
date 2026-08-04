
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class AttributeFilter : IGetKey, IToJson, IGameSerialize
{
    private Game Game { get; }
    public AttributeFilter(Game game, AttributeFilterGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        ActivationAttributeNonNull = gameConfiguration.ActivationAttributeNonNull;
        ArtifactBiasAttributeNonNull = gameConfiguration.ArtifactBiasAttributeNonNull;
        BoolAttributeFiltersBindings = gameConfiguration.BoolAttributeFilterBindings;
        OrAttributeFiltersBindings = gameConfiguration.BitwiseOrAttributeFilterBindings;
        SumAttributeFilterBindings = gameConfiguration.SummationAttributeFilterBindings;
    }

    public virtual GameStateBag? Serialize(SaveGameState saveGameState) => null;
    public bool? ActivationAttributeNonNull { get; }
    public bool? ArtifactBiasAttributeNonNull { get; }
    private (string AttributeKey, bool?[] Value)[]? BoolAttributeFiltersBindings { get; }
    public (BoolAttribute Attribute, bool?[] Value)[] BoolAttributeFilters { get; private set; }
    private (string AttributeKey, bool Value)[]? OrAttributeFiltersBindings { get; }
    public (BitwiseOrAttribute Attribute, bool Value)[] OrAttributeFilters { get; private set; }
    private (string AttributeKey, int? StartingValue, int? EndingValue)[]? SumAttributeFilterBindings { get; }
    public (SummationAttribute Attribute, int? StartingValue, int? EndingValue)[] SumAttributeFilters { get; private set; }

    public string ToJson()
    {
        AttributeFilterGameConfiguration gameConfiguration = new AttributeFilterGameConfiguration()
        {
            Key = Key,
            ActivationAttributeNonNull = ActivationAttributeNonNull,
            ArtifactBiasAttributeNonNull = ArtifactBiasAttributeNonNull,
            BoolAttributeFilterBindings = BoolAttributeFiltersBindings,
            BitwiseOrAttributeFilterBindings = OrAttributeFiltersBindings,
            SummationAttributeFilterBindings = SumAttributeFilterBindings,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
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

        List<(BitwiseOrAttribute, bool)> orAttributeList = new List<(BitwiseOrAttribute, bool)>();
        if (OrAttributeFiltersBindings is not null)
        {
            foreach ((string attributeKey, bool value) in OrAttributeFiltersBindings)
            {
                BitwiseOrAttribute attribute = Game.SingletonRepository.Get<BitwiseOrAttribute>(attributeKey);
                orAttributeList.Add((attribute, value));
            }
        }
        OrAttributeFilters = orAttributeList.ToArray();

        List<(SummationAttribute, int?, int?)> sumAttributeList = new List<(SummationAttribute, int?, int?)>();
        if (SumAttributeFilterBindings is not null)
        {
            foreach ((string attributeKey, int? startingValue, int? endingValue) in SumAttributeFilterBindings)
            {
                SummationAttribute attribute = Game.SingletonRepository.Get<SummationAttribute>(attributeKey);
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

        foreach ((BitwiseOrAttribute attribute, bool value) in OrAttributeFilters)
        {
            bool? effectiveAttributeSetValue = effectiveAttributeSet.Get<OrEffectiveAttributeValue>(attribute).Get();
            if (effectiveAttributeSetValue != value)
            {
                return false;
            }
        }

        foreach ((SummationAttribute attribute, int? startingValue, int? endingValue) in SumAttributeFilters)
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
