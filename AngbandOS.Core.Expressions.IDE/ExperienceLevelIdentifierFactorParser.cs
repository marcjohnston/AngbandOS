// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Expressions;

[Serializable]
internal class ExperienceLevelIdentifierFactorParser : IdentifierFactorParser
{
    private readonly int Value;
    public ExperienceLevelIdentifierFactorParser(int value)
    {
        Value = value;
    }
    public override string Identifier => "x";
    protected override Expression GenerateExpression(string matchedIdentifier)
    {
        return new ExperienceLevelIdentifierExpression(Value, Identifier);
    }
}
