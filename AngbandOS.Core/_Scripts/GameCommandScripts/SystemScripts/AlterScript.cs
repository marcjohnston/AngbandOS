// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class AlterScript : GameCommandUniversalScript, IGetKey
{
    private AlterScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Gets a direction from the player and alters the tile in that direction.  Returns false, if the action fails due to chance.
    /// </summary>
    /// <returns></returns>
    public override RepeatableResultEnum ExecuteGameCommandScript()
    {
        // Assume we won't disturb the player
        bool isRepeatable = false;

        // Get the direction in which to alter something
        if (Game.GetDirectionNoAim(out int dir))
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile tile = Game.Map.Grid[y][x];
            // Altering a tile will take a turn
            Game.EnergyUse = 100;
            // We 'alter' a tile by attacking it
            if (tile.MonsterIndex != 0)
            {
                Game.PlayerAttackMonster(y, x);
            }
            else
            {
                // Check the action based on the type of tile
                AlterAction? alterAction = tile.FeatureType.AlterAction;
                if (alterAction == null)
                {
                    Game.MsgPrint("You're not sure what you can do with that...");
                }
                else
                {                   
                    isRepeatable = alterAction.Execute(x, y);
                }
            }
        }
        return isRepeatable ? RepeatableResultEnum.True : RepeatableResultEnum.False;
    }
}
