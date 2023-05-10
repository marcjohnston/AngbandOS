// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature
{
    [Serializable]
    internal class NatureSpellWhirlwindAttack : Spell
    {
        private NatureSpellWhirlwindAttack(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            for (int dir = 0; dir <= 9; dir++)
            {
                int y = SaveGame.Player.MapY + SaveGame.Level.KeypadDirectionYOffset[dir];
                int x = SaveGame.Player.MapX + SaveGame.Level.KeypadDirectionXOffset[dir];
                GridTile cPtr = SaveGame.Level.Grid[y][x];
                Monster mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                if (cPtr.MonsterIndex != 0 && (mPtr.IsVisible || SaveGame.Level.GridPassable(y, x)))
                {
                    SaveGame.PlayerAttackMonster(y, x);
                }
            }
        }

        public override string Name => "Whirlwind Attack";
        
    }
}