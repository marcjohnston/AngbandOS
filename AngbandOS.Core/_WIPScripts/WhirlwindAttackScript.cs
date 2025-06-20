// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WhirlwindAttackScript : Script, IScript, ICastSpellScript
{
    private WhirlwindAttackScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int dir = 0; dir <= 9; dir++)
        {
            int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
            int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
            GridTile cPtr = Game.Map.Grid[y][x];
            Monster mPtr = Game.Monsters[cPtr.MonsterIndex];
            if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || Game.GridPassable(y, x)))
            {
                Game.PlayerAttackMonster(y, x);
            }
        }
    }
    public string LearnedDetails => "";
}
