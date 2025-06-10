// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ReportMagicsScript : Script, IScript, ICastSpellScript
{
    private ReportMagicsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

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
        if (Game.BlindnessTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.BlindnessTimer.Value);
            info[i++] = "You cannot see";
        }
        if (Game.ConfusedTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.ConfusedTimer.Value);
            info[i++] = "You are confused";
        }
        if (Game.FearTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.FearTimer.Value);
            info[i++] = "You are terrified";
        }
        if (Game.PoisonTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.PoisonTimer.Value);
            info[i++] = "You are poisoned";
        }
        if (Game.HallucinationsTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.HallucinationsTimer.Value);
            info[i++] = "You are hallucinating";
        }
        if (Game.BlessingTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.BlessingTimer.Value);
            info[i++] = "You feel rightous";
        }
        if (Game.HeroismTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.HeroismTimer.Value);
            info[i++] = "You feel heroic";
        }
        if (Game.SuperheroismTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.SuperheroismTimer.Value);
            info[i++] = "You are in a battle rage";
        }
        if (Game.ProtectionFromEvilTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.ProtectionFromEvilTimer.Value);
            info[i++] = "You are protected from evil";
        }
        if (Game.StoneskinTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.StoneskinTimer.Value);
            info[i++] = "You are protected by a mystic shield";
        }
        if (Game.InvulnerabilityTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.InvulnerabilityTimer.Value);
            info[i++] = "You are invulnerable";
        }
        if (Game.EtherealnessTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.EtherealnessTimer.Value);
            info[i++] = "You are incorporeal";
        }
        if (Game.HasConfusingTouch)
        {
            info2[i] = 7;
            info[i++] = "Your hands are glowing dull red.";
        }
        if (Game.WordOfRecallDelay != 0)
        {
            info2[i] = ReportMagicsAux(Game.WordOfRecallDelay);
            info[i++] = "You waiting to be recalled";
        }
        if (Game.AcidResistanceTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.AcidResistanceTimer.Value);
            info[i++] = "You are resistant to acid";
        }
        if (Game.LightningResistanceTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.LightningResistanceTimer.Value);
            info[i++] = "You are resistant to lightning";
        }
        if (Game.FireResistanceTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.FireResistanceTimer.Value);
            info[i++] = "You are resistant to fire";
        }
        if (Game.ColdResistanceTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.ColdResistanceTimer.Value);
            info[i++] = "You are resistant to cold";
        }
        if (Game.PoisonResistanceTimer.Value != 0)
        {
            info2[i] = ReportMagicsAux(Game.PoisonResistanceTimer.Value);
            info[i++] = "You are resistant to poison";
        }
        ScreenBuffer savedScreen = Game.Screen.Clone();
        for (k = 1; k < 24; k++)
        {
            Game.Screen.PrintLine("", k, 13);
        }
        Game.Screen.PrintLine("     Your Current Magic:", 1, 15);
        for (k = 2, j = 0; j < i; j++)
        {
            string dummy = $"{info[j]} {ReportMagicDurations[info2[j]]}.";
            Game.Screen.PrintLine(dummy, k++, 15);
            if (k == 22 && j + 1 < i)
            {
                Game.Screen.PrintLine("-- more --", k, 15);
                Game.Inkey();
                for (; k > 2; k--)
                {
                    Game.Screen.PrintLine("", k, 15);
                }
            }
        }
        Game.Screen.PrintLine("[Press any key to continue]", k, 13);
        Game.Inkey();
        Game.Screen.Restore(savedScreen);
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
