// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.Pantheon;
using AngbandOS.Spells;

namespace AngbandOS
{
    internal class PlayerFactory
    {
        /// <summary>
        /// Beginnings for 'angelic' names used by imps
        /// </summary>
        private static readonly string[] _angelSyllable1 =
            {"Sa", "A", "U", "Mi", "Ra", "Ana", "Pa", "Lu", "She", "Ga", "Da", "O", "Pe", "Lau", "Za", "Ze", "E"};

        /// <summary>
        /// Middles for 'angelic' names used by imps
        /// </summary>
        private static readonly string[] _angelSyllable2 =
            {"br", "m", "l", "z", "zr", "mm", "mr", "r", "ral", "ch", "zaz", "tr", "n", "lar"};

        /// <summary>
        /// Endings for 'angelic' names used by imps
        /// </summary>
        private static readonly string[] _angelSyllable3 = { "iel", "ial", "ael", "ubim", "aphon", "iel", "ael" };

        /// <summary>
        /// Beginnings of 'Cthulhoid' names used by mind flayers, miri nigri, and tcho tchos
        /// </summary>
        private static readonly string[] _cthuloidSyllable1 =
            {"Cth", "Az", "Fth", "Ts", "Xo", "Q'N", "R'L", "Ghata", "L", "Zz", "Fl", "Cl", "S", "Y"};

        /// <summary>
        /// Middles of 'Cthulhoid' names used by mind flayers, miri nigri, and tcho tchos
        /// </summary>
        private static readonly string[] _cthuloidSyllable2 =
            {"nar", "loi", "ul", "lu", "noth", "thon", "ath", "'N", "rhy", "oth", "aza", "agn", "oa", "og"};

        /// <summary>
        /// Endings of 'Cthulhoid' names used by mind flayers, miri nigri, and tcho tchos
        /// </summary>
        private static readonly string[] _cthuloidSyllable3 =
            {"l", "a", "u", "oa", "oggua", "oth", "ath", "aggua", "lu", "lo", "loth", "lotha", "agn", "axl"};

        /// <summary>
        /// Beginnings of 'Dwarven' names used by dwarves, cyclopes, half giants, golems, and nibelungen
        /// </summary>
        private static readonly string[] _dwarfSyllable1 =
            {"B", "D", "F", "G", "Gl", "H", "K", "L", "M", "N", "R", "S", "T", "Th", "V"};

        /// <summary>
        /// Middles of 'Dwarven' names used by dwarves, cyclopes, half giants, golems, and nibelungen
        /// </summary>
        private static readonly string[] _dwarfSyllable2 = { "a", "e", "i", "o", "oi", "u" };

        /// <summary>
        /// Endings of 'Dwarven' names used by dwarves, cyclopes, half giants, golems, and nibelungen
        /// </summary>
        private static readonly string[] _dwarfSyllable3 =
        {
            "bur", "fur", "gan", "gnus", "gnar", "li", "lin", "lir", "mli", "nar", "nus", "rin", "ran", "sin", "sil",
            "sur"
        };

        /// <summary>
        /// Beginnings of 'Elvish' names used by elves, dark elves, high elves, half-elves, and sprites
        /// </summary>
        private static readonly string[] _elfSyllable1 =
        {
            "Al", "An", "Bal", "Bel", "Cal", "Cel", "El", "Elr", "Elv", "Eow", "Ear", "F", "Fal", "Fel", "Fin", "G",
            "Gal", "Gel", "Gl", "Is", "Lan", "Leg", "Lom", "N", "Nal", "Nel", "S", "Sal", "Sel", "T", "Tal", "Tel",
            "Thr", "Tin"
        };

        /// <summary>
        /// Middles of 'Elvish' names used by elves, dark elves, high elves, half-elves, and sprites
        /// </summary>
        private static readonly string[] _elfSyllable2 =
        {
            "a", "adrie", "ara", "e", "ebri", "ele", "ere", "i", "io", "ithra", "ilma", "il-Ga", "ili", "o", "orfi",
            "u", "y"
        };

        /// <summary>
        /// Endings of 'Elvish' names used by elves, dark elves, high elves, half-elves, and sprites
        /// </summary>
        private static readonly string[] _elfSyllable3 =
        {
            "l", "las", "lad", "ldor", "ldur", "linde", "lith", "mir", "n", "nd", "ndel", "ndil", "ndir", "nduil", "ng",
            "mbor", "r", "rith", "ril", "riand", "rion", "s", "thien", "viel", "wen", "wyn"
        };

        /// <summary>
        /// Beginnings of 'Gnomish' names used by gnomes and draconians
        /// </summary>
        private static readonly string[] _gnomeSyllable1 =
        {
            "Aar", "An", "Ar", "As", "C", "H", "Han", "Har", "Hel", "Iir", "J", "Jan", "Jar", "K", "L", "M", "Mar", "N",
            "Nik", "Os", "Ol", "P", "R", "S", "Sam", "San", "T", "Ter", "Tom", "Ul", "V", "W", "Y"
        };

        /// <summary>
        /// Middles of 'Gnomish' names used by gnomes and draconians
        /// </summary>
        private static readonly string[] _gnomeSyllable2 = { "a", "aa", "ai", "e", "ei", "i", "o", "uo", "u", "uu" };

        /// <summary>
        /// Endings of 'Gnomish' names used by gnomes and draconians
        /// </summary>
        private static readonly string[] _gnomeSyllable3 =
        {
            "ron", "re", "la", "ki", "kseli", "ksi", "ku", "ja", "ta", "na", "namari", "neli", "nika", "nikki", "nu",
            "nukka", "ka", "ko", "li", "kki", "rik", "po", "to", "pekka", "rjaana", "rjatta", "rjukka", "la", "lla",
            "lli", "mo", "nni"
        };

        /// <summary>
        /// Beginnings of 'Hobbit' names used by hobbits and kobolds
        /// </summary>
        private static readonly string[] _hobbitSyllable1 =
        {
            "B", "Ber", "Br", "D", "Der", "Dr", "F", "Fr", "G", "H", "L", "Ler", "M", "Mer", "N", "P", "Pr", "Per", "R",
            "S", "T", "W"
        };

        /// <summary>
        /// Middles of 'Hobbit' names used by hobbits and kobolds
        /// </summary>
        private static readonly string[] _hobbitSyllable2 = { "a", "e", "i", "ia", "o", "oi", "u" };

        /// <summary>
        /// Endings of 'Hobbit' names used by hobbits and kobolds
        /// </summary>
        private static readonly string[] _hobbitSyllable3 =
        {
            "bo", "ck", "decan", "degar", "do", "doc", "go", "grin", "lba", "lbo", "lda", "ldo", "lla", "ll", "lo", "m",
            "mwise", "nac", "noc", "nwise", "p", "ppin", "pper", "tho", "to"
        };

        /// <summary>
        /// Beginnings of 'Human' names used by humans, great ones, skeletons, spectres, vampires,
        /// zombies, and half titans
        /// </summary>
        private static readonly string[] _humanSyllable1 =
        {
            "Ab", "Ac", "Ad", "Af", "Agr", "Ast", "As", "Al", "Adw", "Adr", "Ar", "B", "Br", "C", "Cr", "Ch", "Cad",
            "D", "Dr", "Dw", "Ed", "Eth", "Et", "Er", "El", "Eow", "F", "Fr", "G", "Gr", "Gw", "Gal", "Gl", "H", "Ha",
            "Ib", "Jer", "K", "Ka", "Ked", "L", "Loth", "Lar", "Leg", "M", "Mir", "N", "Nyd", "Ol", "Oc", "On", "P",
            "Pr", "R", "Rh", "S", "Sev", "T", "Tr", "Th", "V", "Y", "Z", "W", "Wic"
        };

        /// <summary>
        /// Middles of 'Human' names used by humans, great ones, skeletons, spectres, vampires,
        /// zombies, and half titans
        /// </summary>
        private static readonly string[] _humanSyllable2 =
        {
            "a", "ae", "au", "ao", "are", "ale", "ali", "ay", "ardo", "e", "ei", "ea", "eri", "era", "ela", "eli",
            "enda", "erra", "i", "ia", "ie", "ire", "ira", "ila", "ili", "ira", "igo", "o", "oa", "oi", "oe", "ore",
            "u", "y"
        };

        /// <summary>
        /// Endings of 'Human' names used by humans, great ones, skeletons, spectres, vampires,
        /// zombies, and half titans
        /// </summary>
        private static readonly string[] _humanSyllable3 =
        {
            "a", "and", "b", "bwyn", "baen", "bard", "c", "ctred", "cred", "ch", "can", "d", "dan", "don", "der",
            "dric", "dfrid", "dus", "f", "g", "gord", "gan", "l", "li", "lgrin", "lin", "lith", "lath", "loth", "ld",
            "ldric", "ldan", "m", "mas", "mos", "mar", "mond", "n", "nydd", "nidd", "nnon", "nwan", "nyth", "nad", "nn",
            "nnor", "nd", "p", "r", "ron", "rd", "s", "sh", "seth", "sean", "t", "th", "tha", "tlan", "trem", "tram",
            "v", "vudd", "w", "wan", "win", "wyn", "wyr", "wyr", "wyth"
        };

        /// <summary>
        /// Beginnings of 'Klackon' names used by klackons
        /// </summary>
        private static readonly string[] _klackonSyllable1 =
            {"K'", "K", "Kri", "Kir", "Kiri", "Iriki", "Irik", "Karik", "Iri", "Akri"};

        /// <summary>
        /// Middles of 'Klackon' names used by klackons
        /// </summary>
        private static readonly string[] _klackonSyllable2 =
            {"arak", "i", "iri", "ikki", "ki", "kiri", "ikir", "irak", "arik", "k'", "r"};

        /// <summary>
        /// Endings of 'Klackon' names used by klackons
        /// </summary>
        private static readonly string[] _klackonSyllable3 =
            {"akkak", "ak", "ik", "ikkik", "irik", "arik", "kidik", "kii", "k", "ki", "riki", "irk"};

        /// <summary>
        /// Beginnings of 'Orcish' names used by half orcs, half ogres, and half trolls
        /// </summary>
        private static readonly string[] _orcSyllable1 =
            {"B", "Er", "G", "Gr", "H", "P", "Pr", "R", "V", "Vr", "T", "Tr", "M", "Dr"};

        /// <summary>
        /// Middles of 'Orcish' names used by half orcs, half ogres, and half trolls
        /// </summary>
        private static readonly string[] _orcSyllable2 = { "a", "i", "o", "oo", "u", "ui" };

        /// <summary>
        /// Endings of 'Orcish' names used by half orcs, half ogres, and half trolls
        /// </summary>
        private static readonly string[] _orcSyllable3 =
        {
            "dash", "dish", "dush", "gar", "gor", "gdush", "lo", "gdish", "k", "lg", "nak", "rag", "rbag", "rg", "rk",
            "ng", "nk", "rt", "ol", "urk", "shnak", "mog", "mak", "rak"
        };

        /// <summary>
        /// Beginnings of 'Yeekish' names used by yeeks
        /// </summary>
        private static readonly string[] _yeekSyllable1 = { "Y", "Ye", "Yee", "Y" };

        /// <summary>
        /// Middles of 'Yeekish' names used by yeeks
        /// </summary>
        private static readonly string[] _yeekSyllable2 =
            {"ee", "eee", "ee", "ee-ee", "ee'ee", "'ee", "eee", "ee", "ee"};

        /// <summary>
        /// Endings of 'Yeekish' names used by yeeks
        /// </summary>
        private static readonly string[] _yeekSyllable3 = { "k", "k", "k", "ek", "eek", "ek" };

