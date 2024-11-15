// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterSpells;

[Serializable]
internal class TeleportToMonsterSpell : MonsterSpell
{
    private TeleportToMonsterSpell(Game game) : base(game) { }
    public override bool Annoys => true;

    public override string? VsPlayerBlindMessage => "Someone commands you to return.";
    public override string? VsPlayerActionMessage => "{0} commands you to return.";

    public override void ExecuteOnPlayer(Monster monster)
    {
        Game.TeleportPlayerTo(monster.MapY, monster.MapX);
    }

    public override void ExecuteOnMonster(Monster monster, Monster target) // TODO: Not implemented, monsters do not teleport each other
    {
    }
}
