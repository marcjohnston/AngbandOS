﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnterWizardModeScript : Script
{
    private EnterWizardModeScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        SaveGame.Screen.PrintLine("Enter Wizard Code: ", 0, 0);
        if (!SaveGame.AskforAux(out string tmp, "", 31))
        {
            SaveGame.Screen.Erase(0, 0);
            return false;
        }
        SaveGame.Screen.Erase(0, 0);
        if (tmp == "Dumbledore")
        {
            SaveGame.IsWizard = true;
            SaveGame.MsgPrint("Wizard mode activated.");
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawTitleFlaggedAction>().Set();
        }
        return false;
    }
}