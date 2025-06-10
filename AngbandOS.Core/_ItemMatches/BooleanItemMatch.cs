// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemMatches;

/// <summary>
/// Represents an object that performs a boolean match on an item property.
/// </summary>
[Serializable]
internal class BooleanItemMatch : ItemMatch
{
    public bool TrueToMatchFalseToNotMatch { get; }
    public GetItemProperty<bool> EvaluateLambda { get; }
    public BooleanItemMatch(Game game, bool trueToMatchFalseToNotMatch, GetItemProperty<bool> evaluateLambda) : base(game, trueToMatchFalseToNotMatch ? $"{evaluateLambda.DebugDescription}==true" : $"{evaluateLambda.DebugDescription}==false")
    {
        TrueToMatchFalseToNotMatch = trueToMatchFalseToNotMatch;
        EvaluateLambda = evaluateLambda;
    }

    public override bool Matches(Item item)
    {
        bool value = EvaluateLambda.Get(item);
        return value == TrueToMatchFalseToNotMatch;
    }
}