        private readonly SaveGame SaveGame;
        public PlayerFactory(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        private readonly MenuItem[] _classMenu =
        {
            new MenuItem("Channeler", CharacterClass.Channeler), new MenuItem("Chosen One", CharacterClass.ChosenOne),
            new MenuItem("Cultist", CharacterClass.Cultist), new MenuItem("Druid", CharacterClass.Druid),
            new MenuItem("Fanatic", CharacterClass.Fanatic), new MenuItem("High Mage", CharacterClass.HighMage),
            new MenuItem("Mage", CharacterClass.Mage), new MenuItem("Monk", CharacterClass.Monk),
            new MenuItem("Mindcrafter", CharacterClass.Mindcrafter), new MenuItem("Mystic", CharacterClass.Mystic),
            new MenuItem("Paladin", CharacterClass.Paladin), new MenuItem("Priest", CharacterClass.Priest),
            new MenuItem("Ranger", CharacterClass.Ranger), new MenuItem("Rogue", CharacterClass.Rogue),
            new MenuItem("Warrior", CharacterClass.Warrior), new MenuItem("Warrior Mage", CharacterClass.WarriorMage)
        };

        private readonly string[] _menuItem = new string[32];

        private readonly MenuItem[] _raceMenu =
        {
            new MenuItem("Cyclops", RaceId.Cyclops), new MenuItem("Dark-Elf", RaceId.DarkElf),
            new MenuItem("Draconian", RaceId.Draconian), new MenuItem("Dwarf", RaceId.Dwarf),
            new MenuItem("Elf", RaceId.Elf), new MenuItem("Gnome", RaceId.Gnome), new MenuItem("Golem", RaceId.Golem),
            new MenuItem("Great One", RaceId.Great), new MenuItem("Half Elf", RaceId.HalfElf),
            new MenuItem("Half Giant", RaceId.HalfGiant), new MenuItem("Half Ogre", RaceId.HalfOgre),
            new MenuItem("Half Orc", RaceId.HalfOrc), new MenuItem("Half Titan", RaceId.HalfTitan),
            new MenuItem("Half Troll", RaceId.HalfTroll), new MenuItem("High Elf", RaceId.HighElf),
            new MenuItem("Hobbit", RaceId.Hobbit), new MenuItem("Human", RaceId.Human), new MenuItem("Imp", RaceId.Imp),
            new MenuItem("Klackon", RaceId.Klackon), new MenuItem("Kobold", RaceId.Kobold),
            new MenuItem("Mind Flayer", RaceId.MindFlayer), new MenuItem("Miri Nigri", RaceId.MiriNigri),
            new MenuItem("Nibelung", RaceId.Nibelung), new MenuItem("Skeleton", RaceId.Skeleton),
            new MenuItem("Spectre", RaceId.Spectre), new MenuItem("Sprite", RaceId.Sprite),
            new MenuItem("Tcho-Tcho", RaceId.TchoTcho), new MenuItem("Vampire", RaceId.Vampire),
            new MenuItem("Yeek", RaceId.Yeek), new MenuItem("Zombie", RaceId.Zombie)
        };

        private readonly int[] _realmChoices =
        {
            // Warrior
            RealmChoice.None,
            // Mage
            RealmChoice.Life | RealmChoice.Sorcery | RealmChoice.Nature | RealmChoice.Chaos | RealmChoice.Death |
            RealmChoice.Tarot | RealmChoice.Folk | RealmChoice.Corporeal,
            // Priest
            RealmChoice.Nature | RealmChoice.Chaos | RealmChoice.Tarot | RealmChoice.Folk | RealmChoice.Corporeal,
            // Rogue
            RealmChoice.Sorcery | RealmChoice.Death | RealmChoice.Tarot | RealmChoice.Folk,
            // Ranger
            RealmChoice.Chaos | RealmChoice.Death | RealmChoice.Tarot | RealmChoice.Folk | RealmChoice.Corporeal,
            // Paladin
            RealmChoice.Life | RealmChoice.Death,
            // Warrior Mage
            RealmChoice.Life | RealmChoice.Nature | RealmChoice.Chaos | RealmChoice.Death | RealmChoice.Tarot |
            RealmChoice.Folk | RealmChoice.Sorcery | RealmChoice.Corporeal,
            // Fanatic
            RealmChoice.Chaos,
            // Monk
            RealmChoice.Corporeal | RealmChoice.Tarot | RealmChoice.Chaos,
            // Mindcrafter
            RealmChoice.None,
            // High Mage
            RealmChoice.Life | RealmChoice.Sorcery | RealmChoice.Nature | RealmChoice.Chaos | RealmChoice.Death |
            RealmChoice.Tarot | RealmChoice.Folk | RealmChoice.Corporeal,
            // Druid
            RealmChoice.Nature,
            // Cultist
            RealmChoice.Life | RealmChoice.Sorcery | RealmChoice.Nature | RealmChoice.Death | RealmChoice.Tarot |
            RealmChoice.Folk | RealmChoice.Corporeal,
            // Channeler
            RealmChoice.None,
            // Chosen One
            RealmChoice.None,
            // Mystic
            RealmChoice.None
        };

        private readonly Gender[] _sexInfo = { new Gender("Female", "Queen"), new Gender("Male", "King"), new Gender("Other", "Monarch") };
        private int _menuLength;
        private Player _player;
        private int _prevClass;
        private int _prevGeneration;
        private string _prevName;
        private int _prevRace;
        private Realm _prevRealm1;
        private Realm _prevRealm2;
        private int _prevSex;

        public Player CharacterGeneration(SaveGame saveGame, ExPlayer ex)
        {
            SaveGame.SetBackground(BackgroundImage.Paper);
            SaveGame.PlayMusic(MusicTrack.Chargen);
            _player = new Player(saveGame);
            if (PlayerBirth(ex))
            {
                return _player;
            }
            return null;
        }

        private Realm ChooseRealmRandomly(int choices)
        {
            Realm[] picks = new Realm[Constants.MaxRealm];
            int n = 0;
            if ((choices & RealmChoice.Chaos) != 0 && _player.Realm1 != Realm.Chaos)
            {
                picks[n] = Realm.Chaos;
                n++;
            }
            if ((choices & RealmChoice.Corporeal) != 0 && _player.Realm1 != Realm.Corporeal)
            {
                picks[n] = Realm.Corporeal;
                n++;
            }
            if ((choices & RealmChoice.Death) != 0 && _player.Realm1 != Realm.Death)
            {
                picks[n] = Realm.Death;
                n++;
            }
            if ((choices & RealmChoice.Folk) != 0 && _player.Realm1 != Realm.Folk)
            {
                picks[n] = Realm.Folk;
                n++;
            }
            if ((choices & RealmChoice.Life) != 0 && _player.Realm1 != Realm.Life)
            {
                picks[n] = Realm.Life;
                n++;
            }
            if ((choices & RealmChoice.Nature) != 0 && _player.Realm1 != Realm.Nature)
            {
                picks[n] = Realm.Nature;
                n++;
            }
            if ((choices & RealmChoice.Tarot) != 0 && _player.Realm1 != Realm.Tarot)
            {
                picks[n] = Realm.Tarot;
                n++;
            }
            if ((choices & RealmChoice.Sorcery) != 0 && _player.Realm1 != Realm.Sorcery)
            {
                picks[n] = Realm.Sorcery;
                n++;
            }
            int k = Program.Rng.RandomLessThan(n);
            return picks[k];
        }

        private void DisplayAPlusB(int x, int y, int initial, int bonus)
        {
            string buf = $"{initial:00}% + {bonus / 10}.{bonus % 10}%/lv";
            SaveGame.Print(Colour.Black, buf, y, x);
        }

        private void DisplayClassInfo(int pclass)
        {
            SaveGame.Print(Colour.Purple, "STR:", 36, 21);
            SaveGame.Print(Colour.Purple, "INT:", 37, 21);
            SaveGame.Print(Colour.Purple, "WIS:", 38, 21);
            SaveGame.Print(Colour.Purple, "DEX:", 39, 21);
            SaveGame.Print(Colour.Purple, "CON:", 40, 21);
            SaveGame.Print(Colour.Purple, "CHA:", 41, 21);
            for (int i = 0; i < 6; i++)
            {
                int bonus = Profession.ClassInfo[pclass].AbilityBonus[i];
                DisplayStatBonus(26, 36 + i, bonus);
            }
            SaveGame.Print(Colour.Purple, "Disarming   :", 36, 53);
            SaveGame.Print(Colour.Purple, "Magic Device:", 37, 53);
            SaveGame.Print(Colour.Purple, "Saving Throw:", 38, 53);
            SaveGame.Print(Colour.Purple, "Stealth     :", 39, 53);
            SaveGame.Print(Colour.Purple, "Fighting    :", 40, 53);
            SaveGame.Print(Colour.Purple, "Shooting    :", 41, 53);
            SaveGame.Print(Colour.Purple, "Experience  :", 36, 31);
            SaveGame.Print(Colour.Purple, "Hit Dice    :", 37, 31);
            SaveGame.Print(Colour.Purple, "Infravision :", 38, 31);
            SaveGame.Print(Colour.Purple, "Searching   :", 39, 31);
            SaveGame.Print(Colour.Purple, "Perception  :", 40, 31);
            DisplayAPlusB(67, 36, Profession.ClassInfo[pclass].BaseDisarmBonus, Profession.ClassInfo[pclass].DisarmBonusPerLevel);
            DisplayAPlusB(67, 37, Profession.ClassInfo[pclass].BaseDeviceBonus, Profession.ClassInfo[pclass].DeviceBonusPerLevel);
            DisplayAPlusB(67, 38, Profession.ClassInfo[pclass].BaseSaveBonus, Profession.ClassInfo[pclass].SaveBonusPerLevel);
            DisplayAPlusB(67, 39, Profession.ClassInfo[pclass].BaseStealthBonus * 4, Profession.ClassInfo[pclass].StealthBonusPerLevel * 4);
            DisplayAPlusB(67, 40, Profession.ClassInfo[pclass].BaseMeleeAttackBonus, Profession.ClassInfo[pclass].MeleeAttackBonusPerLevel);
            DisplayAPlusB(67, 41, Profession.ClassInfo[pclass].BaseRangedAttackBonus, Profession.ClassInfo[pclass].RangedAttackBonusPerLevel);
            string buf = "+" + Profession.ClassInfo[pclass].ExperienceFactor + "%";
            SaveGame.Print(Colour.Black, buf, 36, 45);
            buf = "1d" + Profession.ClassInfo[pclass].HitDieBonus;
            SaveGame.Print(Colour.Black, buf, 37, 45);
            SaveGame.Print(Colour.Black, "-", 38, 45);
            buf = $"{Profession.ClassInfo[pclass].BaseSearchBonus:00}%";
            SaveGame.Print(Colour.Black, buf, 39, 45);
            buf = $"{Profession.ClassInfo[pclass].BaseSearchFrequency:00}%";
            SaveGame.Print(Colour.Black, buf, 40, 45);
            switch (pclass)
            {
                case CharacterClass.Cultist:
                    SaveGame.Print(Colour.Purple, "INT based spell casters, who use Chaos and another realm", 30, 20);
                    SaveGame.Print(Colour.Purple, "of their choice. Can't wield weapons except for powerful", 31, 20);
                    SaveGame.Print(Colour.Purple, "chaos blades. Learn to resist chaos (at lvl 20). Have a", 32, 20);
                    SaveGame.Print(Colour.Purple, "cult patron who will randomly give them rewards or", 33, 20);
                    SaveGame.Print(Colour.Purple, "punishments as they increase in level.", 34, 20);
                    break;

                case CharacterClass.Fanatic:
                    SaveGame.Print(Colour.Purple, "Warriors who dabble in INT based Chaos magic. Have a cult", 30, 20);
                    SaveGame.Print(Colour.Purple, "patron who will randomly give them rewards or punishments", 31, 20);
                    SaveGame.Print(Colour.Purple, "as they increase in level. Learn to resist chaos", 32, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 30) and fear (at lvl 40).", 33, 20);
                    break;

                case CharacterClass.ChosenOne:
                    SaveGame.Print(Colour.Purple, "Warriors of fate, who have no spell casting abilities but", 30, 20);
                    SaveGame.Print(Colour.Purple, "gain a large number of passive magical abilities (too long", 31, 20);
                    SaveGame.Print(Colour.Purple, "to list here) as they increase in level.", 32, 20);
                    break;

                case CharacterClass.Channeler:
                    SaveGame.Print(Colour.Purple, "Similar to a spell caster, but rather than casting spells", 30, 20);
                    SaveGame.Print(Colour.Purple, "from a book, they can use their CHA to channel mana into", 31, 20);
                    SaveGame.Print(Colour.Purple, "most types of item, powering the effects of the items", 32, 20);
                    SaveGame.Print(Colour.Purple, "without depleting them.", 33, 20);
                    break;

                case CharacterClass.Druid:
                    SaveGame.Print(Colour.Purple, "Nature priests who use WIS based spell casting and who are", 30, 20);
                    SaveGame.Print(Colour.Purple, "limited to the Nature realm. As priests, they can't use", 31, 20);
                    SaveGame.Print(Colour.Purple, "edged weapons unless those weapons are holy; but they can", 32, 20);
                    SaveGame.Print(Colour.Purple, "wear heavy armour without it disrupting their casting.", 33, 20);
                    break;

                case CharacterClass.HighMage:
                    SaveGame.Print(Colour.Purple, "INT based spell casters who specialise in a single realm", 30, 20);
                    SaveGame.Print(Colour.Purple, "of magic. They may choose any realm, and are better at", 31, 20);
                    SaveGame.Print(Colour.Purple, "casting spells from that realm than a normal mage. High", 32, 20);
                    SaveGame.Print(Colour.Purple, "mages also get more mana than other spell casters do.", 33, 20);
                    SaveGame.Print(Colour.Purple, "Wearing too much armour disrupts their casting.", 34, 20);
                    break;

                case CharacterClass.Mage:
                    SaveGame.Print(Colour.Purple, "Flexible INT based spell casters who can cast magic from", 30, 20);
                    SaveGame.Print(Colour.Purple, "any two realms of their choice. However, they can't wear", 31, 20);
                    SaveGame.Print(Colour.Purple, "much armour before it starts disrupting their casting.", 32, 20);
                    break;

                case CharacterClass.Monk:
                    SaveGame.Print(Colour.Purple, "Masters of unarmed combat. While wearing only light armour", 30, 20);
                    SaveGame.Print(Colour.Purple, "they can move faster and dodge blows and can learn to", 31, 20);
                    SaveGame.Print(Colour.Purple, "resist paralysis (at lvl 25). While not wielding a weapon", 32, 20);
                    SaveGame.Print(Colour.Purple, "they have extra attacks and do increased damage. They are", 33, 20);
                    SaveGame.Print(Colour.Purple, "WIS based casters using Chaos, Tarot or Corporeal magic.", 34, 20);
                    break;

                case CharacterClass.Mindcrafter:
                    SaveGame.Print(Colour.Purple, "Disciples of the psionic arts, Mindcrafters learn a range", 30, 20);
                    SaveGame.Print(Colour.Purple, "of mental abilities; which they power using WIS. As well", 31, 20);
                    SaveGame.Print(Colour.Purple, "as their powers, they learn to resist fear (at lvl 10),", 32, 20);
                    SaveGame.Print(Colour.Purple, "prevent wis drain (at lvl 20), resist confusion", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 30), and gain telepathy (at lvl 40).", 34, 20);
                    break;

                case CharacterClass.Mystic:
                    SaveGame.Print(Colour.Purple, "Mystics master both martial and psionic arts, which they", 30, 20);
                    SaveGame.Print(Colour.Purple, "power using WIS. Can resist confusion (at lvl 10), fear", 31, 20);
                    SaveGame.Print(Colour.Purple, "(lvl 25), paralysis (lvl 30). Telepathy (lvl 40). While", 32, 20);
                    SaveGame.Print(Colour.Purple, "wearing only light armour they can move faster and dodge,", 33, 20);
                    SaveGame.Print(Colour.Purple, "and while not wielding a weapon they do increased damage.", 34, 20);
                    break;

                case CharacterClass.Paladin:
                    SaveGame.Print(Colour.Purple, "Holy warriors who use WIS based spell casting to supplement", 30, 20);
                    SaveGame.Print(Colour.Purple, "their fighting skills. Paladins can specialise in either", 31, 20);
                    SaveGame.Print(Colour.Purple, "Life or Death magic, but their spell casting is weak in", 32, 20);
                    SaveGame.Print(Colour.Purple, "comparison to a full priest. Paladins learn to resist fear", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 40).", 34, 20);
                    break;

                case CharacterClass.Priest:
                    SaveGame.Print(Colour.Purple, "Devout followers of the Great Ones, Priests use WIS based", 30, 20);
                    SaveGame.Print(Colour.Purple, "spell casting. They may choose either Life or Death magic,", 31, 20);
                    SaveGame.Print(Colour.Purple, "and another realm of their choice. Priests can't use edged", 32, 20);
                    SaveGame.Print(Colour.Purple, "weapons unless they are blessed, but can use any armour.", 33, 20);
                    break;

                case CharacterClass.Ranger:
                    SaveGame.Print(Colour.Purple, "Masters of ranged combat, especiallly using bows. Rangers", 30, 20);
                    SaveGame.Print(Colour.Purple, "supplement their shooting and stealth with INT based spell", 31, 20);
                    SaveGame.Print(Colour.Purple, "casting from the Nature realm plus another realm of their", 32, 20);
                    SaveGame.Print(Colour.Purple, "choice from Death, Corporeal, Tarot, Chaos, and Folk.", 33, 20);
                    break;

                case CharacterClass.Rogue:
                    SaveGame.Print(Colour.Purple, "Stealth based characters who are adept at picking locks,", 30, 20);
                    SaveGame.Print(Colour.Purple, "searching, and disarming traps. Rogues can use stealth to", 31, 20);
                    SaveGame.Print(Colour.Purple, "their advantage in order to backstab sleeping or fleeing", 32, 20);
                    SaveGame.Print(Colour.Purple, "foes. They also dabble in INT based magic, learning spells", 33, 20);
                    SaveGame.Print(Colour.Purple, "from the Tarot, Sorcery, Death, or Folk realms.", 34, 20);
                    break;

                case CharacterClass.Warrior:
                    SaveGame.Print(Colour.Purple, "Straightforward, no-nonsense fighters. They are the best", 30, 20);
                    SaveGame.Print(Colour.Purple, "characters at melee combat, and require the least amount", 31, 20);
                    SaveGame.Print(Colour.Purple, "of experience to increase in level. They can learn to", 32, 20);
                    SaveGame.Print(Colour.Purple, "resist fear (at lvl 30). The ideal class for novices.", 33, 20);
                    break;

                case CharacterClass.WarriorMage:
                    SaveGame.Print(Colour.Purple, "A blend of both warrior and mage, getting the abilities of", 30, 20);
                    SaveGame.Print(Colour.Purple, "both but not being the best at either. They use INT based", 31, 20);
                    SaveGame.Print(Colour.Purple, "spell casting, getting access to the Folk realm plus a", 32, 20);
                    SaveGame.Print(Colour.Purple, "second realm of their choice. They pay for their extreme", 33, 20);
                    SaveGame.Print(Colour.Purple, "flexibility by increasing in level only slowly.", 34, 20);
                    break;
            }
        }

        private void DisplayPartialCharacter(int stage)
        {
            int i;
            string str;
            const string spaces = "                 ";
            SaveGame.Clear(0);
            SaveGame.Print(Colour.Blue, "Name        :", 2, 1);
            SaveGame.Print(Colour.Brown, stage == 0 ? _prevName : spaces, 2, 15);
            SaveGame.Print(Colour.Blue, "Gender      :", 3, 1);
            if (stage == 0)
            {
                _player.Gender = _sexInfo[_prevSex];
                str = _player.Gender.Title;
            }
            else if (stage < 6)
            {
                str = spaces;
            }
            else
            {
                _player.Gender = _sexInfo[_player.GenderIndex];
                str = _player.Gender.Title;
            }
            SaveGame.Print(Colour.Brown, str, 3, 15);
            SaveGame.Print(Colour.Blue, "Race        :", 4, 1);
            if (stage == 0)
            {
                _player.Race = Race.RaceInfo[_prevRace];
                str = _player.Race.Title;
            }
            else if (stage < 3)
            {
                str = spaces;
            }
            else
            {
                _player.Race = Race.RaceInfo[_player.RaceIndex];
                str = _player.Race.Title;
            }
            SaveGame.Print(Colour.Brown, str, 4, 15);
            SaveGame.Print(Colour.Blue, "Class       :", 5, 1);
            if (stage == 0)
            {
                _player.Profession = Profession.ClassInfo[_prevClass];
                str = _player.Profession.Title;
            }
            else if (stage < 2)
            {
                str = spaces;
            }
            else
            {
                _player.Profession = Profession.ClassInfo[_player.ProfessionIndex];
                str = _player.Profession.Title;
            }
            SaveGame.Print(Colour.Brown, str, 5, 15);
            string buf = string.Empty;
            if (stage == 0)
            {
                if (_prevRealm1 != Realm.None)
                {
                    if (_prevRealm2 != Realm.None)
                    {
                        buf = Spellcasting.RealmName(_prevRealm1) + "/" + Spellcasting.RealmName(_prevRealm2);
                    }
                    else
                    {
                        buf = Spellcasting.RealmName(_prevRealm1);
                    }
                }
                if (_prevRealm1 != Realm.None || _prevRealm2 != Realm.None)
                {
                    SaveGame.Print(Colour.Blue, "Magic       :", 6, 1);
                }
                if (_prevRealm1 != Realm.None)
                {
                    SaveGame.Print(Colour.Brown, buf, 6, 15);
                }
            }
            else if (stage < 4)
            {
                str = spaces;
                SaveGame.Print(Colour.Blue, str, 6, 0);
                SaveGame.Print(Colour.Brown, str, 6, 15);
            }
            else
            {
                buf = string.Empty;
                if (_player.Realm1 != Realm.None)
                {
                    if (_player.Realm2 != Realm.None)
                    {
                        buf = Spellcasting.RealmName(_player.Realm1) + "/" + Spellcasting.RealmName(_player.Realm2);
                    }
                    else
                    {
                        buf = Spellcasting.RealmName(_player.Realm1);
                    }
                }
                if (_player.Realm1 != Realm.None || _player.Realm2 != Realm.None)
                {
                    SaveGame.Print(Colour.Blue, "Magic       :", 6, 1);
                }
                if (_player.Realm1 != Realm.None)
                {
                    SaveGame.Print(Colour.Brown, buf, 6, 15);
                }
            }
            SaveGame.Print(Colour.Blue, "Birthday", 2, 32);
            SaveGame.Print(Colour.Blue, "Age          ", 3, 32);
            SaveGame.Print(Colour.Blue, "Height       ", 4, 32);
            SaveGame.Print(Colour.Blue, "Weight       ", 5, 32);
            SaveGame.Print(Colour.Blue, "Social Class ", 6, 32);
            SaveGame.Print(Colour.Blue, "STR:", 2 + Ability.Strength, 61);
            SaveGame.Print(Colour.Blue, "INT:", 2 + Ability.Intelligence, 61);
            SaveGame.Print(Colour.Blue, "WIS:", 2 + Ability.Wisdom, 61);
            SaveGame.Print(Colour.Blue, "DEX:", 2 + Ability.Dexterity, 61);
            SaveGame.Print(Colour.Blue, "CON:", 2 + Ability.Constitution, 61);
            SaveGame.Print(Colour.Blue, "CHA:", 2 + Ability.Charisma, 61);
            SaveGame.Print(Colour.Blue, "STR:", 14 + Ability.Strength, 1);
            SaveGame.Print(Colour.Blue, "INT:", 14 + Ability.Intelligence, 1);
            SaveGame.Print(Colour.Blue, "WIS:", 14 + Ability.Wisdom, 1);
            SaveGame.Print(Colour.Blue, "DEX:", 14 + Ability.Dexterity, 1);
            SaveGame.Print(Colour.Blue, "CON:", 14 + Ability.Constitution, 1);
            SaveGame.Print(Colour.Blue, "CHA:", 14 + Ability.Charisma, 1);
            SaveGame.Print(Colour.Blue, "STR:", 22 + Ability.Strength, 1);
            SaveGame.Print(Colour.Blue, "INT:", 22 + Ability.Intelligence, 1);
            SaveGame.Print(Colour.Blue, "WIS:", 22 + Ability.Wisdom, 1);
            SaveGame.Print(Colour.Blue, "DEX:", 22 + Ability.Dexterity, 1);
            SaveGame.Print(Colour.Blue, "CON:", 22 + Ability.Constitution, 1);
            SaveGame.Print(Colour.Blue, "CHA:", 22 + Ability.Charisma, 1);
            SaveGame.Print(Colour.Purple, "Initial", 21, 6);
            SaveGame.Print(Colour.Brown, "Race Class Mods", 21, 14);
            SaveGame.Print(Colour.Green, "Actual", 21, 30);
            SaveGame.Print(Colour.Red, "Reduced", 21, 37);
            SaveGame.Print(Colour.Blue, "abcdefghijklm@", 21, 45);
            SaveGame.Print(Colour.Grey, "..............", 22, 45);
            SaveGame.Print(Colour.Grey, "..............", 23, 45);
            SaveGame.Print(Colour.Grey, "..............", 24, 45);
            SaveGame.Print(Colour.Grey, "..............", 25, 45);
            SaveGame.Print(Colour.Grey, "..............", 26, 45);
            SaveGame.Print(Colour.Grey, "..............", 27, 45);
            SaveGame.Print(Colour.Blue, "Modifications", 28, 45);

            if (stage < 2)
            {
                for (i = 0; i < 6; i++)
                {
                    SaveGame.Print(Colour.Brown, "   ", 22 + i, 20);
                }
            }
            else
            {
                for (i = 0; i < 6; i++)
                {
                    buf = _player.Profession.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3);
                    SaveGame.Print(Colour.Brown, buf, 22 + i, 20);
                }
            }
            if (stage < 3)
            {
                for (i = 0; i < 6; i++)
                {
                    SaveGame.Print(Colour.Brown, "   ", 22 + i, 14);
                }
            }
            else
            {
                for (i = 0; i < 6; i++)
                {
                    buf = (_player.Race.AbilityBonus[i]).ToString("+0;-0;+0").PadLeft(3);
                    SaveGame.Print(Colour.Brown, buf, 22 + i, 14);
                }
            }
        }

