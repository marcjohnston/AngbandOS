using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Use a mutant or racial power
    /// </summary>
    [Serializable]
    internal class MutantPowerCommand : ICommand
    {
        public char Key => 'p';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int i = 0;
            int num;
            int[] powers = new int[36];
            string[] powerDesc = new string[36];
            //int lvl = saveGame.Player.Level;
            int pets = 0;
            int petCtr;
            bool allPets = false;
            Monster monster;
            bool hasRacial = saveGame.Player.Race.HasRacialPowers;
            string racialPowersDescription = saveGame.Player.Race.RacialPowersDescription(saveGame.Player.Level);
            for (num = 0; num < 36; num++)
            {
                powers[num] = 0;
                powerDesc[num] = "";
            }
            num = 0;
            if (saveGame.Player.TimedConfusion != 0)
            {
                saveGame.MsgPrint("You are too confused to use any powers!");
                saveGame.EnergyUse = 0;
                return;
            }
            for (petCtr = saveGame.Level.MMax - 1; petCtr >= 1; petCtr--)
            {
                monster = saveGame.Level.Monsters[petCtr];
                if (monster.SmFriendly)
                {
                    pets++;
                }
            }
            List<Mutations.Mutation> activeMutations = saveGame.Player.Dna.ActivatableMutations(saveGame.Player);
            if (!hasRacial && activeMutations.Count == 0 && pets == 0)
            {
                saveGame.MsgPrint("You have no powers to activate.");
                saveGame.EnergyUse = 0;
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
                powerDesc[num] = activeMutations[j].ActivationSummary(saveGame.Player.Level);
                num++;
            }
            if (pets > 0)
            {
                powerDesc[num] = "dismiss pets";
                powers[num++] = 3;
            }
            bool flag = false;
            bool redraw = false;
            string outVal = $"(Powers {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which power? ";
            while (!flag && saveGame.GetCom(outVal, out char choice))
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (!redraw)
                    {
                        int y = 1, x = 13;
                        int ctr = 0;
                        redraw = true;
                        saveGame.SaveScreen();
                        saveGame.PrintLine("", y++, x);
                        while (ctr < num)
                        {
                            string dummy = $"{ctr.IndexToLetter()}) {powerDesc[ctr]}";
                            saveGame.PrintLine(dummy, y + ctr, x);
                            ctr++;
                        }
                        saveGame.PrintLine("", y + ctr, x);
                    }
                    else
                    {
                        redraw = false;
                        saveGame.Load();
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
                    if (!saveGame.GetCheck(tmpVal))
                    {
                        continue;
                    }
                }
                flag = true;
            }
            if (redraw)
            {
                saveGame.Load();
            }
            if (!flag)
            {
                saveGame.EnergyUse = 0;
                return;
            }
            if (powers[i] == int.MaxValue)
            {
                saveGame.UseRacialPower();
            }
            else if (powers[i] == 3)
            {
                int dismissed = 0;
                if (saveGame.GetCheck("Dismiss all pets? "))
                {
                    allPets = true;
                }
                for (petCtr = saveGame.Level.MMax - 1; petCtr >= 1; petCtr--)
                {
                    monster = saveGame.Level.Monsters[petCtr];
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
                            if (saveGame.GetCheck(checkFriend))
                            {
                                deleteThis = true;
                            }
                        }
                        if (deleteThis)
                        {
                            saveGame.Level.Monsters.DeleteMonsterByIndex(petCtr, true);
                            dismissed++;
                        }
                    }
                }
                string s = dismissed == 1 ? "" : "s";
                saveGame.MsgPrint($"You have dismissed {dismissed} pet{s}.");
            }
            else
            {
                saveGame.EnergyUse = 100;
                activeMutations[powers[i] - 100].Activate(saveGame, saveGame.Player, saveGame.Level);
            }
        }
    }
}
