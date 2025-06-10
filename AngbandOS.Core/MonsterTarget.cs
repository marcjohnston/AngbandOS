// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class MonsterTarget : Target
{
    private readonly Game Game;
    private readonly Monster _monster;
    public override GridCoordinate? GetTargetLocation()
    {
        // Ensure we can still target the monster.
        if (!Game.TargetAble(_monster))
        {
            return null;
        }

        // Return the coordinates for the monster.
        return new GridCoordinate(_monster.MapX, _monster.MapY);
    }

    public override Monster? TargetedMonster => _monster;


    public override string SelectionMessage => "Target Selected.";

    public MonsterTarget(Game game, Monster monster)
    {
        Game = game;
        _monster = monster;
    }
}
