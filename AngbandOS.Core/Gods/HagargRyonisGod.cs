﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Gods;

[Serializable]
internal class HagargRyonisGod : God
{
    private HagargRyonisGod(Game game) : base(game) { } // This object is a singleton.
    public override string LongName => "Hagarg Ryonis, goddess of beasts";
    public override string ShortName => "Hagarg Ryonis";
    public override string FavorDescription => " ({0}% chance to avoid poison/life drain)";
}
