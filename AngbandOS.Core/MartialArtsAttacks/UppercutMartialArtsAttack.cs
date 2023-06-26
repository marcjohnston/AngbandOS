// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MartialArtsAttacks;

[Serializable]
internal class UppercutMartialArtsAttack : MartialArtsAttack
{
    public override int Chance => 12;
    public override int Dd => 4;
    public override string Desc => "You uppercut {0}.";
    public override int Ds => 4;
    public override int Effect => 6;
    public override int MinLevel => 13;
    private UppercutMartialArtsAttack(SaveGame saveGame) : base(saveGame) { }
}
