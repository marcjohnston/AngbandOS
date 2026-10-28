// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal sealed class DamageLearnedKnowledge : LearnedKnowledge, IGetKey, IToJson, IGameSerialize
{
    public string DamageExpressionText { get; }
    public Expression DamageExpression { get; private set; }
    public DamageLearnedKnowledge(Game game, DamageLearnedKnowledgeGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.GetKey;
        DamageExpressionText = gameConfiguration.DamageExpressionText;
    }
    public override string LearnedDetails => $"dam {DamageExpression.Minimize(Game.GetExpressionProviders(), MinimizeOptions).Text}";
    public string Key { get; }

    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState)
    {
        DamageExpression = Game.ParseNumericExpression(DamageExpressionText);
    }
    public string ToJson()
    {
        DamageLearnedKnowledgeGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            DamageExpressionText = DamageExpressionText,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public GameStateBag? Serialize(SaveGameState saveGameState) => null;
}
