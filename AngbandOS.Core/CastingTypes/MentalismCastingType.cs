// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CastingTypes;

[Serializable]
internal class MentalismCastingType : CastingType
{
    private MentalismCastingType(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        int plev = SaveGame.ExperienceLevel;
        if (SaveGame.TimedConfusion.TurnsRemaining != 0)
        {
            SaveGame.MsgPrint("You are too confused!");
            return;
        }
        if (!GetMentalismTalent(out int n))
        {
            return;
        }
        Talents.Talent talent = SaveGame.Talents[n];
        if (talent.ManaCost > SaveGame.Mana)
        {
            SaveGame.MsgPrint("You do not have enough mana to use this talent.");
            if (!SaveGame.GetCheck("Attempt it anyway? "))
            {
                return;
            }
        }
        int chance = talent.FailureChance();
        if (Program.Rng.RandomLessThan(100) < chance)
        {
            SaveGame.MsgPrint("You failed to concentrate hard enough!");
            if (Program.Rng.DieRoll(100) < chance / 2)
            {
                int i = Program.Rng.DieRoll(100);
                if (i < 5)
                {
                    SaveGame.MsgPrint("Oh, no! Your mind has gone blank!");
                    SaveGame.LoseAllInfo();
                }
                else if (i < 15)
                {
                    SaveGame.MsgPrint("Weird visions seem to dance before your eyes...");
                    SaveGame.TimedHallucinations.AddTimer(5 + Program.Rng.DieRoll(10));
                }
                else if (i < 45)
                {
                    SaveGame.MsgPrint("Your brain is addled!");
                    SaveGame.TimedConfusion.AddTimer(Program.Rng.DieRoll(8));
                }
                else if (i < 90)
                {
                    SaveGame.TimedStun.AddTimer(Program.Rng.DieRoll(8));
                }
                else
                {
                    SaveGame.MsgPrint("Your mind unleashes its power in an uncontrollable storm!");
                    SaveGame.Project(1, 2 + (plev / 10), SaveGame.MapY, SaveGame.MapX, plev * 2, SaveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectKill | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem);
                    SaveGame.Mana = Math.Max(0, SaveGame.Mana - (plev * Math.Max(1, plev / 10)));
                }
            }
        }
        else
        {
            talent.Use();
        }
        SaveGame.EnergyUse = 100;
        if (talent.ManaCost <= SaveGame.Mana)
        {
            SaveGame.Mana -= talent.ManaCost;
        }
        else
        {
            int oops = talent.ManaCost - SaveGame.Mana;
            SaveGame.Mana = 0;
            SaveGame.FractionalMana = 0;
            SaveGame.MsgPrint("You faint from the effort!");
            SaveGame.TimedParalysis.AddTimer(Program.Rng.DieRoll((5 * oops) + 1));
            if (Program.Rng.RandomLessThan(100) < 50)
            {
                bool perm = Program.Rng.RandomLessThan(100) < 25;
                SaveGame.MsgPrint("You have damaged your mind!");
                SaveGame.DecreaseAbilityScore(Ability.Wisdom, 15 + Program.Rng.DieRoll(10), perm);
            }
        }
        SaveGame.RedrawManaFlaggedAction.Set();
    }

    private bool GetMentalismTalent(out int sn)
    {
        int i;
        int num = 0;
        int y = 1;
        int x = 20;
        int plev = SaveGame.ExperienceLevel;
        string p = "talent";
        sn = -1;
        bool flag = false;
        ScreenBuffer? savedScreen = null;
        List<Talent> talents = SaveGame.Talents;
        for (i = 0; i < talents.Count; i++)
        {
            if (talents[i].Level <= plev)
            {
                num++;
            }
        }
        string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which {p}? ";
        while (!flag && SaveGame.GetCom(outVal, out char choice))
        {
            if (choice == ' ' || choice == '*' || choice == '?')
            {
                if (savedScreen == null)
                {
                    savedScreen = SaveGame.Screen.Clone();
                    SaveGame.Screen.PrintLine("", y, x);
                    SaveGame.Screen.Print("Name", y, x + 5);
                    SaveGame.Screen.Print("Lv Mana Fail Info", y, x + 35);
                    for (i = 0; i < talents.Count; i++)
                    {
                        Talents.Talent talent = talents[i];
                        if (talent.Level > plev)
                        {
                            break;
                        }
                        string psiDesc = $"  {i.IndexToLetter()}) {talent.SummaryLine()}";
                        SaveGame.Screen.PrintLine(psiDesc, y + i + 1, x);
                    }
                    SaveGame.Screen.PrintLine("", y + i + 1, x);
                }
                else
                {
                    SaveGame.Screen.Restore(savedScreen);
                    savedScreen = null;
                }
                continue;
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
                string tmpVal = $"Use {talents[i].Name}? ";
                if (!SaveGame.GetCheck(tmpVal))
                {
                    continue;
                }
            }
            flag = true;
        }
        if (savedScreen != null)
        {
            SaveGame.Screen.Restore(savedScreen);
        }
        if (!flag)
        {
            return false;
        }
        sn = i;
        return true;
    }
}