        private void DisplayRaceInfo(int race)
        {
            SaveGame.Print(Colour.Purple, "STR:", 36, 21);
            SaveGame.Print(Colour.Purple, "INT:", 37, 21);
            SaveGame.Print(Colour.Purple, "WIS:", 38, 21);
            SaveGame.Print(Colour.Purple, "DEX:", 39, 21);
            SaveGame.Print(Colour.Purple, "CON:", 40, 21);
            SaveGame.Print(Colour.Purple, "CHA:", 41, 21);
            for (int i = 0; i < 6; i++)
            {
                int bonus = Race.RaceInfo[race].AbilityBonus[i] + Profession.ClassInfo[_player.ProfessionIndex].AbilityBonus[i];
                DisplayStatBonus(26, 36 + i, bonus);
            }
            SaveGame.Print(Colour.Purple, "Disarming   :", 36, 53);
            SaveGame.Print(Colour.Purple, "Magic Device:", 37, 53);
            SaveGame.Print(Colour.Purple, "Saving Throw:", 38, 53);
            SaveGame.Print(Colour.Purple, "Stealth     :", 39, 53);
            SaveGame.Print(Colour.Purple, "Fighting    :", 40, 53);
            SaveGame.Print(Colour.Purple, "Shooting    :", 41, 53);
            SaveGame.Print(Colour.Purple, "Experience  :", 36, 31);
            SaveGame.Print(Colour.Purple, "Hit Dice    :", 37, 31);
            SaveGame.Print(Colour.Purple, "Infravision :", 38, 31);
            SaveGame.Print(Colour.Purple, "Searching   :", 39, 31);
            SaveGame.Print(Colour.Purple, "Perception  :", 40, 31);
            DisplayAPlusB(67, 36, Profession.ClassInfo[_player.ProfessionIndex].BaseDisarmBonus + Race.RaceInfo[race].BaseDisarmBonus,
                Profession.ClassInfo[_player.ProfessionIndex].DisarmBonusPerLevel);
            DisplayAPlusB(67, 37, Profession.ClassInfo[_player.ProfessionIndex].BaseDeviceBonus + Race.RaceInfo[race].BaseDeviceBonus,
                Profession.ClassInfo[_player.ProfessionIndex].DeviceBonusPerLevel);
            DisplayAPlusB(67, 38, Profession.ClassInfo[_player.ProfessionIndex].BaseSaveBonus + Race.RaceInfo[race].BaseSaveBonus,
                Profession.ClassInfo[_player.ProfessionIndex].SaveBonusPerLevel);
            DisplayAPlusB(67, 39, (Profession.ClassInfo[_player.ProfessionIndex].BaseStealthBonus * 4) + (Race.RaceInfo[race].BaseStealthBonus * 4),
                Profession.ClassInfo[_player.ProfessionIndex].StealthBonusPerLevel * 4);
            DisplayAPlusB(67, 40, Profession.ClassInfo[_player.ProfessionIndex].BaseMeleeAttackBonus + Race.RaceInfo[race].BaseMeleeAttackBonus,
                Profession.ClassInfo[_player.ProfessionIndex].MeleeAttackBonusPerLevel);
            DisplayAPlusB(67, 41, Profession.ClassInfo[_player.ProfessionIndex].BaseRangedAttackBonus + Race.RaceInfo[race].BaseRangedAttackBonus,
                Profession.ClassInfo[_player.ProfessionIndex].RangedAttackBonusPerLevel);
            string buf = Race.RaceInfo[race].ExperienceFactor + Profession.ClassInfo[_player.ProfessionIndex].ExperienceFactor + "%";
            SaveGame.Print(Colour.Black, buf, 36, 45);
            buf = "1d" + (Race.RaceInfo[race].HitDieBonus + Profession.ClassInfo[_player.ProfessionIndex].HitDieBonus);
            SaveGame.Print(Colour.Black, buf, 37, 45);
            if (Race.RaceInfo[race].Infravision == 0)
            {
                SaveGame.Print(Colour.Black, "nil", 38, 45);
            }
            else
            {
                buf = Race.RaceInfo[race].Infravision + "0 feet";
                SaveGame.Print(Colour.Green, buf, 38, 45);
            }
            buf = $"{Race.RaceInfo[race].BaseSearchBonus + Profession.ClassInfo[_player.ProfessionIndex].BaseSearchBonus:00}%";
            SaveGame.Print(Colour.Black, buf, 39, 45);
            buf = $"{Race.RaceInfo[race].BaseSearchFrequency + Profession.ClassInfo[_player.ProfessionIndex].BaseSearchFrequency:00}%";
            SaveGame.Print(Colour.Black, buf, 40, 45);
            switch (race)
            {
                case RaceId.TchoTcho:
                    SaveGame.Print(Colour.Purple, "Tcho-Tchos are hairless cannibalistic near-humans who dwell", 30, 20);
                    SaveGame.Print(Colour.Purple, "in isolated parts of the world away from more civilised", 31, 20);
                    SaveGame.Print(Colour.Purple, "places where their dark rituals and sacrifices go unseen.", 32, 20);
                    SaveGame.Print(Colour.Purple, "Tcho-Tchos are immune to fear, and can also learn to create", 33, 20);
                    SaveGame.Print(Colour.Purple, "The Yellow Sign (at lvl 35).", 34, 20);
                    break;

                case RaceId.MiriNigri:
                    SaveGame.Print(Colour.Purple, "Miri-Nigri are squat, toad-like chaos beasts. Their", 29, 20);
                    SaveGame.Print(Colour.Purple, "close ties to chaos render them resistant to sound and", 30, 20);
                    SaveGame.Print(Colour.Purple, "immune to confusion. However, their chaotic nature also", 31, 20);
                    SaveGame.Print(Colour.Purple, "makes them prone to random mutation. Also, the outer gods", 32, 20);
                    SaveGame.Print(Colour.Purple, "pay special attention to miri-nigri servants and they", 33, 20);
                    SaveGame.Print(Colour.Purple, "are more likely to interfere with them for good or ill.", 34, 20);
                    break;

                case RaceId.Cyclops:
                    SaveGame.Print(Colour.Purple, "Cyclopes are one eyed giants, often seen as freaks by the", 30, 20);
                    SaveGame.Print(Colour.Purple, "other races. They can learn to throw boulders (at lvl 20)", 31, 20);
                    SaveGame.Print(Colour.Purple, "and although they have weak eyesight their hearing is very", 32, 20);
                    SaveGame.Print(Colour.Purple, "keen and hard to damage, so they are resistant to sound", 33, 20);
                    SaveGame.Print(Colour.Purple, "based attacks.", 34, 20);
                    break;

                case RaceId.DarkElf:
                    SaveGame.Print(Colour.Purple, "Dark elves are underground elves who have a kinship with", 29, 20);
                    SaveGame.Print(Colour.Purple, "fungi the way that surface elves have a kinship with trees.", 30, 20);
                    SaveGame.Print(Colour.Purple, "The innately magical nature of dark elves lets them learn", 31, 20);
                    SaveGame.Print(Colour.Purple, "to fire magical missiles at their opponents (at lvl 2).", 32, 20);
                    SaveGame.Print(Colour.Purple, "They also resist dark-based attacks and can learn to see", 33, 20);
                    SaveGame.Print(Colour.Purple, "invisible creatures (at lvl 20).", 34, 20);
                    break;

                case RaceId.Draconian:
                    SaveGame.Print(Colour.Purple, "Draconians are related to dragons and this shows both in", 29, 20);
                    SaveGame.Print(Colour.Purple, "their physical superiority and their legendary arrogance.", 30, 20);
                    SaveGame.Print(Colour.Purple, "As well as having a breath weapon, their wings let them", 31, 20);
                    SaveGame.Print(Colour.Purple, "avoid falling damage, and they can learn to resist fire", 32, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 5), cold (at lvl 10), acid (at lvl 15), lightning", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 20), and poison (at lvl 35).", 34, 20);
                    break;

                case RaceId.Dwarf:
                    SaveGame.Print(Colour.Purple, "Dwarves are short and stocky, and although not noted for", 29, 20);
                    SaveGame.Print(Colour.Purple, "their intelligence or subtlety they are generally very", 30, 20);
                    SaveGame.Print(Colour.Purple, "pious. They are also rather resistant to spells. As natural", 31, 20);
                    SaveGame.Print(Colour.Purple, "miners, used to feeling their way around in the dark,", 32, 20);
                    SaveGame.Print(Colour.Purple, "dwarves are immune to all forms of blindness and can learn", 33, 20);
                    SaveGame.Print(Colour.Purple, "to detect secret doors and traps (at lvl 5).", 34, 20);
                    break;

                case RaceId.Elf:
                    SaveGame.Print(Colour.Purple, "Elves are creatures of the woods, and cultivate a symbiotic", 30, 20);
                    SaveGame.Print(Colour.Purple, "relationship with trees. While not the sturdiest of races,", 31, 20);
                    SaveGame.Print(Colour.Purple, "they are dextrous and have excellent mental faculties.", 32, 20);
                    SaveGame.Print(Colour.Purple, "Because they are partially photosynthetic, elves are able", 33, 20);
                    SaveGame.Print(Colour.Purple, "to resist light based attacks.", 34, 20);
                    break;

                case RaceId.Gnome:
                    SaveGame.Print(Colour.Purple, "Gnomes are small, playful, and talented at magic. However,", 29, 20);
                    SaveGame.Print(Colour.Purple, "they are almost chronically incapable of taking anything", 30, 20);
                    SaveGame.Print(Colour.Purple, "seriously. Gnomes are constantly fidgeting and always on", 31, 20);
                    SaveGame.Print(Colour.Purple, "the move, and this makes them impossible to paralyse or", 32, 20);
                    SaveGame.Print(Colour.Purple, "magically slow. Gnomes are even able to learn how to ", 33, 20);
                    SaveGame.Print(Colour.Purple, "teleport short distances (at lvl 5).", 34, 20);
                    break;

                case RaceId.Golem:
                    SaveGame.Print(Colour.Purple, "Golems are animated statues. Their inorganic bodies make it", 29, 20);
                    SaveGame.Print(Colour.Purple, "hard for them to digest food properly, but they have innate", 30, 20);
                    SaveGame.Print(Colour.Purple, "natural armour and can't be stunned or made to bleed. They", 31, 20);
                    SaveGame.Print(Colour.Purple, "also resist poison and can see invisible creatures. Golems", 32, 20);
                    SaveGame.Print(Colour.Purple, "can learn to use their armour more efficiently (at lvl 20)", 33, 20);
                    SaveGame.Print(Colour.Purple, "and avoid having their life force drained (at lvl 35).", 34, 20);
                    break;

                case RaceId.Great:
                    SaveGame.Print(Colour.Purple, "Great-Ones are the offspring of the petty gods that rule", 30, 20);
                    SaveGame.Print(Colour.Purple, "Dreamlands. As such they are somewhat more than human.", 31, 20);
                    SaveGame.Print(Colour.Purple, "Their constitution cannot be reduced, and they heal", 32, 20);
                    SaveGame.Print(Colour.Purple, "quickly. They can also learn to travel through dreams", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 30) and restore their health (at lvl 40).", 34, 20);
                    break;

                case RaceId.HalfElf:
                    SaveGame.Print(Colour.Purple, "Half-Elves inherit better ability scores and skills from", 30, 20);
                    SaveGame.Print(Colour.Purple, "their elven parent, but none of that parent's special", 31, 20);
                    SaveGame.Print(Colour.Purple, "abilities. However, a half elf will advance in level more", 32, 20);
                    SaveGame.Print(Colour.Purple, "quickly than a full elf.", 33, 20);
                    break;

                case RaceId.HalfGiant:
                    SaveGame.Print(Colour.Purple, "Half-Giants are immensely strong and tough, and their skin", 30, 20);
                    SaveGame.Print(Colour.Purple, "is stony. They can't have their strength reduced, and they", 31, 20);
                    SaveGame.Print(Colour.Purple, "resist damage from explosions that throw out shards of", 32, 20);
                    SaveGame.Print(Colour.Purple, "stone and metal. They can learn to soften rock into mud", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 10).", 34, 20);
                    break;

                case RaceId.HalfOgre:
                    SaveGame.Print(Colour.Purple, "Half-Ogres are both strong and naturally magical, although", 30, 20);
                    SaveGame.Print(Colour.Purple, "they don't usually have the intelligence to make the most", 31, 20);
                    SaveGame.Print(Colour.Purple, "of their magic. They resist darkness and can't have their", 32, 20);
                    SaveGame.Print(Colour.Purple, "strength reduced. They can also can enter a berserk", 33, 20);
                    SaveGame.Print(Colour.Purple, "rage (at lvl 8).", 34, 20);
                    break;

                case RaceId.HalfOrc:
                    SaveGame.Print(Colour.Purple, "Half-Orcs are stronger than humans, and less dimwitted", 30, 20);
                    SaveGame.Print(Colour.Purple, "their orcish parentage would lead you to assume.", 31, 20);
                    SaveGame.Print(Colour.Purple, "Half-Orcs are born of darkness and are resistant to that", 32, 20);
                    SaveGame.Print(Colour.Purple, "form of attack. They are also able to learn to shrug off", 33, 20);
                    SaveGame.Print(Colour.Purple, "magical fear (at lvl 5).", 34, 20);
                    break;

                case RaceId.HalfTitan:
                    SaveGame.Print(Colour.Purple, "Half-Titans are massively strong, being descended from the", 30, 20);
                    SaveGame.Print(Colour.Purple, "predecessors of the gods that grew from primal chaos. This", 31, 20);
                    SaveGame.Print(Colour.Purple, "legacy lets them resist damage from chaos, and half-titans", 32, 20);
                    SaveGame.Print(Colour.Purple, "can learn to magically probe their foes to find out their", 33, 20);
                    SaveGame.Print(Colour.Purple, "strengths and weaknesses (at lvl 35).", 34, 20);
                    break;

                case RaceId.HalfTroll:
                    SaveGame.Print(Colour.Purple, "Half-Trolls make up for their stupidity by being almost", 29, 20);
                    SaveGame.Print(Colour.Purple, "pure muscle, as strong as creatures much larger than they.", 30, 20);
                    SaveGame.Print(Colour.Purple, "They can't have their strength reduced, and as they grow", 31, 20);
                    SaveGame.Print(Colour.Purple, "stronger they can go into a berserk rage (at lvl 10),", 32, 20);
                    SaveGame.Print(Colour.Purple, "regenerate wounds (at lvl 15), and survive on less food", 33, 20);
                    SaveGame.Print(Colour.Purple, "(at lvl 15).", 34, 20);
                    break;

                case RaceId.HighElf:
                    SaveGame.Print(Colour.Purple, "High-Elves are the leaders of the elven race. They are", 30, 20);
                    SaveGame.Print(Colour.Purple, "more magical than their lesser cousins, but retain their", 31, 20);
                    SaveGame.Print(Colour.Purple, "affinity with nature. High-elves resist light based attacks", 32, 20);
                    SaveGame.Print(Colour.Purple, "and their acute senses are able to see invisible creatures.", 33, 20);
                    break;

                case RaceId.Hobbit:
                    SaveGame.Print(Colour.Purple, "Hobbits are small and surprisingly dextrous given their", 30, 20);
                    SaveGame.Print(Colour.Purple, "propensity for plumpness. They make excellent burglars", 31, 20);
                    SaveGame.Print(Colour.Purple, "and are adept at spell casting too. Hobbits can't have", 32, 20);
                    SaveGame.Print(Colour.Purple, "their dexterity reduced, and they can learn to put together", 33, 20);
                    SaveGame.Print(Colour.Purple, "nourishing meals from the barest scraps (at lvl 15).", 34, 20);
                    break;

                case RaceId.Human:
                    SaveGame.Print(Colour.Purple, "Hopefully you know all about humans already because you", 30, 20);
                    SaveGame.Print(Colour.Purple, "are one! In game terms, humans are the average around which", 31, 20);
                    SaveGame.Print(Colour.Purple, "the other races are measured. As such, humans get no", 32, 20);
                    SaveGame.Print(Colour.Purple, "special abilities, but they increase in level quicker than", 33, 20);
                    SaveGame.Print(Colour.Purple, "any other race. Humans are recommended for new players.", 34, 20);
                    break;

                case RaceId.Imp:
                    SaveGame.Print(Colour.Purple, "Imps are minor demons that have escaped their binding and", 30, 20);
                    SaveGame.Print(Colour.Purple, "are able to run free in the world. Imps naturally resist", 31, 20);
                    SaveGame.Print(Colour.Purple, "fire, and can learn to throw bolt of flame (at lvl 10),", 32, 20);
                    SaveGame.Print(Colour.Purple, "see invisible creatures (at lvl 10), become completely", 33, 20);
                    SaveGame.Print(Colour.Purple, "immune to fire (at lvl 20), and cast fireballs (at lvl 30).", 34, 20);
                    break;

                case RaceId.Klackon:
                    SaveGame.Print(Colour.Purple, "Klackons are humanoid insects. Although most stay safe in", 29, 20);
                    SaveGame.Print(Colour.Purple, "their hive cities, a small number venture forth in search", 30, 20);
                    SaveGame.Print(Colour.Purple, "of adventure. The chitin of a klackon resists acid, and", 31, 20);
                    SaveGame.Print(Colour.Purple, "their ordered minds cannot be confused. They can learn to", 32, 20);
                    SaveGame.Print(Colour.Purple, "spit acid (at lvl 9) and they get progressively faster if", 33, 20);
                    SaveGame.Print(Colour.Purple, "unencumbered by armour.", 34, 20);
                    break;

                case RaceId.Kobold:
                    SaveGame.Print(Colour.Purple, "Kobolds are small reptillian creatures whose claims to be", 30, 20);
                    SaveGame.Print(Colour.Purple, "related to dragons are generally not taken seriously. They", 31, 20);
                    SaveGame.Print(Colour.Purple, "are resistant to poison, and can learn to throw poison", 32, 20);
                    SaveGame.Print(Colour.Purple, "darts (at lvl 9).", 33, 20);
                    break;

                case RaceId.MindFlayer:
                    SaveGame.Print(Colour.Purple, "Mind-Flayers are slimy humanoids with squid-like tentacles", 30, 20);
                    SaveGame.Print(Colour.Purple, "around their mouths. They are all psychic, and neither", 31, 20);
                    SaveGame.Print(Colour.Purple, "their intelligence nor their wisdom can be reduced. They", 32, 20);
                    SaveGame.Print(Colour.Purple, "can learn to see invisible (at lvl 15), blast people's", 33, 20);
                    SaveGame.Print(Colour.Purple, "minds (at lvl 15), and gain telepathy (at lvl 30).", 34, 20);
                    break;

                case RaceId.Nibelung:
                    SaveGame.Print(Colour.Purple, "Nibelungen are also known as dark dwarves and are famous", 30, 20);
                    SaveGame.Print(Colour.Purple, "as the makers of (often cursed) magical items. They can", 31, 20);
                    SaveGame.Print(Colour.Purple, "resist darkness and protect the items they are carrying", 32, 20);
                    SaveGame.Print(Colour.Purple, "from disenchantment. They can also learn to detect traps,", 33, 20);
                    SaveGame.Print(Colour.Purple, "stairs, and secret doors (at lvl 5).", 34, 20);
                    break;

                case RaceId.Skeleton:
                    SaveGame.Print(Colour.Purple, "Skeletons are undead creatures. Being without eyes, they", 30, 20);
                    SaveGame.Print(Colour.Purple, "use magical sight which can see invisible creatures. Their", 31, 20);
                    SaveGame.Print(Colour.Purple, "lack of flesh means that they resist poison and shards, and", 32, 20);
                    SaveGame.Print(Colour.Purple, "their life force is hard to drain. They can learn to resist", 33, 20);
                    SaveGame.Print(Colour.Purple, "cold (at lvl 10), and restore their life force (at lvl 30).", 34, 20);
                    break;

                case RaceId.Spectre:
                    SaveGame.Print(Colour.Purple, "Spectres are ethereal and they can pass through walls and", 29, 20);
                    SaveGame.Print(Colour.Purple, "other obstacles. They resist nether, attacks, poison, and", 30, 20);
                    SaveGame.Print(Colour.Purple, "cold; and they need little food. They also resist having", 31, 20);
                    SaveGame.Print(Colour.Purple, "their life force drained and can see invisible creatures.", 32, 20);
                    SaveGame.Print(Colour.Purple, "Finally, they glow with their own light, can learn to", 33, 20);
                    SaveGame.Print(Colour.Purple, "scare monsters (at lvl 4) and gain telepathy (at lvl 35).", 34, 20);
                    break;

                case RaceId.Sprite:
                    SaveGame.Print(Colour.Purple, "Sprites are tiny fairies, distantly related to elves. They", 29, 20);
                    SaveGame.Print(Colour.Purple, "share their relatives' resistance to light based attacks,", 30, 20);
                    SaveGame.Print(Colour.Purple, "and their wings both protect them from falling damage and", 31, 20);
                    SaveGame.Print(Colour.Purple, "allow them to move progressively faster if unencumbered.", 32, 20);
                    SaveGame.Print(Colour.Purple, "Sprites glow in the dark and can learn to throw fairy dust", 33, 20);
                    SaveGame.Print(Colour.Purple, "to send their enemies to sleep (at lvl 12).", 34, 20);
                    break;

                case RaceId.Vampire:
                    SaveGame.Print(Colour.Purple, "Vampires are powerful undead. They resist darkness, nether,", 30, 20);
                    SaveGame.Print(Colour.Purple, "cold, poison, and having their life force drained. Vampires", 31, 20);
                    SaveGame.Print(Colour.Purple, "produce their own ethereal light in the dark, but are hurt", 32, 20);
                    SaveGame.Print(Colour.Purple, "by direct sunlight. They can learn to drain the life force", 33, 20);
                    SaveGame.Print(Colour.Purple, "from their foes (at lvl 2).", 34, 20);
                    break;

                case RaceId.Yeek:
                    SaveGame.Print(Colour.Purple, "Yeeks are long-eared furry creatures that look vaguely", 30, 20);
                    SaveGame.Print(Colour.Purple, "like humanoid rabbits. Although physically weak, they make", 31, 20);
                    SaveGame.Print(Colour.Purple, "passable spell casters. They are resistant to acid, and can", 32, 20);
                    SaveGame.Print(Colour.Purple, "learn to scream to terrify their foes (at lvl 15) and", 33, 20);
                    SaveGame.Print(Colour.Purple, "become completely immune to acid (at lvl 20).", 34, 20);
                    break;

                case RaceId.Zombie:
                    SaveGame.Print(Colour.Purple, "Zombies are undead creatures. Their decayed flesh resists", 30, 20);
                    SaveGame.Print(Colour.Purple, "nether and poison, and having their life force drained.", 31, 20);
                    SaveGame.Print(Colour.Purple, "Zombies digest food slowly, and can see invisible monsters.", 32, 20);
                    SaveGame.Print(Colour.Purple, "They can learn to restore their life force (at lvl 30).", 33, 20);
                    break;
            }
        }

