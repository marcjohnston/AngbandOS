﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MartialArtsAttacks;

[Serializable]
internal class StrikeMartialArtsAttack : MartialArtsAttack
{
    public override int Chance => 0;
    public override int Dd => 1;
    public override string Desc => "You strike {0}.";
    public override int Ds => 7;
    public override int Effect => 0;
    public override int MinLevel => 3;
    private StrikeMartialArtsAttack(Game game) : base(game) { }
}
