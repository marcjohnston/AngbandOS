// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class MonsterFilter : IGetKey
{
    protected readonly Game Game;
    public MonsterFilter(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
        FrequencyProbabilityExpression = Game.ParseNullableProbabilityExpression(FrequencyProbabilityExpressionText);
    }

    public string ToJson()
    {
        return "";
    }

    /// <summary>
    /// Returns a probability for the frequency in which a match is returned as a match or null, if a match is always returned as a match.
    /// </summary>
    protected virtual string? FrequencyProbabilityExpressionText => null;

    protected Probability? FrequencyProbabilityExpression { get; private set; }

    protected abstract bool Match(Monster mPtr);

    public bool Matches(Monster mPtr)
    {
        bool match = Match(mPtr);

        // If it is a match, check the frequency probability.
        if (match && FrequencyProbabilityExpression != null)
        {
            match = FrequencyProbabilityExpression.Test();
        }
        return match;
    }
}
