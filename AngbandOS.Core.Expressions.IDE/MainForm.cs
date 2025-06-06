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
        statusLabel.Text = "";
        computeLabel.Text = "";
        ExpressionParser parser = new ExpressionParser(new TestParseLanguage(Int32.Parse(experienceValueTextBox.Text)));
        try
        {
            Expression expression = parser.ParseExpression(textBox1.Text);
            TreeNode rootNode = treeView1.Nodes.Add("Expression");
            rootNode.Tag = expression;
            statusLabel.Text = expression.ToString();
            RenderExpression(rootNode, expression);
        }
        catch (Exception ex)
        {
            statusLabel.Text = ex.Message;
        }
    }

    private void RenderExpression(TreeNode rootNode, Expression expression)
    {
        TreeNode newNode;
        switch (expression)
        {
            case IntegerExpression integerExpression:
                newNode = rootNode.Nodes.Add($"Integer {integerExpression.Value}");
                break;
            case IdentifierExpression identifierExpression:
                newNode = rootNode.Nodes.Add($"Identifier {identifierExpression.Identifier}");
                break;
            case MultiplicationInfixExpression multiplicationExpression:
                newNode = rootNode.Nodes.Add($"Multiply");
                RenderExpression(newNode, multiplicationExpression.Factor1);
                RenderExpression(newNode, multiplicationExpression.Factor2);
                break;
            case DivisionInfixExpression divisionExpression:
                newNode = rootNode.Nodes.Add($"Division");
                RenderExpression(newNode, divisionExpression.Dividend);
                RenderExpression(newNode, divisionExpression.Divisor);
                break;
            case AdditionInfixExpression additionExpression:
                newNode = rootNode.Nodes.Add($"Addition");
                RenderExpression(newNode, additionExpression.Addend1);
                RenderExpression(newNode, additionExpression.Addend2);
                break;
            case SubtractionInfixExpression subtractionExpression:
                newNode = rootNode.Nodes.Add($"Subtraction");
                RenderExpression(newNode, subtractionExpression.Minuend);
                RenderExpression(newNode, subtractionExpression.Subtrahend);
                break;
            case ParenthesisExpression parenthesisExpression:
                string sign = !parenthesisExpression.Sign.HasValue ? "" : parenthesisExpression.Sign.Value ? " + " : " - ";
                newNode = rootNode.Nodes.Add($"Parenthesis {sign}");
                RenderExpression(newNode, parenthesisExpression.Expression);
                break;
            case DiceRollExpression diceRollExpression:
                newNode = rootNode.Nodes.Add($"DiceRoll");
                RenderExpression(newNode, diceRollExpression.Dice);
                RenderExpression(newNode, diceRollExpression.Sides);
                break;
            default:
                throw new Exception($"No treeview support for {expression.GetType().Name}.");
        }
        newNode.Tag = expression;
    }

    private void computeButton_Click(object sender, EventArgs e)
    {
        TreeNode node = treeView1.SelectedNode;
        if (node == null)
        {
            node = treeView1.Nodes[0];
        }
        Expression expression = (Expression)node.Tag;
        Expression result = expression.Compute();
        switch (result)
        {
            case IntegerExpression integerExpression:
                computeLabel.Text = $"{integerExpression.Value}";
                break;
            case DecimalExpression decimalExpression:
                computeLabel.Text = $"{decimalExpression.Value}";
                break;
            default:
                MessageBox.Show("Unsupported return data type");
                break;
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
