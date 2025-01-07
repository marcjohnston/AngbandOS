using AngbandOS.Core.Interface;

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
        Parser parser = new Parser(new AngbandOSExpressionParseLanguage());
        Expression expression = parser.ParseExpression(textBox1.Text);
        TreeNode rootNode = treeView1.Nodes.Add("Expression");
        RenderExpression(rootNode, expression);
    }
    private void RenderExpression(TreeNode rootNode, Expression expression)
    {
        switch (expression)
        {
            case IntegerExpression integerExpression:
                rootNode.Nodes.Add($"Integer {integerExpression.Value}");
                break;
            case IdentifierExpression identifierExpression:
                rootNode.Nodes.Add($"Identifier {identifierExpression.Identifier}");
                break;
            case MultiplicationExpression multiplicationExpression:
                TreeNode multiplicationNode = rootNode.Nodes.Add($"Multiply");
                RenderExpression(multiplicationNode, multiplicationExpression.Factor1);
                RenderExpression(multiplicationNode, multiplicationExpression.Factor2);
                break;
            case DivisionExpression divisionExpression:
                TreeNode divisionNode = rootNode.Nodes.Add($"Division");
                RenderExpression(divisionNode, divisionExpression.Dividend);
                RenderExpression(divisionNode, divisionExpression.Divisor);
                break;
            case AdditionExpression additionExpression:
                TreeNode additionNode = rootNode.Nodes.Add($"Addition");
                RenderExpression(additionNode, additionExpression.Addend1);
                RenderExpression(additionNode, additionExpression.Addend2);
                break;
            case SubtractionExpression subtractionExpression:
                TreeNode subtractionNode = rootNode.Nodes.Add($"Subtraction");
                RenderExpression(subtractionNode, subtractionExpression.Minuend);
                RenderExpression(subtractionNode, subtractionExpression.Subtrahend);
                break;
            case DiceRollExpression diceRollExpression:
                TreeNode diceRollNode = rootNode.Nodes.Add($"DiceRoll");
                RenderExpression(diceRollNode, diceRollExpression.Dice);
                RenderExpression(diceRollNode, diceRollExpression.Sides);
                break;
        }
    }
}
