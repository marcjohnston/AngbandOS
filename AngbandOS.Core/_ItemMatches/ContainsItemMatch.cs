// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal class ContainsItemMatch<T> : ItemMatch
{
    public T[] Strings { get; }
    public bool TrueToMatchFalseToNotMatch { get; }
    public GetItemProperty<T> EvaluateLambda { get; }
    public ContainsItemMatch(Game game, T[] strings, bool trueToMatchFalseToNotMatch, GetItemProperty<T> evaluateLambda) : base(game, $"{evaluateLambda.DebugDescription} {(trueToMatchFalseToNotMatch ? "" : "not ")}in({String.Join(",", strings)})")
    {
        Strings = strings;
        TrueToMatchFalseToNotMatch = trueToMatchFalseToNotMatch;
        EvaluateLambda = evaluateLambda;
    }

    public override bool Matches(Item item)
    {
        T value = EvaluateLambda.Get(item);
        bool isOneOf = Strings.Contains(value);
        return isOneOf == TrueToMatchFalseToNotMatch;
    }
}