        private void DisplayRealmInfo(Realm prealm)
        {
            switch (prealm)
            {
                case Realm.Chaos:
                    SaveGame.Print(Colour.Purple, "The Chaos realm is the most destructive realm. It focuses", 30, 20);
                    SaveGame.Print(Colour.Purple, "on combat spells. It is a very good choice for anyone who", 31, 20);
                    SaveGame.Print(Colour.Purple, "wants to be able to damage their foes directly, but is ", 32, 20);
                    SaveGame.Print(Colour.Purple, "somewhat lacking in non-combat spells.", 33, 20);
                    break;

                case Realm.Corporeal:
                    SaveGame.Print(Colour.Purple, "The Corporeal realm contains spells that exclusively affect", 30, 20);
                    SaveGame.Print(Colour.Purple, "the caster's body, although some spells also indirectly", 31, 20);
                    SaveGame.Print(Colour.Purple, "affect other creatures or objects. The corporeal realm is", 32, 20);
                    SaveGame.Print(Colour.Purple, "particularly good at sensing spells.", 33, 20);
                    break;

                case Realm.Death:
                    SaveGame.Print(Colour.Purple, "The Death realm has a combination of life-draining spells,", 30, 20);
                    SaveGame.Print(Colour.Purple, "curses, and undead summoning. Like chaos, it is a very", 31, 20);
                    SaveGame.Print(Colour.Purple, "offensive realm.", 32, 20);
                    break;

                case Realm.Folk:
                    SaveGame.Print(Colour.Purple, "The Folk realm is the least specialised of all the realms.", 30, 20);
                    SaveGame.Print(Colour.Purple, "Folk magic is capable of doing any effect that is possible", 31, 20);
                    SaveGame.Print(Colour.Purple, "in other realms - but usually less effectively than the", 32, 20);
                    SaveGame.Print(Colour.Purple, "specialist realms.", 33, 20);
                    break;

                case Realm.Life:
                    SaveGame.Print(Colour.Purple, "The Life realm is devoted to healing and buffing, with some", 30, 20);
                    SaveGame.Print(Colour.Purple, "offensive capability against undead and demons. It is the", 31, 20);
                    SaveGame.Print(Colour.Purple, "most defensive of the realms.", 32, 20);
                    break;

                case Realm.Nature:
                    SaveGame.Print(Colour.Purple, "The Nature realm has a large number of summoning spells and", 30, 20);
                    SaveGame.Print(Colour.Purple, "miscellaneous spells, but little in the way of offensive", 31, 20);
                    SaveGame.Print(Colour.Purple, "and defensive capabilities.", 32, 20);
                    break;

                case Realm.Sorcery:
                    SaveGame.Print(Colour.Purple, "The Sorcery realm contains spells dealing with raw magic", 30, 20);
                    SaveGame.Print(Colour.Purple, "itself, for example spells dealing with magical items.", 31, 20);
                    SaveGame.Print(Colour.Purple, "It is the premier source of miscellaneous non-combat", 32, 20);
                    SaveGame.Print(Colour.Purple, "utility spells.", 33, 20);
                    break;

                case Realm.Tarot:
                    SaveGame.Print(Colour.Purple, "The Tarot realm is one of the most specialised realms of", 30, 20);
                    SaveGame.Print(Colour.Purple, "all, almost exclusively containing summoning and transport", 31, 20);
                    SaveGame.Print(Colour.Purple, "spells.", 32, 20);
                    break;
            }
        }

        private void DisplayStatBonus(int x, int y, int bonus)
        {
            string buf;
            if (bonus == 0)
            {
                SaveGame.Print(Colour.Black, "+0", y, x);
            }
            else if (bonus < 0)
            {
                buf = bonus.ToString();
                SaveGame.Print(Colour.BrightRed, buf, y, x);
            }
            else
            {
                buf = "+" + bonus;
                SaveGame.Print(Colour.Green, buf, y, x);
            }
        }

        private void GetAhw()
        {
            _player.Age = _player.Race.BaseAge + Program.Rng.DieRoll(_player.Race.AgeRange);
            bool startAtDusk = (_player.RaceIndex == RaceId.Spectre || _player.RaceIndex == RaceId.Zombie || _player.RaceIndex == RaceId.Skeleton || _player.RaceIndex == RaceId.Vampire);
            _player.GameTime = new GameTime(SaveGame, Program.Rng.DieRoll(365), startAtDusk);

            if (_player.GenderIndex == Constants.SexMale)
            {
                _player.Height = Program.Rng.RandomNormal(_player.Race.MaleBaseHeight, _player.Race.MaleHeightRange);
                _player.Weight = Program.Rng.RandomNormal(_player.Race.MaleBaseWeight, _player.Race.MaleWeightRange);
            }
            else if (_player.GenderIndex == Constants.SexFemale)
            {
                _player.Height = Program.Rng.RandomNormal(_player.Race.FemaleBaseHeight, _player.Race.FemaleHeightRange);
                _player.Weight = Program.Rng.RandomNormal(_player.Race.FemaleBaseWeight, _player.Race.FemaleWeightRange);
            }
            else
            {
                if (Program.Rng.DieRoll(2) == 1)
                {
                    _player.Height = Program.Rng.RandomNormal(_player.Race.MaleBaseHeight, _player.Race.MaleHeightRange);
                    _player.Weight = Program.Rng.RandomNormal(_player.Race.MaleBaseWeight, _player.Race.MaleWeightRange);
                }
                else
                {
                    _player.Height = Program.Rng.RandomNormal(_player.Race.FemaleBaseHeight, _player.Race.FemaleHeightRange);
                    _player.Weight = Program.Rng.RandomNormal(_player.Race.FemaleBaseWeight, _player.Race.FemaleWeightRange);
                }
            }
        }

