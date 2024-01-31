// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MoveBodyScript : Script, IScript
{
    private MoveBodyScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Teleports the player to a chosen destination.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.MsgPrint("You focus your Chi. Choose a destination.");
        if (!SaveGame.TgtPt(out int ii, out int ij))
        {
            return;
        }
        SaveGame.Energy -= 60 - SaveGame.ExperienceLevel;
        if (!SaveGame.GridPassableNoCreature(ij, ii) || SaveGame.Grid[ij][ii].TileFlags.IsSet(GridTile.InVault) ||
            SaveGame.Distance(ij, ii, SaveGame.MapY, SaveGame.MapX) > SaveGame.ExperienceLevel + 2 ||
            SaveGame.Rng.RandomLessThan(SaveGame.ExperienceLevel * SaveGame.ExperienceLevel / 2) == 0)
        {
            SaveGame.MsgPrint("You fail to concentrate correctly!");
            SaveGame.Energy -= 100;
            SaveGame.RunScriptInt(nameof(TeleportSelfScript), 10);
        }
        else
        {
            SaveGame.TeleportPlayerTo(ij, ii);
        }
    }
}
