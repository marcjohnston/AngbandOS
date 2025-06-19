// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Check if racial power works based on the minimum level, cost, ability and difficulty.  If the racial power works, it runs an associated script.
/// </summary>
[Serializable]
internal class RacialPowerTest : IGetKey, IBoolValue
{
    protected readonly Game Game;
    public RacialPowerTest(Game game, RacialPowerTestGameConfiguration racialPowerTestGameConfiguration)
    {
        Game = game;
        Key = racialPowerTestGameConfiguration.Key ?? racialPowerTestGameConfiguration.GetType().Name;
        MinLevel = racialPowerTestGameConfiguration.MinLevel;
        CostExpression = racialPowerTestGameConfiguration.CostExpression;
        UseAbilityBindingKey = racialPowerTestGameConfiguration.UseAbilityBindingKey;
        Difficulty = racialPowerTestGameConfiguration.Difficulty;
    }

    public virtual string Key { get; set; }
    public string GetKey => Key;

    public void Bind()
    {
        UseAbility = Game.SingletonRepository.Get<Ability>(UseAbilityBindingKey);
        Cost = Game.ParseNumericExpression(CostExpression);
    }

    public string ToJson()
    {
        RacialPowerTestGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            MinLevel = MinLevel,
            CostExpression = CostExpression,
            UseAbilityBindingKey = UseAbilityBindingKey,
            Difficulty = Difficulty
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public Ability UseAbility { get; private set; }
    public IScript Script { get; private set; }
    public virtual int MinLevel { get; }
    public virtual string CostExpression { get; }
    public Expression Cost { get; private set; }
    public virtual string UseAbilityBindingKey { get; }
    public virtual int Difficulty { get; }

    public bool BoolValue
    {
        get
        {
            IntegerExpression costIntegerExpression = Game.ComputeIntegerExpression(Cost);
            return Game.CheckIfRacialPowerWorks(MinLevel, costIntegerExpression.Value, UseAbility, Difficulty);
        }
    }
}
