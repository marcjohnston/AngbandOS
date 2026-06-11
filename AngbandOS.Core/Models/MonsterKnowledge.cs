// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;
namespace AngbandOS.Core;

[Serializable]
internal class MonsterKnowledge : IGameSerialize
{
    #region State Data
    public readonly byte[] RBlows;
    public int RCastInate;
    public int RCastSpell;
    public int RDeaths;
    public int RDropGold;
    public int RDropItem;
    public bool Guardian;
    public bool OnlyGuardian;
    public MonsterCharacteristics Characteristics = new MonsterCharacteristics();
    public MonsterSpell[] RSpells = new MonsterSpell[] { };
    public int RIgnore;
    public int RPkills;
    public bool RProbed;
    public int RSights;
    public int RTkills;
    public int RWake;
    private readonly MonsterRace _monsterRace;
    #endregion

    public GameStateBag? Serialize(SaveGameState saveGameState)
    {
        return new DictionaryGameStateBag(
            (nameof(_monsterRace), saveGameState.CreateGameStateBag(_monsterRace, typeof(MonsterRace))),
            (nameof(RBlows), saveGameState.CreateGameStateBag(RBlows)),
            (nameof(RCastInate), saveGameState.CreateGameStateBag(RCastInate)),
            (nameof(RCastSpell), saveGameState.CreateGameStateBag(RCastSpell)),
            (nameof(RDeaths), saveGameState.CreateGameStateBag(RDeaths)),
            (nameof(RDropGold), saveGameState.CreateGameStateBag(RDropGold)),
            (nameof(RDropItem), saveGameState.CreateGameStateBag(RDropItem)),
            (nameof(Guardian), saveGameState.CreateGameStateBag(Guardian)),
            (nameof(OnlyGuardian), saveGameState.CreateGameStateBag(OnlyGuardian)),
            (nameof(Characteristics), saveGameState.CreateGameStateBag(Characteristics, typeof(MonsterCharacteristics))),
            (nameof(RSpells), saveGameState.CreateGameStateBag(RSpells, typeof(MonsterSpell))),
            (nameof(RIgnore), saveGameState.CreateGameStateBag(RIgnore)),
            (nameof(RPkills), saveGameState.CreateGameStateBag(RPkills)),
            (nameof(RProbed), saveGameState.CreateGameStateBag(RProbed)),
            (nameof(RSights), saveGameState.CreateGameStateBag(RSights)),
            (nameof(RTkills), saveGameState.CreateGameStateBag(RTkills)),
            (nameof(RWake), saveGameState.CreateGameStateBag(RWake))
        );
    }

    private Game Game { get; }

    public MonsterKnowledge(Game game, MonsterRace monsterRace)
    {
        Game = game;
        _monsterRace = monsterRace;
        RBlows = new byte[monsterRace.Attacks.Length];
    }

    public MonsterKnowledge(Game game, RestoreGameState restoreGameState) : this(game, restoreGameState.GetByKey(nameof(_monsterRace)).GetDerivedReference<MonsterRace>())
    {
        RBlows = restoreGameState.GetByKey(nameof(RBlows)).GetBytes();
        RCastInate = restoreGameState.GetByKey(nameof(RCastInate)).GetInt();
        RCastSpell = restoreGameState.GetByKey(nameof(RCastSpell)).GetInt();
        RDeaths = restoreGameState.GetByKey(nameof(RDeaths)).GetInt();
        RDropGold = restoreGameState.GetByKey(nameof(RDropGold)).GetInt();
        RDropItem = restoreGameState.GetByKey(nameof(RDropItem)).GetInt();
        Guardian = restoreGameState.GetByKey(nameof(Guardian)).GetBool();
        OnlyGuardian = restoreGameState.GetByKey(nameof(OnlyGuardian)).GetBool();
        Characteristics = restoreGameState.GetByKey(nameof(Characteristics)).GetDerivedReference<MonsterCharacteristics>((RestoreGameState restoreGameState) => new MonsterCharacteristics(Game, restoreGameState));
        RSpells = restoreGameState.GetByKey(nameof(RSpells)).GetDerivedReferences<MonsterSpell>();
        RIgnore = restoreGameState.GetByKey(nameof(RIgnore)).GetInt();
        RPkills = restoreGameState.GetByKey(nameof(RPkills)).GetInt();
        RProbed = restoreGameState.GetByKey(nameof(RProbed)).GetBool();
        RSights = restoreGameState.GetByKey(nameof(RSights)).GetInt();
        RTkills = restoreGameState.GetByKey(nameof(RTkills)).GetInt();
        RWake = restoreGameState.GetByKey(nameof(RWake)).GetInt();
    }

