namespace AngbandOS.Core.Expressions;

[Serializable]
public class EqualsInfixExpression : InfixExpression
{
    public EqualsInfixExpression(Expression leftExpression, Expression rightExpression) : base(leftExpression, rightExpression) { }
    public Expression LeftExpression => Operand1;
    public Expression RightExpression => Operand2;
    public override Type[] ResultTypes => new Type[] { typeof(BooleanExpression) };
    public override Expression Compute()
    {
        Expression leftExpression = LeftExpression.Compute();
        Expression rightExpression = RightExpression.Compute();
        if (leftExpression.GetType() != rightExpression.GetType())
        {
            throw new Exception("Boolean expression operands are not the same type.");
        }
        switch (leftExpression)
        {
            case IntegerExpression leftSideIntegerExpression:
                IntegerExpression rightSideIntegerExpression = (IntegerExpression)rightExpression;
                return new BooleanExpression(leftSideIntegerExpression.Value == rightSideIntegerExpression.Value);
            case DecimalExpression leftSideDecimalExpression:
                DecimalExpression rightSideDecimalExpression = (DecimalExpression)rightExpression;
                return new BooleanExpression(leftSideDecimalExpression.Value == rightSideDecimalExpression.Value);
            case BooleanExpression leftSideBooleanExpression:
                BooleanExpression rightSideBooleanExpression = (BooleanExpression)rightExpression;
                return new BooleanExpression(leftSideBooleanExpression.Value == rightSideBooleanExpression.Value);
            default:
                throw new Exception("Unrecognized types for boolean compute.");
        }
    }

    public override string Text => $"{LeftExpression}=={RightExpression}";
}
