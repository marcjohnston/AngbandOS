// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MutantPowerScript : Script, IScript, IRepeatableScript
{
    private MutantPowerScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the mutant power script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the mutant power script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int i = 0;
        int num;
        int[] powers = new int[36];
        string[] powerDesc = new string[36];
        int pets = 0;
        int petCtr;
        bool allPets = false;
        Monster monster;
        bool hasRacial = Game.Race.HasRacialPowers;
        string racialPowersDescription = Game.Race.RacialPowersDescription(Game.ExperienceLevel.Value);
        for (num = 0; num < 36; num++)
        {
            powers[num] = 0;
            powerDesc[num] = "";
        }
        num = 0;
        if (Game.ConfusedTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused to use any powers!");
            Game.EnergyUse = 0;
            return;
        }
        for (petCtr = Game.MMax - 1; petCtr >= 1; petCtr--)
        {
            monster = Game.Monsters[petCtr];
            if (monster.SmFriendly)
            {
                pets++;
            }
        }
        List<Mutation> activeMutations = Game.ActivatableMutations();
        if (!hasRacial && activeMutations.Count == 0 && pets == 0)
        {
            Game.MsgPrint("You have no powers to activate.");
            Game.EnergyUse = 0;
            return;
        }
        if (hasRacial)
        {
            powers[0] = int.MaxValue;
            powerDesc[0] = racialPowersDescription;
            num++;
        }
        for (int j = 0; j < activeMutations.Count; j++)
        {
            powers[num] = j + 100;
            powerDesc[num] = activeMutations[j].ActivationSummary(Game.ExperienceLevel.Value);
            num++;
        }
        if (pets > 0)
        {
            powerDesc[num] = "dismiss pets";
            powers[num++] = 3;
        }
        bool flag = false;
        ScreenBuffer? savedScreen = null;
        string outVal = $"(Powers {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which power? ";
        while (!flag && Game.GetCom(outVal, out char choice))
        {
            if (choice == ' ' || choice == '*' || choice == '?')
            {
                if (savedScreen == null)
                {
                    int y = 1, x = 13;
                    int ctr = 0;
                    savedScreen = Game.Screen.Clone();
                    Game.Screen.PrintLine("", y++, x);
                    while (ctr < num)
                    {
                        string dummy = $"{ctr.IndexToLetter()}) {powerDesc[ctr]}";
                        Game.Screen.PrintLine(dummy, y + ctr, x);
                        ctr++;
                    }
                    Game.Screen.PrintLine("", y + ctr, x);
                }
                else
                {
                    Game.Screen.Restore(savedScreen);
                    savedScreen = null;
                }
                continue;
            }
            if (choice == '\r' && num == 1)
            {
                choice = 'a';
            }
            bool ask = char.IsUpper(choice);
            if (ask)
            {
                choice = char.ToLower(choice);
            }
            i = char.IsLower(choice) ? choice.LetterToNumber() : -1;
            if (i < 0 || i >= num)
            {
                continue;
            }
            if (ask)
            {
                string tmpVal = $"Use {powerDesc[i]}? ";
                if (!Game.GetCheck(tmpVal))
                {
                    continue;
                }
            }
            flag = true;
        }
        if (savedScreen != null)
        {
            Game.Screen.Restore(savedScreen);
        }
        if (!flag)
        {
            Game.EnergyUse = 0;
            return;
        }
        if (powers[i] == int.MaxValue)
        {
            UseRacialPower();
        }
        else if (powers[i] == 3)
        {
            int dismissed = 0;
            if (Game.GetCheck("Dismiss all pets? "))
            {
                allPets = true;
            }
            for (petCtr = Game.MMax - 1; petCtr >= 1; petCtr--)
            {
                monster = Game.Monsters[petCtr];
                if (monster.SmFriendly)
                {
                    bool deleteThis = false;
                    if (allPets)
                    {
                        deleteThis = true;
                    }
                    else
                    {
                        string friendName = monster.VisibleName;
                        string checkFriend = $"Dismiss {friendName}? ";
                        if (Game.GetCheck(checkFriend))
                        {
                            deleteThis = true;
                        }
                    }
                    if (deleteThis)
                    {
                        Game.DeleteMonsterByIndex(petCtr, true);
                        dismissed++;
                    }
                }
            }
            string s = dismissed == 1 ? "" : "s";
            Game.MsgPrint($"You have dismissed {dismissed} pet{s}.");
        }
        else
        {
            Game.EnergyUse = 100;
            activeMutations[powers[i] - 100].Activate();
        }
    }

    /// <summary>
    /// Use the player's racial power, if they have one
    /// </summary>
    public void UseRacialPower()
    {
        // Check the player's race to see what their power is
        Game.Race.UseRacialPower();
    }
}
