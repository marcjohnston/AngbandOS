// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Resolves the most specific mapping from a collection of configured mappings
/// by independently evaluating multiple criteria against each mapping and ranking
/// each mapping by the number of criteria it satisfies.
/// </summary>
/// <remarks>
/// <para>
/// This class is intended for resolving configurable game mappings in which a
/// single table may contain both general fallback mappings and increasingly
/// specialized mappings. Each supplied predicate represents an independent
/// criterion that can be used to determine whether a mapping applies to a
/// particular game scenario.
/// </para>
/// <para>
/// When resolving a mapping, every predicate is evaluated independently against
/// every configured item. Each predicate that returns <see langword="true"/>
/// increases the item's match rank by one. The item or items with the highest
/// rank represent the most specific mappings applicable to the supplied values.
/// </para>
/// <para>
/// For example, a game may allow execution scripts to be mapped to spells using
/// criteria such as the spell, realm, character class, and minimum experience
/// level. A general mapping can act as a fallback for all applicable scenarios,
/// while additional mappings can provide increasingly specialized behavior for
/// a particular realm, character class, or combination of criteria. A mapping
/// that matches more criteria receives a higher rank and takes precedence over
/// mappings that match fewer criteria.
/// </para>
/// <para>
/// This allows a configuration to express a hierarchy of mappings without
/// requiring the mappings themselves to be explicitly ordered. A general
/// fallback mapping may match one criterion, a character-class-specific mapping
/// may match two criteria, and a mapping that additionally applies to a
/// particular realm or experience level may match three or more criteria.
/// </para>
/// <para>
/// The selector also supports validating a configuration before it is used by
/// the game. The validation methods enumerate the supplied possible values for
/// each criterion and evaluate every combination of those values. This allows
/// the configuration designer or user interface to determine whether the
/// configured mappings produce a unique result for every possible game
/// scenario.
/// </para>
/// <para>
/// A configuration is ambiguous when two or more mappings receive the same
/// highest rank for the same combination of input values. For example, one
/// mapping may match a particular race while another mapping matches a
/// particular character class. A player who possesses both that race and
/// character class causes both mappings to receive the same rank. Without an
/// additional distinguishing criterion, the game cannot determine which mapping
/// should be selected.
/// </para>
/// <para>
/// <para>
/// This class cannot be serialized.
/// </para>
/// The validation methods are intended to identify these ambiguous scenarios
/// 
/// during configuration and UI/UX validation rather than allowing the ambiguity
/// 
/// to remain unresolved until runtime.
/// 
/// </para>
/// 
/// </remarks>
/// <typeparam name="T"></typeparam>
/// <typeparam name="T1"></typeparam>
/// <typeparam name="T2"></typeparam>
/// <typeparam name="T3"></typeparam>
/// <typeparam name="T4"></typeparam>
/// <typeparam name="T5"></typeparam>
internal class BestMatchSelector<T, T1, T2, T3, T4, T5>
{
    private IEnumerable<T> Items { get; }
    private Func<T, T1, bool> Query1 { get; }
    private Func<T, T2, bool> Query2 { get; }
    private Func<T, T3, bool> Query3 { get; }
    private Func<T, T4, bool> Query4 { get; }
    private Func<T, T5, bool> Query5 { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatchRanker{T, T1, T2, T3, T4}"/>
    /// class using the specified collection of items and four predicates used to
    /// evaluate the relative suitability of each item.
    /// </summary>
    /// <param name="items">
    /// The collection of items to evaluate.
    /// </param>
    /// <param name="query1">
    /// The first predicate used to evaluate an item against <paramref name="value1"/>
    /// when a match is requested.
    /// </param>
    /// <param name="query2">
    /// The second predicate used to evaluate an item against <paramref name="value2"/>
    /// when a match is requested.
    /// </param>
    /// <param name="query3">
    /// The third predicate used to evaluate an item against <paramref name="value3"/>
    /// when a match is requested.
    /// </param>
    /// <param name="query4">
    /// The fourth predicate used to evaluate an item against <paramref name="value4"/>
    /// when a match is requested.
    /// </param>
    public BestMatchSelector(IEnumerable<T> items, Func<T, T1, bool> query1, Func<T, T2, bool> query2, Func<T, T3, bool> query3, Func<T, T4, bool> query4, Func<T, T5, bool> query5)
    {
        Items = items;
        Query1 = query1;
        Query2 = query2;
        Query3 = query3;
        Query4 = query4;
        Query5 = query5;
    }

    /// <summary>
    /// Returns the single item with the highest number of matching predicates, or
    /// <see langword="null"/> if no items are available or no best match exists
    /// according to the selector's matching rules.
    /// </summary>
    /// <param name="value1">The value supplied to the first predicate.</param>
    /// <param name="value2">The value supplied to the second predicate.</param>
    /// <param name="value3">The value supplied to the third predicate.</param>
    /// <param name="value4">The value supplied to the fourth predicate.</param>
    /// <returns>
    /// The best-matching item, or <see langword="null"/> when no result is available.
    /// </returns>
    public T? GetSingleOrDefault(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
    {
        T[] allMatches = GetAll(value1, value2, value3, value4, value5);
        if (allMatches.Length == 0)
        {
            return default;
        }
        if (allMatches.Length > 1)
        {
            throw new Exception("Ambiguous match.");
        }
        return allMatches[0];
    }

    /// <summary>
    /// Returns the single item with the highest number of matching predicates.
    /// </summary>
    /// <remarks>
    /// This method is intended for cases where the matching criteria are expected
    /// to identify exactly one best-matching item. If the matching rules result in
    /// no suitable item or more than one equally best-matching item, the method
    /// throws an exception.
    /// </remarks>
    public T GetSingle(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
    {
        T[] allMatches = GetAll(value1, value2, value3, value4, value5);
        if (allMatches.Length != 1)
        {
            throw new Exception($"Ambiguous matches for {typeof(T).Name}: {string.Join(", ", allMatches.Select(_match => _match.GetType().Name))} matched.");
        }
        return allMatches[0];
    }

    /// <summary>
    /// Returns all items that share the highest number of matching predicates.
    /// </summary>
    /// <remarks>
    /// Multiple items may be returned when two or more items satisfy the same
    /// maximum number of predicates.
    /// </remarks>
    public T[] GetAll(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
    {
        bool IncrementMatchCount(bool result, ref int matchCount) 
        {
            if (result)
            {
                matchCount++;
            }
            return result;
        }

        if (!Items.Any())
        {
            return Array.Empty<T>();
        }

        // We need to loop through all of the items in the table.
        Dictionary<int, List<T>> matchCountAndItemDictionary = new Dictionary<int, List<T>>();

        // We will also track the highest number of matches.
        int greatestQuantityOfMatches = 0;

        foreach (T item in Items)
        {
            // We will track the match count for each item in the table.
            int matchCount = 0;

            // Now we evaluate each of the queries against the table and increment the match count when the query matches.
            bool query1Result = IncrementMatchCount(Query1(item, value1), ref matchCount);
            bool query2Result = IncrementMatchCount(Query2(item, value2), ref matchCount);
            bool query3Result = IncrementMatchCount(Query3(item, value3), ref matchCount);
            bool query4Result = IncrementMatchCount(Query4(item, value4), ref matchCount);
            bool query5Result = IncrementMatchCount(Query5(item, value5), ref matchCount);

            // Update the greatest quantity of matches.
            if (matchCount > greatestQuantityOfMatches)
            {
                greatestQuantityOfMatches = matchCount;
            }

            // Track this item against this match count.
            if (!matchCountAndItemDictionary.TryGetValue(matchCount, out List<T>? matchingItemsList))
            {
                matchingItemsList = new List<T>();
                matchCountAndItemDictionary.Add(matchCount, matchingItemsList);
            }
            matchingItemsList.Add(item);
        }

        return matchCountAndItemDictionary[greatestQuantityOfMatches].ToArray();
    }

    /// <summary>
    /// Determines whether the supplied collections of possible values produce
    /// exactly zero or one best match for the available items.
    /// </summary>
    /// <param name="value1">The possible values supplied to the first predicate.</param>
    /// <param name="value2">The possible values supplied to the second predicate.</param>
    /// <param name="value3">The possible values supplied to the third predicate.</param>
    /// <param name="value4">The possible values supplied to the fourth predicate.</param>
    /// <returns>
    /// <see langword="true"/> if the supplied values produce zero or one best match;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    public bool ValidateSingleOrDefault(T1[] values1, T2[] values2, T3[] values3, T4[] values4, T5[] values5)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines whether the supplied collections of possible values produce
    /// exactly one best match for the available items.
    /// </summary>
    /// <returns>
    /// <see langword="true"/> if exactly one best match is identified; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public bool ValidateSingle(T1[] values1, T2[] values2, T3[] values3, T4[] values4, T5[] values5)
    {
        throw new NotImplementedException();
    }
}