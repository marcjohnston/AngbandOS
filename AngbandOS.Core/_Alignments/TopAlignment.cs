// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Alignments;

[Serializable]
internal class TopAlignment : Alignment
{
    private TopAlignment(Game game) : base(game) { } // This object is a singleton.
    public override string[] Align(string[] lines, int minimumHeight)
    {
        List<string> alignedLines = lines.ToList();
        for (int i = 0; i < minimumHeight - alignedLines.Count; i++)
        {
            alignedLines.Add(String.Empty);
        }
        return alignedLines.ToArray();
    }
}