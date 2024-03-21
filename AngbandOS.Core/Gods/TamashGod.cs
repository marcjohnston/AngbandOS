// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Gods;

[Serializable]
internal class TamashGod : God
{
    private TamashGod(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string LongName => "Tamash, god of illusion and magic";
    public override string ShortName => "Tamash";
    public override string FavorDescription => " (+{0}% max mana)";
}
