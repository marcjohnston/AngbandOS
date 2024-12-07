// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal abstract class BaseCharacterClass : IGetKey
{
    protected readonly Game Game;
    protected BaseCharacterClass(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the names of the <see cref="ItemAction"/> objects that are associated with this <see cref="BaseCharacterClass"/> or null, if this <see cref="BaseCharacterClass"/> doesn't have any
    /// special item action handling.  This property is used to bind the <see cref="ItemActions"/> property using the bind phase.
    /// </summary>
    protected virtual string[]? ItemActionNames => null;

    /// <summary>
    /// Returns the <see cref="ItemAction"/> objects that are associated with this <see cref="BaseCharacterClass"/> or null, if this <see cref="BaseCharacterClass"/> doesn't have any
    /// special item action handling.  This property is bound using the <see cref="ItemActionNames"/> property during the bind phase.
    /// </summary>
    public ItemAction[]? ItemActions { get; private set; } = null;

    /// <summary>
    /// Returns true, for classes that should use the alternate name for items; false, otherwise.  Returns false, by default. Some classes may render item descriptions differently for
    /// some items.  Druid, Fanatic, Monk, Priest and Ranger classes are return true.  Spellbooks are rendered differently for these classes.
    /// </summary>
    public virtual bool UseAlternateItemNames => false;

    public virtual void Cast() => CastSpell();

    /// <summary>
    ///  Updates the Game bonuses based on the player character and race.  The ChosenOne character class overrides this method.  Does nothing, by default.
    /// </summary>
    public virtual void CalcBonuses() { }

    /// <summary>
    /// Cast a spell.  Game.DoCast is called by default.  Mentalism casting type calls Game.DoMentalism.
    /// </summary>
    protected void CastSpell()
    {
        string prayer = Game.BaseCharacterClass.SpellNoun;
        if (!Game.CanCastSpells)
        {
            Game.MsgPrint("You cannot cast spells!");
            return;
        }
        if (Game.BlindnessTimer.Value != 0 || Game.NoLight())
        {
            Game.MsgPrint("You cannot see!");
            return;
        }
        if (Game.ConfusedTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused!");
            return;
        }
        if (!Game.SelectItem(out Item? oPtr, "Use which book? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(IsUsableSpellBookItemFilter))))
        {
            Game.MsgPrint($"You have no {prayer} books!");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        Game.HandleStuff();

        // Allow the player to select the spell.
        if (!Game.GetSpell(out Spell? spell, Game.BaseCharacterClass.CastVerb, oPtr, true))
        {
            Game.MsgPrint($"You don't know any {prayer}s in that book.");
            return;
        }

        // Check to see if the user cancelled the selection.
        if (spell == null)
        {
            return;
        }

        if (spell.ClassSpell.ManaCost > Game.Mana.IntValue)
        {
            string cast = Game.BaseCharacterClass.CastVerb;
            Game.MsgPrint($"You do not have enough mana to {cast} this {prayer}.");
            if (!Game.GetCheck("Attempt it anyway? "))
            {
                return;
            }
        }
        int failureChance = spell.FailureChance();
        if (Game.DieRoll(100) <= failureChance)
        {
            Game.MsgPrint($"You failed to get the {prayer} off!");

            // Reroll again with the save failure chance to run the failed script.
            if (Game.DieRoll(100) <= failureChance)
            {
                spell.CastFailed();
            }
        }
        else
        {
            spell.CastSpell();
        }
        Game.EnergyUse = 100;
        if (spell.ClassSpell.ManaCost <= Game.Mana.IntValue)
        {
            Game.Mana.IntValue -= spell.ClassSpell.ManaCost;
        }
        else
        {
            int oops = spell.ClassSpell.ManaCost - Game.Mana.IntValue;
            Game.Mana.IntValue = 0;
            Game.FractionalMana = 0;
            Game.MsgPrint("You faint from the effort!");
            Game.ParalysisTimer.AddTimer(Game.DieRoll((5 * oops) + 1));
            if (Game.RandomLessThan(100) < 50)
            {
                bool perm = Game.RandomLessThan(100) < 25;
                Game.MsgPrint("You have damaged your health!");
                Game.DecreaseAbilityScore(AbilityEnum.Constitution, 15 + Game.DieRoll(10), perm);
            }
        }
    }

    public void CastMentalism()
    {
        int plev = Game.ExperienceLevel.IntValue;
        if (Game.ConfusedTimer.Value != 0)
        {
            Game.MsgPrint("You are too confused!");
            return;
        }
        if (!GetMentalismTalent(out int n))
        {
            return;
        }
        Talent talent = Game.Talents[n];
        if (talent.ManaCost > Game.Mana.IntValue)
        {
            Game.MsgPrint("You do not have enough mana to use this talent.");
            if (!Game.GetCheck("Attempt it anyway? "))
            {
                return;
            }
        }
        int chance = talent.FailureChance();
        if (Game.RandomLessThan(100) < chance)
        {
            Game.MsgPrint("You failed to concentrate hard enough!");
            if (Game.DieRoll(100) < chance / 2)
            {
                int i = Game.DieRoll(100);
                if (i < 5)
                {
                    Game.MsgPrint("Oh, no! Your mind has gone blank!");
                    Game.LoseAllInfo();
                }
                else if (i < 15)
                {
                    Game.MsgPrint("Weird visions seem to dance before your eyes...");
                    Game.HallucinationsTimer.AddTimer(5 + Game.DieRoll(10));
                }
                else if (i < 45)
                {
                    Game.MsgPrint("Your brain is addled!");
                    Game.ConfusedTimer.AddTimer(Game.DieRoll(8));
                }
                else if (i < 90)
                {
                    Game.StunTimer.AddTimer(Game.DieRoll(8));
                }
                else
                {
                    Game.MsgPrint("Your mind unleashes its power in an uncontrollable storm!");
                    Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile));
                    projectile.Fire(1, 2 + (plev / 10), Game.MapY.IntValue, Game.MapX.IntValue, plev * 2, kill: true, grid: true, item: true, jump: true);
                    Game.Mana.IntValue = Math.Max(0, Game.Mana.IntValue - (plev * Math.Max(1, plev / 10)));
                }
            }
        }
        else
        {
            talent.Use();
        }
        Game.EnergyUse = 100;
        if (talent.ManaCost <= Game.Mana.IntValue)
        {
            Game.Mana.IntValue -= talent.ManaCost;
        }
        else
        {
            int oops = talent.ManaCost - Game.Mana.IntValue;
            Game.Mana.IntValue = 0;
            Game.FractionalMana = 0;
            Game.MsgPrint("You faint from the effort!");
            Game.ParalysisTimer.AddTimer(Game.DieRoll((5 * oops) + 1));
            if (Game.RandomLessThan(100) < 50)
            {
                bool perm = Game.RandomLessThan(100) < 25;
                Game.MsgPrint("You have damaged your mind!");
                Game.DecreaseAbilityScore(AbilityEnum.Wisdom, 15 + Game.DieRoll(10), perm);
            }
        }
    }

    private bool GetMentalismTalent(out int sn)
    {
        int i;
        int num = 0;
        int y = 1;
        int x = 20;
        int plev = Game.ExperienceLevel.IntValue;
        string p = "talent";
        sn = -1;
        bool flag = false;
        ScreenBuffer? savedScreen = null;
        List<Talent> talents = Game.Talents;
        for (i = 0; i < talents.Count; i++)
        {
            if (talents[i].Level <= plev)
            {
                num++;
            }
        }
        string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which {p}? ";
        while (!flag && Game.GetCom(outVal, out char choice))
        {
            if (choice == ' ' || choice == '*' || choice == '?')
            {
                if (savedScreen == null)
                {
                    savedScreen = Game.Screen.Clone();
                    Game.Screen.PrintLine("", y, x);
                    Game.Screen.Print("Name", y, x + 5);
                    Game.Screen.Print("Lv Mana Fail Info", y, x + 35);
                    for (i = 0; i < talents.Count; i++)
                    {
                        Talent talent = talents[i];
                        if (talent.Level > plev)
                        {
                            break;
                        }
                        string psiDesc = $"  {i.IndexToLetter()}) {talent.SummaryLine()}";
                        Game.Screen.PrintLine(psiDesc, y + i + 1, x);
                    }
                    Game.Screen.PrintLine("", y + i + 1, x);
                }
                else
                {
                    Game.Screen.Restore(savedScreen);
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
            return false;
        }
        sn = i;
        return true;
    }

    /// <summary>
    /// Returns the name for the magic type.  Returns "magic" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string MagicType => "magic";

    /// <summary>
    /// Returns true, if the casting type allows the player to choose which spell they want to learn.  Returns true, by default.  Divine
    /// spell casting returns false.
    /// </summary>
    public virtual bool CanChooseSpellToStudy => true;

    /// <summary>
    /// Returns true, if the casting type allows the player to use mana instead of consuming the item.  Returns false, by default.  Channeling
    /// casting type returns true.
    /// </summary>
    public virtual bool CanUseManaInsteadOfConsumingItem => false;

    /// <summary>
    /// Returns the noun to use for spells.  Returns "spell" by default.  Divine casting returns "prayer".
    /// </summary>
    public virtual string SpellNoun => "spell";

    /// <summary>
    /// Returns the verb to use for casting.  Returns "cast" by default.  Divine casting type returns "recite".
    /// </summary>
    public virtual string CastVerb => "cast";

    /// <summary>
    /// Returns true, if the character class cannot gain spell levels until they reach their first spell level.  Returns false, by default.  Arcane and divine spell casting types
    /// return true.
    /// </summary>
    public virtual bool DoesNotGainSpellLevelsUntilFirstSpellLevel => false;

    /// <summary>
    /// Returns true, if the spell weight of the armor can encumber movement.  Returns false, by default.  Arcane returns true.
    /// </summary>
    public virtual bool WeightEncumbersMovement => false;

    /// <summary>
    /// Returns true, if covered hands with covered with an item that restricts casting.  Returns false, by default.
    /// Arcane spell casting returns true.
    /// </summary>
    public virtual bool CoveredHandsRestrictCasting => false;

    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public string GetKey => Key;
    public void Bind()
    {
        List<ItemFactory> outfitItemFactories = new();
        foreach (string outfitItemFactoryName in OutfitItemFactoryNames)
        {
            outfitItemFactories.Add(Game.SingletonRepository.Get<ItemFactory>(outfitItemFactoryName));
        }
        OutfitItemFactories = outfitItemFactories.ToArray();
        ItemActions = Game.SingletonRepository.GetNullable<ItemAction>(ItemActionNames);
    }

    /// <summary>
    /// Returns the deprecated CharacterClass constant for backwards compatibility.
    /// </summary>
    /// <value>The identifier.</value>
    public abstract int ID { get; }

    /// <summary>
    /// Returns true, if players of the character class are outfitted with scrolls of light at the start of the game.  Returns false, by default.
    /// </summary>
    public virtual bool OutfitsWithScrollsOfLight => false;

    public abstract int[] AbilityBonus { get; }

    public abstract int BaseDeviceBonus { get; }

    public abstract int BaseDisarmBonus { get; }

    public abstract int BaseMeleeAttackBonus { get; }

    public abstract int BaseRangedAttackBonus { get; }

    public abstract int BaseSaveBonus { get; }

    public abstract int BaseSearchBonus { get; }

    public abstract int BaseSearchFrequency { get; }

    public abstract int BaseStealthBonus { get; }

    public abstract int DeviceBonusPerLevel { get; }

    public abstract int DisarmBonusPerLevel { get; }

    public abstract int ExperienceFactor { get; }

    public abstract int HitDieBonus { get; }

    public abstract int MeleeAttackBonusPerLevel { get; }

    public abstract int RangedAttackBonusPerLevel { get; }

    public abstract int SaveBonusPerLevel { get; }

    public abstract int SearchBonusPerLevel { get; }

    public abstract int SearchFrequencyPerLevel { get; }

    public abstract int StealthBonusPerLevel { get; }

    public abstract string Title { get; }

    public virtual string ClassSubName(Realm? realm) => Title;
    public abstract int PrimeStat { get; }

    public abstract string[] Info { get; }

    /// <summary>
    /// Returns the maximum amount of armor weight that the player carry before it affects spellcasting.  Returns 0, by default.
    /// </summary>
    /// <value>The spell weight.</value>
    public virtual int SpellWeight => 0;

    public virtual int SpellStat => AbilityEnum.Strength;
    public virtual int MaximumMeleeAttacksPerRound(int level) => 5;
    public virtual int MaximumWeight => 35;
    public virtual int AttackSpeedMultiplier => 3;
    public virtual ArtifactBias? ArtifactBias => null;
    public virtual int FromScrollWarriorArtifactBiasPercentageChance => 0;
    public virtual bool SenseInventoryTest(int level) => false;
    public virtual bool DetailedSenseInventory => false;

    /// <summary>
    /// Represents realms that are available to the character class.  Returns an empty array, if the character class cannot cast spells.
    /// </summary>
    /// <value>The available realms.</value>
    public virtual Realm[] AvailablePrimaryRealms => new Realm[] { };

    /// <summary>
    /// Represents realms that are available to the character class.  Returns an empty array, if the character class cannot cast spells.
    /// </summary>
    /// <value>The available realms.</value>
    public virtual Realm[] AvailableSecondaryRealms => new Realm[] { };

    public Realm[] RemainingAvailableSecondaryRealms()
    {
        return AvailableSecondaryRealms.Where(_realm => _realm != Game.PrimaryRealm).ToArray();
    }

    public virtual bool WorshipsADeity => false; // TODO: Only priests have a godname ... this seems off.

    /// <summary>
    /// Returns the default deity that the character class worships.  This is used when randomly choosing a CharacterClass.  Defaults to None.
    /// </summary>
    public virtual God? DefaultDeity(Realm? realm) => null;

    /// <summary>
    /// Allows the character class to perform any additional handling when an item is destroyed.  Warriors and Paladins gain experience when specific spell books are
    /// destroyed.  Does nothing, by default.
    /// </summary>
    /// <param name="item">The item.</param>
    public virtual void ItemDestroyed(Item item, int amount)
    {
    }

    /// <summary>
    /// Outfits a new player with a starting inventory.
    /// </summary>
    public virtual void OutfitPlayer()
    {
        // An an item for each item that the character classes designates the player to be outfitted with.
        foreach (ItemFactory itemFactory in OutfitItemFactories)
        {
            // Allow the race to modify the item as the race sees fit.
            ItemFactory outfitItemFactory = Game.Race.OutfitItemClass(itemFactory);

            // Create an item from the factory.
            Item item = outfitItemFactory.GenerateItem();
            if (outfitItemFactory.AimingTuple != null)
            {
                item.WandChargesRemaining = 1;
            }
            Game.OutfitPlayerWithItem(item);

            // Allow the character class a chance to modify the item.
            OutfitItem(item);
        }
    }

    /// <summary>
    /// Represents the class of items a new player should be outfitted with.
    /// </summary>
    protected ItemFactory[] OutfitItemFactories { get; private set; }
    protected abstract string[] OutfitItemFactoryNames { get; }


    /// <summary>
    /// During the outfit process, derived character classes can modify outfitted items.  Does nothing by default.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void OutfitItem(Item item) { }

    /// <summary>
    /// Update the player bonuses for a melee weapon.
    /// </summary>
    /// <param name="oPtr"></param>
    public virtual void UpdateBonusesForMeleeWeapon(Item oPtr) { }
}
