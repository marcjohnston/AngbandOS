// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MartialArtsAttacks;

[Serializable]
internal class SideKickMartialArtsAttack : MartialArtsAttack
{
    public override int Chance => 10;
    public override int Dd => 3;
    public override string Desc => "You kick {0}.";
    public override int Ds => 4;
    public override int Effect => Constants.MaSlow;
    public override int MinLevel => 11;
    private SideKickMartialArtsAttack(SaveGame saveGame) : base(saveGame) { }
}
