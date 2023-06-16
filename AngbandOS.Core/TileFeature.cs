// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class TileFeature
{
    public Colour Attr;
    public char Char;
    public int Mimic;
    public string Name;

    public TileFeature()
    {
    }

    public TileFeature(TileFeature original)
    {
        Attr = original.Attr;
        Char = original.Char;
        Mimic = original.Mimic;
        Name = original.Name;
    }
}