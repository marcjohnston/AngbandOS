// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpikedPitScript : Script, IScript
{
    private SpikedPitScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // A pit can be flown over with feather fall
        if (SaveGame.HasFeatherFall)
        {
            SaveGame.MsgPrint("You fly over a spiked pit.");
        }
        else
        {
            SaveGame.MsgPrint("You fall into a spiked pit!");
            string name = "a pit trap";
            // A pit does 2d6 fall damage
            int damage = SaveGame.DiceRoll(2, 6);
            // 50% chance of doing double damage plus bleeding
            if (SaveGame.RandomLessThan(100) < 50)
            {
                SaveGame.MsgPrint("You are impaled!");
                name = "a spiked pit";
                damage *= 2;
                SaveGame.TimedBleeding.AddTimer(SaveGame.DieRoll(damage));
            }
            SaveGame.TakeHit(damage, name);
        }
    }
}