    public void Display()
    {
        Game.MsgPrint(string.Empty);
        Game.Screen.Erase(1, 0);
        DisplayBody(ColorEnum.White);
        DisplayHeader();
    }

    public void DisplayBody(ColorEnum bodyColor)
    {
        MonsterKnowledge knowledge = this;
        StringBuilder _description = new StringBuilder();
        if (Game.IsWizard.BoolValue)
        {
            knowledge = new MonsterKnowledge(Game, _monsterRace);
            for (int m = 0; m < _monsterRace.Attacks.Length; m++)
            {
                if (_monsterRace.Attacks[m].Effect != null || _monsterRace.Attacks[m].Method != null)
                {
                    knowledge.RBlows[m] = byte.MaxValue;
                }
            }
            knowledge.RProbed = true;
            knowledge.RWake = Constants.MaxUchar;
            knowledge.RIgnore = Constants.MaxUchar;
            knowledge.RDropItem = (_monsterRace.Drop_4D2 ? 8 : 0) +
                                  (_monsterRace.Drop_3D2 ? 6 : 0) +
                                  (_monsterRace.Drop_2D2 ? 4 : 0) +
                                  (_monsterRace.Drop_1D2 ? 2 : 0) +
                                  (_monsterRace.Drop90 ? 1 : 0) +
                                  (_monsterRace.Drop60 ? 1 : 0);
            knowledge.RDropGold = knowledge.RDropItem;
            if (_monsterRace.OnlyDropGold)
            {
                knowledge.RDropItem = 0;
            }
            if (_monsterRace.OnlyDropItem)
            {
                knowledge.RDropGold = 0;
            }
            knowledge.RCastInate = Constants.MaxUchar;
            knowledge.RCastSpell = Constants.MaxUchar;
            knowledge.Characteristics = new MonsterCharacteristics(_monsterRace);
            knowledge.RSpells = _monsterRace.Spells;
        }
        string pronoun = Game.Gender.Pronoun.Trim();
        string capitalizedPronoun = $"{pronoun[0].ToString().ToUpper()}{pronoun[1..]}";
        string possessiveAdjective = Game.Gender.PossessiveAdjective;
        MonsterCharacteristics characteristics = new MonsterCharacteristics(_monsterRace, knowledge.Characteristics);
        MonsterSpell[] combinedSpells = _monsterRace.Spells.Concat(knowledge.RSpells).ToArray();
        if (_monsterRace.Unique)
        {
            characteristics.Unique = true;
        }
        if (_monsterRace.Guardian)
        {
            Guardian = true;
        }
        if (_monsterRace.Male)
        {
            characteristics.Male = true;
        }
        if (_monsterRace.Female)
        {
            characteristics.Female = true;
        }
        if (_monsterRace.Friends)
        {
            characteristics.Friends = true;
        }
        if (_monsterRace.Escorted)
        {
            characteristics.Escorted = true;
        }
        if (_monsterRace.EscortsGroup)
        {
            characteristics.EscortsGroup = true;
        }
        if (knowledge.RTkills != 0 || knowledge.RProbed)
        {
            if (_monsterRace.Orc)
            {
                characteristics.Orc = true;
            }
            if (_monsterRace.Troll)
            {
                characteristics.Troll = true;
            }
            if (_monsterRace.Giant)
            {
                characteristics.Giant = true;
            }
            if (_monsterRace.Dragon)
            {
                characteristics.Dragon = true;
            }
            if (_monsterRace.Demon)
            {
                characteristics.Demon = true;
            }
            if (_monsterRace.Cthuloid)
            {
                characteristics.Cthuloid = true;
            }
            if (_monsterRace.Undead)
            {
                characteristics.Undead = true;
            }
            if (_monsterRace.Evil)
            {
                characteristics.Evil = true;
            }
            if (_monsterRace.Good)
            {
                characteristics.Good = true;
            }
            if (_monsterRace.Animal)
            {
                characteristics.Animal = true;
            }
            if (_monsterRace.GreatOldOne)
            {
                characteristics.GreatOldOne = true;
            }
            if (_monsterRace.ForceMaxHp)
            {
                characteristics.ForceMaxHp = true;
            }
        }
        string buf = _monsterRace.Description;
        _description.Append(buf);
        _description.Append(" ");
        bool old = false;
        if (_monsterRace.Level == 0)
        {
            _description.Append(pronoun).Append(" lives in the town");
            old = true;
        }
        else if (knowledge.RTkills != 0 || knowledge.RProbed)
        {
            _description.Append(capitalizedPronoun).Append(" is normally found at level ").Append(_monsterRace.Level);
            old = true;
        }
        if (old)
        {
            _description.Append(", and ");
        }
        else
        {
            _description.Append(capitalizedPronoun).Append(' ');
            old = true;
        }
        _description.Append("moves");
        if (characteristics.RandomMove50 || characteristics.RandomMove25)
        {
            if (characteristics.RandomMove50 && characteristics.RandomMove25)
            {
                _description.Append(" extremely");
            }
            else if (characteristics.RandomMove50)
            {
                _description.Append(" somewhat");
            }
            else if (characteristics.RandomMove25)
            {
                _description.Append(" a bit");
            }
            _description.Append(" erratically");
            if (_monsterRace.Speed != 110)
            {
                _description.Append(", and");
            }
        }
        if (_monsterRace.Speed > 110)
        {
            if (_monsterRace.Speed > 130)
            {
                _description.Append(" incredibly");
            }
            else if (_monsterRace.Speed > 120)
            {
                _description.Append(" very");
            }
            _description.Append(" quickly");
            _description.Append(" (").Append(Game.ExtractEnergy[_monsterRace.Speed] / 10.0).Append(" actions per turn)");
        }
        else if (_monsterRace.Speed < 110)
        {
            if (_monsterRace.Speed < 90)
            {
                _description.Append(" incredibly");
            }
            else if (_monsterRace.Speed < 100)
            {
                _description.Append(" very");
            }
            _description.Append(" slowly");
            _description.Append(" (").Append(Game.ExtractEnergy[_monsterRace.Speed] / 10.0).Append(" actions per turn)");
        }
        else
        {
            _description.Append(" at normal speed");
        }
        if (characteristics.NeverMove)
        {
            if (old)
            {
                _description.Append(", but ");
            }
            else
            {
                _description.Append(pronoun).Append(' ');
                old = true;
            }
            _description.Append("does not deign to chase intruders");
        }
        if (old)
        {
            _description.Append(". ");
        }
        string? q;
        string? p;
        if (knowledge.RTkills != 0 || knowledge.RProbed)
        {
            _description.Append(characteristics.Unique ? "Killing this" : "A kill of this");
            if (characteristics.EldritchHorror)
            {
                _description.Append(" sanity-blasting");
            }
            if (characteristics.Animal)
            {
                _description.Append(" natural");
            }
            if (characteristics.Evil)
            {
                _description.Append(" evil");
            }
            if (characteristics.Good)
            {
                _description.Append(" good");
            }
            if (characteristics.Undead)
            {
                _description.Append(" undead");
            }
            if (characteristics.Dragon)
            {
                _description.Append(" dragon");
            }
            else if (characteristics.Demon)
            {
                _description.Append(" demon");
            }
            else if (characteristics.Giant)
            {
                _description.Append(" giant");
            }
            else if (characteristics.Troll)
            {
                _description.Append(" troll");
            }
            else if (characteristics.Orc)
            {
                _description.Append(" orc");
            }
            else if (characteristics.GreatOldOne)
            {
                _description.Append(" Great Old One");
            }
            else
            {
                _description.Append(" creature");
            }
            int i = _monsterRace.Mexp * _monsterRace.Level / Game.ExperienceLevel.IntValue;
            int j = ((_monsterRace.Mexp * _monsterRace.Level % Game.ExperienceLevel.IntValue * 1000 /
                     Game.ExperienceLevel.IntValue) + 5) / 10;
            if (i > 0)
            {
                _description.Append(" is worth ").AppendFormat("{0:n0}", i).Append("xp");
            }
            else if (j > 0)
            {
                _description.Append(" is worth negligible xp");
            }
            else
            {
                _description.Append(" is worth no xp");
            }
            p = "th";
            i = Game.ExperienceLevel.IntValue % 10;
            if (Game.ExperienceLevel.IntValue / 10 == 1)
            {
            }
            else if (i == 1)
            {
                p = "st";
            }
            else if (i == 2)
            {
                p = "nd";
            }
            else if (i == 3)
            {
                p = "rd";
            }
            q = "";
            i = Game.ExperienceLevel.IntValue;
            if (i == 8 || i == 11 || i == 18)
            {
                q = "n";
            }
            _description.Append(" for a").Append(q).Append(' ').Append(i).Append(p).Append(" level character. ");
        }
        if (characteristics.FireAura && characteristics.LightningAura)
        {
            _description.Append(capitalizedPronoun).Append(" is surrounded by flames and electricity. ");
        }
        else if (characteristics.FireAura)
        {
            _description.Append(capitalizedPronoun).Append(" is surrounded by flames. ");
        }
        else if (characteristics.LightningAura)
        {
            _description.Append(capitalizedPronoun).Append(" is surrounded by electricity. ");
        }
        if (characteristics.Reflecting)
        {
            _description.Append(capitalizedPronoun).Append(" reflects bolt spells. ");
        }
        if (characteristics.Escorted || characteristics.EscortsGroup)
        {
            _description.Append(capitalizedPronoun).Append(" usually appears with escorts. ");
        }
        else if (characteristics.Friends)
        {
            _description.Append(capitalizedPronoun).Append(" usually appears in groups. ");
        }

        // %CGP - Capitalized gender pronoun
        // %GP - gender pronoun
        // %GA - gender possessive adjective
        // %
        // %CGP %may. %CGP $maybreathe, and is also magical, casting spells %intelligently %which
        // %CGP %may. $CGP is magical, casting spells %intelligently %which

        Dictionary<string, List<string>> monsterSpellKnowledgeDictionary = new Dictionary<string, List<string>>();
        foreach (MonsterSpell monsterSpell in combinedSpells)
        {
            string actionVerb = monsterSpell.KnowledgeAction.CollapsableActionVerb.Trim();
            if (!monsterSpellKnowledgeDictionary.TryGetValue(actionVerb, out List<string>? nouns))
            {
                nouns = new List<string>();
                monsterSpellKnowledgeDictionary.Add(actionVerb, nouns);
            }
            nouns.Add(monsterSpell.KnowledgeAction.UniqueDescription);
        }

        int n;
        string maySentence = "";
        if (monsterSpellKnowledgeDictionary.TryGetValue("may", out List<string>? mayItemList))
        {
            string mayItemListText = StringLibrary.BuildList(mayItemList.ToArray());
            maySentence = StringLibrary.SurroundIf($"{capitalizedPronoun} may ", mayItemListText, ".");
        }

        string mayBreatheLeftDisjunct = "";
        if (monsterSpellKnowledgeDictionary.TryGetValue("may breathe", out List<string>? mayBreatheItemList))
        {
            string mayBreatheItemListText = StringLibrary.BuildList(mayBreatheItemList.ToArray());
            mayBreatheLeftDisjunct = StringLibrary.PrefixIf($"{capitalizedPronoun} may breathe ", mayBreatheItemListText);
        }

        string magicalRightDisjunct = "";
        if (monsterSpellKnowledgeDictionary.TryGetValue("which", out List<string>? magicalItemList))
        {
            string magicalItemListText = StringLibrary.BuildList(magicalItemList.ToArray());
            string prefix = $"magical, casting spells";
            if (characteristics.Smart)
            {
                prefix = $"{prefix} intelligently";
            }
            prefix = $"{prefix} which ";
            magicalRightDisjunct = StringLibrary.PrefixIf(prefix, magicalItemListText);
        }

        string mayBreatheAndMagicalSentence = "";
        if (!String.IsNullOrEmpty(mayBreatheLeftDisjunct) && !String.IsNullOrEmpty(magicalRightDisjunct))
        {
            mayBreatheAndMagicalSentence = $"{mayBreatheLeftDisjunct}, and is also {magicalRightDisjunct}";
        }
        else if (!String.IsNullOrEmpty(mayBreatheLeftDisjunct))
        {
            mayBreatheAndMagicalSentence = mayBreatheLeftDisjunct;
        }
        else if (!String.IsNullOrEmpty(magicalRightDisjunct))
        {
            mayBreatheAndMagicalSentence = $"{capitalizedPronoun} is {magicalRightDisjunct}";
        }

        string monsterSpellsKnowledge = StringLibrary.DelimitIf(maySentence, " ", mayBreatheAndMagicalSentence);
        _description.Append(monsterSpellsKnowledge);

        if (!String.IsNullOrEmpty(mayBreatheAndMagicalSentence))
        {
            int m = knowledge.RCastInate + knowledge.RCastSpell;
            n = _monsterRace.FrequencyChance;
            if (m > 100)
            {
                _description.Append("; 1 time in ").Append(100 / n);
            }
            else if (m != 0)
            {
                n = (n + 9) / 10 * 10;
                _description.Append("; about 1 time in ").Append(100 / n);
            }
            _description.Append(". ");
        }
        if (KnowArmor(_monsterRace, knowledge))
        {
            _description.Append(capitalizedPronoun).Append(" is AC ").Append(_monsterRace.ArmorClass);
            if (_monsterRace.Hdice == 1 && _monsterRace.Hside == 1)
            {
                _description.Append(" and has 1hp. ");
            }
            else
            {
                _description.Append(characteristics.ForceMaxHp
                    ? $" and has {_monsterRace.Hdice * _monsterRace.Hside:n0}hp. "
                    : $" and has {_monsterRace.Hdice}d{_monsterRace.Hside}hp. ");
            }
        }
        int vn = 0;
        string[] vp = new string[64];
        if (characteristics.OpenDoor)
        {
            vp[vn++] = "open doors";
        }
        if (characteristics.BashDoor)
        {
            vp[vn++] = "bash down doors";
        }
        if (characteristics.PassWall)
        {
            vp[vn++] = "pass through walls";
        }
        if (characteristics.KillWall)
        {
            vp[vn++] = "bore through walls";
        }
        if (characteristics.MoveBody)
        {
            vp[vn++] = "push past weaker monsters";
        }
        if (characteristics.KillBody)
        {
            vp[vn++] = "destroy weaker monsters";
        }
        if (characteristics.TakeItem)
        {
            vp[vn++] = "pick up objects";
        }
        if (characteristics.KillItem)
        {
            vp[vn++] = "destroy objects";
        }
        if (vn != 0)
        {
            _description.Append(capitalizedPronoun);
            for (n = 0; n < vn; n++)
            {
                if (n == 0)
                {
                    _description.Append(" can ");
                }
                else if (n < vn - 1)
                {
                    _description.Append(", ");
                }
                else
                {
                    _description.Append(" and ");
                }
                _description.Append(vp[n]);
            }
            _description.Append(". ");
        }
        if (characteristics.Invisible)
        {
            _description.Append(capitalizedPronoun).Append(" is invisible. ");
        }
        if (characteristics.ColdBlood)
        {
            _description.Append(capitalizedPronoun).Append(" is cold blooded. ");
        }
        if (characteristics.EmptyMind)
        {
            _description.Append(capitalizedPronoun).Append(" is not detected by telepathy. ");
        }
        if (characteristics.WeirdMind)
        {
            _description.Append(capitalizedPronoun).Append(" is rarely detected by telepathy. ");
        }
        if (characteristics.Multiply)
        {
            _description.Append(capitalizedPronoun).Append(" breeds explosively. ");
        }
        if (characteristics.Regenerate)
        {
            _description.Append(capitalizedPronoun).Append(" regenerates quickly. ");
        }
        vn = 0;
        if (characteristics.HurtByRock)
        {
            vp[vn++] = "rock remover";
        }
        if (characteristics.HurtByLight)
        {
            vp[vn++] = "bright light";
        }
        if (characteristics.HurtByFire)
        {
            vp[vn++] = "fire";
        }
        if (characteristics.HurtByCold)
        {
            vp[vn++] = "cold";
        }
        if (vn != 0)
        {
            _description.Append(capitalizedPronoun);
            for (n = 0; n < vn; n++)
            {
                if (n == 0)
                {
                    _description.Append(" is hurt by ");
                }
                else if (n < vn - 1)
                {
                    _description.Append(", ");
                }
                else
                {
                    _description.Append(" and ");
                }
                _description.Append(vp[n]);
            }
            _description.Append(". ");
        }
        vn = 0;
        if (characteristics.ImmuneAcid)
        {
            vp[vn++] = "acid";
        }
        if (characteristics.ImmuneLightning)
        {
            vp[vn++] = "lightning";
        }
        if (characteristics.ImmuneFire)
        {
            vp[vn++] = "fire";
        }
        if (characteristics.ImmuneCold)
        {
            vp[vn++] = "cold";
        }
        if (characteristics.ImmunePoison)
        {
            vp[vn++] = "poison";
        }
        if (vn != 0)
        {
            _description.Append(capitalizedPronoun);
            for (n = 0; n < vn; n++)
            {
                if (n == 0)
                {
                    _description.Append(" resists ");
                }
                else if (n < vn - 1)
                {
                    _description.Append(", ");
                }
                else
                {
                    _description.Append(" and ");
                }
                _description.Append(vp[n]);
            }
            _description.Append(". ");
        }
        vn = 0;
        if (characteristics.ResistNether)
        {
            vp[vn++] = "nether";
        }
        if (characteristics.ResistWater)
        {
            vp[vn++] = "water";
        }
        if (characteristics.ResistPlasma)
        {
            vp[vn++] = "plasma";
        }
        if (characteristics.ResistNexus)
        {
            vp[vn++] = "nexus";
        }
        if (characteristics.ResistDisenchant)
        {
            vp[vn++] = "disenchantment";
        }
        if (characteristics.ResistTeleport)
        {
            vp[vn++] = "teleportation";
        }
        if (vn != 0)
        {
            _description.Append(capitalizedPronoun);
            for (n = 0; n < vn; n++)
            {
                if (n == 0)
                {
                    _description.Append(" resists ");
                }
                else if (n < vn - 1)
                {
                    _description.Append(", ");
                }
                else
                {
                    _description.Append(" and ");
                }
                _description.Append(vp[n]);
            }
            _description.Append(". ");
        }
        vn = 0;
        if (characteristics.ImmuneStun)
        {
            vp[vn++] = "stunned";
        }
        if (characteristics.ImmuneFear)
        {
            vp[vn++] = "frightened";
        }
        if (characteristics.ImmuneConfusion)
        {
            vp[vn++] = "confused";
        }
        if (characteristics.ImmuneSleep)
        {
            vp[vn++] = "slept";
        }
        if (vn != 0)
        {
            _description.Append(capitalizedPronoun);
            for (n = 0; n < vn; n++)
            {
                if (n == 0)
                {
                    _description.Append(" cannot be ");
                }
                else if (n < vn - 1)
                {
                    _description.Append(", ");
                }
                else
                {
                    _description.Append(" or ");
                }
                _description.Append(vp[n]);
            }
            _description.Append(". ");
        }
        if (knowledge.RWake * knowledge.RWake > _monsterRace.Sleep || knowledge.RIgnore == Constants.MaxUchar ||
            (_monsterRace.Sleep == 0 && (knowledge.RTkills >= 10 || knowledge.RProbed)))
        {
            string act;
            if (_monsterRace.Sleep > 200)
            {
                act = "prefers to ignore";
            }
            else if (_monsterRace.Sleep > 95)
            {
                act = "pays very little attention to";
            }
            else if (_monsterRace.Sleep > 75)
            {
                act = "pays little attention to";
            }
            else if (_monsterRace.Sleep > 45)
            {
                act = "tends to overlook";
            }
            else if (_monsterRace.Sleep > 25)
            {
                act = "takes quite a while to see";
            }
            else if (_monsterRace.Sleep > 10)
            {
                act = "takes a while to see";
            }
            else if (_monsterRace.Sleep > 5)
            {
                act = "is fairly observant of";
            }
            else if (_monsterRace.Sleep > 3)
            {
                act = "is observant of";
            }
            else if (_monsterRace.Sleep > 1)
            {
                act = "is very observant of";
            }
            else if (_monsterRace.Sleep > 0)
            {
                act = "is vigilant for";
            }
            else
            {
                act = "is ever vigilant for";
            }
            _description.Append(capitalizedPronoun).Append(' ').Append(act).Append(" intruders, which ").Append(pronoun).Append(" may notice from ").AppendFormat("{0:n0}", 10 * _monsterRace.NoticeRange).Append(" feet. ");
        }
        if (knowledge.RDropGold != 0 || knowledge.RDropItem != 0)
        {
            bool sin = false;
            _description.Append(capitalizedPronoun).Append(" may carry");
            n = Math.Max(knowledge.RDropGold, knowledge.RDropItem);
            if (n == 1)
            {
                _description.Append(" a");
                sin = true;
            }
            else if (n == 2)
            {
                _description.Append(" one or two");
            }
            else
            {
                _description.Append(" up to ").Append(n);
            }
            if (characteristics.DropGreat)
            {
                p = " exceptional";
            }
            else if (characteristics.DropGood)
            {
                p = " good";
                sin = false;
            }
            else
            {
                p = null;
            }
            if (knowledge.RDropItem != 0)
            {
                if (sin)
                {
                    _description.Append("n");
                }
                sin = false;
                if (!string.IsNullOrEmpty(p))
                {
                    _description.Append(p);
                }
                _description.Append(" object");
                if (n != 1)
                {
                    _description.Append("s");
                }
                p = " or";
            }
            if (knowledge.RDropGold != 0)
            {
                if (string.IsNullOrEmpty(p))
                {
                    sin = false;
                }
                if (sin)
                {
                    _description.Append("n");
                }
                if (!string.IsNullOrEmpty(p))
                {
                    _description.Append(p);
                }
                _description.Append(" treasure");
                if (n != 1)
                {
                    _description.Append("s");
                }
            }
            _description.Append(". ");
        }
        n = 0;
        for (int m = 0; m < _monsterRace.Attacks.Length; m++)
        {
            if (_monsterRace.Attacks[m].Method == null)
            {
                continue;
            }
            if (knowledge.RBlows[m] != 0)
            {
                n++;
            }
        }
        int r = 0;
        for (int m = 0; m < _monsterRace.Attacks.Length; m++)
        {
            if (_monsterRace.Attacks[m].Method == null)
            {
                continue;
            }
            if (knowledge.RBlows[m] == 0)
            {
                continue;
            }
            Attack method = _monsterRace.Attacks[m].Method;
            AttackEffect? effect = _monsterRace.Attacks[m].Effect;
            int d1 = _monsterRace.Attacks[m].Dice;
            int d2 = _monsterRace.Attacks[m].Sides;
            p = method.KnowledgeAction;
            if (effect == null)
                q = null;
            else
                q = effect.Description;

            if (r == 0)
            {
                _description.Append(capitalizedPronoun).Append(" can ");
            }
            else if (r < n - 1)
            {
                _description.Append(", ");
            }
            else
            {
                _description.Append(", and ");
            }
            if (string.IsNullOrEmpty(p))
            {
                p = "do something weird";
            }
            _description.Append(p);
            if (!string.IsNullOrEmpty(q))
            {
                _description.Append(" to ");
                _description.Append(q);
                if (d1 != 0 && d2 != 0 && KnowDamage(_monsterRace, knowledge, m))
                {
                    _description.Append(" for ").Append(d1).Append('d').Append(d2).Append(" damage");
                }
            }
            r++;
        }
        if (r != 0)
        {
            _description.Append(". ");
        }
        else if (characteristics.NeverAttack)
        {
            _description.Append(capitalizedPronoun).Append(" has no physical attacks. ");
        }
        else
        {
            _description.Append("Nothing is known about ").Append(possessiveAdjective).Append(" attack. ");
        }
        if (characteristics.Unique)
        {
            bool dead = _monsterRace.MaxNum == 0;
            if (knowledge.RDeaths != 0)
            {
                _description.Append(pronoun).Append(" has slain ").AppendFormat("{0:n0}", knowledge.RDeaths).Append(" of your ancestors");
                if (dead)
                {
                    _description.Append(", but you have avenged them! ");
                }
                else
                {
                    string remain = knowledge.RDeaths == 1 ? "remains" : "remain";
                    _description.Append(", who ").Append(remain).Append(" unavenged. ");
                }
            }
            else if (dead)
            {
                _description.Append("You have slain this foe. ");
            }
        }
        else if (knowledge.RDeaths != 0)
        {
            string has = knowledge.RDeaths == 1 ? "has" : "have";
            _description.AppendFormat("{0:n0}", knowledge.RDeaths).Append(" of your ancestors ").Append(has).Append(" been killed by this creature, ");
            if (knowledge.RPkills != 0)
            {
                _description.Append(
                    "and you have exterminated at least ").AppendFormat("{0:n0}", knowledge.RPkills).Append(" of the creatures. ");
            }
            else if (knowledge.RTkills != 0)
            {
                _description.Append(
                    "and your ancestors have exterminated at least ").AppendFormat("{0:n0}", knowledge.RTkills).Append(" of the creatures. ");
            }
            else
            {
                _description.Append("and ").Append(pronoun).Append(" is not ever known to have been defeated. ");
            }
        }
        else
        {
            if (knowledge.RPkills != 0)
            {
                _description.Append("You have killed at least ").AppendFormat("{0:n0}", knowledge.RPkills).Append(" of these creatures. ");
            }
            else if (knowledge.RTkills != 0)
            {
                _description.Append(
                    "Your ancestors have killed at least ").AppendFormat("{0:n0}", knowledge.RTkills).Append(" of these creatures. ");
            }
            else
            {
                _description.Append("No battles to the death are recalled. ");
            }
        }
        if (Guardian)
        {
            _description.Append("You feel an intense desire to kill this monster... ");
        }
        Game.Screen.PrintWrap(bodyColor, _description.ToString());
    }

