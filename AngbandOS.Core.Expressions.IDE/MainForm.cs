namespace AngbandOS.Core.Expressions.IDE;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        treeView1.Nodes.Clear();
        ExpressionParser parser = new ExpressionParser(new TestParseLanguage());
        Expression expression = parser.ParseExpression(textBox1.Text);
        TreeNode rootNode = treeView1.Nodes.Add("Expression");
        rootNode.Tag = expression;
        RenderExpression(rootNode, expression);
    }

    private void RenderExpression(TreeNode rootNode, Expression expression)
    {
        switch (expression)
        {
            case IntegerExpression integerExpression:
                TreeNode integerNode = rootNode.Nodes.Add($"Integer {integerExpression.Value}");
                integerNode.Tag = expression;
                break;
            case IdentifierExpression identifierExpression:
                TreeNode identifierNode = rootNode.Nodes.Add($"Identifier {identifierExpression.Identifier}");
                identifierNode.Tag = expression;
                break;
            case MultiplicationExpression multiplicationExpression:
                TreeNode multiplicationNode = rootNode.Nodes.Add($"Multiply");
                multiplicationNode.Tag = expression;
                RenderExpression(multiplicationNode, multiplicationExpression.Factor1);
                RenderExpression(multiplicationNode, multiplicationExpression.Factor2);
                break;
            case DivisionExpression divisionExpression:
                TreeNode divisionNode = rootNode.Nodes.Add($"Division");
                divisionNode.Tag = expression;
                RenderExpression(divisionNode, divisionExpression.Dividend);
                RenderExpression(divisionNode, divisionExpression.Divisor);
                break;
            case AdditionExpression additionExpression:
                TreeNode additionNode = rootNode.Nodes.Add($"Addition");
                additionNode.Tag = expression;
                RenderExpression(additionNode, additionExpression.Addend1);
                RenderExpression(additionNode, additionExpression.Addend2);
                break;
            case SubtractionExpression subtractionExpression:
                TreeNode subtractionNode = rootNode.Nodes.Add($"Subtraction");
                subtractionNode.Tag = expression;
                RenderExpression(subtractionNode, subtractionExpression.Minuend);
                RenderExpression(subtractionNode, subtractionExpression.Subtrahend);
                break;
            case DiceRollExpression diceRollExpression:
                TreeNode diceRollNode = rootNode.Nodes.Add($"DiceRoll");
                diceRollNode.Tag = expression;
                RenderExpression(diceRollNode, diceRollExpression.Dice);
                RenderExpression(diceRollNode, diceRollExpression.Sides);
                break;
        }
    }

    private void computeButton_Click(object sender, EventArgs e)
    {
        TreeNode node = treeView1.SelectedNode;
        Expression expression = (Expression)node.Tag;
        Expression result = expression.Compute();
        if (result is IntegerExpression integerResult)
        {
            label1.Text = $"{expression}={integerResult.Value}";
        }
        else
        {
            MessageBox.Show("Invalid return data type");
        }
    }
}
