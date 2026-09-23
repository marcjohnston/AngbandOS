namespace AngbandOS.Core.Expressions;

internal enum ExpressionProvidersEnum
{
    /// <summary>
    /// Returns the players current charisma value.
    /// </summary>
    GetCharisma,

    /// <summary>
    /// Returns the random number generator object.
    /// </summary>
    Random,

    /// <summary>
    /// Returns a function that returns the current difficulty value as an integer.
    /// </summary>
    GetDifficulty,

    /// <summary>
    /// Returns a function that returns the current health value as an integer.
    /// </summary>
    GetHealth,

    /// <summary>
    /// Returns the current monster's health value as an integer.
    /// </summary>
    MonsterHealth,

    /// <summary>
    /// Returns the current monster level as an integer.
    /// </summary>
    MonsterLevel,

    /// <summary>
    /// Returns a function that returns the current experience level value as an integer.
    /// </summary>
    GetExperienceLevel,
}