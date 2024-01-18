// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WalkAndPickupScript : Script
{
    private WalkAndPickupScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        bool more = false;
        // If we don't already have a direction, get one
        if (SaveGame.GetDirectionNoAim(out int dir))
        {
            // Walking takes a full turn
            SaveGame.EnergyUse = 100;
            SaveGame.MovePlayer(dir, false);
            more = true;
        }
        return more;
    }
}
