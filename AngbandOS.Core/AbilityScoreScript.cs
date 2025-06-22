// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class AbilityScoreScript : EatOrQuaffUniversalScript, IGetKey
{
    public AbilityScoreScript(Game game, AbilityScoreScriptGameConfiguration gameConfiguration) : base(game)
    {
        Key = gameConfiguration.Key ?? gameConfiguration.GetType().Name;
        LearnedDetails = gameConfiguration.LearnedDetails;
        UsesItem = gameConfiguration.UsesItem;
        AbilityBindingKey = gameConfiguration.AbilityBindingKey;
        TrueToIncreaseFalseToDecrease = gameConfiguration.TrueToIncreaseFalseToDecrease;
    }
    public virtual string Key { get; }
    public string GetKey => Key;

    public override string LearnedDetails { get; }
    public override bool UsesItem { get; }
    public void Bind()
    {
        Ability = Game.SingletonRepository.Get<Ability>(AbilityBindingKey);
    }

    protected Ability Ability { get; private set; }
    protected virtual string AbilityBindingKey { get; }
    protected virtual bool TrueToIncreaseFalseToDecrease { get; }
    public override IdentifiedResult ExecuteEatOrQuaffScript()
    {
        if (TrueToIncreaseFalseToDecrease)
        {
            return Game.TryIncreasingAbilityScore(Game.IntelligenceAbility);
        }
        else
        {
            return Game.TryDecreasingAbilityScore(Game.IntelligenceAbility);
        }
    }

    public string ToJson()
    {
        AbilityScoreScriptGameConfiguration gameConfiguration = new AbilityScoreScriptGameConfiguration()
        {
            Key = Key,
            LearnedDetails = LearnedDetails,
            UsesItem = UsesItem,
            AbilityBindingKey = AbilityBindingKey,
            TrueToIncreaseFalseToDecrease = TrueToIncreaseFalseToDecrease,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }
}

