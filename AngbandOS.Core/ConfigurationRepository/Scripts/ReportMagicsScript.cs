// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ReportMagicsScript : Script, IScript
{
    private ReportMagicsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        string[] ReportMagicDurations =
        {
            "for a short time", "for a little while", "for a while", "for a long while", "for a long time",
            "for a very long time", "for an incredibly long time", "until you hit a monster"
        };

        int i = 0, j, k;
        string[] info = new string[128];
        int[] info2 = new int[128];
        if (SaveGame.TimedBlindness.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedBlindness.TurnsRemaining);
            info[i++] = "You cannot see";
        }
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedConfusion.TurnsRemaining);
            info[i++] = "You are confused";
        }
        if (SaveGame.TimedFear.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedFear.TurnsRemaining);
            info[i++] = "You are terrified";
        }
        if (SaveGame.TimedPoison.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedPoison.TurnsRemaining);
            info[i++] = "You are poisoned";
        }
        if (SaveGame.TimedHallucinations.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedHallucinations.TurnsRemaining);
            info[i++] = "You are hallucinating";
        }
        if (SaveGame.TimedBlessing.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedBlessing.TurnsRemaining);
            info[i++] = "You feel rightous";
        }
        if (SaveGame.TimedHeroism.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedHeroism.TurnsRemaining);
            info[i++] = "You feel heroic";
        }
        if (SaveGame.TimedSuperheroism.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedSuperheroism.TurnsRemaining);
            info[i++] = "You are in a battle rage";
        }
        if (SaveGame.TimedProtectionFromEvil.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedProtectionFromEvil.TurnsRemaining);
            info[i++] = "You are protected from evil";
        }
        if (SaveGame.TimedStoneskin.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedStoneskin.TurnsRemaining);
            info[i++] = "You are protected by a mystic shield";
        }
        if (SaveGame.TimedInvulnerability.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedInvulnerability.TurnsRemaining);
            info[i++] = "You are invulnerable";
        }
        if (SaveGame.TimedEtherealness.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedEtherealness.TurnsRemaining);
            info[i++] = "You are incorporeal";
        }
        if (SaveGame.HasConfusingTouch)
        {
            info2[i] = 7;
            info[i++] = "Your hands are glowing dull red.";
        }
        if (SaveGame.WordOfRecallDelay != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.WordOfRecallDelay);
            info[i++] = "You waiting to be recalled";
        }
        if (SaveGame.TimedAcidResistance.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedAcidResistance.TurnsRemaining);
            info[i++] = "You are resistant to acid";
        }
        if (SaveGame.TimedLightningResistance.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedLightningResistance.TurnsRemaining);
            info[i++] = "You are resistant to lightning";
        }
        if (SaveGame.TimedFireResistance.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedFireResistance.TurnsRemaining);
            info[i++] = "You are resistant to fire";
        }
        if (SaveGame.TimedColdResistance.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedColdResistance.TurnsRemaining);
            info[i++] = "You are resistant to cold";
        }
        if (SaveGame.TimedPoisonResistance.TurnsRemaining != 0)
        {
            info2[i] = ReportMagicsAux(SaveGame.TimedPoisonResistance.TurnsRemaining);
            info[i++] = "You are resistant to poison";
        }
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        for (k = 1; k < 24; k++)
        {
            SaveGame.Screen.PrintLine("", k, 13);
        }
        SaveGame.Screen.PrintLine("     Your Current Magic:", 1, 15);
        for (k = 2, j = 0; j < i; j++)
        {
            string dummy = $"{info[j]} {ReportMagicDurations[info2[j]]}.";
            SaveGame.Screen.PrintLine(dummy, k++, 15);
            if (k == 22 && j + 1 < i)
            {
                SaveGame.Screen.PrintLine("-- more --", k, 15);
                SaveGame.Inkey();
                for (; k > 2; k--)
                {
                    SaveGame.Screen.PrintLine("", k, 15);
                }
            }
        }
        SaveGame.Screen.PrintLine("[Press any key to continue]", k, 13);
        SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);
    }

    private int ReportMagicsAux(int dur)
    {
        if (dur <= 5)
        {
            return 0;
        }
        if (dur <= 10)
        {
            return 1;
        }
        if (dur <= 20)
        {
            return 2;
        }
        if (dur <= 50)
        {
            return 3;
        }
        if (dur <= 100)
        {
            return 4;
        }
        if (dur <= 200)
        {
            return 5;
        }
        return 6;
    }

}
