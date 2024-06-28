// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal class StringsItemMatch : ItemMatch
{
    public string[] Strings { get; }
    public bool TrueToMatchFalseToNotMatch { get; }
    public Func<Item, string> EvaluateLambda { get; }
    public StringsItemMatch(Game game, string title, string[] strings, bool trueToMatchFalseToNotMatch, Func<Item, string> evaluateLambda) : base(game, title)
    {
        Strings = strings;
        TrueToMatchFalseToNotMatch = trueToMatchFalseToNotMatch;
        EvaluateLambda = evaluateLambda;
    }

    public override bool Matches(Item item)
    {
        string value = EvaluateLambda(item);
        bool isOneOf = Strings.Contains(value);
        return isOneOf == TrueToMatchFalseToNotMatch;
    }
}