        private void GetExtra()
        {
            int i;
            _player.MaxLevelGained = 1;
            _player.Level = 1;
            _player.ExperienceMultiplier = _player.Race.ExperienceFactor + _player.Profession.ExperienceFactor;
            _player.HitDie = _player.Race.HitDieBonus + _player.Profession.HitDieBonus;
            _player.MaxHealth = _player.HitDie;
            _player.PlayerHp[0] = _player.HitDie;
            int lastroll = _player.HitDie;
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                _player.PlayerHp[i] = lastroll;
                lastroll--;
                if (lastroll < 1)
                {
                    lastroll = _player.HitDie;
                }
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                int j = Program.Rng.DieRoll(Constants.PyMaxLevel - 1);
                lastroll = _player.PlayerHp[i];
                _player.PlayerHp[i] = _player.PlayerHp[j];
                _player.PlayerHp[j] = lastroll;
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                _player.PlayerHp[i] = _player.PlayerHp[i - 1] + _player.PlayerHp[i];
            }
        }

        private void GetMoney()
        {
            int gold = (_player.SocialClass * 6) + Program.Rng.DieRoll(100) + 300;
            for (int i = 0; i < 6; i++)
            {
                if (_player.AbilityScores[i].Adjusted >= 18 + 50)
                {
                    gold -= 300;
                }
                else if (_player.AbilityScores[i].Adjusted >= 18 + 20)
                {
                    gold -= 200;
                }
                else if (_player.AbilityScores[i].Adjusted > 18)
                {
                    gold -= 150;
                }
                else
                {
                    gold -= (_player.AbilityScores[i].Adjusted - 8) * 10;
                }
            }
            if (gold < 100)
            {
                gold = 100;
            }
            _player.Gold = gold;
        }

        private void GetRealmsRandomly()
        {
            int pclas = _player.ProfessionIndex;
            _player.Realm1 = Realm.None;
            _player.Realm2 = Realm.None;
            if (_realmChoices[pclas] == RealmChoice.None)
            {
                return;
            }
            switch (pclas)
            {
                case CharacterClass.WarriorMage:
                    _player.Realm1 = Realm.Folk;
                    break;

                case CharacterClass.Fanatic:
                    _player.Realm1 = Realm.Chaos;
                    break;

                case CharacterClass.Priest:
                    _player.Realm1 = ChooseRealmRandomly(RealmChoice.Life | RealmChoice.Death);
                    break;

                case CharacterClass.Ranger:
                    _player.Realm1 = Realm.Nature;
                    break;

                case CharacterClass.Druid:
                    _player.Realm1 = Realm.Nature;
                    break;

                case CharacterClass.Cultist:
                    _player.Realm1 = Realm.Chaos;
                    break;

                default:
                    _player.Realm1 = ChooseRealmRandomly(_realmChoices[pclas]);
                    break;
            }
            if (pclas == CharacterClass.Paladin || pclas == CharacterClass.Rogue || pclas == CharacterClass.Fanatic ||
                pclas == CharacterClass.Monk || pclas == CharacterClass.HighMage ||
                pclas == CharacterClass.Druid)
            {
                return;
            }
            _player.Realm2 = ChooseRealmRandomly(_realmChoices[pclas]);
            if (_player.ProfessionIndex == CharacterClass.Priest)
            {
                switch (_player.Realm2)
                {
                    case Realm.Nature:
                        _player.Religion.Deity = GodName.Hagarg_Ryonis;
                        break;

                    case Realm.Folk:
                        _player.Religion.Deity = GodName.Zo_Kalar;
                        break;

                    case Realm.Chaos:
                        _player.Religion.Deity = GodName.Nath_Horthah;
                        break;

                    case Realm.Corporeal:
                        _player.Religion.Deity = GodName.Lobon;
                        break;

                    case Realm.Tarot:
                        _player.Religion.Deity = GodName.Tamash;
                        break;

                    default:
                        _player.Religion.Deity = GodName.None;
                        break;
                }
            }
            else
            {
                _player.Religion.Deity = GodName.None;
            }
        }

        private void GetStats()
        {
            int i, j;
            while (true)
            {
                List<int> dice = new List<int>() { 17, 16, 14, 12, 11, 10 };
                for (i = 0; i < 6; i++)
                {
                    int index = Program.Rng.DieRoll(dice.Count) - 1;
                    j = dice[index];
                    dice.RemoveAt(index);
                    _player.AbilityScores[i].InnateMax = j;
                    int bonus = _player.Race.AbilityBonus[i] + _player.Profession.AbilityBonus[i];
                    _player.AbilityScores[i].Innate = _player.AbilityScores[i].InnateMax;
                    _player.AbilityScores[i].Adjusted = _player.AbilityScores[i]
                        .ModifyStatValue(_player.AbilityScores[i].InnateMax, bonus);
                }
                if (_player.AbilityScores[Profession.PrimeStat(_player.ProfessionIndex)].InnateMax > 13)
                {
                    break;
                }
            }
        }

        private void MenuDisplay(int current)
        {
            SaveGame.Clear(30);
            SaveGame.Print(Colour.Orange, "=>", 35, 0);
            for (int i = 0; i < _menuLength; i++)
            {
                int row = 35 + i - current;
                if (row >= 30 && row <= 40)
                {
                    Colour a = Colour.Purple;
                    if (i == current)
                    {
                        a = Colour.Pink;
                    }
                    SaveGame.Print(a, _menuItem[i], row, 2);
                }
            }
        }

        private bool PlayerBirth(ExPlayer ex)
        {
            if (ex == null)
            {
                _prevSex = Constants.SexFemale;
                _prevRace = RaceId.Human;
                _prevClass = CharacterClass.Warrior;
                _prevRealm1 = Realm.None;
                _prevRealm2 = Realm.None;
                _prevName = "Xena";
                _prevGeneration = 0;
            }
            else
            {
                _prevSex = ex.GenderIndex;
                _prevRace = ex.RaceIndexAtBirth;
                _prevClass = ex.ProfessionIndex;
                _prevRealm1 = ex.Realm1;
                _prevRealm2 = ex.Realm2;
                _prevName = ex.Name;
                _prevGeneration = ex.Generation;
            }
            if (!PlayerBirthAux())
            {
                return false;
            }
            _player.RaceIndexAtBirth = _player.RaceIndex;
            SaveGame.Quests.PlayerBirthQuests();
            SaveGame.MessageAdd(" ");
            SaveGame.MessageAdd("  ");
            SaveGame.MessageAdd("====================");
            SaveGame.MessageAdd("  ");
            SaveGame.MessageAdd(" ");
            _player.IsDead = false;
            PlayerOutfit(SaveGame);
            return true;
        }

        /// <summary>
        /// Create a random name for a character based on their race.
        /// </summary>
        /// <param name="raceIndex"> The race for which to generate a name </param>
        /// <returns> The random name </returns>
        private string CreateRandomName(int raceIndex)
        {
            string name = "";
            do
            {
                switch (raceIndex)
                {
                    case RaceId.Cyclops:
                    case RaceId.Dwarf:
                    case RaceId.HalfGiant:
                    case RaceId.Golem:
                    case RaceId.Nibelung:
                        name = _dwarfSyllable1[Program.Rng.RandomLessThan(_dwarfSyllable1.Length)];
                        name += _dwarfSyllable2[Program.Rng.RandomLessThan(_dwarfSyllable2.Length)];
                        name += _dwarfSyllable3[Program.Rng.RandomLessThan(_dwarfSyllable3.Length)];
                        break;

                    case RaceId.DarkElf:
                    case RaceId.Elf:
                    case RaceId.HalfElf:
                    case RaceId.HighElf:
                    case RaceId.Sprite:
                        name = _elfSyllable1[Program.Rng.RandomLessThan(_elfSyllable1.Length)];
                        name += _elfSyllable2[Program.Rng.RandomLessThan(_elfSyllable2.Length)];
                        name += _elfSyllable3[Program.Rng.RandomLessThan(_elfSyllable3.Length)];
                        break;

                    case RaceId.Draconian:
                    case RaceId.Gnome:
                        name = _gnomeSyllable1[Program.Rng.RandomLessThan(_gnomeSyllable1.Length)];
                        name += _gnomeSyllable2[Program.Rng.RandomLessThan(_gnomeSyllable2.Length)];
                        name += _gnomeSyllable3[Program.Rng.RandomLessThan(_gnomeSyllable3.Length)];
                        break;

                    case RaceId.Hobbit:
                    case RaceId.Kobold:
                        name = _hobbitSyllable1[Program.Rng.RandomLessThan(_hobbitSyllable1.Length)];
                        name += _hobbitSyllable2[Program.Rng.RandomLessThan(_hobbitSyllable2.Length)];
                        name += _hobbitSyllable3[Program.Rng.RandomLessThan(_hobbitSyllable3.Length)];
                        break;

                    case RaceId.Yeek:
                        name = _yeekSyllable1[Program.Rng.RandomLessThan(_yeekSyllable1.Length)];
                        name += _yeekSyllable2[Program.Rng.RandomLessThan(_yeekSyllable2.Length)];
                        name += _yeekSyllable3[Program.Rng.RandomLessThan(_yeekSyllable3.Length)];
                        break;

                    case RaceId.Great:
                    case RaceId.HalfTitan:
                    case RaceId.Human:
                    case RaceId.Skeleton:
                    case RaceId.Spectre:
                    case RaceId.Vampire:
                    case RaceId.Zombie:
                        name = _humanSyllable1[Program.Rng.RandomLessThan(_humanSyllable1.Length)];
                        name += _humanSyllable2[Program.Rng.RandomLessThan(_humanSyllable2.Length)];
                        name += _humanSyllable3[Program.Rng.RandomLessThan(_humanSyllable3.Length)];
                        break;

                    case RaceId.HalfOgre:
                    case RaceId.HalfOrc:
                    case RaceId.HalfTroll:
                        name = _orcSyllable1[Program.Rng.RandomLessThan(_orcSyllable1.Length)];
                        name += _orcSyllable2[Program.Rng.RandomLessThan(_orcSyllable2.Length)];
                        name += _orcSyllable3[Program.Rng.RandomLessThan(_orcSyllable3.Length)];
                        break;

                    case RaceId.Klackon:
                        name = _klackonSyllable1[Program.Rng.RandomLessThan(_klackonSyllable1.Length)];
                        name += _klackonSyllable2[Program.Rng.RandomLessThan(_klackonSyllable2.Length)];
                        name += _klackonSyllable3[Program.Rng.RandomLessThan(_klackonSyllable3.Length)];
                        break;

                    case RaceId.MiriNigri:
                    case RaceId.MindFlayer:
                    case RaceId.TchoTcho:
                        name = _cthuloidSyllable1[Program.Rng.RandomLessThan(_cthuloidSyllable1.Length)];
                        name += _cthuloidSyllable2[Program.Rng.RandomLessThan(_cthuloidSyllable2.Length)];
                        name += _cthuloidSyllable3[Program.Rng.RandomLessThan(_cthuloidSyllable3.Length)];
                        break;

                    case RaceId.Imp:
                        name = _angelSyllable1[Program.Rng.RandomLessThan(_angelSyllable1.Length)];
                        name += _angelSyllable2[Program.Rng.RandomLessThan(_angelSyllable2.Length)];
                        name += _angelSyllable3[Program.Rng.RandomLessThan(_angelSyllable3.Length)];
                        break;
                }
            } while (name.Length > 12);
            return name;
        }

        private bool PlayerBirthAux()
        {
            int i;
            int stage = 0;
            int[] menu = new int[9];
            bool[] autoChose = new bool[8];
            Realm[] realmChoice = new Realm[8];
            for (i = 0; i < 8; i++)
            {
                menu[i] = 0;
            }
            menu[BirthStage.ClassSelection] = 14;
            menu[BirthStage.RaceSelection] = 16;
            SaveGame.Clear();
            int viewMode = 1;
            while (true)
            {
                char c;
                switch (stage)
                {
                    case BirthStage.Introduction:
                        _player.Religion.Deity = GodName.None;
                        for (i = 0; i < 8; i++)
                        {
                            autoChose[i] = false;
                        }
                        _menuItem[0] = "Choose";
                        _menuItem[1] = "Random";
                        _menuItem[2] = "Re-use";
                        _menuLength = 3;
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        switch (menu[stage])
                        {
                            case 0:
                                SaveGame.Print(Colour.Purple, "Choose your character's race, sex, and class; and select", 35,
                                    20);
                                SaveGame.Print(Colour.Purple, "which realms of magic your character will use.", 36, 20);
                                break;

                            case 1:
                                SaveGame.Print(Colour.Purple, "Let the game generate a character for you randomly.", 35, 20);
                                break;

                            case 2:
                                SaveGame.Print(Colour.Purple, "Re-play with a character similar to the one you played", 35,
                                    20);
                                SaveGame.Print(Colour.Purple, "last time.", 36, 20);
                                break;
                        }
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                return false;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        break;

                    case BirthStage.ClassSelection:
                        _player.Religion.Deity = GodName.None;
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            _player.ProfessionIndex = _prevClass;
                            _player.Profession = Profession.ClassInfo[_player.ProfessionIndex];
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            _player.ProfessionIndex = Program.Rng.RandomLessThan(Constants.MaxClass);
                            _player.Profession = Profession.ClassInfo[_player.ProfessionIndex];
                            stage++;
                            break;
                        }
                        autoChose[stage] = false;
                        _menuLength = Constants.MaxClass;
                        for (i = 0; i < Constants.MaxClass; i++)
                        {
                            _menuItem[i] = _classMenu[i].Text;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayClassInfo(_classMenu[menu[stage]].Index);
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        if (stage > BirthStage.ClassSelection)
                        {
                            _player.ProfessionIndex = _classMenu[menu[BirthStage.ClassSelection]].Index;
                            _player.Profession = Profession.ClassInfo[_player.ProfessionIndex];
                        }
                        break;

                    case BirthStage.RaceSelection:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            _player.RaceIndex = _prevRace;
                            _player.GetFirstLevelMutation = _player.RaceIndex == RaceId.MiriNigri;
                            _player.Race = Race.RaceInfo[_player.RaceIndex];
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            do
                            {
                                int k = Program.Rng.RandomLessThan(Constants.MaxRaces);
                                _player.GetFirstLevelMutation = k == RaceId.MiriNigri;
                                _player.RaceIndex = k;
                                _player.Race = Race.RaceInfo[_player.RaceIndex];
                            }
                            while ((_player.Race.Choice & (1L << _player.ProfessionIndex)) == 0);
                            stage++;
                            break;
                        }
                        autoChose[stage] = false;
                        _menuLength = Constants.MaxRaces;
                        for (i = 0; i < Constants.MaxRaces; i++)
                        {
                            _menuItem[i] = _raceMenu[i].Text;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayRaceInfo(_raceMenu[menu[stage]].Index);
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        if (stage > BirthStage.RaceSelection)
                        {
                            _player.RaceIndex = _raceMenu[menu[BirthStage.RaceSelection]].Index;
                            _player.Race = Race.RaceInfo[_player.RaceIndex];
                            _player.GetFirstLevelMutation = _player.RaceIndex == RaceId.MiriNigri;
                        }
                        break;

                    case BirthStage.RealmSelection1:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            _player.Realm1 = _prevRealm1;
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            GetRealmsRandomly();
                            stage++;
                            break;
                        }
                        switch (_player.ProfessionIndex)
                        {
                            case CharacterClass.Cultist:
                            case CharacterClass.Fanatic:
                                autoChose[stage] = true;
                                _player.Realm1 = Realm.Chaos;
                                stage++;
                                break;

                            case CharacterClass.WarriorMage:
                                autoChose[stage] = true;
                                _player.Realm1 = Realm.Folk;
                                stage++;
                                break;

                            case CharacterClass.Druid:
                            case CharacterClass.Ranger:
                                autoChose[stage] = true;
                                _player.Realm1 = Realm.Nature;
                                stage++;
                                break;

                            case CharacterClass.Paladin:
                            case CharacterClass.Priest:
                                realmChoice[0] = Realm.Life;
                                realmChoice[1] = Realm.Death;
                                _menuLength = 2;
                                break;

                            case CharacterClass.Rogue:
                                realmChoice[0] = Realm.Death;
                                realmChoice[1] = Realm.Sorcery;
                                realmChoice[2] = Realm.Tarot;
                                realmChoice[3] = Realm.Folk;
                                _menuLength = 4;
                                break;

                            case CharacterClass.HighMage:
                            case CharacterClass.Mage:
                                realmChoice[0] = Realm.Life;
                                realmChoice[1] = Realm.Death;
                                realmChoice[2] = Realm.Nature;
                                realmChoice[3] = Realm.Sorcery;
                                realmChoice[4] = Realm.Corporeal;
                                realmChoice[5] = Realm.Tarot;
                                realmChoice[6] = Realm.Chaos;
                                realmChoice[7] = Realm.Folk;
                                _menuLength = 8;
                                break;

                            case CharacterClass.Monk:
                                realmChoice[0] = Realm.Corporeal;
                                realmChoice[1] = Realm.Tarot;
                                realmChoice[2] = Realm.Chaos;
                                _menuLength = 3;
                                break;

                            case CharacterClass.ChosenOne:
                            case CharacterClass.Channeler:
                            case CharacterClass.Mindcrafter:
                            case CharacterClass.Mystic:
                            case CharacterClass.Warrior:
                                autoChose[stage] = true;
                                _player.Realm1 = Realm.None;
                                stage++;
                                break;
                        }
                        if (stage > BirthStage.RealmSelection1)
                        {
                            break;
                        }
                        autoChose[stage] = false;
                        for (i = 0; i < _menuLength; i++)
                        {
                            _menuItem[i] = Spellcasting.RealmName(realmChoice[i]);
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayRealmInfo(realmChoice[menu[stage]]);
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        if (stage > BirthStage.RealmSelection1)
                        {
                            _player.Realm1 = realmChoice[menu[BirthStage.RealmSelection1]];
                        }
                        break;

                    case BirthStage.RealmSelection2:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            _player.Realm2 = _prevRealm2;
                            if (_player.ProfessionIndex == CharacterClass.Priest)
                            {
                                switch (_player.Realm2)
                                {
                                    case Realm.Nature:
                                        _player.Religion.Deity = GodName.Hagarg_Ryonis;
                                        break;

                                    case Realm.Folk:
                                        _player.Religion.Deity = GodName.Zo_Kalar;
                                        break;

                                    case Realm.Chaos:
                                        _player.Religion.Deity = GodName.Nath_Horthah;
                                        break;

                                    case Realm.Corporeal:
                                        _player.Religion.Deity = GodName.Lobon;
                                        break;

                                    case Realm.Tarot:
                                        _player.Religion.Deity = GodName.Tamash;
                                        break;

                                    default:
                                        _player.Religion.Deity = GodName.None;
                                        break;
                                }
                            }
                            else
                            {
                                _player.Religion.Deity = GodName.None;
                            }
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            stage++;
                            break;
                        }
                        _player.Realm2 = Realm.None;
                        switch (_player.ProfessionIndex)
                        {
                            case CharacterClass.ChosenOne:
                            case CharacterClass.Channeler:
                            case CharacterClass.Mindcrafter:
                            case CharacterClass.Warrior:
                            case CharacterClass.Fanatic:
                            case CharacterClass.HighMage:
                            case CharacterClass.Paladin:
                            case CharacterClass.Rogue:
                            case CharacterClass.Monk:
                            case CharacterClass.Mystic:
                            case CharacterClass.Druid:
                                autoChose[stage] = true;
                                _player.Realm2 = Realm.None;
                                stage++;
                                break;

                            case CharacterClass.Cultist:
                            case CharacterClass.WarriorMage:
                            case CharacterClass.Ranger:
                            case CharacterClass.Priest:
                            case CharacterClass.Mage:
                                _menuLength = 0;
                                int realmFilter = _realmChoices[_player.ProfessionIndex];
                                if ((realmFilter & RealmChoice.Life) != 0 && _player.Realm1 != Realm.Life)
                                {
                                    realmChoice[_menuLength] = Realm.Life;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Death) != 0 && _player.Realm1 != Realm.Death)
                                {
                                    realmChoice[_menuLength] = Realm.Death;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Nature) != 0 && _player.Realm1 != Realm.Nature)
                                {
                                    realmChoice[_menuLength] = Realm.Nature;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Sorcery) != 0 && _player.Realm1 != Realm.Sorcery)
                                {
                                    realmChoice[_menuLength] = Realm.Sorcery;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Corporeal) != 0 && _player.Realm1 != Realm.Corporeal)
                                {
                                    realmChoice[_menuLength] = Realm.Corporeal;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Tarot) != 0 && _player.Realm1 != Realm.Tarot)
                                {
                                    realmChoice[_menuLength] = Realm.Tarot;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Chaos) != 0 && _player.Realm1 != Realm.Chaos)
                                {
                                    realmChoice[_menuLength] = Realm.Chaos;
                                    _menuLength++;
                                }
                                if ((realmFilter & RealmChoice.Folk) != 0 && _player.Realm1 != Realm.Folk)
                                {
                                    realmChoice[_menuLength] = Realm.Folk;
                                    _menuLength++;
                                }
                                break;
                        }
                        if (stage > BirthStage.RealmSelection2)
                        {
                            break;
                        }
                        autoChose[stage] = false;
                        for (i = 0; i < _menuLength; i++)
                        {
                            _menuItem[i] = Spellcasting.RealmName(realmChoice[i]);
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayRealmInfo(realmChoice[menu[stage]]);
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        if (stage > BirthStage.RealmSelection2)
                        {
                            _player.Realm2 = realmChoice[menu[BirthStage.RealmSelection2]];
                            if (_player.ProfessionIndex == CharacterClass.Priest)
                            {
                                switch (_player.Realm2)
                                {
                                    case Realm.Nature:
                                        _player.Religion.Deity = GodName.Hagarg_Ryonis;
                                        break;

                                    case Realm.Folk:
                                        _player.Religion.Deity = GodName.Zo_Kalar;
                                        break;

                                    case Realm.Chaos:
                                        _player.Religion.Deity = GodName.Nath_Horthah;
                                        break;

                                    case Realm.Corporeal:
                                        _player.Religion.Deity = GodName.Lobon;
                                        break;

                                    case Realm.Tarot:
                                        _player.Religion.Deity = GodName.Tamash;
                                        break;

                                    default:
                                        _player.Religion.Deity = GodName.None;
                                        break;
                                }
                            }
                            else
                            {
                                _player.Religion.Deity = GodName.None;
                            }
                        }
                        break;

                    case BirthStage.GenderSelection:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            _player.GenderIndex = _prevSex;
                            _player.Gender = _sexInfo[_player.GenderIndex];
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            _player.GenderIndex = Program.Rng.RandomBetween(0, 1);
                            _player.Gender = _sexInfo[_player.GenderIndex];
                            stage++;
                            break;
                        }
                        _menuLength = Constants.MaxGenders;
                        for (i = 0; i < Constants.MaxGenders; i++)
                        {
                            _menuItem[i] = _sexInfo[i].Title;
                        }
                        DisplayPartialCharacter(stage);
                        autoChose[stage] = false;
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        SaveGame.Print(Colour.Purple, "Your sex has no effect on gameplay.", 35, 21);
                        SaveGame.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true)
                        {
                            c = SaveGame.Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        if (stage > BirthStage.GenderSelection)
                        {
                            _player.GenderIndex = menu[BirthStage.GenderSelection];
                            _player.Gender = _sexInfo[_player.GenderIndex];
                        }
                        break;

                    case BirthStage.Confirmation:
                        if (menu[0] != Constants.GenerateReplay)
                        {
                            _player.Name = CreateRandomName(_player.RaceIndex);
                            _player.Generation = 1;
                        }
                        else
                        {
                            _player.Name = string.IsNullOrEmpty(_prevName) ? CreateRandomName(_player.RaceIndex) : _prevName;
                            _player.Generation = _prevGeneration + 1;
                        }
                        GetStats();
                        GetExtra();
                        GetAhw();
                        GetHistory(_player);
                        GetMoney();
                        _player.Spellcasting = new Spellcasting(_player);
                        _player.GooPatron =
                            SaveGame.PatronList[Program.Rng.DieRoll(SaveGame.PatronList.Length) - 1];
                        _player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses | UpdateFlags.UpdateHealth);
                        SaveGame.Player = _player;
                        SaveGame.UpdateStuff();
                        SaveGame.Player = null;
                        _player.Health = _player.MaxHealth;
                        _player.Mana = _player.MaxMana;
                        _player.Energy = 150;
                        CharacterViewer characterViewer = new CharacterViewer(SaveGame, _player);
                        while (true)
                        {
                            characterViewer.DisplayPlayer();
                            SaveGame.Print(Colour.Orange,
                                "[Use return to confirm, or left to go back.]", 43, 1);
                            c = SaveGame.Inkey();
                            if (c == 13)
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == '8')
                            {
                                viewMode++;
                                if (viewMode > 1)
                                {
                                    viewMode = 0;
                                }
                            }
                            if (c == '2')
                            {
                                viewMode--;
                                if (viewMode < 0)
                                {
                                    viewMode = 1;
                                }
                            }
                            if (c == 'h')
                            {
                                SaveGame.ShowManual();
                            }
                        }
                        break;

                    case BirthStage.Naming:
                        _player.InputPlayerName();
                        return true;
                }
            }
        }

        private void PlayerOutfit(SaveGame saveGame)
        {
            Item item = new Item(saveGame);
            
            if (_player.RaceIndex == RaceId.Golem || _player.RaceIndex == RaceId.Skeleton || _player.RaceIndex == RaceId.Zombie ||
                _player.RaceIndex == RaceId.Vampire || _player.RaceIndex == RaceId.Spectre)
            {
                item.AssignItemType(new ScrollSatisfyHunger());
                item.Count = (char)Program.Rng.RandomBetween(2, 5);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                item.IdentStoreb = true;
                _player.Inventory.InvenCarry(item, false);
                item = new Item(saveGame);
            }
            else
            {
                item.AssignItemType(new FoodRation());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                _player.Inventory.InvenCarry(item, false);
                item = new Item(saveGame);
            }
            if (_player.RaceIndex == RaceId.Vampire || _player.RaceIndex == RaceId.Spectre ||
                _player.ProfessionIndex == CharacterClass.ChosenOne)
            {
                item.AssignItemType(new ScrollLight());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                item.IdentStoreb = true;
                _player.Inventory.InvenCarry(item, false);
            }
            else
            {
                item.AssignItemType(new LightWoodenTorch());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.TypeSpecificValue = Program.Rng.RandomBetween(3, 7) * 500;
                item.BecomeFlavourAware();
                item.BecomeKnown();
                _player.Inventory.InvenCarry(item, false);
                Item carried = new Item(saveGame, item) { Count = 1 };
                _player.Inventory[InventorySlot.Lightsource] = carried;
                _player.WeightCarried += carried.Weight;
            }

            ItemClass[][] _playerInit = new ItemClass[16][];
            _playerInit[CharacterClass.Warrior] = new ItemClass[]
            {
                new RingFearResistance(),
                new SwordBroadSword(),
                new HardArmorChainMail()
            };
            _playerInit[CharacterClass.Mage] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordDagger(),
                new DeathBookBlackPrayers()
            };
            _playerInit[CharacterClass.Priest] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new HaftedMace(),
                new DeathBookBlackPrayers()
            };
            _playerInit[CharacterClass.Rogue] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordDagger(),
                new SoftArmorSoftLeatherArmour()
            };
            _playerInit[CharacterClass.Ranger] = new ItemClass[]
            {
                new NatureBookCallOfTheWild(),
                new SwordBroadSword(),
                new DeathBookBlackPrayers()
            };
            _playerInit[CharacterClass.Paladin] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordBroadSword(),
                new ScrollProtectionFromEvil()
            };
            _playerInit[CharacterClass.WarriorMage] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordShortSword(),
                new DeathBookBlackPrayers()
            };
            _playerInit[CharacterClass.Fanatic] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordBroadSword(),
                new HardArmorMetalScaleMail()
            };
            _playerInit[CharacterClass.Monk] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new PotionHealing(),
                new SoftArmorSoftLeatherArmour()
            };
            _playerInit[CharacterClass.Mindcrafter] = new ItemClass[]
            {
                new SwordSmallSword(),
                new PotionRestoreMana(),
                new SoftArmorSoftLeatherArmour()
            };
            _playerInit[CharacterClass.HighMage] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new SwordDagger(),
                new RingSustainIntelligence()
            };
            _playerInit[CharacterClass.Druid] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new HaftedQuarterstaff(),
                new RingSustainWisdom()
            };
            _playerInit[CharacterClass.Cultist] = new ItemClass[]
            {
                new SorceryBookBeginnersHandbook(),
                new RingSustainIntelligence(),
                new DeathBookBlackPrayers()
            };
            _playerInit[CharacterClass.Channeler] = new ItemClass[]
            {
                new WandMagicMissile(),
                new SwordDagger(),
                new RingSustainCharisma()
            };
            _playerInit[CharacterClass.ChosenOne] = new ItemClass[]
            {
                new SwordSmallSword(),
                new PotionHealing(),
                new SoftArmorSoftLeatherArmour()
            };
            _playerInit[CharacterClass.Mystic] = new ItemClass[]
            {
                new RingSustainWisdom(),
                new PotionHealing(),
                new SoftArmorSoftLeatherArmour()
            };

            ItemClass[] startingItems = _playerInit[_player.ProfessionIndex];
            for (int i = 0; i < startingItems.Length; i++)
            {
                ItemClass baseItemCategory = startingItems[i];

                if (baseItemCategory.GetType().Name == "RingFearResistance" && _player.RaceIndex == RaceId.TchoTcho)
                {
                    baseItemCategory = new RingSustainStrength();
                }
                item = new Item(saveGame);
                item.AssignItemType(baseItemCategory);
                if (baseItemCategory.CategoryEnum == ItemCategory.Sword && _player.ProfessionIndex == CharacterClass.Rogue && _player.Realm1 == Realm.Death)
                {
                    item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                }
                if (baseItemCategory.CategoryEnum == ItemCategory.Wand)
                {
                    item.TypeSpecificValue = 1;
                }
                item.IdentStoreb = true;
                item.BecomeFlavourAware();
                item.BecomeKnown();
                int slot = _player.Inventory.WieldSlot(item);
                if (slot == -1)
                {
                    _player.Inventory.InvenCarry(item, false);
                }
                else
                {
                    _player.Inventory[slot] = item;
                    _player.WeightCarried += item.Weight;
                }
            }
        }

        /// <summary>
        /// List of backstory fragments joined together on character generation
        /// </summary>
        private readonly PlayerHistory[] _backgroundTable =
        {
            // Group 1: Human start /Half-Elf legitimacy 1->2->3->50->51->52->53->End
            new PlayerHistory("You are the illegitimate and unacknowledged child ", 10, 1, 2, 25),
            new PlayerHistory("You are the illegitimate but acknowledged child ", 20, 1, 2, 35),
            new PlayerHistory("You are one of several children ", 95, 1, 2, 45),
            new PlayerHistory("You are the first child ", 100, 1, 2, 50),
            // Group 2: Human/Half-Elf/Half-Orc/Half-Ogre/Half-Giant/Half-Titan parent 2->3->50->51->52->53->End
            new PlayerHistory("of a Serf. ", 40, 2, 3, 65),
            new PlayerHistory("of a Yeoman. ", 65, 2, 3, 80),
            new PlayerHistory("of a Townsman. ", 80, 2, 3, 90),
            new PlayerHistory("of a Guildsman. ", 90, 2, 3, 105),
            new PlayerHistory("of a Landed Knight. ", 96, 2, 3, 120),
            new PlayerHistory("of a Noble Family. ", 99, 2, 3, 130),
            new PlayerHistory("of the Royal Blood Line. ", 100, 2, 3, 140),
            // Group 3: Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan
            // childhood 3->50->51->52->53->End
            new PlayerHistory("You are the black sheep of the family. ", 20, 3, 50, 20),
            new PlayerHistory("You are a credit to the family. ", 80, 3, 50, 55),
            new PlayerHistory("You are a well liked child. ", 100, 3, 50, 60),
            // Group 4: Half-Elf start 4->1->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was of the Teleri. ", 40, 4, 1, 50),
            new PlayerHistory("Your father was of the Teleri. ", 75, 4, 1, 55),
            new PlayerHistory("Your mother was of the Noldor. ", 90, 4, 1, 55),
            new PlayerHistory("Your father was of the Noldor. ", 95, 4, 1, 60),
            new PlayerHistory("Your mother was of the Vanyar. ", 98, 4, 1, 65),
            new PlayerHistory("Your father was of the Vanyar. ", 100, 4, 1, 70),
            // Group 7: Elf/High-Elf start 7->8->9->54->55->56->End
            new PlayerHistory("You are one of several children ", 60, 7, 8, 50),
            new PlayerHistory("You are the only child ", 100, 7, 8, 55),
            // Group 8: Elf/High-Elf ancestry 8->9->54->55->56->End
            new PlayerHistory("of a Teleri ", 75, 8, 9, 50),
            new PlayerHistory("of a Noldor ", 95, 8, 9, 55),
            new PlayerHistory("of a Vanyar ", 100, 8, 9, 60),
            // Group 9: Elf/High-Elf parent 9->54->55->56->End
            new PlayerHistory("Ranger. ", 40, 9, 54, 80),
            new PlayerHistory("Archer. ", 70, 9, 54, 90),
            new PlayerHistory("Warrior. ", 87, 9, 54, 110),
            new PlayerHistory("Mage. ", 95, 9, 54, 125),
            new PlayerHistory("Prince. ", 99, 9, 54, 140),
            new PlayerHistory("King. ", 100, 9, 54, 145),
            // Group 10: Hobbit start 10->11->3->50->51->52->53->End
            new PlayerHistory("You are one of several children of a Hobbit ", 85, 10, 11, 45),
            new PlayerHistory("You are the only child of a Hobbit ", 100, 10, 11, 55),
            // Group 11: Hobbit parent 11->3->50->51->52->53->End
            new PlayerHistory("Bum. ", 20, 11, 3, 55),
            new PlayerHistory("Tavern Owner. ", 30, 11, 3, 80),
            new PlayerHistory("Miller. ", 40, 11, 3, 90),
            new PlayerHistory("Home Owner. ", 50, 11, 3, 100),
            new PlayerHistory("Burglar. ", 80, 11, 3, 110),
            new PlayerHistory("Warrior. ", 95, 11, 3, 115),
            new PlayerHistory("Mage. ", 99, 11, 3, 125),
            new PlayerHistory("Clan Elder. ", 100, 11, 3, 140),
            // Group 13: Gnome start 13->14->3->50->51->52->53->End
            new PlayerHistory("You are one of several children of a Gnome ", 85, 13, 14, 45),
            new PlayerHistory("You are the only child of a Gnome ", 100, 13, 14, 55),
            // Group 14: Gnome parent 14->3->50->51->52->53->End
            new PlayerHistory("Beggar. ", 20, 14, 3, 55),
            new PlayerHistory("Braggart. ", 50, 14, 3, 70),
            new PlayerHistory("Prankster. ", 75, 14, 3, 85),
            new PlayerHistory("Warrior. ", 95, 14, 3, 100),
            new PlayerHistory("Mage. ", 100, 14, 3, 125),
            // Group 16: Dwarf start 16->17->18->57->58->59->60->61->End
            new PlayerHistory("You are one of two children of a Dwarven ", 25, 16, 17, 40),
            new PlayerHistory("You are the only child of a Dwarven ", 100, 16, 17, 50),
            // Group 17: Dwarf parent 17->18->57->58->59->60->61->End
            new PlayerHistory("Thief. ", 10, 17, 18, 60),
            new PlayerHistory("Prison Guard. ", 25, 17, 18, 75),
            new PlayerHistory("Miner. ", 75, 17, 18, 90),
            new PlayerHistory("Warrior. ", 90, 17, 18, 110),
            new PlayerHistory("Priest. ", 99, 17, 18, 130),
            new PlayerHistory("King. ", 100, 17, 18, 150),
            // Group 18: Dwarf/Nibelung childhood 18->57->58->59->60->61->End
            new PlayerHistory("You are the black sheep of the family. ", 15, 18, 57, 10),
            new PlayerHistory("You are a credit to the family. ", 85, 18, 57, 50),
            new PlayerHistory("You are a well liked child. ", 100, 18, 57, 55),
            // Group 19: Half-Orc start 19->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was an Orc, but it is unacknowledged. ", 25, 19, 20, 25),
            new PlayerHistory("Your mother was an Orc. ", 50, 19, 20, 25),
            new PlayerHistory("Your father was an Orc. ", 75, 19, 20, 25),
            new PlayerHistory("Your father was an Orc, but it is unacknowledged. ", 100, 19, 20, 25),
            // Group 20: Half-Orc/Half-Ogre/Half-Giant/Half-Titan adoption 20->2->3->50->51->52->53->End
            new PlayerHistory("You are the child ", 80, 20, 2, 50),
            new PlayerHistory("You are the adopted child ", 100, 20, 2, 50),
            // Group 22: Half-Troll start 22->23->62->63->64->65->66->End
            new PlayerHistory("Your mother was a Cave-Troll ", 30, 22, 23, 20),
            new PlayerHistory("Your father was a Cave-Troll ", 60, 22, 23, 25),
            new PlayerHistory("Your mother was a Hill-Troll ", 75, 22, 23, 30),
            new PlayerHistory("Your father was a Hill-Troll ", 90, 22, 23, 35),
            new PlayerHistory("Your mother was a Water-Troll ", 95, 22, 23, 40),
            new PlayerHistory("Your father was a Water-Troll ", 100, 22, 23, 45),
            // Group 23: Half-Troll parent 23->62->63->64->65->66->End
            new PlayerHistory("Cook. ", 5, 23, 62, 60),
            new PlayerHistory("Warrior. ", 95, 23, 62, 55),
            new PlayerHistory("Priest. ", 99, 23, 62, 65),
            new PlayerHistory("Clan Chief. ", 100, 23, 62, 80),
            // Group 24: Kobold scales 24->25->26->End
            new PlayerHistory("You have green scales, ", 25, 24, 25, 50),
            new PlayerHistory("You have dark green scales, ", 50, 24, 25, 50),
            new PlayerHistory("You have yellow scales, ", 75, 24, 25, 50),
            new PlayerHistory("You have green scales, a yellow belly, ", 100, 24, 25, 50),
            // Group 25: Kobold eyes 25->26->End
            new PlayerHistory("bright eyes, ", 25, 25, 26, 50),
            new PlayerHistory("yellow eyes, ", 50, 25, 26, 50),
            new PlayerHistory("red eyes, ", 75, 25, 26, 50),
            new PlayerHistory("snake-like eyes, ", 100, 25, 26, 50),
            // Group 26: Kobold tail 26->End
            new PlayerHistory("and a long sinuous tail.", 20, 26, 0, 50),
            new PlayerHistory("and a short tail.", 40, 26, 0, 50),
            new PlayerHistory("and a muscular tail.", 60, 26, 0, 50),
            new PlayerHistory("and a long tail.", 80, 26, 0, 50),
            new PlayerHistory("and a sinuous tail.", 100, 26, 0, 50),
            // Group 50: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan eyes 50->51->52->53->End
            new PlayerHistory("You have dark brown eyes, ", 20, 50, 51, 50),
            new PlayerHistory("You have brown eyes, ", 60, 50, 51, 50),
            new PlayerHistory("You have hazel eyes, ", 70, 50, 51, 50),
            new PlayerHistory("You have green eyes, ", 80, 50, 51, 50),
            new PlayerHistory("You have blue eyes, ", 90, 50, 51, 50),
            new PlayerHistory("You have blue-gray eyes, ", 100, 50, 51, 50),
            // Group 51: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan hairstyle 51->52->53->End
            new PlayerHistory("straight ", 70, 51, 52, 50),
            new PlayerHistory("wavy ", 90, 51, 52, 50),
            new PlayerHistory("curly ", 100, 51, 52, 50),
            // Group 52: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan hair colour 52->53->End
            new PlayerHistory("black hair, ", 30, 52, 53, 50),
            new PlayerHistory("brown hair, ", 70, 52, 53, 50),
            new PlayerHistory("auburn hair, ", 80, 52, 53, 50),
            new PlayerHistory("red hair, ", 90, 52, 53, 50),
            new PlayerHistory("blond hair, ", 100, 52, 53, 50),
            // Group 53: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan complexion 53->End
            new PlayerHistory("and a very dark complexion.", 10, 53, 0, 50),
            new PlayerHistory("and a dark complexion.", 30, 53, 0, 50),
            new PlayerHistory("and an olive complexion.", 80, 53, 0, 50),
            new PlayerHistory("and a pale complexion.", 90, 53, 0, 50),
            new PlayerHistory("and a very pale complexion.", 100, 53, 0, 50),
            // Group 54: Elf/High-Elf eyes 54->55->56->End
            new PlayerHistory("You have light grey eyes, ", 85, 54, 55, 50),
            new PlayerHistory("You have light blue eyes, ", 95, 54, 55, 50),
            new PlayerHistory("You have light green eyes, ", 100, 54, 55, 50),
            // Group 55: Elf/High-Elf hairstyle 55->56->End
            new PlayerHistory("straight ", 75, 55, 56, 50),
            new PlayerHistory("wavy ", 100, 55, 56, 50),
            // Group 56: Elf/High-Elf colour 56->End
            new PlayerHistory("black hair, and a pale complexion.", 75, 56, 0, 50),
            new PlayerHistory("brown hair, and a pale complexion.", 85, 56, 0, 50),
            new PlayerHistory("blond hair, and a pale complexion.", 95, 56, 0, 50),
            new PlayerHistory("silver hair, and a pale complexion.", 100, 56, 0, 50),
            // Group 57: Dwarf/Nibelung eyes 57->58->59->60->61->End
            new PlayerHistory("You have dark brown eyes, ", 99, 57, 58, 50),
            new PlayerHistory("You have glowing red eyes, ", 100, 57, 58, 60),
            // Group 58: Dwarf/Nibelung hairstyle 58->59->60->61->End
            new PlayerHistory("straight ", 90, 58, 59, 50),
            new PlayerHistory("wavy ", 100, 58, 59, 50),
            // Group 59: Dwarf/Nibelung hair colour 59->60->61->End
            new PlayerHistory("black hair, ", 75, 59, 60, 50),
            new PlayerHistory("brown hair, ", 100, 59, 60, 50),
            // Group 60: Dwarf/Nibelung beard 60->61->End
            new PlayerHistory("a one foot beard, ", 25, 60, 61, 50),
            new PlayerHistory("a two foot beard, ", 60, 60, 61, 51),
            new PlayerHistory("a three foot beard, ", 90, 60, 61, 53),
            new PlayerHistory("a four foot beard, ", 100, 60, 61, 55),
            // Group 61: Dwarf/Nibelung complexion 61->End
            new PlayerHistory("and a dark complexion.", 100, 61, 0, 50),
            // Group 62: Half-Troll/Zombie eyes 62->63->64->65->66->End
            new PlayerHistory("You have slime green eyes, ", 60, 62, 63, 50),
            new PlayerHistory("You have puke yellow eyes, ", 85, 62, 63, 50),
            new PlayerHistory("You have blue-bloodshot eyes, ", 99, 62, 63, 50),
            new PlayerHistory("You have glowing red eyes, ", 100, 62, 63, 55),
            // Group 63: Half-Troll/Zombie hairstyle 63->64->65->66->End
            new PlayerHistory("dirty ", 33, 63, 64, 50),
            new PlayerHistory("mangy ", 66, 63, 64, 50),
            new PlayerHistory("oily ", 100, 63, 64, 50),
            // Group 64: Half-Troll/Zombie hair 64->65->66->End
            new PlayerHistory("sea-weed green hair, ", 33, 64, 65, 50),
            new PlayerHistory("bright red hair, ", 66, 64, 65, 50),
            new PlayerHistory("dark purple hair, ", 100, 64, 65, 50),
            // Group 65: Half-Troll/Zombie skin colour 65->66->End
            new PlayerHistory("and green ", 25, 65, 66, 50),
            new PlayerHistory("and blue ", 50, 65, 66, 50),
            new PlayerHistory("and white ", 75, 65, 66, 50),
            new PlayerHistory("and black ", 100, 65, 66, 50),
            // Group 66: Half-Troll/Zombie skin texture 66->End
            new PlayerHistory("ulcerous skin.", 33, 66, 0, 50),
            new PlayerHistory("scabby skin.", 66, 66, 0, 50),
            new PlayerHistory("leprous skin.", 100, 66, 0, 50),
            // Group 67: Great One start 67->68->50->51->52->53->End
            new PlayerHistory("You are an unacknowledged child of ", 50, 67, 68, 45),
            new PlayerHistory("You are a rebel child of ", 80, 67, 68, 65),
            new PlayerHistory("You are a long lost child of ", 100, 67, 68, 55),
            // Group 68: Great One parent 68->50->51->52->53->End
            new PlayerHistory("someone with Great One blood. ", 50, 68, 50, 80),
            new PlayerHistory("an unknown child of a Great One. ", 65, 68, 50, 90),
            new PlayerHistory("an unknown Great One. ", 79, 68, 50, 100),
            new PlayerHistory("Karakal. ", 80, 68, 50, 130),
            new PlayerHistory("Hagarg Ryonis. ", 83, 68, 50, 105),
            new PlayerHistory("Lobon. ", 84, 68, 50, 105),
            new PlayerHistory("Nath-Horthath. ", 85, 68, 50, 90),
            new PlayerHistory("Tamash. ", 87, 68, 50, 100),
            new PlayerHistory("Zo-Kalar. ", 88, 68, 50, 125),
            new PlayerHistory("Karakal. ", 89, 68, 50, 120),
            new PlayerHistory("Hagarg Ryonis. ", 90, 68, 50, 140),
            new PlayerHistory("Lobon. ", 91, 68, 50, 115),
            new PlayerHistory("Nath-Horthath. ", 92, 68, 50, 110),
            new PlayerHistory("Tamash. ", 93, 68, 50, 105),
            new PlayerHistory("Zo-Kalar. ", 94, 68, 50, 95),
            new PlayerHistory("Karakal. ", 95, 68, 50, 115),
            new PlayerHistory("Hagarg Ryonis. ", 96, 68, 50, 110),
            new PlayerHistory("Lobon. ", 97, 68, 50, 135),
            new PlayerHistory("Nath-Horthath. ", 98, 68, 50, 90),
            new PlayerHistory("Tamash. ", 99, 68, 50, 105),
            new PlayerHistory("Zo-Kalar. ", 100, 68, 50, 80),
            // Group 69: Dark-Elf start 68->70->71->72->73->End
            new PlayerHistory("You are one of several children of a Dark Elven ", 85, 69, 70, 45),
            new PlayerHistory("You are the only child of a Dark Elven ", 100, 69, 70, 55),
            // Group 70: Dark-Elf parent 70->71->72->73->End
            new PlayerHistory("Warrior. ", 50, 70, 71, 60),
            new PlayerHistory("Warlock. ", 80, 70, 71, 75),
            new PlayerHistory("Noble. ", 100, 70, 71, 95),
            // Group 71: Dark-Elf eyes 71->72->73->End
            new PlayerHistory("You have black eyes, ", 100, 71, 72, 50),
            // Group 72: Dark-Elf hair style 72->73->End
            new PlayerHistory("straight ", 70, 72, 73, 50),
            new PlayerHistory("wavy ", 90, 72, 73, 50),
            new PlayerHistory("curly ", 100, 72, 73, 50),
            // Group 73: Dark-Elf complexion 73->End
            new PlayerHistory("black hair and a very dark complexion.", 100, 73, 0, 50),
            // Group 74: Half-Ogre start 74->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was an Ogre, but it is unacknowledged. ", 25, 74, 20, 25),
            new PlayerHistory("Your father was an Ogre. ", 50, 74, 20, 25),
            new PlayerHistory("Your mother was an Ogre. ", 75, 74, 20, 25),
            new PlayerHistory("Your father was an Ogre, but it is unacknowledged. ", 100, 74, 20, 25),
            // Group 75: Half-Giant start 75->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was a Hill Giant. ", 10, 75, 20, 50),
            new PlayerHistory("Your mother was a Fire Giant. ", 12, 75, 20, 55),
            new PlayerHistory("Your mother was a Frost Giant. ", 20, 75, 20, 60),
            new PlayerHistory("Your mother was a Cloud Giant. ", 23, 75, 20, 65),
            new PlayerHistory("Your mother was a Storm Giant. ", 25, 75, 20, 70),
            new PlayerHistory("Your father was a Hill Giant. ", 60, 75, 20, 50),
            new PlayerHistory("Your father was a Fire Giant. ", 70, 75, 20, 55),
            new PlayerHistory("Your father was a Frost Giant. ", 80, 75, 20, 60),
            new PlayerHistory("Your father was a Cloud Giant. ", 90, 75, 20, 65),
            new PlayerHistory("Your father was a Storm Giant. ", 100, 75, 20, 70),
            // Group 76: Half-Titan start 75->20->2->3->50->51->52->53->End
            new PlayerHistory("Your father was an unknown Titan. ", 75, 76, 20, 50),
            new PlayerHistory("Your mother was Themis. ", 80, 76, 20, 100),
            new PlayerHistory("Your mother was Mnemosyne. ", 85, 76, 20, 100),
            new PlayerHistory("Your father was Okeanoas. ", 90, 76, 20, 100),
            new PlayerHistory("Your father was Crius. ", 95, 76, 20, 100),
            new PlayerHistory("Your father was Hyperion. ", 98, 76, 20, 125),
            new PlayerHistory("Your father was Kronos. ", 100, 76, 20, 150),
            // Group 77: Cyclops start 77->109->110->111->112->End
            new PlayerHistory("You are the offspring of an unknown Cyclops. ", 90, 77, 109, 50),
            new PlayerHistory("You are Polyphemos's child. ", 98, 77, 109, 80),
            new PlayerHistory("You are Uranos's child. ", 100, 77, 109, 135),
            // Group 78: Yeek start 78->79->80->81->135->136->137->End
            new PlayerHistory("You are the runt of ", 20, 78, 79, 40),
            new PlayerHistory("You come from ", 80, 78, 79, 50),
            new PlayerHistory("You are the largest of ", 100, 78, 79, 55),
            // Group 79: Yeek litter size 79->80->81->135->136->137->End
            new PlayerHistory("a litter of 3 pups. ", 15, 79, 80, 55),
            new PlayerHistory("a litter of 4 pups. ", 40, 79, 80, 55),
            new PlayerHistory("a litter of 5 pups. ", 70, 79, 80, 50),
            new PlayerHistory("a litter of 6 pups. ", 85, 79, 80, 50),
            new PlayerHistory("a litter of 7 pups. ", 95, 79, 80, 45),
            new PlayerHistory("a litter of 8 pups. ", 100, 79, 80, 45),
            // Group 80: Yeek parent 80->81->135->136->137->End
            new PlayerHistory("Your mother was a scavenger. ", 25, 80, 81, 40),
            new PlayerHistory("Your mother was a sneak. ", 50, 80, 81, 45),
            new PlayerHistory("Your mother was a warrior. ", 75, 80, 81, 50),
            new PlayerHistory("Your mother was a master yeek. ", 95, 80, 81, 55),
            new PlayerHistory("Your father was a yeek king. ", 100, 80, 81, 60),
            // Group 81: Yeek fur style 81->135->136->137->End
            new PlayerHistory("You have mangy ", 33, 81, 135, 50),
            new PlayerHistory("You have short ", 66, 81, 135, 50),
            new PlayerHistory("You have long ", 100, 81, 135, 50),
            // Group 82: Kobold start 82->83->24->25->26->End
            new PlayerHistory("You are one of several children of ", 100, 82, 83, 50),
            // Group 83: Kobold parent 83->24->25->26->End
            new PlayerHistory("a Small Kobold. ", 40, 83, 24, 50),
            new PlayerHistory("a Kobold. ", 75, 83, 24, 55),
            new PlayerHistory("a Large Kobold. ", 95, 83, 24, 65),
            new PlayerHistory("Vort, the Kobold Queen. ", 100, 83, 24, 100),
            // Group 84: Klackon start 84->85->86->End
            new PlayerHistory("You are one of several children of a Klackon hive queen. ", 100, 84, 85, 50),
            // Group 85: Klackon skin 85->86->End
            new PlayerHistory("You have red chitin, ", 40, 85, 86, 50),
            new PlayerHistory("You have black chitin, ", 90, 85, 86, 50),
            new PlayerHistory("You have yellow chitin, ", 100, 85, 86, 50),
            // Group 86: Klackon antennae 86->End
            new PlayerHistory("long antennae, and black eyes.", 50, 86, 0, 50),
            new PlayerHistory("short antennae, and black eyes.", 80, 86, 0, 50),
            new PlayerHistory("feathered antennae, and black eyes.", 100, 86, 0, 50),
            // Group 87: Nibelung start 87->88->18->57->58->59->60->61->End
            new PlayerHistory("You are one of several children of ", 100, 87, 88, 89),
            // Group 88: Nibelung parent 88->18->57->58->59->60->61->End
            new PlayerHistory("a Nibelung Slave. ", 30, 88, 18, 20),
            new PlayerHistory("a Nibelung Thief. ", 50, 88, 18, 40),
            new PlayerHistory("a Nibelung Smith. ", 70, 88, 18, 60),
            new PlayerHistory("a Nibelung Miner. ", 90, 88, 18, 75),
            new PlayerHistory("a Nibelung Priest. ", 95, 88, 18, 100),
            new PlayerHistory("Mime, the Nibelung. ", 100, 88, 18, 100),
            // Group 89: Draconian start 89->90->91->End
            new PlayerHistory("You are one of several children of a Draconian ", 85, 89, 90, 50),
            new PlayerHistory("You are the only child of a Draconian ", 100, 89, 90, 55),
            // Group 90: Draconian parent 90->91->End
            new PlayerHistory("Warrior. ", 50, 90, 91, 50),
            new PlayerHistory("Priest. ", 65, 90, 91, 65),
            new PlayerHistory("Mage. ", 85, 90, 91, 70),
            new PlayerHistory("Noble. ", 100, 90, 91, 100),
            // Group 91: Draconian colour 91->End
            new PlayerHistory("You have green wings, green skin and yellow belly.", 30, 91, 0, 50),
            new PlayerHistory("You have green wings, and green skin.", 55, 91, 0, 50),
            new PlayerHistory("You have red wings, and red skin.", 80, 91, 0, 50),
            new PlayerHistory("You have black wings, and black skin.", 90, 91, 0, 50),
            new PlayerHistory("You have metallic skin, and shining wings.", 100, 91, 0, 50),
            // Group 92: Mind-Flayer start 93->93->End
            new PlayerHistory("You have slimy skin, empty glowing eyes, and ", 100, 92, 93, 80),
            // Group 93: Mind-Flayer tentacles 93->End
            new PlayerHistory("three tentacles around your mouth.", 20, 93, 0, 45),
            new PlayerHistory("four tentacles around your mouth.", 80, 93, 0, 50),
            new PlayerHistory("five tentacles around your mouth.", 100, 93, 0, 55),
            // Group 94: Imp start 94->95->96->97->End
            new PlayerHistory("You ancestor was ", 100, 94, 95, 50),
            // Group 95: Imp ancestor 95->96->97->End
            new PlayerHistory("a mindless demonic spawn. ", 30, 95, 96, 20),
            new PlayerHistory("a minor demon. ", 60, 95, 96, 50),
            new PlayerHistory("a major demon. ", 90, 95, 96, 75),
            new PlayerHistory("a demon lord. ", 100, 95, 96, 99),
            // Group 96: Imp skin 96->97->End
            new PlayerHistory("You have red skin, ", 50, 96, 97, 50),
            new PlayerHistory("You have brown skin, ", 100, 96, 97, 50),
            // Group 97: Imp eyes 97->End
            new PlayerHistory("claws, fangs, spikes, and glowing red eyes.", 40, 97, 0, 50),
            new PlayerHistory("claws, fangs, and glowing red eyes.", 70, 97, 0, 50),
            new PlayerHistory("claws, and glowing red eyes.", 100, 97, 0, 50),
            // Group 98: Golem start 98->99->100->101->End
            new PlayerHistory("You were shaped from ", 100, 98, 99, 50),
            // Group 99: Golem material 99->100->101->End
            new PlayerHistory("clay ", 40, 99, 100, 50),
            new PlayerHistory("stone ", 80, 99, 100, 50),
            new PlayerHistory("wood ", 85, 99, 100, 40),
            new PlayerHistory("iron ", 99, 99, 100, 50),
            new PlayerHistory("pure gold ", 100, 99, 100, 100),
            // Group 100: Golem creator 100->101->End
            new PlayerHistory("by a Kabbalist", 40, 100, 101, 50),
            new PlayerHistory("by a Wizard", 65, 100, 101, 50),
            new PlayerHistory("by an Alchemist", 90, 100, 101, 50),
            new PlayerHistory("by a Priest", 100, 100, 101, 60),
            // Group 101: Golem purpose 101->End
            new PlayerHistory(" to fight evil.", 10, 101, 0, 65),
            new PlayerHistory(".", 100, 101, 0, 50),
            // Group 102: Skeleton start 102->103->104->105->106->End
            new PlayerHistory("You were created by ", 100, 102, 103, 50),
            // Group 103: Skeleton creator 103->104->105->106->End
            new PlayerHistory("a Necromancer. ", 30, 103, 104, 50),
            new PlayerHistory("a magical experiment. ", 50, 103, 104, 50),
            new PlayerHistory("an Evil Priest. ", 70, 103, 104, 50),
            new PlayerHistory("a pact with the demons. ", 75, 103, 104, 50),
            new PlayerHistory("a restless spirit. ", 85, 103, 104, 50),
            new PlayerHistory("a curse. ", 95, 103, 104, 30),
            new PlayerHistory("an oath. ", 100, 103, 104, 50),
            // Group 104: Skeleton join 104->105->106->End
            new PlayerHistory("You have ", 100, 104, 105, 50),
            // Group 105: Skeleton bones 105->106->End
            new PlayerHistory("dirty, dry bones, ", 40, 105, 106, 50),
            new PlayerHistory("rotten black bones, ", 60, 105, 106, 50),
            new PlayerHistory("filthy, brown bones, ", 80, 105, 106, 50),
            new PlayerHistory("shining white bones, ", 100, 105, 106, 50),
            // Group 106: Skeleton eyes 106->End
            new PlayerHistory("and glowing eyes.", 30, 106, 0, 50),
            new PlayerHistory("and eyes which burn with hellfire.", 50, 106, 0, 50),
            new PlayerHistory("and empty eyesockets.", 100, 106, 0, 50),
            // Group 107: Zombie start 107->108->62->63->64->65->66->End
            new PlayerHistory("You were created by ", 100, 107, 108, 50),
            // Group 108: Zombie creator 108->62->63->64->65->66->End
            new PlayerHistory("a Necromancer. ", 30, 108, 62, 50),
            new PlayerHistory("a Wizard. ", 50, 108, 62, 50),
            new PlayerHistory("a restless spirit. ", 60, 108, 62, 50),
            new PlayerHistory("an Evil Priest. ", 70, 108, 62, 50),
            new PlayerHistory("a pact with the demons. ", 80, 108, 62, 50),
            new PlayerHistory("a curse. ", 95, 108, 62, 30),
            new PlayerHistory("an oath. ", 100, 108, 62, 50),
            // Group 109: Cyclops eye 109->110->111->112->End
            new PlayerHistory("You have a dark brown eye, ", 20, 109, 110, 50),
            new PlayerHistory("You have a brown eye, ", 60, 109, 110, 50),
            new PlayerHistory("You have a hazel eye, ", 70, 109, 110, 50),
            new PlayerHistory("You have a green eye, ", 80, 109, 110, 50),
            new PlayerHistory("You have a blue eye, ", 90, 109, 110, 50),
            new PlayerHistory("You have a blue-gray eye, ", 100, 109, 110, 50),
            // Group 110: Cyclops hair style 110->111->112->End
            new PlayerHistory("straight ", 70, 110, 111, 50),
            new PlayerHistory("wavy ", 90, 110, 111, 50),
            new PlayerHistory("curly ", 100, 110, 111, 50),
            // Group 111: Cyclops hair colour 111->112->End
            new PlayerHistory("black hair, ", 30, 111, 112, 50),
            new PlayerHistory("brown hair, ", 70, 111, 112, 50),
            new PlayerHistory("auburn hair, ", 80, 111, 112, 50),
            new PlayerHistory("red hair, ", 90, 111, 112, 50),
            new PlayerHistory("blond hair, ", 100, 111, 112, 50),
            // Group 112: Cyclops complexion 112->End
            new PlayerHistory("and a very dark complexion.", 10, 112, 0, 50),
            new PlayerHistory("and a dark complexion.", 30, 112, 0, 50),
            new PlayerHistory("and an olive complexion.", 80, 112, 0, 50),
            new PlayerHistory("and a pale complexion.", 90, 112, 0, 50),
            new PlayerHistory("and a very pale complexion.", 100, 112, 0, 50),
            // Group 113: Vampire start 113->114->115->116->117->End
            new PlayerHistory("You arose from an unmarked grave. ", 20, 113, 114, 50),
            new PlayerHistory("In life you were a simple peasant, the victim of a powerful Vampire Lord. ", 40, 113, 114, 50),
            new PlayerHistory("In life you were a Vampire Hunter, but they got you. ", 60, 113, 114, 50),
            new PlayerHistory("In life you were a Necromancer. ", 80, 113, 114, 50),
            new PlayerHistory("In life you were a powerful noble. ", 95, 113, 114, 50),
            new PlayerHistory("In life you were a powerful and cruel tyrant. ", 100, 113, 114, 50),
            // Group 114: Vampire join 114->115->116->117->End
            new PlayerHistory("You have ", 100, 114, 115, 50),
            // Group 115: Vampire hair 115->116->117->End
            new PlayerHistory("jet-black hair, ", 25, 115, 116, 50),
            new PlayerHistory("matted brown hair, ", 50, 115, 116, 50),
            new PlayerHistory("white hair, ", 75, 115, 116, 50),
            new PlayerHistory("a hairless head, ", 100, 115, 116, 50),
            // Group 116: Vampire eyes 116->117->End
            new PlayerHistory("eyes like red coals, ", 25, 116, 117, 50),
            new PlayerHistory("blank white eyes, ", 50, 116, 117, 50),
            new PlayerHistory("feral yellow eyes, ", 75, 116, 117, 50),
            new PlayerHistory("bloodshot red eyes, ", 100, 116, 117, 50),
            // Group 117: Vampire complexion 117->End
            new PlayerHistory("and a deathly pale complexion.", 100, 117, 0, 50),
            // Group 118: Spectre start 118->119->134->120->121->122->123->End
            new PlayerHistory("You were created by ", 100, 118, 119, 50),
            // Group 119: Spectre origin 119->134->120->121->122->123->End
            new PlayerHistory("a Necromancer. ", 30, 119, 134, 50),
            new PlayerHistory("a magical experiment. ", 50, 119, 134, 50),
            new PlayerHistory("an Evil Priest. ", 70, 119, 134, 50),
            new PlayerHistory("a pact with the demons. ", 75, 119, 134, 50),
            new PlayerHistory("a restless spirit. ", 85, 119, 134, 50),
            new PlayerHistory("a curse. ", 95, 119, 134, 30),
            new PlayerHistory("an oath. ", 100, 119, 134, 50),
            // Group 120: Spectre hair 120->121->122->123->End
            new PlayerHistory("jet-black hair, ", 25, 120, 121, 50),
            new PlayerHistory("matted brown hair, ", 50, 120, 121, 50),
            new PlayerHistory("white hair, ", 75, 120, 121, 50),
            new PlayerHistory("a hairless head, ", 100, 120, 121, 50),
            // Group 121: Spectre eyes 121->122->123->End
            new PlayerHistory("eyes like red coals, ", 25, 121, 122, 50),
            new PlayerHistory("blank white eyes, ", 50, 121, 122, 50),
            new PlayerHistory("feral yellow eyes, ", 75, 121, 122, 50),
            new PlayerHistory("bloodshot red eyes, ", 100, 121, 122, 50),
            // Group 122: Spectre complexion 122->123->End
            new PlayerHistory(" and a deathly gray complexion. ", 100, 122, 123, 50),
            // Group 123: Spectre aura 123->End
            new PlayerHistory("An eerie green aura surrounds you.", 100, 123, 0, 50),
            // Group 124: Sprite start 124->125->126->127->128->End
            new PlayerHistory("Your parents were ", 100, 124, 125, 50),
            // Group 125: Sprite parents 125->126->127->128->End
            new PlayerHistory("pixies. ", 20, 125, 126, 35),
            new PlayerHistory("nixies. ", 30, 125, 126, 25),
            new PlayerHistory("wood sprites. ", 75, 125, 126, 50),
            new PlayerHistory("wood spirits. ", 90, 125, 126, 75),
            new PlayerHistory("noble faerie folk. ", 100, 125, 126, 85),
            // Group 126: Sprite wings 126->127->128->End
            new PlayerHistory("You have dragonfly wings attached to your back, ", 45, 126, 127, 50),
            new PlayerHistory("You have butterfly wings attached to your back, ", 90, 126, 127, 50),
            new PlayerHistory("You have beetle wings attached to your back, ", 100, 126, 127, 50),
            // Group 127: Sprite hair 127->128->End
            new PlayerHistory("straight blond hair, ", 80, 127, 128, 50),
            new PlayerHistory("wavy blond hair, ", 100, 127, 128, 50),
            // Group 128: Sprite eyes 128->End
            new PlayerHistory("blue eyes, and skin the colour of pine.", 25, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of ash.", 50, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of oak.", 75, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of mahogany.", 100, 128, 0, 50),
            // Group 129: Miri-Nigri start 129->130->131->132->133->End
            new PlayerHistory("You were summoned by a cult. ", 30, 129, 130, 40),
            new PlayerHistory("You crawled out from a fissure in the ground. ", 50, 129, 130, 50),
            new PlayerHistory("You were summoned by a lone wizard. ", 60, 129, 130, 60),
            new PlayerHistory("You squeezed into the world through a crack between dimensions. ", 75, 129, 130, 50),
            new PlayerHistory("You are the blasphemous crossbreed of unspeakable creatures of chaos. ", 100, 129, 130, 30),
            // Group 130: Miri-Nigri eyes 130->131->132->133->End
            new PlayerHistory("You have green reptilian eyes, ", 60, 130, 131, 50),
            new PlayerHistory("You have unblinking eyes, ", 85, 130, 131, 50),
            new PlayerHistory("You have fathomless black eyes, ", 99, 130, 131, 50),
            new PlayerHistory("You have altogether too many eyes, ", 100, 130, 131, 55),
            // Group 131: Miri-Nigri skin texture 131->132->133->End
            new PlayerHistory("slimy ", 10, 131, 132, 50),
            new PlayerHistory("smooth ", 33, 131, 132, 50),
            new PlayerHistory("slippery ", 66, 131, 132, 50),
            new PlayerHistory("oily ", 100, 131, 132, 50),
            // Group 132: Miri-Nigri skin colour 132->133->End
            new PlayerHistory("green skin, ", 33, 132, 133, 50),
            new PlayerHistory("black skin, ", 66, 132, 133, 50),
            new PlayerHistory("pale skin, ", 100, 132, 133, 50),
            // Group 133: Miri-Nigri mutation 133->End
            new PlayerHistory("and tentacles.", 50, 133, 0, 50),
            new PlayerHistory("and webbed feet.", 75, 133, 0, 50),
            new PlayerHistory("and suckers on your fingers.", 85, 133, 0, 50),
            new PlayerHistory("and no toes.", 90, 133, 0, 50),
            new PlayerHistory("and no nose.", 95, 133, 0, 50),
            new PlayerHistory("and no teeth.", 97, 133, 0, 50),
            new PlayerHistory("and no ears.", 100, 133, 0, 50),
            // Group 134: Spectre join 134->120->121->122->123->End
            new PlayerHistory("You have ", 100, 134, 120, 50),
            // Group 135: Yeek fur colour 135->136->137->End
            new PlayerHistory("blue fur, ", 40, 135, 136, 50),
            new PlayerHistory("brown fur, ", 60, 135, 136, 50),
            new PlayerHistory("striped fur, ", 95, 135, 136, 50),
            new PlayerHistory("spotted fur, ", 100, 135, 136, 50),
            // Group 136: Yeek ears 136->137->End
            new PlayerHistory("rounded ears, ", 10, 136, 137, 50),
            new PlayerHistory("pointed ears, ", 90, 136, 137, 50),
            new PlayerHistory("lop ears, ", 100, 136, 137, 50),
            // Group 137: Yeek eyes 137->End
            new PlayerHistory("and glowing yellow eyes.", 10, 137, 0, 50),
            new PlayerHistory("and glowing red eyes.", 90, 137, 0, 50),
            new PlayerHistory("and glowing orange eyes.", 100, 137, 0, 50),
            // Group 138: Tcho-Tcho start 138->139->140->141->142->End
            new PlayerHistory("You are the only child of ", 10, 138, 139, 50),
            new PlayerHistory("You are one of the children of ", 90, 138, 139, 50),
            new PlayerHistory("You don't know who your parents were. ", 100, 138, 140, 10),
            // Group 139: Tcho-Tcho parent 139->140->141->142->End
            new PlayerHistory("a hunter. ", 40, 139, 140, 20),
            new PlayerHistory("a warrior. ", 75, 139, 140, 30),
            new PlayerHistory("a cultist. ", 95, 139, 140, 50),
            new PlayerHistory("a warlock. ", 100, 139, 140, 60),
            new PlayerHistory("a high priest. ", 10, 139, 140, 80),
            // Group 140: Tcho-Tcho eyes 140->141->142->End
            new PlayerHistory("You have deep-set eyes, ", 30, 140, 141, 50),
            new PlayerHistory("You have a missing eye, ", 40, 140, 141, 50),
            new PlayerHistory("You have dark eyes, ", 90, 140, 141, 50),
            new PlayerHistory("You have bloodshot eyes, ", 100, 140, 141, 50),
            // Group 141: Tcho-Tcho body 141->142->End
            new PlayerHistory("many scars, and ", 30, 141, 142, 50),
            new PlayerHistory("obscene tattoos, and ", 50, 141, 142, 50),
            new PlayerHistory("ritual scarification, and ", 70, 141, 142, 50),
            new PlayerHistory("an extra toe, and ", 82, 141, 142, 50),
            new PlayerHistory("a vestigial tail, and ", 87, 141, 142, 50),
            new PlayerHistory("unmistakable signs of inbreeding, and ", 90, 141, 142, 50),
            new PlayerHistory("a missing nose, and ", 100, 141, 142, 50),
            // Group 142: Tcho-Tcho teeth 142->End
            new PlayerHistory("missing teeth.", 30, 142, 0, 50),
            new PlayerHistory("sharpened teeth.", 50, 142, 0, 50),
            new PlayerHistory("rotten teeth.", 70, 142, 0, 50),
            new PlayerHistory("filed-down teeth.", 90, 142, 0, 50),
            new PlayerHistory("no teeth.", 100, 142, 0, 50)
        };

        /// <summary>
        /// Create a background for a character by stringing together randomised text fragments
        /// based on their race
        /// </summary>
        /// <param name="player"> The player that needs a background </param>
        private void GetHistory(Player player)
        {
            int i;
            int chart;
            for (i = 0; i < 4; i++)
            {
                player.History[i] = string.Empty;
            }
            string fullHistory = string.Empty;
            int socialClass = Program.Rng.DieRoll(4);
            // Start on a chart based on the character's race
            switch (player.RaceIndex)
            {
                case RaceId.Great:
                    {
                        // Great One 67->68->50->51->52->53->End
                        chart = 67;
                        break;
                    }
                case RaceId.Human:
                    {
                        // Human 1->2->3->50->51->52->53->End
                        chart = 1;
                        break;
                    }
                case RaceId.TchoTcho:
                    {
                        // Tcho-Tcho 138->139->140->141->142->End
                        chart = 138;
                        break;
                    }
                case RaceId.HalfElf:
                    {
                        // Half-Elf 4->1->2->3->50->51->52->53->End
                        chart = 4;
                        break;
                    }
                case RaceId.Elf:
                case RaceId.HighElf:
                    {
                        // Elf/High-Elf 7->8->9->54->55->56->End
                        chart = 7;
                        break;
                    }
                case RaceId.Hobbit:
                    {
                        // Hobbit 10->11->3->50->51->52->53->End
                        chart = 10;
                        break;
                    }
                case RaceId.Gnome:
                    {
                        // Gnome 13->14->3->50->51->52->53->End
                        chart = 13;
                        break;
                    }
                case RaceId.Dwarf:
                    {
                        // Dwarf 16->17->18->57->58->59->60->61->End
                        chart = 16;
                        break;
                    }
                case RaceId.HalfOrc:
                    {
                        // Half-Orc 19->20->2->3->50->51->52->53->End
                        chart = 19;
                        break;
                    }
                case RaceId.HalfTroll:
                    {
                        // Half-Troll 22->23->62->63->64->65->66->End
                        chart = 22;
                        break;
                    }
                case RaceId.DarkElf:
                    {
                        // Dark-Elf 68->70->71->72->73->End
                        chart = 69;
                        break;
                    }
                case RaceId.HalfOgre:
                    {
                        // Half-Ogre 74->20->2->3->50->51->52->53->End
                        chart = 74;
                        break;
                    }
                case RaceId.HalfGiant:
                    {
                        // Half-Giant 75->20->2->3->50->51->52->53->End
                        chart = 75;
                        break;
                    }
                case RaceId.HalfTitan:
                    {
                        // Half-Titan 75->20->2->3->50->51->52->53->End
                        chart = 76;
                        break;
                    }
                case RaceId.Cyclops:
                    {
                        // Cyclops 77->109->110->111->112->End
                        chart = 77;
                        break;
                    }
                case RaceId.Yeek:
                    {
                        // Yeek 78->79->80->81->135->136->137->End
                        chart = 78;
                        break;
                    }
                case RaceId.Kobold:
                    {
                        // Kobold 82->83->24->25->26->End
                        chart = 82;
                        break;
                    }
                case RaceId.Klackon:
                    {
                        // Klackon 84->85->86->End
                        chart = 84;
                        break;
                    }
                case RaceId.Nibelung:
                    {
                        // Nibelung 87->88->18->57->58->59->60->61->End
                        chart = 87;
                        break;
                    }
                case RaceId.Draconian:
                    {
                        // Draconian 89->90->91->End
                        chart = 89;
                        break;
                    }
                case RaceId.MindFlayer:
                    {
                        // Mind-Flayer 93->93->End
                        chart = 92;
                        break;
                    }
                case RaceId.Imp:
                    {
                        // Imp 94->95->96->97->End
                        chart = 94;
                        break;
                    }
                case RaceId.Golem:
                    {
                        // Golem 98->99->100->101->End
                        chart = 98;
                        break;
                    }
                case RaceId.Skeleton:
                    {
                        // Skeleton 102->103->104->105->106->End
                        chart = 102;
                        break;
                    }
                case RaceId.Zombie:
                    {
                        // Zombie 107->108->62->63->64->65->66->End
                        chart = 107;
                        break;
                    }
                case RaceId.Vampire:
                    {
                        // Vampire 113->114->115->116->117->End
                        chart = 113;
                        break;
                    }
                case RaceId.Spectre:
                    {
                        // Spectre 118->119->134->120->121->122->123->End
                        chart = 118;
                        break;
                    }
                case RaceId.Sprite:
                    {
                        // Sprite 124->125->126->127->128->End
                        chart = 124;
                        break;
                    }
                case RaceId.MiriNigri:
                    {
                        // Miri-Nigri 129->130->131->132->133->End
                        chart = 129;
                        break;
                    }
                default:
                    {
                        // Unrecognised race gets no history
                        chart = 0;
                        break;
                    }
            }
            // Keep going till we get to an end
            while (chart != 0)
            {
                i = 0;
                // Roll percentile for which background to use within each chart
                int roll = Program.Rng.DieRoll(100);
                // Find the correct chart and background
                while (chart != _backgroundTable[i].Chart || roll > _backgroundTable[i].Roll)
                {
                    i++;
                }
                // Add the text to our buffer
                fullHistory += _backgroundTable[i].Info;
                // Adjust our social class by the bonus or penalty for that fragment
                socialClass += _backgroundTable[i].Bonus - 50;
                chart = _backgroundTable[i].Next;
            }
            // Make sure our social class didn't go out of bounds
            if (socialClass > 100)
            {
                socialClass = 100;
            }
            else if (socialClass < 1)
            {
                socialClass = 1;
            }
            player.SocialClass = socialClass;
            // Split the buffer into four strings to fit on four lines of the screen
            string s = fullHistory.Trim();
            i = 0;
            while (true)
            {
                int n = s.Length;
                if (n < 60)
                {
                    player.History[i] = s;
                    break;
                }
                for (n = 60; n > 0 && s[n - 1] != ' '; n--)
                {
                }
                player.History[i++] = s.Substring(0, n).Trim();
                s = s.Substring(n).Trim();
            }
        }
    }
}