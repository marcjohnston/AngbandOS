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
internal abstract class RacialPowerTest : IGetKey, IBoolValue
{
    protected readonly Game Game;
    protected RacialPowerTest(Game game)
    {
        Game = game;
    }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;

    public void Bind()
    {
        UseAbility = Game.SingletonRepository.Get<Ability>(AbilityBindingKey);
        Cost = Game.ParseNumericExpression(CostExpression);
    }

    public string ToJson()
    {
        return "";
    }

    public Ability UseAbility { get; private set; }
    public IScript Script { get; private set; }
    public abstract int MinLevel { get; }
    public abstract string CostExpression { get; }
    public Expression Cost { get; private set; }
    public abstract string AbilityBindingKey { get; }
    public abstract int Difficulty { get; }

    public bool BoolValue
    {
        get
        {
            IntegerExpression costIntegerExpression = Game.ComputeIntegerExpression(Cost);
            return Game.CheckIfRacialPowerWorks(MinLevel, costIntegerExpression.Value, UseAbility, Difficulty);
        }
    }
}
