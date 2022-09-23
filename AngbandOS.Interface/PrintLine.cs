namespace AngbandOS.Core.Interface;

public class PrintLine
{
    public int row { get; set; }
    public int col { get; set; }
    public string text { get; set; }
    public Colour foreColour { get; set; }
    public Colour backColour { get; set; }

    public PrintLine(int row, int col, string text, Colour foreColour, Colour backColour)
    {
        this.row = row;
        this.col = col;
        this.text = text;
        this.foreColour = foreColour;
        this.backColour = backColour;
    }
}
