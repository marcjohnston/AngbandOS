// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ItemIdentification : IGetKey, IToJson
{
    private readonly Game Game;
    public ItemIdentification(Game game, ItemIdentificationGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        AttributesFilterBindingKey = gameConfiguration.AttributesFilterBindingKey;
        InterpolationExpressionAttributeNames = gameConfiguration.InterpolationExpressionAttributeNames;
        EffectDescription = gameConfiguration.EffectDescription;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ItemIdentificationGameConfiguration gameConfiguration = new ItemIdentificationGameConfiguration()
        {
            Key = Key,
            AttributesFilterBindingKey = AttributesFilterBindingKey,
            InterpolationExpressionAttributeNames = InterpolationExpressionAttributeNames,
            EffectDescription = EffectDescription,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public string Key { get; }

    public string GetKey => Key;

    private string AttributesFilterBindingKey { get; }
    public AttributeFilter AttributesFilter { get; private set; }

    public void Bind()
    {
        AttributesFilter = Game.SingletonRepository.Get<AttributeFilter>(AttributesFilterBindingKey);
        InterpolationExpressionAttributes = Game.SingletonRepository.GetNullable<Attribute>(InterpolationExpressionAttributeNames);
    }
    private string[]? InterpolationExpressionAttributeNames { get; }
    public Attribute[]? InterpolationExpressionAttributes { get; private set; }
    public string[] EffectDescription { get; }
    public bool Test(EffectiveAttributeSet effectiveAttributeSet)
    {
        return AttributesFilter.Test(effectiveAttributeSet);
    }

    public string[] GenerateIdentifications(EffectiveAttributeSet effectiveAttributeSet)
    {
        // Generate the parameters to send.
        List<string> interpolationExpressions = new List<string>();
        if (InterpolationExpressionAttributes is not null)
        {
            foreach (Attribute attribute in InterpolationExpressionAttributes)
            {
                EffectiveAttributeValue effectiveAttributeValue = effectiveAttributeSet.Get(attribute);
                interpolationExpressions.Add(effectiveAttributeValue.RenderForItemIdentification);
            }
        }

        List<string> effectDescriptionList = new List<string>();
        foreach (string effectDescriptionLine in EffectDescription)
        {
            string effectDescription = String.Format(effectDescriptionLine, interpolationExpressions.ToArray());
            effectDescriptionList.Add(effectDescription);
        }

        return effectDescriptionList.ToArray();
    }
}
