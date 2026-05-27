// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class DurationLearnedKnowledge : LearnedKnowledge, IGetKey, IToJson
{
    public string DurationExpressionText { get; }
    public Expression DurationExpression { get; private set; }
    public DurationLearnedKnowledge(Game game, DurationLearnedKnowledgeGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        DurationExpressionText = gameConfiguration.DurationExpressionText;
    }
    public override string LearnedDetails => $"dur {DurationExpression.Minimize(MinimizeOptions).Text}";
    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        DurationExpression = Game.ParseNumericExpression(DurationExpressionText);
    }
    public string ToJson()
    {
        DurationLearnedKnowledgeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            DurationExpressionText = DurationExpressionText,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}
