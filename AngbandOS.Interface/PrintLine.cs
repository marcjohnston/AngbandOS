namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents a line of text to be rendered onto the console.
/// </summary>
public class PrintLine
{
    /// <summary>
    /// The 0-based row in which the line should be rendered.  
    /// </summary>
    public int row { get; set; }

    /// <summary>
    /// The 0-based column in which the line should start at.
    /// </summary>
    public int col { get; set; }

    /// <summary>
    /// The text to render.
    /// </summary>
    public string text { get; set; }

    /// <summary>
    /// The foreground color to render the text.
    /// </summary>
    public ColorEnum foreColor { get; set; }

    /// <summary>
    /// The background color to render the text.
    /// </summary>
    public ColorEnum backColor { get; set; }

    public PrintLine(int row, int col, string text, ColorEnum foreColor, ColorEnum backColor)
    {
        this.row = row;
        this.col = col;
        this.text = text;
        this.foreColor = foreColor;
        this.backColor = backColor;
    }
}
