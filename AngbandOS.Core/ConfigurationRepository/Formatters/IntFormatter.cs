// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.PropertyFormatters;

[Serializable]
internal abstract class IntFormatter : Formatter
{
    protected IntFormatter(SaveGame saveGame) : base(saveGame) { }

    public abstract string Format(int value, int width);
}
