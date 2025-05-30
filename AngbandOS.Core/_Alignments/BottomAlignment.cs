﻿
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class BottomAlignment : Alignment
{
    private BottomAlignment(Game game) : base(game) { } // This object is a singleton.
    public override string[] Align(string[] lines, int minimumHeight)
    {
        List<string> alignedLines = lines.ToList();
        for (int i = 0; i < minimumHeight - lines.Length; i++)
        {
            alignedLines.Insert(0, String.Empty);
        }
        return alignedLines.ToArray();
    }
}
