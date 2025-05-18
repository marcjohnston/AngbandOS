// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TunnelScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private TunnelScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the tunnel script and disposes of the repeatable result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the stay script and returns true, if the tunnel succeeded or failed due to chance; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        bool isRepeatable = false;
        // Get the direction in which we wish to tunnel
        if (Game.GetDirectionNoAim(out int dir))
        {
            // Pick up the tile that the player wishes to tunnel through
            int tileY = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int tileX = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[tileY][tileX];
            // Check if it can be tunneled through
            if (tile.FeatureType.IsPassable || tile.FeatureType.IsYellowSignSigil)
            {
                Game.MsgPrint("You cannot tunnel through air.");
            }
            else if (tile.FeatureType.IsVisibleDoor)
            {
                Game.MsgPrint("You cannot tunnel through doors.");
            }
            // Can't tunnel if there's a monster there - so attack the monster instead
            else if (tile.MonsterIndex != 0)
            {
                Game.EnergyUse = 100;
                Game.MsgPrint("There is a monster in the way!");
                Game.PlayerAttackMonster(tileY, tileX);
            }
            else
            {
                // Tunnel through the tile
                isRepeatable = Game.TunnelThroughTile(tileY, tileX);
            }
        }
        return new RepeatableResult(isRepeatable);
    }
}
