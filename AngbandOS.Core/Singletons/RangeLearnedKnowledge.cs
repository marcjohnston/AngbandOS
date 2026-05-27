// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RangeLearnedKnowledge : LearnedKnowledge, IGetKey, IToJson, IGameSerialize
{
    public string RangeExpressionText { get; }
    public Expression RangeExpression { get; private set; }
    public RangeLearnedKnowledge(Game game, RangeLearnedKnowledgeGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        RangeExpressionText = gameConfiguration.RangeExpressionText;
    }
    public override string LearnedDetails => $"range {RangeExpression.Minimize(MinimizeOptions).Text}";
    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        RangeExpression = Game.ParseNumericExpression(RangeExpressionText);
    }
    public string ToJson()
    {
        RangeLearnedKnowledgeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            RangeExpressionText = RangeExpressionText,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
    public GameStateBag? Serialize(SaveGameState saveGameState) => null;
}
