using AngbandOS.Core;
using AngbandOS.Enumerations;
using AngbandOS.Projection;
using AngbandOS.Spells;
using System;

namespace AngbandOS.Commands
{
    internal class CastCommand : ICommand
    {
        public char Key => 'm';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            if (saveGame.Player.HasAntiMagic)
            {
                string whichMagicType = "magic";
                if (saveGame.Player.ProfessionIndex == CharacterClass.Mindcrafter || saveGame.Player.ProfessionIndex == CharacterClass.Mystic)
                {
                    whichMagicType = "psychic talents";
                }
                else if (saveGame.Player.Spellcasting.Type == CastingType.Divine)
                {
                    whichMagicType = "prayer";
                }
                saveGame.MsgPrint($"An anti-magic shell disrupts your {whichMagicType}!");
                saveGame.EnergyUse = 5;
            }
            else
            {
                if (saveGame.Player.Spellcasting.Type == CastingType.Mentalism)
                {
                    DoCmdMentalism(saveGame);
                }
                else
                {
                    DoCmdCast(saveGame);
                }
            }
        }

        public static bool GetSpell(SaveGame saveGame, out int sn, string prompt, int sval, bool known, bool realm2, Player player)
        {
            int i;
            int spell;
            int num = 0;
            int[] spells = new int[64];
            Realm useRealm = realm2 ? player.Realm2 : player.Realm1;
            string p = player.Spellcasting.Type == CastingType.Divine ? "prayer" : "spell";
            for (spell = 0; spell < 32; spell++)
            {
                if ((GlobalData.BookSpellFlags[sval] & (1u << spell)) != 0)
                {
                    spells[num++] = spell;
                }
            }
            bool okay = false;
            sn = -2;
            for (i = 0; i < num; i++)
            {
                if (player.SpellOkay(spells[i], known, realm2))
                {
                    okay = true;
                }
            }
            if (!okay)
            {
                return false;
            }
            sn = -1;
            bool flag = false;
            bool redraw = false;
            string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) {prompt} which {p}? ";
            while (!flag && saveGame.GetCom(outVal, out char choice))
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (!redraw)
                    {
                        redraw = true;
                        saveGame.SaveScreen();
                        player.PrintSpells(spells, num, 1, 20, useRealm);
                    }
                    else
                    {
                        redraw = false;
                        saveGame.Load();
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
                spell = spells[i];
                if (!player.SpellOkay(spell, known, realm2))
                {
                    saveGame.MsgPrint($"You may not {prompt} that {p}.");
                    continue;
                }
                if (ask)
                {
                    Spell sPtr = player.Spellcasting.Spells[realm2 ? 1 : 0][spell % 32];
                    string tmpVal = $"{prompt} {sPtr.Name} ({sPtr.ManaCost} mana, {sPtr.FailureChance(player)}% fail)? ";
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
                return false;
            }
            sn = spell;
            return true;
        }

