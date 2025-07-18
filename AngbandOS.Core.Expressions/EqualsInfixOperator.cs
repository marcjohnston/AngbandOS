﻿namespace AngbandOS.Core.Expressions;

[Serializable]
public class EqualsInfixOperator : InfixOperator
{
    public override string OperatorSymbol => "==";
    public override InfixExpression CreateExpression(Expression operand1, Expression operand2) => new EqualsInfixExpression(operand1, operand2);
}
