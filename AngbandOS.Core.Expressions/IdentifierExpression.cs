namespace AngbandOS.Core.Expressions;

public abstract class IdentifierExpression : Expression
{
    public readonly string Identifier;
    public IdentifierExpression(string identifier)
    {
        Identifier = identifier;
    }
    public override string Text => $"{Identifier}";
}