        private void DoCmdCast(SaveGame saveGame)
        {
            string prayer = saveGame.Player.Spellcasting.Type == CastingType.Divine ? "prayer" : "spell";
            if (saveGame.Player.Realm1 == 0)
            {
                saveGame.MsgPrint("You cannot cast spells!");
                return;
            }
            if (saveGame.Player.TimedBlindness != 0 || saveGame.Level.NoLight())
            {
                saveGame.MsgPrint("You cannot see!");
                return;
            }
            if (saveGame.Player.TimedConfusion != 0)
            {
                saveGame.MsgPrint("You are too confused!");
                return;
            }
            Inventory.ItemFilterUseableSpellBook = true;
            if (!saveGame.GetItem(out int item, "Use which book? ", false, true, true, null))
            {
                if (item == -2)
                {
                    saveGame.MsgPrint($"You have no {prayer} books!");
                }
                Inventory.ItemFilterUseableSpellBook = false;
                return;
            }
            Inventory.ItemFilterUseableSpellBook = false;
            Item oPtr = item >= 0 ? saveGame.Player.Inventory[item] : saveGame.Level.Items[0 - item];
            int sval = oPtr.ItemSubCategory;
            bool useSetTwo = oPtr.Category == saveGame.Player.Realm2.ToSpellBookItemCategory();
            saveGame.HandleStuff();
            if (!GetSpell(saveGame, out int spell, saveGame.Player.Spellcasting.Type == CastingType.Divine ? "recite" : "cast", sval,
                true, useSetTwo, saveGame.Player))
            {
                if (spell == -2)
                {
                    saveGame.MsgPrint($"You don't know any {prayer}s in that book.");
                }
                return;
            }
            Spell sPtr = useSetTwo ? saveGame.Player.Spellcasting.Spells[1][spell] : saveGame.Player.Spellcasting.Spells[0][spell];
            if (sPtr.ManaCost > saveGame.Player.Mana)
            {
                string cast = saveGame.Player.Spellcasting.Type == CastingType.Divine ? "recite" : "cast";
                saveGame.MsgPrint($"You do not have enough mana to {cast} this {prayer}.");
                if (!saveGame.GetCheck("Attempt it anyway? "))
                {
                    return;
                }
            }
            int chance = sPtr.FailureChance(saveGame.Player);
            if (Program.Rng.RandomLessThan(100) < chance)
            {
                saveGame.MsgPrint($"You failed to get the {prayer} off!");
                if (oPtr.Category == ItemCategory.ChaosBook && Program.Rng.DieRoll(100) < spell)
                {
                    saveGame.MsgPrint("You produce a chaotic effect!");
                    WildMagic(spell, saveGame);
                }
                else if (oPtr.Category == ItemCategory.DeathBook && Program.Rng.DieRoll(100) < spell)
                {
                    if (sval == 3 && Program.Rng.DieRoll(2) == 1)
                    {
                        saveGame.Level.Monsters[0].SanityBlast(saveGame, true);
                    }
                    else
                    {
                        saveGame.MsgPrint("It hurts!");
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(oPtr.ItemSubCategory + 1, 6), "a miscast Death spell");
                        if (spell > 15 && Program.Rng.DieRoll(6) == 1 && !saveGame.Player.HasHoldLife)
                        {
                            saveGame.Player.LoseExperience(spell * 250);
                        }
                    }
                }
            }
            else
            {
                sPtr.Cast(saveGame);
                if (!sPtr.Worked)
                {
                    int e = sPtr.FirstCastExperience;
                    sPtr.Worked = true;
                    saveGame.Player.GainExperience(e * sPtr.Level);
                }
            }
            saveGame.EnergyUse = 100;
            if (sPtr.ManaCost <= saveGame.Player.Mana)
            {
                saveGame.Player.Mana -= sPtr.ManaCost;
            }
            else
            {
                int oops = sPtr.ManaCost - saveGame.Player.Mana;
                saveGame.Player.Mana = 0;
                saveGame.Player.FractionalMana = 0;
                saveGame.MsgPrint("You faint from the effort!");
                saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.DieRoll((5 * oops) + 1));
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    bool perm = Program.Rng.RandomLessThan(100) < 25;
                    saveGame.MsgPrint("You have damaged your health!");
                    saveGame.Player.DecreaseAbilityScore(Ability.Constitution, 15 + Program.Rng.DieRoll(10), perm);
                }
            }
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
        }

        private void DoCmdMentalism(SaveGame saveGame)
        {
            int plev = saveGame.Player.Level;
            if (saveGame.Player.TimedConfusion != 0)
            {
                saveGame.MsgPrint("You are too confused!");
                return;
            }
            if (!GetMentalismTalent(saveGame, out int n, saveGame.Player))
            {
                return;
            }
            Talents.Talent talent = saveGame.Player.Spellcasting.Talents[n];
            if (talent.ManaCost > saveGame.Player.Mana)
            {
                saveGame.MsgPrint("You do not have enough mana to use this talent.");
                if (!saveGame.GetCheck("Attempt it anyway? "))
                {
                    return;
                }
            }
            int chance = talent.FailureChance(saveGame.Player);
            if (Program.Rng.RandomLessThan(100) < chance)
            {
                saveGame.MsgPrint("You failed to concentrate hard enough!");
                if (Program.Rng.DieRoll(100) < chance / 2)
                {
                    int i = Program.Rng.DieRoll(100);
                    if (i < 5)
                    {
                        saveGame.MsgPrint("Oh, no! Your mind has gone blank!");
                        saveGame.LoseAllInfo();
                    }
                    else if (i < 15)
                    {
                        saveGame.MsgPrint("Weird visions seem to dance before your eyes...");
                        saveGame.Player.SetTimedHallucinations(saveGame.Player.TimedHallucinations + 5 + Program.Rng.DieRoll(10));
                    }
                    else if (i < 45)
                    {
                        saveGame.MsgPrint("Your brain is addled!");
                        saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.DieRoll(8));
                    }
                    else if (i < 90)
                    {
                        saveGame.Player.SetTimedStun(saveGame.Player.TimedStun + Program.Rng.DieRoll(8));
                    }
                    else
                    {
                        saveGame.MsgPrint("Your mind unleashes its power in an uncontrollable storm!");
                        saveGame.Project(1, 2 + (plev / 10), saveGame.Player.MapY, saveGame.Player.MapX, plev * 2,
                            new ProjectMana(saveGame),
                            ProjectionFlag.ProjectJump | ProjectionFlag.ProjectKill | ProjectionFlag.ProjectGrid |
                            ProjectionFlag.ProjectItem);
                        saveGame.Player.Mana = Math.Max(0, saveGame.Player.Mana - (plev * Math.Max(1, plev / 10)));
                    }
                }
            }
            else
            {
                talent.Use(saveGame);
            }
            saveGame.EnergyUse = 100;
            if (talent.ManaCost <= saveGame.Player.Mana)
            {
                saveGame.Player.Mana -= talent.ManaCost;
            }
            else
            {
                int oops = talent.ManaCost - saveGame.Player.Mana;
                saveGame.Player.Mana = 0;
                saveGame.Player.FractionalMana = 0;
                saveGame.MsgPrint("You faint from the effort!");
                saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.DieRoll((5 * oops) + 1));
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    bool perm = Program.Rng.RandomLessThan(100) < 25;
                    saveGame.MsgPrint("You have damaged your mind!");
                    saveGame.Player.DecreaseAbilityScore(Ability.Wisdom, 15 + Program.Rng.DieRoll(10), perm);
                }
            }
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
        }

        private bool GetMentalismTalent(SaveGame saveGame, out int sn, Player player)
        {
            int i;
            int num = 0;
            int y = 1;
            int x = 20;
            int plev = player.Level;
            string p = "talent";
            sn = -1;
            bool flag = false;
            bool redraw = false;
            TalentList talents = player.Spellcasting.Talents;
            for (i = 0; i < talents.Count; i++)
            {
                if (talents[i].Level <= plev)
                {
                    num++;
                }
            }
            string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which {p}? ";
            while (!flag && saveGame.GetCom(outVal, out char choice))
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (!redraw)
                    {
                        redraw = true;
                        saveGame.SaveScreen();
                        saveGame.PrintLine("", y, x);
                        saveGame.Print("Name", y, x + 5);
                        saveGame.Print("Lv Mana Fail Info", y, x + 35);
                        for (i = 0; i < talents.Count; i++)
                        {
                            Talents.Talent talent = talents[i];
                            if (talent.Level > plev)
                            {
                                break;
                            }
                            string psiDesc = $"  {i.IndexToLetter()}) {talent.SummaryLine(player)}";
                            saveGame.PrintLine(psiDesc, y + i + 1, x);
                        }
                        saveGame.PrintLine("", y + i + 1, x);
                    }
                    else
                    {
                        redraw = false;
                        saveGame.Load();
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
                return false;
            }
            sn = i;
            return true;
        }

        private void WildMagic(int spell, SaveGame saveGame)
        {
            int counter = 0;
            int type = Constants.SummonBizarre1 - 1 + Program.Rng.DieRoll(6);
            if (type < Constants.SummonBizarre1)
            {
                type = Constants.SummonBizarre1;
            }
            else if (type > Constants.SummonBizarre6)
            {
                type = Constants.SummonBizarre6;
            }
            switch (Program.Rng.DieRoll(spell) + Program.Rng.DieRoll(8) + 1)
            {
                case 1:
                case 2:
                case 3:
                    saveGame.TeleportPlayer(10);
                    break;

                case 4:
                case 5:
                case 6:
                    saveGame.TeleportPlayer(100);
                    break;

                case 7:
                case 8:
                    saveGame.TeleportPlayer(200);
                    break;

                case 9:
                case 10:
                case 11:
                    saveGame.UnlightArea(10, 3);
                    break;

                case 12:
                case 13:
                case 14:
                    saveGame.LightArea(Program.Rng.DiceRoll(2, 3), 2);
                    break;

                case 15:
                    saveGame.DestroyDoorsTouch();
                    break;

                case 16:
                case 17:
                    saveGame.WallBreaker();
                    break;

                case 18:
                    saveGame.SleepMonstersTouch();
                    break;

                case 19:
                case 20:
                    saveGame.TrapCreation();
                    break;

                case 21:
                case 22:
                    saveGame.DoorCreation();
                    break;

                case 23:
                case 24:
                case 25:
                    saveGame.AggravateMonsters(1);
                    break;

                case 26:
                    saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 5);
                    break;

                case 27:
                case 28:
                    saveGame.Player.Dna.GainMutation(saveGame);
                    break;

                case 29:
                case 30:
                    saveGame.ApplyDisenchant();
                    break;

                case 31:
                    saveGame.LoseAllInfo();
                    break;

                case 32:
                    saveGame.FireBall(new ProjectChaos(saveGame), 0, spell + 5, 1 + (spell / 10));
                    break;

                case 33:
                    saveGame.WallStone();
                    break;

                case 34:
                case 35:
                    while (counter++ < 8)
                    {
                        saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty * 3 / 2,
                            type);
                    }
                    break;

                case 36:
                case 37:
                    saveGame.ActivateHiSummon();
                    break;

                case 38:
                    saveGame.SummonReaver();
                    break;

                default:
                    saveGame.ActivateDreadCurse();
                    break;
            }
        }
    }
}
