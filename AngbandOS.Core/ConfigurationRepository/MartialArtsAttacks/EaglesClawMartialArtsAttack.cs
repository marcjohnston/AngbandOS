﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MartialArtsAttacks;

[Serializable]
internal class EaglesClawMartialArtsAttack : MartialArtsAttack
{
    public override int Chance => 25;
    public override int Dd => 6;
    public override string Desc => "You hit {0} with an Eagle's Claw.";
    public override int Ds => 6;
    public override int Effect => 0;
    public override int MinLevel => 29;
    private EaglesClawMartialArtsAttack(SaveGame saveGame) : base(saveGame) { }
}