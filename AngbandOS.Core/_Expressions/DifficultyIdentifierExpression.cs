// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Expressions;

[Serializable]
internal class DifficultyIdentifierExpression : IdentifierExpression
{
    public DifficultyIdentifierExpression(string matchedIdentifier) : base(matchedIdentifier) { }
    public override Type[] ResultTypes => new Type[] { typeof(IntegerExpression) };
    public override Expression Compute(Dictionary<string, object> providers)
    {
        Func<int> GetDifficulty = (Func<int>)providers["Difficulty"];
        return new IntegerExpression(GetDifficulty());
    }
    public override Expression Minimize(Dictionary<string, object> providers, MinimizeOptions? options = null)
    {
        Func<int> GetDifficulty = (Func<int>)providers["Difficulty"];
        return new IntegerExpression(GetDifficulty());
    }
}
