// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal
{
    [Serializable]
    internal class CorporealSpellMoveBody : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.MsgPrint("You focus your Chi. Choose a destination.");
            if (!saveGame.TgtPt(out int ii, out int ij))
            {
                return;
            }
            saveGame.Player.Energy -= 60 - saveGame.Player.Level;
            if (!saveGame.Level.GridPassableNoCreature(ij, ii) || saveGame.Level.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
                saveGame.Level.Distance(ij, ii, saveGame.Player.MapY, saveGame.Player.MapX) > saveGame.Player.Level + 2 ||
                Program.Rng.RandomLessThan(saveGame.Player.Level * saveGame.Player.Level / 2) == 0)
            {
                saveGame.MsgPrint("You fail to concentrate correctly!");
                saveGame.Player.Energy -= 100;
                saveGame.TeleportPlayer(10);
            }
            else
            {
                saveGame.TeleportPlayerTo(ij, ii);
            }
        }

        public override string Name => "Move Body";
        
        protected override string Comment(Player player)
        {
            return $"range {player.Level + 2}";
        }
    }
}