    private void DisplayHeader()
    {
        char c1 = _monsterRace.Symbol.Character;
        ColorEnum a1 = _monsterRace.Color;
        Game.Screen.Erase(0, 0);
        Game.Screen.Goto(0, 0);
        if (!_monsterRace.Unique)
        {
            Game.Screen.Print(ColorEnum.White, "The ");
        }
        Game.Screen.Print(ColorEnum.White, _monsterRace.FriendlyName);
        Game.Screen.Print(ColorEnum.White, " ('");
        Game.Screen.Print(a1, c1.ToString());
        Game.Screen.Print(ColorEnum.White, "')");
    }

    private bool KnowArmor(MonsterRace monsterType, MonsterKnowledge knowledge)
    {
        int kills = knowledge.RTkills;
        if ((kills > 304 / (4 + monsterType.Level)) || knowledge.RProbed)
        {
            return true;
        }
        if (!monsterType.Unique)
        {
            return false;
        }
        return kills > 304 / (38 + (5 * monsterType.Level / 4));
    }

    private bool KnowDamage(MonsterRace monsterType, MonsterKnowledge knowledge, int i)
    {
        int a = knowledge.RBlows[i];
        int d1 = monsterType.Attacks[i].Dice;
        int d2 = monsterType.Attacks[i].Sides;
        int d = d1 * d2;
        if ((4 + monsterType.Level) * a > 80 * d)
        {
            return true;
        }
        if (!monsterType.Unique)
        {
            return false;
        }
        return (4 + monsterType.Level) * 2 * a > 80 * d;
    }
}