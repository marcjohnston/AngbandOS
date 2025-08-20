// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
namespace AngbandOS.Core;

[Serializable]
internal class Game
{
    //public string Find(string folder, string key)
    //{
    //    string path = Path.Combine(folder, $"{key}.cs");
    //    if (File.Exists(path))
    //        return path;
    //    foreach (string subfolder in Directory.GetDirectories(folder))
    //    {
    //        path = Path.Combine(subfolder, $"{key}.cs");
    //        if (File.Exists(path))
    //            return path;
    //    }
    //    throw new Exception("");
    //}
    //public string? CutProperty(string folder, string key, string text)
    //{
    //    string path = Find(folder, key);
    //    List<string> lines = File.ReadAllLines(path).ToList();
    //    foreach (string line in lines)
    //    {
    //        if (line.Contains(text))
    //        {
    //            lines.Remove(line);
    //            File.WriteAllLines(path, lines);
    //            return line;
    //        }
    //    }
    //    return null;
    //}

    //public void PasteProperty(string folder, string key, string text)
    //{
    //    string path = Path.Combine(folder, $"{key}.cs");
    //    List<string> lines = File.ReadAllLines(path).ToList();
    //    if (!lines.Any(_l => _l.Contains($"class {key}")))
    //        throw new Exception("");
    //    for (int i = lines.Count - 1; i >= 0; i--)
    //    {
    //        string line = lines[i];
    //        if (line.Contains("}"))
    //        {
    //            lines.Insert(i, text);
    //            File.WriteAllLines(path, lines);
    //            return;
    //        }
    //    }
    //    throw new Exception("");
    //}

    public int EnchantBonus(int bonus)
    {
        do
        {
            bonus++;
        } while (bonus < DieRoll(5) || DieRoll(bonus) == 1);
        if (bonus > 4 && DieRoll(Constants.WeirdLuck) != 1)
        {
            bonus = 4;
        }
        return bonus;
    }

    #region Game Replay
    /// <summary>
    /// Returns the date and time of when the last keystroke was presented to the game either by the replay system or via the keyboard/console.
    /// </summary>
    private DateTime? LastKeystrokeDateTime = null;

    /// <summary>
    /// Tracks the index for the GameReplayStep that will be sent to the game during game replay mode.  In recording mode, it is incremented to ensure the game doesn't attempt to replay the same keystroke.
    /// </summary>
    private int ReplayQueueIndex = 0;

    /// <summary>
    /// The queue for recording keystrokes or playing back keystrokes.  This structure is used for both recording and playback.
    /// </summary>
    public readonly List<GameReplayStep> ReplayQueue = new List<GameReplayStep>(); // List.Add has a O(1) time complexity until it needs to be resized.

    /// <summary>
    /// Returns the random seed to start the game that is applied to the non-fixed random generator.
    /// </summary>
    public int MainSequenceRandomSeed;

    /// <summary>
    /// Returns the value of the non-fixed random seed to use to restore the non-fixed random generator.  This seed is needed because the Random object cannot be serialized and we need to restore
    /// the non-fixed random generator when a saved game is restored.
    /// </summary>
    public int CurrentSequenceRandomSeed;

    /// <summary>
    /// Returns true, when the game is processing the popup menu.  This value is used to determine when the game is entering and existing the popup menu mode.  Keystrokes that are used during, to render or
    /// to exit the popup menu are not recorded--in actuality, those keystrokes are removed from the queue.
    /// </summary>
    public bool PreviousInPopupMenu = false;
    #endregion

    public readonly int[][] BlowsTable;
    public readonly int[] RequiredExperiencePerLevel;
    public readonly int[] ExtractEnergy;

    public Ability StrengthAbility; // TODO: These are still hardcoded into the framework
    public Ability IntelligenceAbility; // TODO: These are still hardcoded into the framework
    public Ability WisdomAbility; // TODO: These are still hardcoded into the framework
    public Ability DexterityAbility; // TODO: These are still hardcoded into the framework
    public Ability ConstitutionAbility; // TODO: These are still hardcoded into the framework
    public Ability CharismaAbility; // TODO: These are still hardcoded into the framework

    private const int DecayRate = 10;
    private const int PatronRestingFavour = 30;
    public God? God;

    public readonly List<Mutation> NaturalAttacks = new List<Mutation>();
    public int GenomeArmorClassBonus;
    public bool ChaosGift;
    public int CharismaBonus;
    public int ConstitutionBonus;
    public int DexterityBonus;
    public bool ElecHit;
    public bool Esp;
    public bool FeatherFall;
    public bool FireHit;
    public bool FreeAction;
    public int InfravisionBonus;
    public int IntelligenceBonus;
    public bool MagicResistance;
    public bool Regen;
    public bool ResFear;
    public bool ResTime;
    public int SearchBonus;
    public int SpeedBonus;
    public int StealthBonus;
    public int StrengthBonus;
    public bool SuppressRegen;
    public bool SustainAll;
    public bool Vulnerable;
    public int WisdomBonus;
    public readonly List<Mutation> MutationsNotPossessed = new List<Mutation>();
    public readonly List<Mutation> MutationsPossessed = new List<Mutation>();

    [NonSerialized]
    private Random _mainSequence;

    [NonSerialized]
    private Random _fixed;

    public Random UseRandom => UseFixed ? _fixed : _mainSequence;

    /// <summary>
    /// Set true to use the fixed seed, and false to use the generic randomiser
    /// </summary>
    public bool UseFixed = false;

    private const int _randnorNum = 256;
    private const int _randnorStd = 64;

    private readonly int[] _randnorTable =
    {
        206, 613, 1022, 1430, 1838, 2245, 2652, 3058, 3463, 3867, 4271, 4673, 5075, 5475, 5874, 6271, 6667, 7061,
        7454, 7845, 8234, 8621, 9006, 9389, 9770, 10148, 10524, 10898, 11269, 11638, 12004, 12367, 12727, 13085,
        13440, 13792, 14140, 14486, 14828, 15168, 15504, 15836, 16166, 16492, 16814, 17133, 17449, 17761, 18069,
        18374, 18675, 18972, 19266, 19556, 19842, 20124, 20403, 20678, 20949, 21216, 21479, 21738, 21994, 22245,
        22493, 22737, 22977, 23213, 23446, 23674, 23899, 24120, 24336, 24550, 24759, 24965, 25166, 25365, 25559,
        25750, 25937, 26120, 26300, 26476, 26649, 26818, 26983, 27146, 27304, 27460, 27612, 27760, 27906, 28048,
        28187, 28323, 28455, 28585, 28711, 28835, 28955, 29073, 29188, 29299, 29409, 29515, 29619, 29720, 29818,
        29914, 30007, 30098, 30186, 30272, 30356, 30437, 30516, 30593, 30668, 30740, 30810, 30879, 30945, 31010,
        31072, 31133, 31192, 31249, 31304, 31358, 31410, 31460, 31509, 31556, 31601, 31646, 31688, 31730, 31770,
        31808, 31846, 31882, 31917, 31950, 31983, 32014, 32044, 32074, 32102, 32129, 32155, 32180, 32205, 32228,
        32251, 32273, 32294, 32314, 32333, 32352, 32370, 32387, 32404, 32420, 32435, 32450, 32464, 32477, 32490,
        32503, 32515, 32526, 32537, 32548, 32558, 32568, 32577, 32586, 32595, 32603, 32611, 32618, 32625, 32632,
        32639, 32645, 32651, 32657, 32662, 32667, 32672, 32677, 32682, 32686, 32690, 32694, 32698, 32702, 32705,
        32708, 32711, 32714, 32717, 32720, 32722, 32725, 32727, 32729, 32731, 32733, 32735, 32737, 32739, 32740,
        32742, 32743, 32745, 32746, 32747, 32748, 32749, 32750, 32751, 32752, 32753, 32754, 32755, 32756, 32757,
        32757, 32758, 32758, 32759, 32760, 32760, 32761, 32761, 32761, 32762, 32762, 32763, 32763, 32763, 32764,
        32764, 32764, 32764, 32765, 32765, 32765, 32765, 32766, 32766, 32766, 32766, 32767
    };

    private int _fixedSeed;

    public int FixedSeed // TODO: This is ugly
    {
        get => _fixedSeed;
        set
        {
            _fixed = new Random(value);
            _fixedSeed = value;
        }
    }

    public readonly ExpressionParser ExpressionParser;
    public readonly ParseLanguage ParseLanguage;
    public readonly IntegerToDecimalExpressionTypeConverter IntegerToDecimalExpressionTypeConverter;
    public readonly DecimalToIntegerExpressionTypeConverter DecimalToIntegerExpressionTypeConverter;

    public readonly string[] ShopkeeperAcceptedComments;
    public readonly string[] IllegibleFlavorSyllables;
    public readonly string[] FindQuests;
    public readonly string[] ElvishTexts;
    public readonly string[] FunnyDescriptions;
    public readonly string[] FunnyComments;
    public readonly string[] HorrificDescriptions;

    public readonly RefreshMapProperty RefreshMap;
    public readonly TrackedMonsterChangedProperty TrackedMonsterChanged;
    public bool IsBirthday;
    public bool IsDawn;
    public bool IsDusk;
    public bool IsFeelTime;
    public bool IsHalloween;
    public bool IsMidnight;
    public bool IsNewYear;

    private const int LevelFeelDelay = 2500;
    private const int MillisecondsPerTurn = 800;
    private int _birthday;
    private readonly CurrentGameDateTimeProperty CurrentGameDateTime;
    private int _currentTurn;

    /// <summary>
    /// Returns the date and time for the next dawn.  This is computed on a regular basis.
    /// </summary>
    private DateTime _dawn;

    /// <summary>
    /// Returns the date and time for the next dusk.  This is computed on a regular basic.
    /// </summary>
    private DateTime _dusk;

    private DateTime _gameStartDateTime;
    private int _levelEntryTurn;
    private TimeSpan _tick = new TimeSpan(0, 0, 0, 0, MillisecondsPerTurn);

    public const int DungeonCount = 20; // TODO: Use the Singleton.Dungeons.Count property

    /// <summary>
    /// Returns the maximum level of light that the player is allowed to have.  Returns 5, by default.  The <see cref="UpdateLightFlaggedAction"/> uses a precomputed algorithm for processing the
    /// light-of-sight and which grid locations can get the light.  This algorithm would need to be updated to support further distances.
    /// </summary>
    public int? MaximumLightLevel { get; set; } = 5;

    /// <summary>
    /// Returns the additive value of items that offer strength modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusStrengthValue = 1200;

    /// <summary>
    /// Returns the additive value of items that offer intelligence modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusIntelligenceValue = 1200;

    /// <summary>
    /// Returns the additive value of items that offer wisdom modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusWisdomValue = 1200;

    /// <summary>
    /// Returns the additive value of items that have the dexterity modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusDexterityValue = 1200;

    /// <summary>
    /// Returns the additive value of items that have the constitution modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusConstitutionValue = 1200;

    /// <summary>
    /// Returns the additive value of items that have the charisma modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusCharismaValue = 450;

    /// <summary>
    /// Returns the additive value of items that have the stealth modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusStealthValue = 350;

    /// <summary>
    /// Returns the additive value of items that have the search modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusSearchValue = 200;

    /// <summary>
    /// Returns the additive value of items that have the infravision modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusInfravisionValue = 200;

    /// <summary>
    /// Returns the additive value of items that have the tunnel modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusTunnelValue = 225;

    /// <summary>
    /// Returns the additive value of items that have the extra blows modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusExtraBlowslValue = 7000;

    /// <summary>
    /// Returns the additive value of items that have the speed modifiers.  Each bonus unit is assigned this much value.
    /// </summary>
    public int BonusSpeedlValue = 33000;

    /// <summary>
    /// Returns the additive value of items that have the chaotic modifier.
    /// </summary>
    public int BonusChaoticValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the vampiric modifier.
    /// </summary>
    public int BonusVampiricValue = 13000;

    /// <summary>
    /// Returns the additive value of items that have the anti-theft modifier.
    /// </summary>
    public int BonusAntiTheftValue = 0;

    /// <summary>
    /// Returns the additive value of items that have the slay-animal modifier.
    /// </summary>
    public int BonusSlayAnimalValue = 3500;

    /// <summary>
    /// Returns the additive value of items that have the slay-evil modifier.
    /// </summary>
    public int BonusSlayEvilValue = 4500;

    /// <summary>
    /// Returns the additive value of items that have the slay-undead modifier.
    /// </summary>
    public int BonusSlayUndeadValue = 3500;

    /// <summary>
    /// Returns the additive value of items that have the slay-demon modifier.
    /// </summary>
    public int BonusSlayDemonValue = 3500;

    /// <summary>
    /// Returns the additive value of items that have the slay-orc modifier.
    /// </summary>
    public int BonusSlayOrcValue = 3000;

    /// <summary>
    /// Returns the additive value of items that have the slay-troll modifier.
    /// </summary>
    public int BonusSlayTrollValue = 3500;

    /// <summary>
    /// Returns the additive value of items that have the slay-giant modifier.
    /// </summary>
    public int BonusSlayGiantlValue = 3500;

    /// <summary>
    /// Returns the additive value of items that have the slay-dragon modifier.
    /// </summary>
    public int BonusSlayDragonValue = 1500;

    /// <summary>
    /// Returns the additive value of items that have the vorpal modifier.
    /// </summary>
    public int BonusVorpalValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the impact modifier.
    /// </summary>
    public int BonusImpactValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the poison-branding modifier.
    /// </summary>
    public int BonusBrandPoisValue = 7500;

    /// <summary>
    /// Returns the additive value of items that have the acid-branding modifier.
    /// </summary>
    public int BonusBrandAcidValue = 7500;

    /// <summary>
    /// Returns the additive value of items that have the electricity-branding modifier.
    /// </summary>
    public int BonusBrandElecValue = 7500;

    /// <summary>
    /// Returns the additive value of items that have the fire-branding modifier.
    /// </summary>
    public int BonusBrandFireValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the cold-branding modifier.
    /// </summary>
    public int BonusBrandColdValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the sustain-strength modifier.
    /// </summary>
    public int BonusSustStrValue = 850;

    /// <summary>
    /// Returns the additive value of items that have the sustain-intelligence modifier.
    /// </summary>
    public int BonusSustIntValue = 850;

    /// <summary>
    /// Returns the additive value of items that have the sustain-wisdom modifier.
    /// </summary>
    public int BonusSustWisValue = 850;

    /// <summary>
    /// Returns the additive value of items that have the sustain-dexterity modifier.
    /// </summary>
    public int BonusSustDexValue = 850;

    /// <summary>
    /// Returns the additive value of items that have the sustain-constitution modifier.
    /// </summary>
    public int BonusSustConValue = 850;

    /// <summary>
    /// Returns the additive value of items that have the sustain-charisma modifier.
    /// </summary>
    public int BonusSustChaValue = 250;

    /// <summary>
    /// Returns the additive value of items that have the acid-immunity modifier.
    /// </summary>
    public int BonusImAcidValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the electricity-immunity modifier.
    /// </summary>
    public int BonusImElecValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the fire-immunity modifier.
    /// </summary>
    public int BonusImFireValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the cold-immunity modifier.
    /// </summary>
    public int BonusImColdValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the bolts-and-arrows-reflection modifier.
    /// </summary>
    public int BonusReflectValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the free-action modifier.
    /// </summary>
    public int BonusFreeActValue = 4500;

    /// <summary>
    /// Returns the additive value of items that have the hold-life-experiences modifier.
    /// </summary>
    public int BonusHoldLifeValue = 8500;

    /// <summary>
    /// Returns the additive value of items that have the acid-resistance modifier.
    /// </summary>
    public int BonusResAcidValue = 1250;

    /// <summary>
    /// Returns the additive value of items that have the electricity-resistance modifier.
    /// </summary>
    public int BonusResElecValue = 1250;

    /// <summary>
    /// Returns the additive value of items that have the fire-resistance modifier.
    /// </summary>
    public int BonusResFireValue = 1250;

    /// <summary>
    /// Returns the additive value of items that have the cold-resistance modifier.
    /// </summary>
    public int BonusResColdValue = 1250;

    /// <summary>
    /// Returns the additive value of items that have the poison-resistance modifier.
    /// </summary>
    public int BonusResPoisValue = 2500;

    /// <summary>
    /// Returns the additive value of items that have the fear-resistance modifier.
    /// </summary>
    public int BonusResFearValue = 2500;

    /// <summary>
    /// Returns the additive value of items that have the light-resistance modifier.
    /// </summary>
    public int BonusResLightValue = 1750;

    /// <summary>
    /// Returns the additive value of items that have the darkness-resistance modifier.
    /// </summary>
    public int BonusResDarkValue = 1750;

    /// <summary>
    /// Returns the additive value of items that have the blindness-resistance modifier.
    /// </summary>
    public int BonusResBlindValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the confusion-resistance modifier.
    /// </summary>
    public int BonusResConfValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the sound-resistance modifier.
    /// </summary>
    public int BonusResSoundValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the shards-resistance modifier.
    /// </summary>
    public int BonusResShardsValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the nether-resistance modifier.
    /// </summary>
    public int BonusResNetherValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the nexus-resistance modifier.
    /// </summary>
    public int BonusResNexusValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the chaos-resistance modifier.
    /// </summary>
    public int BonusResChaosValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the disenchantment-resistance modifier.
    /// </summary>
    public int BonusResDisenValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the sheath-of-fire modifier.
    /// </summary>
    public int BonusShFireValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the sheath-of-electricity modifier.
    /// </summary>
    public int BonusShElecValue = 5000;

    /// <summary>
    /// Returns the additive value of items that have the teleportation-immunity modifier.
    /// </summary>
    public int BonusNoTeleValue = 2500;

    /// <summary>
    /// Returns the additive value of items that have the magic-immunity modifier.
    /// </summary>
    public int BonusNoMagicValue = 2500;

    /// <summary>
    /// Returns the additive value of items that have the wraith-form modifier.
    /// </summary>
    public int BonusWraithValue = 250000;

    /// <summary>
    /// Returns the additive value of items that have the dread-curse modifier.
    /// </summary>
    public int BonusDreadCurseValue = -15000;

    /// <summary>
    /// Returns the additive value of items that have the feather-fall modifier.
    /// </summary>
    public int BonusFeatherValue = 1250;

    /// <summary>
    /// Returns the additive value of items that have the see-invisible modifier.
    /// </summary>
    public int BonusSeeInvisValue = 2000;

    /// <summary>
    /// Returns the additive value of items that have the telepathy modifier.
    /// </summary>
    public int BonusTelepathyValue = 12500;

    /// <summary>
    /// Returns the additive value of items that have the slow-digestion modifier.
    /// </summary>
    public int BonusSlowDigestValue = 750;

    /// <summary>
    /// Returns the additive value of items that have the regeneration modifier.
    /// </summary>
    public int BonusRegenValue = 2500;

    /// <summary>
    /// Returns the additive value of items that have the extra-might modifier.
    /// </summary>
    public int BonusXtraMightValue = 2250;

    /// <summary>
    /// Returns the additive value of items that have the extra-shots modifier.
    /// </summary>
    public int BonusXtraShotsValue = 10000;

    /// <summary>
    /// Returns the additive value of items that have the ignore-acid modifier.
    /// </summary>
    public int BonusIgnoreAcidValue = 100;

    /// <summary>
    /// Returns the additive value of items that have the ignore-electricity modifier.
    /// </summary>
    public int BonusIgnoreElecValue = 100;

    /// <summary>
    /// Returns the additive value of items that have the ignore-fire modifier.
    /// </summary>
    public int BonusIgnoreFireValue = 100;

    /// <summary>
    /// Returns the additive value of items that have the ignore-cold modifier.
    /// </summary>
    public int BonusIgnoreColdValue = 100;

    /// <summary>
    /// Returns the additive value of items that have the drain-experience modifier.
    /// </summary>
    public int BonusDrainExpValue = -12500;

    /// <summary>
    /// Returns the additive value of items that have the teleport modifier.
    /// </summary>
    public int BonusTeleportValue = 250;

    /// <summary>
    /// Returns the additive value of items that have the aggravate modifier.
    /// </summary>
    public int BonusAggravateValue = -10000;

    /// <summary>
    /// Returns the additive value of items that have the blessed modifier.
    /// </summary>
    public int BonusBlessedValue = 750;

    /// <summary>
    /// Returns the additive value of items that have the cursed modifier.
    /// </summary>
    public int BonusIsCursedValue = -5000;

    /// <summary>
    /// Returns the additive value of items that have the heavy-curse modifier.
    /// </summary>
    public int BonusHeavyCurseValue = -12500;

    /// <summary>
    /// Returns the additive value of items that have the permanent-curse modifier.
    /// </summary>
    public int BonusPermaCurseValue = -15000;

    /// <summary>
    /// Returns true, if the player is dead; false, otherwise.
    /// </summary>
    public bool IsDead = false;

    public const int OneInChanceUpStairsReturnsToTownLevel = 5;

    public SingletonRepository SingletonRepository;

    private DungeonGenerator DungeonGenerator;

    /// <summary>
    /// Maximum amount of health that can be drained from an opponent in one turn
    /// </summary>
    private const int _maxVampiricDrain = 100;

    /// <summary>
    /// The direction the player is currently running in
    /// </summary>
    public int CurrentRunDirection;

    /// <summary>
    /// A list of entry points into the _directionCycle for each direction (except 0 or 5) that
    /// take you to a middling entry for that direction from which we can safely rotate to
    /// either side
    /// </summary>
    private readonly int[] _cycleEntryPoint = { 0, 8, 9, 10, 7, 0, 11, 6, 5, 4 };

    /// <summary>
    /// A list of keypad directions which rotates left when you increment and right when you decrement
    /// </summary>
    private readonly int[] _directionCycle = { 1, 2, 3, 6, 9, 8, 7, 4, 1, 2, 3, 6, 9, 8, 7, 4, 1 };

    private bool _findBreakleft;
    private bool _findBreakright;
    private bool _findOpenarea;

    /// <summary>
    /// The direction in which we were previously running
    /// </summary>
    private int _previousRunDirection;

    /// <summary>
    /// Returns the date and time when the last player input was received or the game was initially started.  Null, until the game is started.
    /// </summary>
    public DateTime? LastInputReceived = null;

    public int CommandRepeat;
    public readonly List<Quest> Quests;

    public WildernessRegion[][] Wilderness { get; private set; }
    private byte[][] _elevationMap;

    public int AllocKindSize;
    public AllocationEntry[] AllocKindTable;
    public int AllocRaceSize;
    public AllocationEntry[] AllocRaceTable;
    public LevelStartEnum CameFrom;

    /// <summary>
    /// Uses to control whether messages are rendered to the player when bonuses are updated.
    /// </summary>
    public bool CharacterXtra; // TODO: This global can be removed when actions are updated

    public bool CreateDownStair;
    public bool CreateUpStair;
    public Dungeon CurDungeon; // TODO: This may be CurTown.Dungeon?
    public int CurrentDepth;
    public Town CurTown;
    public string DiedFrom;
    public int DungeonDifficulty;
    public int EnergyUse;
    public bool HackMind;
    public bool NewLevelFlag;
    public bool Playing;
    public Dungeon RecallDungeon;
    public int Resting;
    public int Running;

    /// <summary>
    /// Returns the target the player has selected; or null, if the player hasn't chosen a target.
    /// </summary>
    public Target? TargetWho;

    public int TotalFriendLevels;
    public int TotalFriends;
    public NullableMonsterProperty TrackedMonster;

    /// <summary>
    /// Returns true, when the GetItem/SelectItem is rendering the equipment list, instead of the inventory list (when the ViewingItemList is true).
    /// </summary>
    public bool ViewingEquipment; // TODO: Convert to parameter

    /// <summary>
    /// Returns true, when the player is selecting an item and the inventory/equipment list is being rendered.
    /// </summary>
    public bool ViewingItemList;

    private List<Monster> _petList = new List<Monster>();
    private int _seedFlavor;
    public const int HurtChance = 16;

    public ExPlayer ExPlayer;

    /// <summary>
    /// Returns the level of the first spell that the player can cast or null, if there are no books or spells in either realm.
    /// </summary>
    public int? LevelOfFirstSpell;

    public int HalfLevelsOfSpellcraft()
    {
        int levels = ExperienceLevel.IntValue;
        if (BaseCharacterClass.DoesNotGainSpellLevelsUntilFirstSpellLevel && LevelOfFirstSpell != null)
        {
            levels = levels - LevelOfFirstSpell.Value + 1;
            if (levels < 0)
            {
                levels = 0;
            }
        }
        return levels;
    }

    /// <summary>
    /// Represents the order in which spells that have been learned.  When a spell is learned, it is added to this list.  It is not removed, if the spell is forgotten,
    /// so that when the player regains the necessary experience, the same spell is relearned.
    /// </summary>
    public readonly List<Spell> SpellOrder = new List<Spell>();
                                                         
    public List<Talent> Talents;

    /// <summary>
    /// Represents the object responsible for saving the game, when needed.  If null, the game cannot be saved.
    /// </summary>
    [NonSerialized]
    public ICorePersistentStorage? CorePersistentStorage;

    /// <summary>
    /// Returns the object that the calling application provided to be used to connect the game input and output to the calling application.
    /// </summary>
    [NonSerialized]
    public IConsoleViewPort ConsoleViewPort;

    public int CommandArgument;
    public int CommandDirection;
    public char CurrentCommand;

    /// <summary>
    /// Set to indicate that there is a full screen overlay covering the normally updated locations
    /// </summary>
    public bool FullScreenOverlay;

    /// <summary>
    /// Set to indicate that the cursor should be hidden while waiting for a keypress with a
    /// full screen overlay
    /// </summary>
    public bool HideCursorOnFullScreenInkey;

    public bool InPopupMenu;

    public char[] KeyQueue;

    /// <summary>
    /// The current contents of the game screen.
    /// </summary>
    public Window Screen;

    public int KeyHead = 0;
    public int KeyTail = 0;

    /// <summary>
    /// A buffer of artificial keypresses.  Keys in this buffer will be read from by the Inkey method before the keyboard queue is read.  These artifical keypresses are used only for conversion of 
    /// </summary>
    public string _artificialKeyBuffer = "";

    private string[][] _keymapAct;

    /// <summary>
    /// Returns true, if the parent is requesting the game to shut down immediately.  Returns false, by default.
    /// </summary>
    [NonSerialized]
    public bool Shutdown = false;

    /// GUI
    public const int SafeMaxAttempts = 5000;

    public readonly string[] History = new string[4];
    public readonly int[] MaxDlv = new int[DungeonCount];
    public readonly int[] PlayerHp = new int[Constants.PyMaxLevel];
    public int Age;
    public int ArmorClassBonus;
    public int Energy;
    public readonly ExperienceMultiplierIntProperty ExperienceMultiplier;

    public Bonuses Bonuses = new Bonuses(); // Create a new bonuses with default values until the UpdateBonusesFlaggedAction updates it.

    public int FractionalExperiencePoints;
    public int FractionalHealth;
    public int FractionalMana;
    public Gender? Gender = null; // The gender will be null until the player has selected the gender.
    public int Generation; // This is how many times the character name has changed.
    public bool GetFirstLevelMutation;
    
    public readonly GoldIntProperty Gold;
    public readonly ManaIntProperty Mana;
    public readonly MaxManaIntProperty MaxMana;
    public readonly ExperiencePointsIntProperty ExperiencePoints;
    public int DisplayedArmorClassBonus;
    public int DisplayedBaseArmorClass;
    public readonly StringProperty PlayerName;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>state->speed</remarks>
    public readonly SpeedIntProperty Speed;

    public readonly SpareSpellSlotsIntProperty SpareSpellSlots;

    public View ConsoleView { get; private set; }

    public readonly HealthPointsIntProperty Health;

    public readonly MaxHealthPointsIntProperty MaxHealth;

    /// <summary>
    ///
    /// </summary>
    /// <remarks>borg: This was player->exp</remarks>
    public readonly FoodIntProperty Food; // TODO: How is this different from a timer

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->lev</remarks>
    public readonly ExperienceLevelIntProperty ExperienceLevel;

    public Patron GooPatron;
    public bool HasAcidImmunity;
    public bool HasAcidResistance;
    public bool HasAggravation;
    public bool HasAntiMagic;
    public bool HasAntiTeleport;
    public bool HasAntiTheft;
    public bool HasBlessedBlade;
    public bool HasBlindnessResistance;
    public bool HasChaosResistance;
    public bool HasColdImmunity;
    public bool HasColdResistance;

    /// <summary>
    /// Returns true, if the players automatically instills confusion in monsters when the player touches the monster.
    /// </summary>
    public bool HasConfusingTouch;

    public bool HasConfusionResistance;
    public bool HasDarkResistance;
    public bool HasDisenchantResistance;
    public bool HasElementalVulnerability;
    public bool HasExperienceDrain;
    public bool HasExtraMight;
    public bool HasFearResistance;
    public bool HasFeatherFall;
    public bool HasFireImmunity;
    public bool HasFireResistance;
    public bool HasFireSheath;
    public bool HasFreeAction;

    /// <summary>
    /// Returns true, if the players race glows in the dark.  Spectres, sprites and vampires glow.
    /// </summary>
    public int GlowInTheDarkRadius;

    public bool HasHoldLife;
    public bool HasLightningImmunity;
    public bool HasLightningResistance;
    public bool HasElectricitySheath;
    public bool HasLightResistance;
    public bool HasNetherResistance;
    public bool HasNexusResistance;
    public bool HasPoisonResistance;
    public bool HasQuakeWeapon;
    public bool HasRandomTeleport;
    public bool HasReflection;
    public bool HasRegeneration;
    public bool HasRestrictingArmor;
    public bool HasRestrictingGloves;
    public bool HasSeeInvisibility;
    public bool HasShardResistance;
    public bool HasSlowDigestion;
    public bool HasSoundResistance;
    public bool HasSustainCharisma;
    public bool HasSustainConstitution;
    public bool HasSustainDexterity;
    public bool HasSustainIntelligence;
    public bool HasSustainStrength;
    public bool HasSustainWisdom;
    public bool HasTelepathy;
    public bool HasTimeResistance;
    public int Height;
    public int HitDie;
    public int InfravisionRange;
    public bool IsSearching;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->total_winner</remarks>
    public readonly IsWinnerBoolProperty IsWinner;
    public readonly IsWizardBoolProperty IsWizard;

    public int LightLevel;

    /// <summary>
    /// The current player X position.
    /// </summary>
    public readonly MapXIntProperty MapX;

    /// <summary>
    /// The current player Y position.
    /// </summary>
    public readonly MapYIntProperty MapY;

    /// <summary>
    /// Returns the highest experience points that the player has achieved.  This value may be different from the current experience points due to the player losing experience.  This
    /// property maintains this highest value so that the player can restore those lost experience.
    /// </summary>
    /// <remarks>borg: player->max_exp</remarks>
    public readonly HighestExperiencePointsAchievedIntProperty MaxExperienceGained;

    /// <summary>
    ///
    /// </summary>
    /// <remarks>borg: player->max_lev</remarks>
    public int MaxLevelGained;
    public int MeleeAttacksPerRound;
    public int MissileAttacksPerRound;
    public int OldSpareSpellSlots;

    /// <summary>
    /// Represents the character class of the player.  Will be null prior to the character class birth selection.
    /// </summary>
    public BaseCharacterClass BaseCharacterClass;

    /// <summary>
    /// Returns the current race of the character.  Will be null before the player is birthed.
    /// </summary>
    public Race? Race = null;

    /// <summary>
    /// Returns the race the character was first assigned at birth.
    /// </summary>
    public Race RaceAtBirth;

    /// <summary>
    /// Returns the primary realm that the player studies.
    /// </summary>
    /// <value>The realm1.</value>
    public Realm? PrimaryRealm = null;

    /// <summary>
    /// Returns the secondary realm that the player studies.
    /// </summary>
    /// <value>The realm2.</value>
    public Realm? SecondaryRealm = null;

    /// <summary>
    /// Returns true, if the player can cast spells and/or read books.  True, for character classes that can choose either a primary and/or secondary realm.
    /// </summary>
    public bool CanCastSpells => PrimaryRealm != null || SecondaryRealm != null;

    public bool UsesMana => CanCastSpells || BaseCharacterClass.CanUseManaInsteadOfConsumingItem;

    /// <summary>
    /// Returns true, if the player has chosen the realm <T> for either the primary or secondary realms to study.
    /// </summary>
    /// <returns></returns>
    [Obsolete("Relies on the Realm.Key")]
    public bool Studies(string realmName) => (PrimaryRealm != null && PrimaryRealm.Key == realmName) || (SecondaryRealm != null && SecondaryRealm.Key == realmName); // TODO: This relies on the realm key.

    public int SkillDigging;
    public int SkillDisarmTraps;
    public int SkillMelee;
    public int SkillRanged;
    public int SkillSavingThrow;
    public int SkillSearchFrequency;
    public int SkillSearching;
    public int SkillStealth;
    public int SkillThrowing;
    public int SkillUseDevice;
    public int SocialClass;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_OPP_ACID]</remarks>
    public readonly Timer AcidResistanceTimer;
    public readonly Timer BleedingTimer;
    public readonly Timer BlessingTimer;
    public readonly Timer BlindnessTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_OPP_COLD]</remarks>
    public readonly Timer ColdResistanceTimer;
    public readonly Timer ConfusionTimer;
    public readonly Timer EtherealnessTimer;
    public readonly Timer FearTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_OPP_FIRE]</remakrs>
    public readonly Timer FireResistanceTimer;
    public readonly Timer HallucinationsTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>readonly borg: player->timed[TMD_FAST]</remarks>
    public readonly Timer HasteTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_HERO]</remarks>
    public readonly Timer HeroismTimer;
    public readonly Timer InfravisionTimer;
    public readonly Timer InvulnerabilityTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_OPP_ELEC]</remarks>
    public readonly Timer LightningResistanceTimer;
    public readonly Timer ParalysisTimer;
    public readonly Timer PoisonTimer;

    /// <summary>
    /// 
    /// </summaryreadonly >
    /// <remarks>readonly borg: player->timed[TMD_OPP_POIS]</remarks>
    public readonly Timer PoisonResistanceTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg:player->timed[TMD_PROTEVIL]</remarks>
    public readonly Timer ProtectionFromEvilTimer;
    public readonly Timer SeeInvisibilityTimer;
    public readonly Timer SlowTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_STONESKIN]</remarks>
    public readonly Timer StoneskinTimer;
    public readonly Timer StunTimer;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->timed[TMD_SHERO]</remarks>
    public readonly Timer SuperheroismTimer;
    public readonly Timer TelepathyTimer;

    /// <summary>
    /// Returns the index of the town that the player owns a home; or null, if the player doesn't own a home.
    /// </summary>
    public Town? TownWithHouse;

    public int Weight;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->upkeep->total_weight</remarks>
    public int WeightCarried;

    public int WildernessX;
    public int WildernessY;

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>borg: player->word_recall</remarks>
    public int WordOfRecallDelay;

    /// <summary>
    /// Returns the maximum height of any level.
    /// </summary>
    public const int MaxHgt = 126;

    /// <summary>
    /// Returns the maximum width of any level.
    /// </summary>
    public const int MaxWid = 198;

    public readonly Map Map;
    public readonly int[] KeypadDirectionXOffset = { 0, -1, 0, 1, -1, 0, 1, -1, 0, 1 };
    public readonly int[] KeypadDirectionYOffset = { 0, 1, 1, 1, 0, 0, 0, -1, -1, -1 };

    /// <summary>
    /// Returns all of the directions in a sequence.  This is used for for the StarBall and StarLight projectiles where the projectiles are launched in every direction in a specific sequence.
    /// </summary>
    public readonly int[] OrderedDirection = { 2, 8, 6, 4, 3, 1, 9, 7 }; // The final direction [8] and a non-directional value of 5 has been removed because it is not used.

    /// <summary>
    /// 0=South, 1=North, 2=East, 3=West, 4=SE, 5=SW, 6=NE, 7=NW, 8=0,0
    /// </summary>
    public readonly int[] OrderedDirectionXOffset = { 0, 0, 1, -1, 1, -1, 1, -1, 0 };

    /// <summary>
    /// 0=South, 1=North, 2=East, 3=West, 4=SE, 5=SW, 6=NE, 7=NW, 8=0,0
    /// </summary>
    public readonly int[] OrderedDirectionYOffset = { 1, -1, 0, 0, 1, 1, -1, -1, 0 };

    public readonly int[] TempX = new int[Constants.TempMax]; // TODO: Use CursorPositon and combine TempX and TempY into a list to absolve TempN
    public readonly int[] TempY = new int[Constants.TempMax]; // TODO: These are shared privates??? what a hack

    /// <summary>
    /// Appears to be the height of the level.
    /// </summary>
    public int CurHgt;

    /// <summary>
    /// Appears to be the width of the level.
    /// </summary>
    public int CurWid;

    public int DangerFeeling;
    public int DangerRating;
    public int MaxPanelCols;
    public int MaxPanelRows;
    public int MCnt;
    public int MonsterMax = 1; // This is the current number of monsters.  Monster[0] is the player.
    public int MonsterLevel;

    /// <summary>
    /// Returns the map sector.
    /// </summary>
    public int PanelCol;

    /// <summary>
    /// Returns the map sector.
    /// </summary>
    public int PanelRow;

    /// <summary>
    /// Returns the last level column of the playable area that is visible in the viewport.
    /// </summary>
    public int PanelColMax;

    /// <summary>
    /// Returns the first level column of the playable area that is visible in the viewport.
    /// </summary>
    public int PanelColMin;

    /// <summary>
    /// Returns the last level row of the playable area that is visible in the viewport.
    /// </summary>
    public int PanelRowMax;

    /// <summary>
    /// Returns the first level row of the playable area that is visible in the viewport.
    /// </summary>
    public int PanelRowMin;

    public bool SpecialDanger;
    public bool SpecialTreasure;
    public int TempN;
    public int TreasureFeeling;
    public int TreasureRating;

    private const string _imageMonsterHack = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string _imageObjectHack = "?/|\\\"!$()_-=[]{},~";

    public readonly List<GridCoordinate> Light = new List<GridCoordinate>(); // TODO: This belongs to UpdateLightFlaggedActions and should be private.
    public readonly List<GridCoordinate> View = new List<GridCoordinate>(); // TODO: This belongs to UpdateViewFlaggedActions and should be private.
    public int CurrentlyActingMonster;
    public MonsterRaceFilter? DunBias = null; // The dungeon does not have a bias for monsters.
    public int NumRepro;
    public bool RepairMonsters;
    public bool ShimmerMonsters;

    /// <summary>
    /// Returns a fixed array of monsters.  All items in the array are pre-instantiates instances of the Monster class.  A dead or no-monster is when Monster.Race==null.
    /// </summary>
    public Monster[] Monsters; // TODO: make this a list
    private int _hackMIdxIi;

    private const int _maxQuests = 50;

    public int ActiveQuests => Quests.Where(q => q.IsActive).Count();

    /// <summary>
    /// Returns the maximum number of messages that can be stored in the message log.  Once this log size has been filled, the oldest messages will be deleted.
    /// </summary>
    public readonly int? MaxMessageLogLength = 2048;

    /// <summary>
    /// Returns the name of the town that the player will start in; or null, for a random eligible town to be selected.  Returns null, by default.
    /// </summary>
    public readonly string? StartupTownName = null;

    /// <summary>
    /// Returns the item factories to be used to generate gold.  If there are no item factories defined, gold will not be generated.
    /// </summary>
    public readonly ItemFactory[]? GoldFactories = null;

    /// <summary>
    /// Returns the one-in-probability that found gold is great.
    /// </summary>
    public readonly ProbabilityExpression GoldItemIsGreatProbability;

    /// <summary>
    /// Returns an <see cref="IntegerExpression"/> from an expression computation.  A type-conversion from a decimal result to an integer result is performed as needed.  If the result is not
    /// a valid <see cref="IntegerExpression"/> an exception is thrown.
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IntegerExpression ComputeIntegerExpression(Expression expression)
    {
        return expression.Compute<IntegerExpression>(DecimalToIntegerExpressionTypeConverter);
    }

//    private static string SuffixIf(string? value, string suffix) => String.IsNullOrEmpty(value) ? "" : $"{value}{suffix}";
    private static string DelimitIf(string? prefix, string delimiter, string? suffix) => String.IsNullOrEmpty(prefix) || String.IsNullOrEmpty(suffix) ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";
    private static string DelimitIf(string? prefix, char delimiter, char? suffix) => String.IsNullOrEmpty(prefix) || suffix is null ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";
    private static string DelimitIf(string? prefix, char delimiter, string? suffix) => String.IsNullOrEmpty(prefix) || String.IsNullOrEmpty(suffix) ? $"{prefix}{suffix}" : $"{prefix}{delimiter}{suffix}";

    /// <summary>
    /// Returns a string representation for composite key.  The returned key is compliant for filenames and ensures keys do not collide in namespace.
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static string GetCompositeKey(params string?[] keys)
    {
        const char wildCardCharacter = '~';
        const char keyDelimiter = '-';
        string compositeKey = "";
        foreach (string? key in keys)
        {
            if (String.IsNullOrEmpty(key))
            {
                compositeKey = $"{DelimitIf(compositeKey, keyDelimiter, wildCardCharacter)}";
            }
            else
            {
                if (key.Contains("-") || key.Contains(wildCardCharacter))
                {
                    throw new Exception($"The singleton key {key} presented for composite generation cannot contain the reserved character '{keyDelimiter}' or '{wildCardCharacter}'.");
                }
                compositeKey = $"{DelimitIf(compositeKey, keyDelimiter, key)}";
            }
        }
        return compositeKey;
    }

    /// <summary>
    /// Returns an <see cref="DecimalExpression"/> from an expression computation.  A type-conversion from a integer result to an decimal result is performed as needed.  If the result is not
    /// a valid <see cref="DecimalExpression"/> an exception is thrown.
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public DecimalExpression ComputeDecimalExpression(Expression expression)
    {
        return expression.Compute<DecimalExpression>(IntegerToDecimalExpressionTypeConverter);
    }

    /// <summary>
    /// Creates a new game.  
    /// </summary>
    /// <param name="configuration">Represents configuration data to use when generating a new game.</param>
    /// <remarks>
    /// For game replay mode, construction of the game DOES NOT use the random generator.  We only initialize the non-fixed seed.
    /// 
    /// </remarks>
    public Game(GameConfiguration gameConfiguration, string? serializedGameReplay)
    {
        // Restore the game replay, if needed.
        if (!string.IsNullOrEmpty(serializedGameReplay))
        {
            GameReplay gameReplay = JsonSerializer.Deserialize<GameReplay>(serializedGameReplay);
            MainSequenceRandomSeed = gameReplay.MainSequenceRandomSeed;
            ReplayQueue.AddRange(gameReplay.GameReplaySteps);
        }
        else
        {
            // Generate all new random seeds.
            Random r = new Random();
            MainSequenceRandomSeed = r.Next(int.MaxValue);
        }

        ParseLanguage = new AngbandOSExpressionParseLanguage(this);
        ExpressionParser = new ExpressionParser(ParseLanguage);
        IntegerToDecimalExpressionTypeConverter = new IntegerToDecimalExpressionTypeConverter();
        DecimalToIntegerExpressionTypeConverter = new DecimalToIntegerExpressionTypeConverter();

        IsDead = true;
        Map = new Map(this);

        DungeonGenerator = new StandardDungeonGenerator(this);

        // Create an instance of the SingletonRepository.  This allows repositories that are loading access to the SingletonRepository object. // TODO: This needs to be fixed once the items no longer reference other objects during construction
        SingletonRepository = new SingletonRepository(this);

        // Load all of the predefined objects.  The singleton repository must already be created.
        DateTime startTime = DateTime.Now;
        SingletonRepository.Load(gameConfiguration);
        TimeSpan elapsedTime = DateTime.Now - startTime;
        if (gameConfiguration.MaxMessageLogLength != null)
        {
            MaxMessageLogLength = gameConfiguration.MaxMessageLogLength.Value;
        }
        if (gameConfiguration.StartupTownName != null)
        {
            StartupTownName = gameConfiguration.StartupTownName;
        }
        if (gameConfiguration.GoldFactoriesBindingKeys != null)
        {
            List<ItemFactory> goldFactoryList = new List<ItemFactory>();
            foreach (string goldFactoryBindingKey in gameConfiguration.GoldFactoriesBindingKeys)
            {
                goldFactoryList.Add(SingletonRepository.Get<ItemFactory>(goldFactoryBindingKey));
            }
            GoldFactories = goldFactoryList.ToArray();
        }
        GoldItemIsGreatProbability = ParseProbabilityExpression(gameConfiguration.GoldItemIsGreatProbabilityExpression ?? "1/20");

        RequiredExperiencePerLevel = gameConfiguration.RequiredExperiencePerLevel;
        ExtractEnergy = gameConfiguration.ExtractEnergy;
        BlowsTable = gameConfiguration.BlowsTable;

        ElvishTexts = gameConfiguration.ElvishTexts ?? new string[] { };
        HorrificDescriptions = gameConfiguration.HorrificDescriptions ?? new string[] { };
        FunnyComments = gameConfiguration.FunnyComments ?? new string[] { };
        FunnyDescriptions = gameConfiguration.FunnyDescriptions ?? new string[] { };
        FindQuests = gameConfiguration.FindQuests ?? new string[] { };
        IllegibleFlavorSyllables = gameConfiguration.IllegibleFlavorSyllables ?? new string[] { };
        ShopkeeperAcceptedComments = gameConfiguration.ShopkeeperAcceptedComments ?? new string[] { };

        Debug.Print($"Singleton repository load took {elapsedTime.TotalSeconds.ToString()} seconds.");

        Quests = new List<Quest>();
        GameMessage = (GameMessageStringProperty)SingletonRepository.Get<Property>(nameof(GameMessageStringProperty));
        Gold = (GoldIntProperty)SingletonRepository.Get<Property>(nameof(GoldIntProperty));
        Mana = (ManaIntProperty)SingletonRepository.Get<Property>(nameof(ManaIntProperty));
        MaxMana = (MaxManaIntProperty)SingletonRepository.Get<Property>(nameof(MaxManaIntProperty));
        ExperiencePoints = (ExperiencePointsIntProperty)SingletonRepository.Get<Property>(nameof(ExperiencePointsIntProperty));
        Food = (FoodIntProperty)SingletonRepository.Get<Property>(nameof(FoodIntProperty));
        Health = (HealthPointsIntProperty)SingletonRepository.Get<Property>(nameof(HealthPointsIntProperty));
        Speed = (SpeedIntProperty)SingletonRepository.Get<Property>(nameof(SpeedIntProperty));
        MaxHealth = (MaxHealthPointsIntProperty)SingletonRepository.Get<Property>(nameof(MaxHealthPointsIntProperty));
        SpareSpellSlots = (SpareSpellSlotsIntProperty)SingletonRepository.Get<Property>(nameof(SpareSpellSlotsIntProperty));
        ExperienceLevel = (ExperienceLevelIntProperty)SingletonRepository.Get<Property>(nameof(ExperienceLevelIntProperty));
        ExperienceMultiplier = (ExperienceMultiplierIntProperty)SingletonRepository.Get<Property>(nameof(ExperienceMultiplierIntProperty));
        IsWinner = (IsWinnerBoolProperty)SingletonRepository.Get<Property>(nameof(IsWinnerBoolProperty));
        IsWizard = (IsWizardBoolProperty)SingletonRepository.Get<Property>(nameof(IsWizardBoolProperty));
        PlayerName = (PlayerNameStringProperty)SingletonRepository.Get<Property>(nameof(PlayerNameStringProperty));
        CurrentGameDateTime = (CurrentGameDateTimeProperty)SingletonRepository.Get<Property>(nameof(CurrentGameDateTimeProperty));
        RefreshMap = (RefreshMapProperty)SingletonRepository.Get<Property>(nameof(RefreshMapProperty));
        TrackedMonsterChanged = (TrackedMonsterChangedProperty)SingletonRepository.Get<Property>(nameof(TrackedMonsterChangedProperty));
        MapX = (MapXIntProperty)SingletonRepository.Get<Property>(nameof(MapXIntProperty));
        MapY = (MapYIntProperty)SingletonRepository.Get<Property>(nameof(MapYIntProperty));
        MaxExperienceGained = (HighestExperiencePointsAchievedIntProperty)SingletonRepository.Get<Property>(nameof(HighestExperiencePointsAchievedIntProperty));
        TrackedMonster = (TrackedMonsterNullableMonsterProperty)SingletonRepository.Get<Property>(nameof(TrackedMonsterNullableMonsterProperty));

        AcidResistanceTimer = (AcidResistanceTimer)SingletonRepository.Get<Timer>(nameof(Timers.AcidResistanceTimer));
        BleedingTimer = (BleedingTimer)SingletonRepository.Get<Timer>(nameof(Timers.BleedingTimer));
        BlessingTimer = (BlessingTimer)SingletonRepository.Get<Timer>(nameof(Timers.BlessingTimer));
        BlindnessTimer = (BlindnessTimer)SingletonRepository.Get<Timer>(nameof(Timers.BlindnessTimer));
        ColdResistanceTimer = (ColdResistanceTimer)SingletonRepository.Get<Timer>(nameof(Timers.ColdResistanceTimer));
        ConfusionTimer = (ConfusingTimer)SingletonRepository.Get<Timer>(nameof(Timers.ConfusingTimer));
        EtherealnessTimer = (EtherealnessTimer)SingletonRepository.Get<Timer>(nameof(Timers.EtherealnessTimer));
        FearTimer = (FearTimer)SingletonRepository.Get<Timer>(nameof(Timers.FearTimer));
        FireResistanceTimer = (FireResistanceTimer)SingletonRepository.Get<Timer>(nameof(Timers.FireResistanceTimer));
        HallucinationsTimer = (HallucinatingTimer)SingletonRepository.Get<Timer>(nameof(Timers.HallucinatingTimer));
        HasteTimer = (HasteTimer)SingletonRepository.Get<Timer>(nameof(Timers.HasteTimer));
        HeroismTimer = (HeroismTimer)SingletonRepository.Get<Timer>(nameof(Timers.HeroismTimer));
        InfravisionTimer = (InfravisionTimer)SingletonRepository.Get<Timer>(nameof(Timers.InfravisionTimer));
        InvulnerabilityTimer = (InvulnerabilityTimer)SingletonRepository.Get<Timer>(nameof(Timers.InvulnerabilityTimer));
        LightningResistanceTimer = (LightningResistanceTimer)SingletonRepository.Get<Timer>(nameof(Timers.LightningResistanceTimer));
        ParalysisTimer = (ParalysisTimer)SingletonRepository.Get<Timer>(nameof(Timers.ParalysisTimer));
        PoisonTimer = (PoisoningTimer)SingletonRepository.Get<Timer>(nameof(Timers.PoisoningTimer));
        PoisonResistanceTimer = (PoisonResistanceTimer)SingletonRepository.Get<Timer>(nameof(Timers.PoisonResistanceTimer));
        ProtectionFromEvilTimer = (ProtectionFromEvilTimer)SingletonRepository.Get<Timer>(nameof(Timers.ProtectionFromEvilTimer));
        SeeInvisibilityTimer = (SeeInvisibilityTimer)SingletonRepository.Get<Timer>(nameof(Timers.SeeInvisibilityTimer));
        SlowTimer = (SlowTimer)SingletonRepository.Get<Timer>(nameof(Timers.SlowTimer));
        StoneskinTimer = (StoneskinTimer)SingletonRepository.Get<Timer>(nameof(Timers.StoneskinTimer));
        StunTimer = (StunningTimer)SingletonRepository.Get<Timer>(nameof(Timers.StunningTimer));
        SuperheroismTimer = (SuperheroismTimer)SingletonRepository.Get<Timer>(nameof(Timers.SuperheroismTimer));
        TelepathyTimer = (TelepathyTimer)SingletonRepository.Get<Timer>(nameof(Timers.TelepathyTimer));

        if (String.IsNullOrEmpty(gameConfiguration.DungeonViewBindingKey))
        {
            throw new Exception($"No {nameof(gameConfiguration.DungeonViewBindingKey)} provided.");
        }
        View consoleView = SingletonRepository.Get<View>(gameConfiguration.DungeonViewBindingKey);
        RenderView(consoleView);

        InitializeAllocationTables();
    }

    public void RenderView(View view)
    {
        ConsoleView = view;
    }

    /// <summary>
    /// Return a JsonSerializerOptions that should be used to serialize entities. 
    /// </summary>
    /// <returns></returns>
    public static JsonSerializerOptions GetJsonSerializerOptions()
    {
        return new JsonSerializerOptions() { IncludeFields = true };
    }

    public bool GetBool(string prompt, out bool value)
    {
        value = false;
        if (!GetCom(prompt, out char text))
        {
            return false;
        }
        if (text == '0')
        {
            value = false;
            return true;
        }
        if (text == '1')
        {
            value = true;
            return true;
        }
        return false;
    }

    public void StorePrtGold()
    {
        Screen.PrintLine("Gold Remaining: ", 39, 53);
        string outVal = $"{Gold.IntValue, 9}";
        Screen.PrintLine(outVal, 39, 68);
    }

    public void SayComment_1()
    {
        MsgPrint(new WeightedRandom<string>(this, ShopkeeperAcceptedComments).ChooseOrDefault());
    }

    public bool ServiceHaggle(int serviceCost, out int price)
    {
        int finalAsk = serviceCost;
        MsgPrint("You quickly agree upon the price.");
        MsgPrint(null);
        finalAsk += finalAsk / 10;
        price = finalAsk;
        const string pmt = "Final Offer";
        string outVal = $"{pmt} :  {finalAsk}";
        Screen.Print(outVal, 1, 0);
        return !GetCheck("Accept deal? ");
    }

    /// <summary>
    /// Retrieves a save game from persistent storage.  If no persistent storage is specified, a new game is created. This static method is used as a factory
    /// to generate the Game object that can be played using the Play method.  This is the only static method.
    /// </summary>
    /// <param name="persistentStorage"></param>
    /// <returns></returns>
    public static Game LoadGame(ICorePersistentStorage persistentStorage)
    {
        if (persistentStorage == null)
        {
            throw new ArgumentNullException("persistentStorage", "A persistentStorage object must be provided to load the game and cannot be null.");
        }

        // Retrieve the saved game from the persistent storage.  If the persistent storage doesn't find it, the return data is expected to be null; which
        // will indicate that a new game needs to be created.
        byte[]? data = persistentStorage.ReadGame();

        if (data == null)
        {
            throw new Exception("Saved game does not exist.");
        }

        // Deserialize the game.
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream(data);
        return (Game)formatter.Deserialize(memoryStream);
    }


    public MonsterRaceFilter GetRandomBizarreMonsterSelector()
    {
        switch (DieRoll(6))
        {
            case 1:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre1MonsterRaceFilter));
            case 2:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre2MonsterRaceFilter));
            case 3:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre3MonsterRaceFilter));
            case 4:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre4MonsterRaceFilter));
            case 5:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre5MonsterRaceFilter));
            default:
                return SingletonRepository.Get<MonsterRaceFilter>(nameof(Bizarre6MonsterRaceFilter));
        }
    }

    // PROFILE MESSAGING START
    /// <summary>
    /// Returns the queue that stores all of the messages.  An actual Queue isn't being used because the Count property for the last item 
    /// in the queue is being updated when non-empty duplicate messages are rendered sequentially.
    /// </summary>
    private readonly List<GameMessage> MessageLog = new List<GameMessage>();
    private readonly List<GameMessage> RecentMessages = new List<GameMessage>();
    private GameMessage[] PreviousMessages;

    /// <summary>
    /// Returns the current X position of the cursor when rendering messages.
    /// </summary>
    private GameMessageStringProperty GameMessage;

    /// <summary>
    /// Returns the unique index of the first message in the MessageLog.  When messages drop out of the list due to the size of the MessageLog, this index is incremented
    /// by one.  We do not actually store indexes with each message because they are one-to-one with the list.
    /// </summary>
    public int MessageFirstQueueIndex = 0;

    public PageOfGameMessages? GetPageOfGameMessages(int? firstIndex = null, int lastIndex = 0, int? maximumMessagesToRetrieve = null)
    {
        int firstIndexValue;

        // Resolve a null firstIndex.
        if (firstIndex == null)
        {
            // If the message log is empty, return null.
            if (MessageLog.Count == 0)
            {
                return null;
            }
            firstIndexValue = MessageLog.Count - 1;
        }
        else
        {
            firstIndexValue = firstIndex.Value;
        }

        // Resolve the lastIndex, based on a maximum number of messages to retrieve.
        if (maximumMessagesToRetrieve != null)
        {
            lastIndex = firstIndexValue - maximumMessagesToRetrieve.Value;
            if (lastIndex < 0)
            {
                lastIndex = 0;
            }
        }

        // If messages have dropped out of the queue, we may need to shorten the list.
        if (lastIndex < MessageFirstQueueIndex)
        {
            lastIndex = MessageFirstQueueIndex;
        }

        // Validate the request.
        if (firstIndex >= MessageLog.Count)
        {
            throw new ArgumentException("The firstIndex refers to a message that does not exist.");
        }
        if (lastIndex > firstIndex)
        {
            throw new ArgumentException("The lastIndex cannot be larger than the firstIndex.");
        }
        if (firstIndex < 0 || lastIndex < 0 || maximumMessagesToRetrieve < 0)
        {
            throw new ArgumentException("Parameters do not support values less than zero.");
        }

        // Gather the messages.
        int recordCount = firstIndexValue - lastIndex + 1;
        GameMessage[] messages = MessageLog.GetRange(lastIndex, recordCount).ToArray();

        if (messages.Length == 0)
        {
            return null;
        }

        // Build the return object.
        PageOfGameMessages messageBatch = new PageOfGameMessages(messages, firstIndexValue, lastIndex);
        return messageBatch;
    }

    private void MessageAdd(string str)
    {
        // Generate the message that will be stored.
        GameMessage message = new GameMessage(str);

        // simple case - list is empty
        if (MessageLog.Count == 0)
        {
            MessageLog.Add(message);
            RecentMessages.Add(message);

            // Fire the event that the game messages have been updated.
            ConsoleViewPort.MessagesUpdated();
            return;
        }

        // If it's not blank it might be a repeat
        if (!string.IsNullOrEmpty(str))
        {
            GameMessage lastMessage = MessageLog.Last();
            if (lastMessage.Text == str)
            {
                // Same as last - just increment the count
                lastMessage.Count++;
                ConsoleViewPort.MessagesUpdated();
                RecentMessages.Add(message);
                return;
            }
        }

        // We're still here, so we just add ourselves
        MessageLog.Add(message);
        RecentMessages.Add(message);

        // Fire the event that the game messages have been updated.
        ConsoleViewPort.MessagesUpdated();
    }

    public int MessageNum()
    {
        return MessageLog.Count;
    }

    public string GetMessageText(int age)
    {
        if (age >= MessageLog.Count)
        {
            return string.Empty;
        }
        GameMessage agedMessage = MessageLog[MessageLog.Count - age - 1];
        string message = agedMessage.Text;
        if (agedMessage.Count > 1)
        {
            message += $" (x{agedMessage.Count})";
        }
        return message;
    }

    /// <summary>
    /// Indicates the beginning of a new command being issued by the player.  All messages that have been rendered to the player are batched 
    /// together and stored into a fixed length queue.  This MessageFlush is called in the RequestCommand method during the dungeon game play 
    /// and when in a store.
    /// </summary>
    private void CloseBatchOfMessages()
    {
        // Batch all of the message together from the last command and store them as the previous messages.
        PreviousMessages = RecentMessages.ToArray();

        ConsoleViewPort.MessagesReceived(PreviousMessages);

        // Empty the recent list of messages to prepare for the next command.
        RecentMessages.Clear();

        // Limit the length of the queue.
        if (MaxMessageLogLength != null)
        {
            while (MessageLog.Count > MaxMessageLogLength)
            {
                // Drop the first message.
                MessageLog.RemoveAt(0);

                // To maintain track of the indexes for each message, we need to increment the index value that we are tracking for the first message.
                MessageFirstQueueIndex++;
            }
        }
    }

    /// <summary>
    /// Erases the message line and prepares the next message to be rendered at column 0.
    /// </summary>
    public void MsgClear()
    {
        Screen.PrintLine("", 0, 0);
        GameMessage.StringValue = "";
    }

    /// <summary>
    /// Renders a message on the same line, if MessageAppendNextMessage is not set to false; otherwise, a -more- prompt will be rendered and the key input buffer
    /// is cleared prior to rendering the message on a new line.  If the message is null, any previous message is forced to render and the key input buffer is
    /// cleared.
    /// </summary>
    /// <param name="messages">Set to NULL to force a --more-- prompt (if there is text the player hasn't seen), then reset the line for new message starting at 0, 0.</param>
    public void MsgPrint(params string[]? messages)
    {
        const string MorePrompt = "-more-";

        /// <summary>
        /// Renders the -more- prompt and waits for a key input.  Keys in the input buffer are preserved.
        /// </summary>
        /// <param name="cursorXPosition"></param>
        void ShowMorePrompt()
        {
            if (GameMessage.StringValue.Length > 0)
            {
                Screen.Print(ColorEnum.BrightBlue, MorePrompt, 0, GameMessage.StringValue.Length + 1);
                while (!Shutdown)
                {
                    string save = _artificialKeyBuffer;
                    _artificialKeyBuffer = "";
                    Inkey();
                    _artificialKeyBuffer = save;
                    break;
                }
            }
            Screen.Erase(0, 0);
            GameMessage.StringValue = "";
        }

        void Render(string message)
        {
            // Capitalize the first letter.
            if (message.Length > 2)
            {
                message = message.Substring(0, 1).ToUpper() + message.Substring(1);
            }
            if (!IsDead)
            {
                MessageAdd(message);
            }

            // Check to see if the message being rendered is longer than one screen width.  If so, it will need to be split.  Compute the amount of space available.
            int lengthOfMore = MorePrompt.Length;
            int maxWidth = Screen.Width - lengthOfMore - 1;

            // Check to see if we need to -more- the current line.  Any form of the current message exceeding the current line will force a -more-.
            if (GameMessage.StringValue.Length + message.Length + 1 > maxWidth)
            {
                // Close the current line to prepare for the current message.
                ShowMorePrompt();
            }

            // At this point, either the msg fits within the screen, or msg itself is longer than one screen width and the message line is blank.
            // Determine if the message is too long for a line by itself.
            while (message.Length > maxWidth)
            {
                // Find a place to break 
                int check = maxWidth;
                while (check > 0 && message[check] != ' ')
                {
                    check--;
                }

                // Check to see if there were any spaces to break on.
                if (check == 0)
                {
                    // There were none.  Force break on non-breaking character.
                    check = maxWidth;
                }
                else
                {
                    // Extract the first message.
                    GameMessage.StringValue = message.Substring(0, check);

                    // Remove the first message.
                    message = message.Substring(check + 1);

                    // Render the first message.
                    Screen.Print(ColorEnum.White, GameMessage.StringValue, 0, 0);

                    // Render more prompt to clear for next message.
                    ShowMorePrompt();
                }
            }

            GameMessage.StringValue = DelimitIf(GameMessage.StringValue, " ", message);
            Screen.Print(ColorEnum.White, GameMessage.StringValue, 0, 0);
        }

        if (messages is null)
        {
            ShowMorePrompt();
        }
        else
        {
            foreach (string message in messages)
            {
                Render(message);
            }
        }
    }

    public byte Elevation(int wildY, int wildX, int y, int x)
    {
        return _elevationMap[((wildY - 1) * (Constants.WildernessHeight - 1)) + y + 1][
            ((wildX - 1) * (Constants.WildernessWidth - 1)) + x + 1];
    }

    public void MakeIslandContours()
    {
        do
        {
            bool reject = false;
            PerlinNoise perlinNoise = new PerlinNoise(RandomLessThan(int.MaxValue - 1));
            const int mapWidth = (10 * (Constants.WildernessWidth - 1)) + 3;
            const int mapHeight = (10 * (Constants.WildernessHeight - 1)) + 3;
            const double widthDivisor = 1 / (double)mapWidth;
            const double heightDivisor = 1 / (double)mapHeight;
            _elevationMap = new byte[mapHeight][];
            for (int row = 0; row < mapHeight; row++)
            {
                _elevationMap[row] = new byte[mapWidth];
            }
            for (int row = 0; row < mapHeight; row++)
            {
                for (int col = 0; col < mapWidth; col++)
                {
                    double v = perlinNoise.Noise(10 * col * widthDivisor, 10 * row * heightDivisor, -0.5);
                    v = (v + 1) / 2;
                    double dX = Math.Abs(col - (mapWidth / 2)) * widthDivisor;
                    double dY = Math.Abs(row - (mapHeight / 2)) * heightDivisor;
                    double d = Math.Max(dX, dY);
                    const double elevation = 0.05;
                    const double steepness = 6.0;
                    const double dropoff = 50.0;
                    v += elevation - (dropoff * Math.Pow(d, steepness));
                    v = Math.Min(1, Math.Max(0, v));
                    byte rounded = (byte)(v * 10);
                    _elevationMap[row][col] = rounded;
                }
            }
            for (int row = 0; row < mapHeight; row++)
            {
                if (_elevationMap[row][1] != 0)
                {
                    reject = true;
                }
                if (_elevationMap[row][mapWidth - 2] != 0)
                {
                    reject = true;
                }
            }
            for (int col = 0; col < mapWidth; col++)
            {
                if (_elevationMap[1][col] != 0)
                {
                    reject = true;
                }
                if (_elevationMap[mapHeight - 2][col] != 0)
                {
                    reject = true;
                }
            }
            if (!reject)
            {
                break;
            }
        } while (true);
    }

    /// <summary>
    /// Removes all items from a grid tile.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    public void DeleteObject(int y, int x)
    {
        if (!InBounds(y, x))
        {
            return;
        }
        GridTile cPtr = Map.Grid[y][x];
        cPtr.Items.Clear();
        ConsoleView.RefreshMapLocation(y, x);
    }

    public bool AddItemToMonster(Item item, Monster monster)
    {
        item.HoldingMonsterIndex = monster.GetMonsterIndex();
        monster.Items.Add(item);
        return true;
    }

    public bool AddItemToGrid(Item item, int x, int y)
    {
        GridTile tile = Map.Grid[y][x];
        item.Y = y;
        item.X = x;
        item.HoldingMonsterIndex = 0;
        tile.Items.Add(item);
        return true;
    }

    /// <summary>
    /// Returns an item from the players inventory.  If there is no item at the desired slot, null is returned.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Item? GetInventoryItem(int index)
    {
        return Inventory[index];
    }
    public void SetInventoryItem(int index, Item? item)
    {
        Inventory[index] = item;
    }

    /// <summary>
    /// Initialise the navigator with a direction
    /// </summary>
    /// <param name="direction"> The direction in which we wish to run </param>
    public void StartRun(int direction)
    {
        CurrentRunDirection = direction;
        _previousRunDirection = direction;
        _findOpenarea = true;
        _findBreakright = false;
        _findBreakleft = false;
        bool wallDoubleAheadLeft = false;
        bool wallDoubleAheadRight = false;
        bool wallAheadRight = false;
        bool wallAheadLeft = false;
        // Get the row and column of the first step in the run
        int row = MapY.IntValue + KeypadDirectionYOffset[direction];
        int col = MapX.IntValue + KeypadDirectionXOffset[direction];
        // Get the index of our run direction in the cycle
        int cycleIndex = _cycleEntryPoint[direction];
        // If there's a wall ahead-left of us, remember that
        if (SeeWall(_directionCycle[cycleIndex + 1], MapY.IntValue, MapX.IntValue))
        {
            _findBreakleft = true;
            wallAheadLeft = true;
        }
        // Else check if there's a wall ahead-left of our first step, and remember that
        else if (SeeWall(_directionCycle[cycleIndex + 1], row, col))
        {
            _findBreakleft = true;
            wallDoubleAheadLeft = true;
        }
        // If there's a wall ahead-right of us, remember that
        if (SeeWall(_directionCycle[cycleIndex - 1], MapY.IntValue, MapX.IntValue))
        {
            _findBreakright = true;
            wallAheadRight = true;
        }
        // Else check if there's a wall ahead-right of our first step, and remember that
        else if (SeeWall(_directionCycle[cycleIndex - 1], row, col))
        {
            _findBreakright = true;
            wallDoubleAheadRight = true;
        }
        // If we're looking for breaks on either side, we're not looking for an open area
        if (_findBreakleft && _findBreakright)
        {
            _findOpenarea = false;
            // If we're moving orthogonally and we have a wall double-ahead on either side,
            // nudge our assumed previous direction away from it
            if ((direction & 0x01) != 0)
            {
                if (wallDoubleAheadLeft && !wallDoubleAheadRight)
                {
                    _previousRunDirection = _directionCycle[cycleIndex - 1];
                }
                else if (wallDoubleAheadRight && !wallDoubleAheadLeft)
                {
                    _previousRunDirection = _directionCycle[cycleIndex + 1];
                }
            }
            // If there's a wall directly ahead but not diagonally ahead, nudge our assumed
            // previous direction away from it
            else if (SeeWall(_directionCycle[cycleIndex], row, col))
            {
                if (wallAheadLeft && !wallAheadRight)
                {
                    _previousRunDirection = _directionCycle[cycleIndex - 2];
                }
                else if (wallAheadRight && !wallAheadLeft)
                {
                    _previousRunDirection = _directionCycle[cycleIndex + 2];
                }
            }
        }
    }

    /// <summary>
    /// Check if we can and should move forward on our current path, adjusting our path if
    /// necessary to go around corners and stopping if the way forward becomes ambiguous or we
    /// see a monster.
    /// </summary>
    /// <returns> True if we must stop running, false if we may carry on </returns>
    public bool NavigateNextStep()
    {
        int newDirection;
        int checkDir = 0;
        int row;
        int col;
        int i;
        GridTile tile;
        int option = 0;
        int option2 = 0;
        int previousDirection = _previousRunDirection;
        // Set our search width to 1 if we're moving diagonally, or two if we're moving orthogonally
        int searchWidth = (previousDirection & 0x01) + 1;
        // Search to either side from right to left with a width equal to the search width
        for (i = -searchWidth; i <= searchWidth; i++)
        {
            // Pick up the tile 0-2 rotations from the direction we previously moved
            newDirection = _directionCycle[_cycleEntryPoint[previousDirection] + i];
            row = MapY.IntValue + KeypadDirectionYOffset[newDirection];
            col = MapX.IntValue + KeypadDirectionXOffset[newDirection];
            tile = Map.Grid[row][col];
            // If there's a monster there we must stop moving
            if (tile.MonsterIndex != 0)
            {
                Monster monster = Monsters[tile.MonsterIndex];
                if (monster.IsVisible)
                {
                    return true;
                }
            }
            // If there's an item there we weren't previously aware of then we must stop moving
            foreach (Item item in tile.Items)
            {
                if (item.WasNoticed)
                {
                    return true;
                }
            }
            bool tileUnseen = true;
            // If the tile is something we should not run past then we must stop moving
            if (tile.PlayerMemorized)
            {
                bool notice = !tile.FeatureType.RunPast;
                if (notice)
                {
                    return true;
                }
                tileUnseen = false;
            }
            // We can enter the tile or it's unseen
            if (tileUnseen || GridPassable(row, col))
            {
                if (_findOpenarea)
                {
                    // Ignore the open area
                }
                else if (option == 0)
                {
                    // It's an option for changing direction to
                    option = newDirection;
                }
                // We shouldn't be finding open areas, but we did find one so we have to stop
                else if (option2 != 0)
                {
                    return true;
                }
                // We've previously found an option and it isn't just a diagonal corner-cut from
                // this one so we have to stop
                else if (option != _directionCycle[_cycleEntryPoint[previousDirection] + i - 1])
                {
                    return true;
                }
                // If we're running diagonally then we can have a second option two away
                else if ((newDirection & 0x01) != 0)
                {
                    checkDir = _directionCycle[_cycleEntryPoint[previousDirection] + i - 2];
                    option2 = newDirection;
                }
                // We're running orthogonally so we can have a second option one away
                else
                {
                    checkDir = _directionCycle[_cycleEntryPoint[previousDirection] + i + 1];
                    option2 = option;
                    option = newDirection;
                }
            }
            else
            // If we were looking for an open area we're now just looking for a left or right
            {
                if (_findOpenarea)
                {
                    if (i < 0)
                    {
                        _findBreakright = true;
                    }
                    else if (i > 0)
                    {
                        _findBreakleft = true;
                    }
                }
            }
        }
        // If we're looking for an open area, search both directions
        if (_findOpenarea)
        {
            // Look left first
            for (i = -searchWidth; i < 0; i++)
            {
                newDirection = _directionCycle[_cycleEntryPoint[previousDirection] + i];
                row = MapY.IntValue + KeypadDirectionYOffset[newDirection];
                col = MapX.IntValue + KeypadDirectionXOffset[newDirection];
                tile = Map.Grid[row][col];
                if (!tile.PlayerMemorized || !tile.FeatureType.IsWall)
                {
                    if (_findBreakright)
                    {
                        return true;
                    }
                }
                else
                {
                    if (_findBreakleft)
                    {
                        return true;
                    }
                }
            }
            // Then look left
            for (i = searchWidth; i > 0; i--)
            {
                newDirection = _directionCycle[_cycleEntryPoint[previousDirection] + i];
                row = MapY.IntValue + KeypadDirectionYOffset[newDirection];
                col = MapX.IntValue + KeypadDirectionXOffset[newDirection];
                tile = Map.Grid[row][col];
                if (!tile.PlayerMemorized || !tile.FeatureType.IsWall)
                {
                    if (_findBreakleft)
                    {
                        return true;
                    }
                }
                else
                {
                    if (_findBreakright)
                    {
                        return true;
                    }
                }
            }
        }
        // Not looking for an open area
        else
        {
            // If we have nowhere else to run, we must stop
            if (option == 0)
            {
                return true;
            }
            // If we only have one option, take it
            if (option2 == 0)
            {
                CurrentRunDirection = option;
                _previousRunDirection = option;
            }
            // if we don't see a wall in one of our two options, take that one
            else
            {
                row = MapY.IntValue + KeypadDirectionYOffset[option];
                col = MapX.IntValue + KeypadDirectionXOffset[option];
                if (!SeeWall(option, row, col) || !SeeWall(checkDir, row, col))
                {
                    if (SeeNothing(option, row, col) && SeeNothing(option2, row, col))
                    {
                        CurrentRunDirection = option;
                        _previousRunDirection = option2;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    CurrentRunDirection = option2;
                    _previousRunDirection = option2;
                }
            }
        }
        // No options, so just return whether or not we can move forward
        return SeeWall(CurrentRunDirection, MapY.IntValue, MapX.IntValue);
    }

    /// <summary>
    /// Check whether we can see a wall in a certain direction from a point
    /// </summary>
    /// <param name="direction"> The direction in which we're looking </param>
    /// <param name="y"> The y coordinate of our location </param>
    /// <param name="x"> The x coordinate of our location </param>
    /// <returns> True if we can see a wall, false if not </returns>
    public bool SeeWall(int direction, int y, int x)
    {
        y += KeypadDirectionYOffset[direction];
        x += KeypadDirectionXOffset[direction];
        // Out of bounds is not a wall
        if (!InBounds2(y, x))
        {
            return false;
        }
        // Any passable grid is okay
        if (GridPassable(y, x))
        {
            return false;
        }
        // If we don't know what's there it's okay
        if (!Map.Grid[y][x].PlayerMemorized)
        {
            return false;
        }
        // It was impassable and we knew it
        return true;
    }

    /// <summary>
    /// Check if we see an open space in a given direction from a given point
    /// </summary>
    /// <param name="direction"> The direction in which we're looking </param>
    /// <param name="y"> The y coordinate of our location </param>
    /// <param name="x"> The x coordinate of our location </param>
    /// <returns> </returns>
    private bool SeeNothing(int direction, int y, int x)
    {
        y += KeypadDirectionYOffset[direction];
        x += KeypadDirectionXOffset[direction];
        // Out of bounds is empty
        if (!InBounds2(y, x))
        {
            return true;
        }
        // Unknown tiles are not empty
        if (Map.Grid[y][x].PlayerMemorized)
        {
            return false;
        }
        // Anything we can walk through is empty
        if (!GridPassable(y, x))
        {
            return true;
        }
        // It's empty if we can't see it
        return !PlayerCanSeeBold(y, x);
    }

    public Item? MakeObject(int objectLevel, bool good, bool great, bool doNotAllowChestToBeCreated)
    {
        Item? MakeFixedArtifact()
        {
            WeightedRandom<FixedArtifact> fixedArtifactsWeightedRandom = SingletonRepository.ToWeightedRandom<FixedArtifact>();
            do
            {
                FixedArtifact aPtr = fixedArtifactsWeightedRandom.Choose();
                if (!aPtr.DisableViaRandom)
                {
                    continue;
                }
                if (aPtr.CurNum != 0)
                {
                    continue;
                }
                if (aPtr.Level > Difficulty)
                {
                    int d = (aPtr.Level - Difficulty) * 2;
                    if (RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (RandomLessThan(aPtr.Rarity) != 0)
                {
                    return null;
                }
                ItemFactory kIdx = aPtr.BaseItemFactory;
                if (kIdx.LevelNormallyFound > objectLevel)
                {
                    int d = (kIdx.LevelNormallyFound - objectLevel) * 5;
                    if (RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                Item item = kIdx.GenerateItem();
                item.ApplyFixedArtifact(aPtr);
                return item;
            } while (true); // TODO: This may loop forever if no fixed artifact can be created.
        }

        int prob = good ? 10 : 1000;
        int baselevel = good ? objectLevel + 10 : objectLevel;

        Item? item = null;

        // Attempt to create a fixed artifact.
        if (RandomLessThan(prob) == 0) // TODO: This should be a configurable setting
        {
            item = MakeFixedArtifact();
        }
        
        // Attempt to create a non-artifact.
        if (item == null)
        {
            ItemFactory? kIdx = RandomItemType(baselevel, doNotAllowChestToBeCreated, good);
            if (kIdx == null)
            {
                return null;
            }
            item = kIdx.GenerateItem();
        }
        item.EnchantItem(objectLevel, true, good, great, true); 
        item.StackCount = item.MakeObjectCount;
        if (!item.EffectivePropertySet.IsCursed && !item.IsBroken && item.LevelNormallyFound > Difficulty)
        {
            TreasureRating += item.LevelNormallyFound - Difficulty;
        }
        return item;
    }

    /// <summary>
    /// Returns a gold item.  If the configuration doesn't define any Gold item factories, null is returned.
    /// </summary>
    /// <param name="goldType"></param>
    /// <returns></returns>
    public Item? MakeGold(int objectLevel)
    {
        if (GoldFactories == null)
        {
            return null;
        }

        // The type of gold to be created depends on the level it is found.
        int goldType = ((DieRoll(objectLevel + 2) + 2) / 2) - 1;

        // A great find has some probability.
        if (GoldItemIsGreatProbability.Test())
        {
            goldType += DieRoll(objectLevel + 1);
        }

        if (goldType >= GoldFactories.Length)
        {
            goldType = GoldFactories.Length - 1;
        }
        ItemFactory itemFactory = GoldFactories[goldType];
        return itemFactory.GenerateItem();
    }

    private void ResetUniqueOnlyGuardianStatus()
    {
        foreach (MonsterRace race in SingletonRepository.Get<MonsterRace>())
        {
            race.OnlyGuardian = false;
        }
    }

    /// <summary>
    /// Returns an <see cref="ItemFactory"/> for the creation of an object.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="doNotAllowChestToBeCreated"></param>
    /// <param name="good"></param>
    /// <returns></returns>
    public ItemFactory? RandomItemType(int level, bool doNotAllowChestToBeCreated, bool good)
    {
        int i;
        int j;
        AllocationEntry[] table = AllocKindTable;
        if (level > 0)
        {
            if (RandomLessThan(Constants.GreatObj) == 0)
            {
                level = 1 + (level * Constants.MaxDepth / DieRoll(Constants.MaxDepth));
            }
        }
        int total = 0;
        for (i = 0; i < AllocKindSize; i++)
        {
            if (table[i].Level > level)
            {
                break;
            }
            table[i].FinalProbability = 0;
            int kIdx = table[i].Index;
            ItemFactory kPtr = SingletonRepository.Get<ItemFactory>(kIdx);
            if (doNotAllowChestToBeCreated && kPtr.IsContainer)
            {
                continue;
            }

            // Determine the final probability.  If only good objects are requested and the object is not good, then set it to 0.
            bool isGood = kPtr.BonusArmorClass >= 0 && kPtr.BonusHit >= 0 && kPtr.BonusDamage >= 0;
            table[i].FinalProbability = good && !isGood ? 0 : table[i].BaseProbability;

            total += table[i].FinalProbability;
        }
        if (total <= 0)
        {
            return null;
        }
        long value = RandomLessThan(total);
        for (i = 0; i < AllocKindSize; i++)
        {
            if (value < table[i].FinalProbability)
            {
                break;
            }
            value -= table[i].FinalProbability;
        }
        int p = RandomLessThan(100);
        if (p < 60)
        {
            j = i;
            value = RandomLessThan(total);
            for (i = 0; i < AllocKindSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            if (table[i].Level < table[j].Level)
            {
                i = j;
            }
        }
        if (p < 10)
        {
            j = i;
            value = RandomLessThan(total);
            for (i = 0; i < AllocKindSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            if (table[i].Level < table[j].Level)
            {
                i = j;
            }
        }
        return SingletonRepository.Get<ItemFactory>(table[i].Index);
    }

    /// <summary>
    /// Serializes an object and uses the persistent storage services to write the object to the desired facilities.
    /// </summary>
    /// <param name="player">The player to save.  If the player is dead, then this should be the corpse.</param>
    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memoryStream = new MemoryStream();
        formatter.Serialize(memoryStream, this);
        memoryStream.Position = 0;
        GameDetails gameDetails = new GameDetails()
        {
            CharacterName = PlayerName.StringValue, // The player parameter
            Level = ExperienceLevel.IntValue, // The player parameter
            Gold = Gold.IntValue, // The parameter
            IsAlive = !IsDead, // If the player is dead, then the game Player will be null.
            Comments = ""
        };
        CorePersistentStorage?.WriteGame(gameDetails, memoryStream.ToArray());
    }

    private void ResetStompability()
    {
        foreach (ItemFactory itemFactory in SingletonRepository.Get<ItemFactory>())
        {
            itemFactory.Stompable[StompableTypeEnum.Broken] = itemFactory.InitialBrokenStomp;
            itemFactory.Stompable[StompableTypeEnum.Average] = itemFactory.InitialAverageStomp;
            itemFactory.Stompable[StompableTypeEnum.Good] = itemFactory.InitialGoodStomp;
            itemFactory.Stompable[StompableTypeEnum.Excellent] = itemFactory.InitialExcellentStomp;
        }
    }

    /// <summary>
    /// Initializes everything for a new game.  This method is called when starting a new game and when the player dies and a new game is started.  This method does not allocate
    /// memory for a game, that is done in the Game constructor.  This method resets all of the value.
    /// </summary>
    /// <exception cref="Exception"></exception>
    private void GenerateNewGame()
    {
        SetBackground(BackgroundImageEnum.Paper);
        PlayMusic(MusicTrackEnum.Chargen);
        Inventory = new Item[InventorySlotEnum.Total];
        for (int i = 0; i < InventorySlotEnum.Total; i++)
        {
            Inventory[i] = null;
        }
        _invenCnt = 0;
        InitializeMutations();
        for (int i = 0; i < 4; i++)
        {
            History[i] = "";
        }

        StrengthAbility = SingletonRepository.Get<Ability>(nameof(StrengthAbility));
        IntelligenceAbility = SingletonRepository.Get<Ability>(nameof(IntelligenceAbility));
        WisdomAbility = SingletonRepository.Get<Ability>(nameof(WisdomAbility));
        DexterityAbility = SingletonRepository.Get<Ability>(nameof(DexterityAbility));
        ConstitutionAbility = SingletonRepository.Get<Ability>(nameof(ConstitutionAbility));
        CharismaAbility = SingletonRepository.Get<Ability>(nameof(CharismaAbility)); 

        WeightCarried = 0;

        foreach (FixedArtifact aPtr in SingletonRepository.Get<FixedArtifact>())
        {
            aPtr.CurNum = 0;
        }
        foreach (ItemFactory kPtr in SingletonRepository.Get<ItemFactory>())
        {
            kPtr.Tried = false;
        }
        for (int i = 1; i < SingletonRepository.Count<MonsterRace>(); i++)
        {
            MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(i);
            rPtr.CurNum = 0;
            rPtr.MaxNum = 100;
            if (rPtr.Unique)
            {
                rPtr.MaxNum = 1;
            }
            rPtr.Knowledge.RPkills = 0;
        }
        SingletonRepository.Get<MonsterRace>(SingletonRepository.Count<MonsterRace>() - 1).MaxNum = 0;
        Food.IntValue = Constants.PyFoodFull - 1;
        IsWizard.BoolValue = false;
        IsWinner.BoolValue = false;

        // Reset the home ownership for the player.
        TownWithHouse = null;

        Generation = 1;



        if (ExPlayer == null)
        {
            _prevSex = SingletonRepository.Get<Gender>(nameof(FemaleGender));
            _prevRace = SingletonRepository.Get<Race>(nameof(HumanRace));
            _prevCharacterClass = SingletonRepository.Get<BaseCharacterClass>(nameof(WarriorCharacterClass));
            _prevPrimaryRealm = null;
            _prevSecondaryRealm = null;
            _prevName = "Xena";
            _prevGeneration = 0;
        }
        else
        {
            _prevSex = ExPlayer.Gender;
            _prevRace = ExPlayer.RaceAtBirth;
            _prevCharacterClass = SingletonRepository.Get<BaseCharacterClass>(ExPlayer.CharacterClassName);
            _prevPrimaryRealm = ExPlayer.PrimaryRealm;
            _prevSecondaryRealm = ExPlayer.SecondaryRealm;
            _prevName = ExPlayer.Name;
            _prevGeneration = ExPlayer.Generation;
        }

        Screen.Clear();
        BirthStage? birthStage = SingletonRepository.Get<BirthStage>(nameof(IntroductionBirthStage));
        while (birthStage != null && !Shutdown)
        {
            birthStage = birthStage.Render();
        }

        if (Shutdown)
        {
            return;
        }

        RaceAtBirth = Race;
        InitializeQuests();
        IsDead = false;
        PlayerOutfit();

        AssignItemFlavors();
        ResetItemFlavors();

        _seedFlavor = RandomLessThan(int.MaxValue);
        CreateWorld();
        foreach (var dungeon in SingletonRepository.Get<Dungeon>())
        {
            dungeon.RandomiseOffset();
        }
        ResetStompability();
        CurrentDepth = 0;
        if (StartupTownName != null)
        {
            Town? startupTown = SingletonRepository.Get<Town>(StartupTownName);
            if (startupTown == null)
            {
                throw new Exception("The configured startup town does not exist.");
            }
            CurTown = startupTown;
        }
        else
        {
            Town[] townsAllowedToStartup = SingletonRepository.Get<Town>().Where(_town => _town.AllowStartupTown).ToArray();
            if (townsAllowedToStartup.Length == 0)
            {
                throw new Exception("There are no towns marked for startup");
            }
            WeightedRandom<Town> weightedRandomOfTownsAllowedToStartup = new WeightedRandom<Town>(this, townsAllowedToStartup);
            Town? town = weightedRandomOfTownsAllowedToStartup.ChooseOrDefault();
            if (town == null)
            {
                throw new Exception("No startup town.");
            }
            CurTown = town;
        }
        CurDungeon = CurTown.Dungeon;
        RecallDungeon = CurDungeon;
        RecallDungeon.RecallLevel = 1;
        DungeonDifficulty = 0;
        WildernessX = CurTown.X;
        WildernessY = CurTown.Y;
        CameFrom = LevelStartEnum.StartRandom;
        GenerateNewLevel();
    }

    /// <summary>
    /// Plays the current game.
    /// </summary>
    /// <param name="consoleViewPort"></param>
    /// <param name="persistentStorage"></param>
    /// <param name="updateMonitor"></param>
    /// <remarks>
    /// For game replay mode and the ability to restore a saved game, we need to reinitialize the random generator because the Random object is not serializable.
    /// </remarks>
    public void Play(IConsoleViewPort consoleViewPort, ICorePersistentStorage? persistentStorage)
    {
        // If this game is to be replayed, we need to initialize the non-fixed random with the same value that was used to construct the game.
        if (ReplayQueueIndex == 0)
        {
            // This is a new game or we are replaying a game.
            _mainSequence = new Random(MainSequenceRandomSeed);
        }
        else
        {
            // Restore an existing game to continue playing.
            _mainSequence = new Random(CurrentSequenceRandomSeed);
        }

        // Reset the last keystroke date and time.  This ensures the time offline isn't recorded as wait time.
        LastKeystrokeDateTime = DateTime.Now;

        ConsoleViewPort = consoleViewPort;
        Shutdown = false;
        LastInputReceived = DateTime.Now;
        CorePersistentStorage = persistentStorage;
        KeyQueue = new char[ConsoleViewPort.MaximumKeyQueueLength];
        Screen = new Window(consoleViewPort);
        MapMovementKeys();

        FullScreenOverlay = true;
        SetBackground(BackgroundImageEnum.Normal);
        Screen.CursorVisible = false;
        if (UseFixed)
        {
            UseFixed = false;
        }
        if (IsDead)
        {
            GenerateNewGame();
        }
        ConsoleViewPort.GameStarted();
        //MessageAppendNextMessage = false;
        MsgPrint(null);
        UpdateScreen();
        FullScreenOverlay = false;
        SetBackground(BackgroundImageEnum.Overhead);
        Playing = true;
        if (Health.IntValue < 0)
        {
            IsDead = true;
        }

        // Repeat the dungeon loop until normal game ends or the shutdown flag is raised.
        while (!Shutdown)
        {
            // Play the current dungeon 
            DungeonLoop();

            // We need to detect if the shutdown has happened, or if we are changing the dungeon 
            if (!Shutdown)
            {
                // The dungeon level is changing.
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
                TargetWho = null;
                HealthTrack(null);
                SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Check(true);
                SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Check(true);
                if (!Playing && !IsDead)
                {
                    break;
                }
                _petList = GetPets();
                WipeMList();
                MsgPrint(null);
                if (IsDead)
                {
                    ConsoleViewPort.PlayerDied(PlayerName.StringValue, DiedFrom, ExperienceLevel.IntValue);

                    // Store the player info
                    ExPlayer = new ExPlayer(Gender, Race, RaceAtBirth, BaseCharacterClass?.GetType().Name, PrimaryRealm, SecondaryRealm, PlayerName.StringValue, ExperienceLevel.IntValue, Generation);
                    break;
                }
                GenerateNewLevel();
                ReplacePets(MapY.IntValue, MapX.IntValue, _petList);
            }
        }
        ConsoleViewPort.GameStopped();
        CloseGame();
    }

    public Store? FindHomeStore(Town town) => Array.Find(town.Stores, store => store.GetType() == typeof(HomeStoreFactory));

    public void MoveHouse(Town oldTown, Town newTown)
    {
        Store? newStore = FindHomeStore(newTown);
        Store? oldStore = FindHomeStore(oldTown);
        if (oldStore == null)
        {
            return;
        }
        if (newStore == null)
        {
            return;
        }
        oldStore.MoveInventoryToAnotherStore(newStore);
    }

    public int Difficulty => CurrentDepth + DungeonDifficulty;

    public void ActivateDreadCurse()
    {
        do
        {
            switch (DieRoll(27))
            {
                case 1:
                case 2:
                case 3:
                case 16:
                case 17:
                    AggravateMonsters();
                    break;

                case 4:
                case 5:
                case 6:
                    ActivateHiSummon();
                    break;

                case 7:
                case 8:
                case 9:
                case 18:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, null, true, false);
                    break;

                case 10:
                case 11:
                case 12:
                    MsgPrint("You feel your life draining away...");
                    LoseExperience(ExperiencePoints.IntValue / 16);
                    break;

                case 13:
                case 14:
                case 15:
                case 19:
                case 20:
                    if (!HasFreeAction || DieRoll(100) >= SkillSavingThrow)
                    {
                        MsgPrint("You feel like a statue!");
                        if (HasFreeAction)
                        {
                            ParalysisTimer.AddTimer(DieRoll(3));
                        }
                        else
                        {
                            ParalysisTimer.AddTimer(DieRoll(13));
                        }
                    }
                    break;

                case 21:
                case 22:
                case 23:
                    WeightedRandom<Ability> abilitiesWeightedRandom = SingletonRepository.ToWeightedRandom<Ability>();
                    TryDecreasingAbilityScore(abilitiesWeightedRandom.Choose());
                    break;

                case 24:
                    MsgPrint("Huh? Who am I? What am I doing here?");
                    LoseAllInfo();
                    break;

                case 25:
                    SummonReaver();
                    break;

                default:
                    foreach (Ability ability in SingletonRepository.Get<Ability>())
                    {
                        do
                        {
                            TryDecreasingAbilityScore(ability);
                        } while (DieRoll(2) == 1);
                    }
                    break;
            }
        } while (DieRoll(3) == 1);
    }

    public void ActivateChestTrap(int y, int x, Item chestItem)
    {
        if (chestItem.ContainerIsOpen || chestItem.ContainerTraps == null)
        {
            return;
        }
        foreach (ChestTrap trap in chestItem.ContainerTraps)
        {
            (IsNoticedEnum isNoticed, DestroysContentsEnum destroysContents) = trap.ActivationGridTileScript.Apply(MapX.IntValue, MapY.IntValue);
            if (destroysContents == DestroysContentsEnum.True)
            {
                MsgPrint("Everything inside the chest is destroyed!");
                chestItem.ContainerIsOpen = true;
            }
        }
    }

    public void DisplayWildMap()
    {
        int y;
        for (y = 0; y < 12; y++)
        {
            for (int x = 0; x < 12; x++)
            {
                string wildMapSymbol = "^";
                ColorEnum wildMapAttr = ColorEnum.Green;
                if (Wilderness[y][x].Dungeon != null)
                {
                    Dungeon dungeon = Wilderness[y][x].Dungeon;
                    wildMapSymbol = dungeon.Visited ? dungeon.MapSymbol : "?";
                    wildMapAttr = Wilderness[y][x].Town != null ? ColorEnum.Grey : ColorEnum.Brown;

                    // Check to see if there are any active quests in the dungeon and show them in bright red.
                    if (Wilderness[y][x].Dungeon.ActiveQuestCount() != 0) 
                    {
                        wildMapAttr = ColorEnum.BrightRed;
                    }
                }
                if (x == 0 || y == 0 || x == 11 || y == 11)
                {
                    wildMapSymbol = "~";
                    wildMapAttr = ColorEnum.Blue;
                }
                Screen.Print(wildMapAttr, wildMapSymbol, y + 2, x + 2);
            }
        }
        Screen.Print(ColorEnum.Purple, "+------------+", 1, 1);
        for (y = 0; y < 12; y++)
        {
            Screen.Print(ColorEnum.Purple, "|", y + 2, 1);
            Screen.Print(ColorEnum.Purple, "|", y + 2, 14);
        }
        Screen.Print(ColorEnum.Purple, "+------------+", 14, 1);
        for (y = 0; y < DungeonCount; y++)
        {
            Dungeon dungeon = SingletonRepository.Get<Dungeon>(y);
            int activeQuestCount = dungeon.ActiveQuestCount();
            string depth = dungeon.KnownDepth ? $"{dungeon.MaxLevel}" : "?";
            string difficulty = dungeon.KnownOffset ? $"{dungeon.Offset}" : "?";
            string buffer;
            if (dungeon.Visited)
            {
                buffer = y < SingletonRepository.Count<Town>()
                    ? $"{dungeon.MapSymbol} = {SingletonRepository.Get<Town>(y).Name} (L:{depth}, D:{difficulty}, Q:{activeQuestCount})"
                    : $"{dungeon.MapSymbol} = {dungeon.Name} (L:{depth}, D:{difficulty}, Q:{activeQuestCount})";
            }
            else
            {
                buffer = $"? = {dungeon.Name} (L:{depth}, D:{difficulty}, Q:{activeQuestCount})";
            }
            ColorEnum keyAttr = ColorEnum.Brown;
            if (y < SingletonRepository.Count<Town>())
            {
                keyAttr = ColorEnum.Grey;
            }
            if (activeQuestCount != 0)
            {
                keyAttr = ColorEnum.BrightRed;
            }
            Screen.Print(keyAttr, buffer, y + 1, 19);
        }
        Screen.Print(ColorEnum.Purple, "L:levels", 16, 1);
        Screen.Print(ColorEnum.Purple, "D:difficulty", 17, 1);
        Screen.Print(ColorEnum.Purple, "Q:quests", 18, 1);
        Screen.Print(ColorEnum.Purple, "(Your position is marked with the cursor)", DungeonCount + 2, 19);
    }

    /// <summary>
    /// Interrupts a repeat command.  This is known as disturbing the player.
    /// </summary>
    /// <param name="stopSearch">Specify true, to turn off search mode, if the player has SearchMode enabled; false, to not change the current SearchMode.</param>
    public void Disturb(bool stopSearch)
    {
        if (CommandRepeat != 0)
        {
            CommandRepeat = 0;
            SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
        }
        if (Resting != 0)
        {
            Resting = 0;
            SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
        }
        if (Running != 0)
        {
            Running = 0;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        }
        if (stopSearch && IsSearching)
        {
            IsSearching = false;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
        }
    }

    public void DoCmdSaveGame(bool isAutosave)
    {
        if (!isAutosave)
        {
            Disturb(true);
        }
        MsgPrint(null);
        HandleStuff();
        UpdateScreen();
        DiedFrom = "(saved)";
        SaveGame();
        UpdateScreen();
        DiedFrom = "(alive and well)";
    }

    /// <summary>
    /// Returns a list of labels and label ranges to represent inventory slot selections.  Example: a,c-g
    /// </summary>
    /// <param name="inventorySlots"></param>
    /// <returns></returns>
    private string GetLabelRanges(IEnumerable<int> inventorySlots)
    {
        int[] inventorySlotsArray = inventorySlots.OrderBy(_slot => _slot).ToArray();
        string ranges = "";
        int? last = null;
        int? current = null;
        for (int i = 0; i < inventorySlotsArray.Length; i++)
        {
            int inventorySlot = inventorySlotsArray[i];
            bool finish = false;
            if (last == null)
            {
                last = inventorySlot;
                current = inventorySlot;
            }
            else if (current + 1 == inventorySlot)
            {
                current = inventorySlot;
            }
            else
            {
                finish = true;
            }
            if (finish || i + 1 == inventorySlotsArray.Length)
            { 
                if (ranges.Length > 0)
                {
                    ranges += ",";
                } 
                    
                if (last == current)
                {
                    ranges += $"{last.Value.IndexToLabel()}";
                }
                else
                {
                    ranges += $"{last.Value.IndexToLabel()}-{current.Value.IndexToLabel()}";
                }
                last = inventorySlot;
                current = inventorySlot;
            }
        }
        return ranges;
    }

    /// <summary>
    /// Returns an item selected by the player.  If the player doesn't have any items capable of being selected, false is returned; otherwise the item selected by the user is returned on the output
    /// parameter.  If the user cancels the selection, a true value is returned and the output item parameter is set to null.
    /// </summary>
    /// <param name="returnItem"></param>
    /// <param name="prompt"></param>
    /// <param name="canChooseFromEquipment"></param>
    /// <param name="canChooseFromInventory"></param>
    /// <param name="canChooseFromFloor"></param>
    /// <param name="itemFilter"></param>
    /// <returns></returns>
    public bool SelectItem(out Item? itemIndex, string prompt, bool canChooseFromEquipment, bool canChooseFromInventory, bool canChooseFromFloor, IItemFilter? itemFilter)
    {
        GridTile tile = Map.Grid[MapY.IntValue][MapX.IntValue];
        bool allowFloor = false;
        MsgPrint(null);
        bool done = false;
        bool item = false;
        itemIndex = null;
        List<int> inventory = new List<int>();
        List<int> equipment = new List<int>();
        if (canChooseFromInventory)
        {
            for (int ii = 0; ii < InventorySlotEnum.PackCount; ii++)
            {
                Item? oPtr = GetInventoryItem(ii);
                if (oPtr != null && (itemFilter == null || itemFilter.Matches(oPtr)))
                {
                    inventory.Add(ii);
                }
            }
        }
        if (canChooseFromEquipment)
        {
            foreach (WieldSlot inventorySlot in SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
            {
                foreach (int ii in inventorySlot.InventorySlots)
                {
                    Item? oPtr = GetInventoryItem(ii);
                    if (oPtr != null && (itemFilter == null || itemFilter.Matches(oPtr)))
                    {
                        equipment.Add(ii);
                    }
                }
            }
        }
        if (canChooseFromFloor)
        {
            foreach (Item oPtr in tile.Items)
            {
                if (ItemMatchesFilter(oPtr, itemFilter))
                {
                    allowFloor = true;
                }
            }
        }
        if (!allowFloor && inventory.Count == 0 && equipment.Count == 0)
        {
            ViewingItemList = false;
            itemIndex = null;
            done = true;
        }
        else
        {
            // If the user was rendering the equipment list and the item selection can choose from the equipment, then render the equipment.  // TODO: this doesn't make sense
            if (ViewingItemList && ViewingEquipment && canChooseFromEquipment)
            {
                ViewingEquipment = true;
            }
            else if (canChooseFromInventory)
            {
                ViewingEquipment = false;
            }
            else if (canChooseFromEquipment)
            {
                ViewingEquipment = true;
            }
            else
            {
                ViewingEquipment = false;
            }
        }
        ScreenBuffer? savedScreen = null;
        if (ViewingItemList)
        {
            savedScreen = Screen.Clone();
        }
        while (!done && !Shutdown)
        {
            if (ViewingItemList)
            {
                if (ViewingEquipment)
                {
                    ShowEquipment(itemFilter);
                }
                else
                {
                    ShowInven(_inventorySlot => !_inventorySlot.IsEquipment, itemFilter);
                }
            }
            string tmpVal;
            string outVal;
            if (!ViewingEquipment)
            {
                outVal = "Inven:";
                if (inventory.Count > 0)
                {
                    tmpVal = $" {GetLabelRanges(inventory)},";
                    outVal += tmpVal;
                }
                if (!ViewingItemList)
                {
                    outVal += " * to see,";
                }
                if (canChooseFromEquipment)
                {
                    outVal += " / for Equip,";
                }
            }
            else
            {
                outVal = "Equip:";
                if (equipment.Count > 0)
                {
                    tmpVal = $" {GetLabelRanges(equipment)}";
                    outVal += tmpVal;
                }
                if (!ViewingItemList)
                {
                    outVal += " * to see,";
                }
                if (canChooseFromInventory)
                {
                    outVal += " / for Inven,";
                }
            }
            if (allowFloor)
            {
                outVal += " - for floor,";
            }
            outVal += " ESC";
            tmpVal = $"({outVal}) {prompt}";
            Screen.PrintLine(tmpVal, 0, 0);
            char which = Inkey();
            int k;
            switch (which)
            {
                case '\x1b':
                    {
                        done = true;
                        item = true;
                        break;
                    }
                case '*':
                case '?':
                case ' ':
                    {
                        if (!ViewingItemList)
                        {
                            savedScreen = Screen.Clone();
                            ViewingItemList = true;
                        }
                        else
                        {
                            Screen.Restore(savedScreen);
                            ViewingItemList = false;
                        }
                        break;
                    }
                case '/':
                    {
                        if (!canChooseFromInventory || !canChooseFromEquipment)
                        {
                            break;
                        }
                        if (ViewingItemList)
                        {
                            Screen.Restore(savedScreen);
                        }
                        ViewingEquipment = !ViewingEquipment;
                        break;
                    }
                case '-':
                    {
                        if (allowFloor)
                        {
                            foreach (Item oPtr in tile.Items)
                            {
                                if (ItemMatchesFilter(oPtr, itemFilter))
                                {
                                    itemIndex = oPtr;
                                    item = true;
                                    done = true;
                                    break;
                                }
                            }
                            if (done)
                            {
                            }
                        }
                        break;
                    }
                case '\n':
                case '\r':
                    {
                        if (!ViewingEquipment)
                        {
                            k = inventory.Count == 1 ? inventory[0] : -1;
                        }
                        else
                        {
                            k = equipment.Count == 1 ? equipment[0] : -1;
                        }
                        if (k < 0)
                        {
                            break;
                        }
                        Item? oPtr = GetInventoryItem(k);
                        if (!GetItemOkay(oPtr, itemFilter))
                        {
                            break;
                        }
                        itemIndex = oPtr;
                        item = true;
                        done = true;
                        break;
                    }
                default:
                    {
                        bool ver = char.IsUpper(which);
                        if (ver)
                        {
                            which = char.ToLower(which);
                        }
                        k = !ViewingEquipment ? LabelToInven(which) : LabelToEquip(which);
                        if (k < 0 || k >= InventorySlotEnum.Total)
                        {
                            break;
                        }
                        Item? oPtr = GetInventoryItem(k);
                        if (oPtr == null)
                        {
                            break;
                        }
                        if (!GetItemOkay(oPtr, itemFilter))
                        {
                            break;
                        }
                        if (ver && !Verify("Try", oPtr))
                        {
                            done = true;
                            break;
                        }
                        itemIndex = oPtr;
                        item = true;
                        done = true;
                        break;
                    }
            }
        }
        if (savedScreen != null)
        {
            Screen.Restore(savedScreen);
        }
        ViewingItemList = false;
        MsgClear();
        return item;
    }

    /// <summary>
    /// Gains the experience when the character class destroys a spell book.  Derived classes must determine if the character class gains experience when they destroy a
    /// spell book and can call this common method to perform the gain experience.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="count">The number of items what were destroyed.</param>
    public void GainExperienceFromSpellBookDestroy(Item item, int count)
    {
        if (ExperiencePoints.IntValue < Constants.PyMaxExp)
        {
            int testerExp = MaxExperienceGained.IntValue / 20;
            if (testerExp > 10000)
            {
                testerExp = 10000;
            }
            testerExp /= item.ExperienceGainDivisorForDestroying;
            if (testerExp < 1)
            {
                testerExp = 1;
            }
            MsgPrint("You feel more experienced.");
            GainExperience(testerExp * count);
        }
    }

    /// <summary>
    /// Returns the specific store that the player is currently in.  Returns null, if the player is not detected as being in a store.
    /// </summary>
    /// <returns></returns>
    public Store? GetWhichStore()
    {
        foreach (Store store in CurTown.Stores)
        {
            if (MapX.IntValue == store.X && MapY.IntValue == store.Y)
            {
                return store;
            }
        }
        return null;
    }

    public void HandleStuff()
    {
        // Oops - we might have just died...
        if (IsDead)
        {
            return;
        }
        UpdateStuff();
        RedrawStuff();
    }

    public string[] ConvertToMultiline(string multiLineName)
    {

        List<string> names = new();
        int width = 12;
        string[] ff = multiLineName.Split('\n');
        foreach (string fff in ff)
        {
            string f = fff;
            while (f.Length > width)
            {
                int pos = width;
                while (f[pos] != ' ' && pos > 0)
                {
                    pos--;
                }
                if (pos == 0)
                {
                    names.Add(f.Substring(0, width));
                    f = f.Substring(width);
                }
                else
                {
                    names.Add(f.Substring(0, pos));
                    f = f.Substring(pos + 1);
                }
            }
            names.Add(f);
        }
        return names.ToArray();
    }

    public void HealthTrack(int? mIdx)
    {
        TrackedMonster.Value = mIdx == null ? null : Monsters[mIdx.Value];
    }

    public void MonsterDeath(Monster mPtr)
    {
        int dumpItem = 0;
        int dumpGold = 0;
        int number = 0;
        int qIdx = 0;
        bool quest = false;
        MonsterRace rPtr = mPtr.Race;
        if (rPtr == null)
        {
            return;
        }
        bool visible = mPtr.IsVisible || rPtr.Unique;
        bool good = rPtr.DropGood;
        bool great = rPtr.DropGreat;
        bool doGold = !rPtr.OnlyDropItem;
        bool doItem = !rPtr.OnlyDropGold;
        bool cloned = false;
        int y = mPtr.MapY;
        int x = mPtr.MapX;
        if (mPtr.SmCloned)
        {
            cloned = true;
        }
        foreach (Item oPtr in mPtr.Items)
        {
            oPtr.HoldingMonsterIndex = 0;
            DropNear(oPtr, null, y, x);
        }
        if (mPtr.StolenGold > 0)
        {

            Item oPtr = rPtr.GoldItemFactory.GenerateItem();
            oPtr.GoldPieces = mPtr.StolenGold;
            DropNear(oPtr, null, y, x);
        }
        mPtr.Items.Clear();
        if (rPtr.Drop60 && RandomLessThan(100) < 60)
        {
            number++;
        }
        if (rPtr.Drop90 && RandomLessThan(100) < 90)
        {
            number++;
        }
        if (rPtr.Drop_1D2)
        {
            number += DiceRoll(1, 2);
        }
        if (rPtr.Drop_2D2)
        {
            number += DiceRoll(2, 2);
        }
        if (rPtr.Drop_3D2)
        {
            number += DiceRoll(3, 2);
        }
        if (rPtr.Drop_4D2)
        {
            number += DiceRoll(4, 2);
        }
        if (cloned)
        {
            number = 0;
        }
        if (IsQuest(CurrentDepth) && rPtr.Guardian)
        {
            qIdx = GetQuestNumber();
            Quests[qIdx].Killed++;
            if (Quests[qIdx].Killed == Quests[qIdx].ToKill)
            {
                great = true;
                good = true;
                doGold = false;
                number += 2;
                quest = true;
                Quests[qIdx].Level = 0;
            }
        }
        int objectLevel = (Difficulty + rPtr.Level) / 2;
        for (int j = 0; j < number; j++)
        {
            if (doGold && (!doItem || RandomLessThan(100) < 50))
            {
                // Make gold to drop near the monster.
                Item qPtr = rPtr.GoldItemFactory.GenerateItem();
                DropNear(qPtr, null, y, x);
                dumpGold++;
            }
            else
            {
                if (!quest || j > 1)
                {
                    Item? qPtr = MakeObject(objectLevel, good, great, false);
                    if (qPtr != null)
                    {
                        DropNear(qPtr, null, y, x);
                        dumpItem++;
                    }
                }
                else
                {
                    Item? qPtr = MakeObject(objectLevel, true, true, false);
                    if (qPtr != null)
                    {
                        DropNear(qPtr, null, y, x);
                        dumpItem++;
                    }
                }
            }
        }
        if (visible && (dumpItem != 0 || dumpGold != 0))
        {
            LoreTreasure(mPtr, dumpItem, dumpGold);
        }
        if (!rPtr.Guardian)
        {
            return;
        }
        if (Quests[qIdx].Killed != Quests[qIdx].ToKill)
        {
            return;
        }
        rPtr.Guardian = !rPtr.Guardian;
        if (ActiveQuests == 0)
        {
            RunScript(nameof(WinnerScript));
        }
        else
        {
            if (CurrentDepth < CurDungeon.MaxLevel)
            {
                while (!CaveValidBold(y, x))
                {
                    const int d = 1;
                    (int ny, int nx) = Scatter(y, x, d);
                    y = ny;
                    x = nx;
                }
                DeleteObject(y, x);
                MsgPrint("A magical stairway appears...");
                CaveSetFeat(y, x, CurDungeon.Tower ? GetUpStaircaseTile : GetDownStaircaseTile);
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
            }
        }
    }

    public void Winner()
    {
    }

    public void NoticeStuff()
    {
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeReorderFlaggedAction)).Check();
    }

    public void OpenChest(int y, int x, Item item)
    {
        int number = item.NumberOfItemsContained;

        // Check to see if there is anything in the chest.  A chest trap will set this to zero, if it explodes.
        if (item.ContainerIsOpen)
        {
            number = 0;
        }
        int objectLevel = item.LevelOfObjectsInContainer + 10;
        for (; number > 0; --number)
        {
            if (item.IsSmall && RandomLessThan(100) < 75)
            {
                Item? qPtr = MakeGold(objectLevel);
                if (qPtr != null)
                {
                    DropNear(qPtr, null, y, x);
                }
            }
            else
            {
                Item? qPtr = MakeObject(objectLevel, false, false, true);
                if (qPtr != null)
                {
                    DropNear(qPtr, null, y, x);
                }
            }
        }
        item.ContainerIsOpen = true;
        item.BecomeKnown();
    }

    public void UpdateStuff()
    {
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Check();
        if (FullScreenOverlay)
        {
            return;
        }
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Check();
    }

    private List<Flavor>? GenerateFlavors(ItemClass itemClass)
    {
        if (itemClass.NumberOfFlavorsToGenerate == 0)
        {
            return itemClass.ItemFlavorRepository?.ToList();
        }

        List<Flavor>? itemFlavors = new List<Flavor>();

        UseFixed = true;
        FixedSeed = _seedFlavor;
        WeightedRandom<string> illegibleFlavorSyllablesWeightedRandom = new WeightedRandom<string>(this, IllegibleFlavorSyllables);
        if (illegibleFlavorSyllablesWeightedRandom.SumCount == 0)
        {
            throw new Exception("No illegible syllables loaded to generate item flavors.");
        }

        for (int i = 0; i < itemClass.NumberOfFlavorsToGenerate; i++)
        {
            while (true)
            {
                string buf = "";
                while (true)
                {
                    string tmp = "";
                    int s = RandomLessThan(100) < 30 ? 1 : 2;
                    for (int q = 0; q < s; q++)
                    {
                        tmp += illegibleFlavorSyllablesWeightedRandom.Choose();
                    }
                    if (buf.Length + tmp.Length > 14)
                    {
                        break;
                    }
                    buf += " ";
                    buf += tmp;
                }
                bool okay = true;
                string name = buf.Substring(1);
                foreach (Flavor testFlavor in itemFlavors)
                {
                    if (testFlavor.Name.Substring(0, 4) == name.Substring(0, 4))
                    {
                        okay = false;
                        break;
                    }
                }
                if (okay)
                {
                    // Select a random flavor from the repository.
                    int index = RandomLessThan(itemClass.ItemFlavorRepository.Length);
                    Flavor baseFlavor = itemClass.ItemFlavorRepository[index];

                    // Generate an item flavor.
                    Flavor flavor = new IllegibleItemFlavor(this, baseFlavor.Symbol, baseFlavor.Color, name);
                    itemFlavors.Add(flavor);
                    break;
                }
            }
        }

        return itemFlavors;
    }

    private void ResetItemFlavors()
    {
        // Enumerate all of the item factories and turn on the FlavorAware flag for all item factories that do not have flavors.
        UseFixed = false;
        foreach (ItemFactory itemFactory in SingletonRepository.Get<ItemFactory>())
        {
            itemFactory.IsFlavorAware = !itemFactory.ItemClass.HasFlavor;
        }
    }
    private void AssignItemFlavors()
    {
        // Create a dictionary that tracks all of the flavor repositories as the flavors are being assigned.
        Dictionary<ItemClass, List<Flavor>> itemClassWorkingRepositoryOfItemFlavors = new Dictionary<ItemClass, List<Flavor>>();

        // Loop through all of the item factories.  Multiple item factories will have common item class flavor repositories.
        foreach (ItemFactory kPtr in SingletonRepository.Get<ItemFactory>())
        {
            // Check to see if the item class has flavor.
            if (kPtr.ItemClass.HasFlavor)
            {
                // Check to see if the item has a predefined flavor.
                if (kPtr.PreassignedItemFlavor != null)
                {
                    // Assign the predefined flavor.
                    kPtr.Flavor = kPtr.PreassignedItemFlavor;
                }
                else
                {
                    // No, it doesn't have a preasigned flavor.  Assign one from the item class flavor repository.
                    if (!itemClassWorkingRepositoryOfItemFlavors.TryGetValue(kPtr.ItemClass, out List<Flavor>? currentFlavorRepository))
                    {
                        // Get the flavor repository for the item class.  This generation process may involve generating illegible scroll titles.
                        List<Flavor>? completeFlavorRepository = GenerateFlavors(kPtr.ItemClass);

                        // The dictionary currently isn't tracking the repository.  Set it up now.
                        currentFlavorRepository = completeFlavorRepository;
                        itemClassWorkingRepositoryOfItemFlavors.Add(kPtr.ItemClass, currentFlavorRepository);
                    }

                    // Ensure there are enough flavors.
                    if (currentFlavorRepository.Count == 0)
                    {
                        throw new Exception($"The ItemClass {kPtr.ItemClass.Name} does not have enough flavors to assign to the associated factories.");
                    }

                    // Select a random item flavor.
                    int randomIndex = UseRandom.Next(currentFlavorRepository.Count);

                    // Retrieve the flavor to assign to the factory.
                    kPtr.Flavor = currentFlavorRepository[randomIndex];

                    // Remove the used flavor from the current item class repository.
                    currentFlavorRepository.RemoveAt(randomIndex);
                }

                kPtr.FlavorSymbol = kPtr.Flavor.Symbol;
                kPtr.FlavorColor = kPtr.Flavor.Color;
            }
        }
    }

    private void CloseGame()
    {
        HandleStuff();
        MsgPrint(null);
        FullScreenOverlay = true;
        if (IsDead)
        {
            if (IsWinner.BoolValue)
            {
                Kingly();
            }

            //HighScore score = new HighScore(this);
            SaveGame();
            PrintTomb();
            if (IsWizard.BoolValue)
            {
                return;
            }
            //Program.HiScores.InsertNewScore(score);
            //Program.HiScores.DisplayScores(score.Pts);
        }
        else
        {
            DoCmdSaveGame(false);
            //if (!Program.ExitToDesktop)
            //{
            //    Terminal.PlayMusic(MusicTrack.Menu);
            //    Program.HiScores.DisplayScores(new HighScore(this));
            //}
        }
    }

    /// <summary>
    /// Returns the number of regions of width for the island.  Returns 12, by default.
    /// </summary>
    public int IslandWidth => 12;

    /// <summary>
    /// Returns the number of regions of height for the island.  Returns 12, by default.
    /// </summary>
    public int IslandHeight => 12;

    private void CreateWorld() 
    {
        // Create and initialize the wilderness regions.
        Wilderness = new WildernessRegion[IslandHeight][];
        for (int i = 0; i < IslandHeight; i++)
        {
            Wilderness[i] = new WildernessRegion[IslandWidth];
            for (int j = 0; j < IslandWidth; j++)
            {
                Wilderness[i][j] = new WildernessRegion();
                Wilderness[i][j].Seed = RandomLessThan(int.MaxValue);
                Wilderness[i][j].Dungeon = null;
                Wilderness[i][j].Town = null;
                Wilderness[i][j].RoadMap = 0;
            }
        }

        MakeIslandContours();

        // The game world automatically gets a single instance of every town.  Initialize each town now.
        List<Dungeon> dungeonList = SingletonRepository.Get<Dungeon>().ToList();

        // Reset the position for each dungeon.
        foreach (Dungeon dungeon in dungeonList)
        {
            dungeon.X = 0;
            dungeon.Y = 0;
        }

        // Initialize the towns first and remove the associated dungeons from the list.
        foreach (Town town in SingletonRepository.Get<Town>())
        {
            town.Initialize();

            // Consider dungeons under the town have already been visited.
            Dungeon dungeon = town.Dungeon;
            dungeon.Visited = true;
            while (true)
            {
                // Choose a wilderness region for the dungeon.
                int x = RandomBetween(2, IslandWidth - 3);
                int y = RandomBetween(2, IslandHeight - 3);

                // Ensure the wilderness doesn't already have a dungeon, and none of the surrounding wildernesses do either.
                if (Wilderness[y][x].Dungeon == null && Wilderness[y - 1][x].Dungeon == null &&
                    Wilderness[y + 1][x].Dungeon == null && Wilderness[y][x - 1].Dungeon == null &&
                    Wilderness[y][x + 1].Dungeon == null && Wilderness[y - 1][x + 1].Dungeon == null &&
                    Wilderness[y + 1][x + 1].Dungeon == null && Wilderness[y - 1][x - 1].Dungeon == null &&
                    Wilderness[y + 1][x - 1].Dungeon == null)
                {
                    // Place the town and the dungeon at this wilderness region.
                    Wilderness[y][x].Dungeon = dungeon;
                    Wilderness[y][x].Town = town;
                    dungeon.X = x;
                    dungeon.Y = y;
                    town.X = x;
                    town.Y = y;

                    break;
                }
            }

            // This dungeon is already processed, remove it from the list.
            dungeonList.Remove(dungeon);
        }


        // Initialize the remaining dungeons.
        foreach (Dungeon dungeon in dungeonList)
        {
            dungeon.Visited = false;
            dungeon.KnownDepth = false;
            dungeon.KnownOffset = false;

            while (true)
            {
                int x = RandomBetween(2, IslandWidth - 3);
                int y = RandomBetween(2, IslandHeight - 3);

                // Choose a region that doesn't already have a dungeon.
                if (Wilderness[y][x].Dungeon == null)
                {
                    Wilderness[y][x].Dungeon = dungeon;
                    dungeon.X = x;
                    dungeon.Y = y;

                    break;
                }

            }

        }

        // Create walkway paths between the towns.
        for (int i = 0; i < SingletonRepository.Count<Town>() - 1; i++)
        {
            int curX = SingletonRepository.Get<Town>(i).X;
            int curY = SingletonRepository.Get<Town>(i).Y;
            int destX = SingletonRepository.Get<Town>(i + 1).X;
            int destY = SingletonRepository.Get<Town>(i + 1).Y;
            while (true)
            {
                int xDisp = destX - curX;
                int xSgn = 0;
                if (xDisp > 0)
                {
                    xSgn = 1;
                }
                if (xDisp < 0)
                {
                    xSgn = -1;
                    xDisp = -xDisp;
                }
                int yDisp = destY - curY;
                int ySgn = 0;
                if (yDisp > 0)
                {
                    ySgn = 1;
                }
                if (yDisp < 0)
                {
                    ySgn = -1;
                    yDisp = -yDisp;
                }
                if (xDisp == 0 && yDisp == 0)
                {
                    break;
                }
                else
                {
                    int curdir;
                    int nextdir;
                    if (xDisp == yDisp && xSgn == 1 && ySgn == -1)
                    {
                        curdir = Constants.RoadUp;
                        nextdir = Constants.RoadDown;
                    }
                    else if (xSgn == 1 && xDisp >= yDisp)
                    {
                        curdir = Constants.RoadRight;
                        nextdir = Constants.RoadLeft;
                    }
                    else if (ySgn == 1 && yDisp >= xDisp)
                    {
                        curdir = Constants.RoadDown;
                        nextdir = Constants.RoadUp;
                    }
                    else if (xSgn == -1 && xDisp >= yDisp)
                    {
                        curdir = Constants.RoadLeft;
                        nextdir = Constants.RoadRight;
                    }
                    else
                    {
                        curdir = Constants.RoadUp;
                        nextdir = Constants.RoadDown;
                    }
                    Wilderness[curY][curX].RoadMap |= curdir;
                    if (curdir == Constants.RoadRight)
                    {
                        curX++;
                    }
                    else if (curdir == Constants.RoadLeft)
                    {
                        curX--;
                    }
                    else if (curdir == Constants.RoadDown)
                    {
                        curY++;
                    }
                    else
                    {
                        curY--;
                    }
                    Wilderness[curY][curX].RoadMap |= nextdir;
                }
            }
        }
    }

    /// <summary>
    /// This is all of the logic for each turn in the game.
    /// </summary>
    private void DungeonLoop()
    {
        NewLevelFlag = false;
        HackMind = false;
        CurrentCommand = (char)0;
        CommandRepeat = 0;
        CommandArgument = 0;
        CommandDirection = 0;
        TargetWho = null;
        HealthTrack(null);
        ShimmerMonsters = true;
        RepairMonsters = true;
        Disturb(true);
        if (MaxLevelGained < ExperienceLevel.IntValue)
        {
            MaxLevelGained = ExperienceLevel.IntValue;
        }
        if (CurDungeon.RecallLevel < CurrentDepth)
        {
            CurDungeon.RecallLevel = CurrentDepth;
        }
        if (IsQuest(CurrentDepth))
        {
            if (CurDungeon.Tower)
            {
                CreateUpStair = false;
            }
            else
            {
                CreateDownStair = false;
            }
        }
        if (CurrentDepth <= 0)
        {
            CreateDownStair = false;
            CreateUpStair = false;
        }
        if (CreateUpStair || CreateDownStair)
        {
            if (CaveValidBold(MapY.IntValue, MapX.IntValue))
            {
                DeleteObject(MapY.IntValue, MapX.IntValue);
                CaveSetFeat(MapY.IntValue, MapX.IntValue, CreateDownStair ? GetDownStaircaseTile : GetUpStaircaseTile);
            }
            CreateDownStair = false;
            CreateUpStair = false;
        }
        RecenterScreenAroundPlayer();
        PanelBoundsCenter();
        MsgPrint(null);
        CharacterXtra = true;

        // Invalidate the main screen.
        ConsoleView.Invalidate();

        // TOSO: These flagged actions are not part of the main form yet
        SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        CharacterXtra = false;
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        NoticeStuff();
        UpdateStuff();
        RedrawStuff();
        UpdateScreen();
        if (!Playing || IsDead || NewLevelFlag)
        {
            return;
        }
        if (IsQuest(CurrentDepth))
        {
            QuestDiscovery();
        }
        MonsterLevel = Difficulty;
        HackMind = true;
        if (CameFrom == LevelStartEnum.StartHouse)
        {
            RunScript(nameof(EnterStoreScript));
            CameFrom = LevelStartEnum.StartRandom;
        }
        if (CurrentDepth == 0)
        {
            if (Difficulty == 0)
            {
                PlayMusic(MusicTrackEnum.Town);
            }
            else
            {
                PlayMusic(MusicTrackEnum.Wilderness);
            }
        }
        else
        {
            if (IsQuest(CurrentDepth))
            {
                PlayMusic(MusicTrackEnum.QuestLevel);
            }
            else
            {
                PlayMusic(MusicTrackEnum.Dungeon);
            }
        }
        while (!Shutdown)
        {
            if (MCnt + 32 > Constants.MaxMIdx)
            {
                CompactMonsters(64);
            }
            if (MCnt + 32 < MonsterMax)
            {
                CompactMonsters(0);
            }
            ProcessPlayer();

            NoticeStuff();
            UpdateStuff();
            RedrawStuff();
            ConsoleView.MoveCursorTo(MapY.IntValue, MapX.IntValue);
            if (!Playing || IsDead || NewLevelFlag)
            {
                break;
            }
            TotalFriends = 0;
            TotalFriendLevels = 0;
            ProcessAllMonsters();
            NoticeStuff();
            UpdateStuff();
            RedrawStuff();
            ConsoleView.MoveCursorTo(MapY.IntValue, MapX.IntValue);
            if (!Playing || IsDead || NewLevelFlag)
            {
                break;
            }
            ProcessWorld();
            NoticeStuff();
            UpdateStuff();
            RedrawStuff();
            ConsoleView.MoveCursorTo(MapY.IntValue, MapX.IntValue);
            if (!Playing || IsDead || NewLevelFlag)
            {
                break;
            }
            Tick();
            if (!IsFeelTime)
            {
                continue;
            }
            if (CurrentDepth > 0)
            {
                RunScript(nameof(SayFeelingScript));
            }
        }
    }

    private void InitializeAllocationTables()
    {
        int[] itemCountPerLevel = new int[Constants.MaxDepth];
        int[] aux = new int[Constants.MaxDepth];
        AllocKindSize = 0;

        // Enumerate all items.
        foreach (ItemFactory kPtr in SingletonRepository.Get<ItemFactory>())
        {
            if (kPtr.DepthsFoundAndChances != null)
            {
                // For each depth and chance found, increment the depth table.
                foreach ((int depth, int _) in kPtr.DepthsFoundAndChances)
                {
                    AllocKindSize++;
                    itemCountPerLevel[depth]++;
                }
            }
        }

        // Increment the number of items that can be found at each level cumulatively.
        for (int i = 1; i < Constants.MaxDepth; i++)
        {
            itemCountPerLevel[i] += itemCountPerLevel[i - 1];
        }

        // TODO: We shouldn't need this.
        //if (itemCountPerLevel[0] == 0)
        //{
        //    throw new Exception("No town objects!");
        //}

        // For every item and every depth, create an allocation entry.
        AllocKindTable = new AllocationEntry[AllocKindSize];
        for (int k = 0; k < AllocKindSize; k++)
        {
            AllocKindTable[k] = new AllocationEntry();
        }
        AllocationEntry[] table = AllocKindTable;

        for (int i = 1; i < SingletonRepository.Count<ItemFactory>(); i++)
        {
            ItemFactory kPtr = SingletonRepository.Get<ItemFactory>(i);

            if (kPtr.DepthsFoundAndChances != null)
            {
                // For each depth and chance found, increment the depth table.
                foreach ((int depth, int chance) in kPtr.DepthsFoundAndChances)
                {
                    int p = 100 / chance;
                    int y = depth > 0 ? itemCountPerLevel[depth - 1] : 0;
                    int z = y + aux[depth];
                    table[z].Index = i;
                    table[z].Level = depth;
                    table[z].BaseProbability = p;
                    table[z].FilteredProbabiity = p;
                    table[z].FinalProbability = p;
                    aux[depth]++;
                }
            }
        }
        aux = new int[Constants.MaxDepth];
        itemCountPerLevel = new int[Constants.MaxDepth];
        AllocRaceSize = 0;
        for (int i = 1; i < SingletonRepository.Count<MonsterRace>() - 1; i++)
        {
            MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(i);
            if (rPtr.Rarity != 0)
            {
                AllocRaceSize++;
                itemCountPerLevel[rPtr.Level]++;
            }
        }
        for (int i = 1; i < Constants.MaxDepth; i++)
        {
            itemCountPerLevel[i] += itemCountPerLevel[i - 1];
        }

        // TODO: This shouldn't be needed.
        //if (itemCountPerLevel[0] == 0)
        //{
        //    throw new Exception("No town monsters!");
        //}
        AllocRaceTable = new AllocationEntry[AllocRaceSize];
        for (int k = 0; k < AllocRaceSize; k++)
        {
            AllocRaceTable[k] = new AllocationEntry();
        }
        table = AllocRaceTable;
        for (int i = 1; i < SingletonRepository.Count<MonsterRace>() - 1; i++)
        {
            MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(i);
            if (rPtr.Rarity != 0)
            {
                int x = rPtr.Level;
                int p = 100 / rPtr.Rarity;
                int y = x > 0 ? itemCountPerLevel[x - 1] : 0;
                int z = y + aux[x];
                table[z].Index = i;
                table[z].Level = x;
                table[z].BaseProbability = p;
                table[z].FilteredProbabiity = p;
                table[z].FinalProbability = p;
                aux[x]++;
            }
        }
    }

    private void Kingly()
    {
        CurrentDepth = 0;
        DiedFrom = "Ripe Old Age";
        ExperiencePoints.IntValue = MaxExperienceGained.IntValue;
        ExperienceLevel.IntValue = MaxLevelGained;
        Gold.IntValue += 10000000;
        SetBackground(BackgroundImageEnum.Crown);
        Screen.Clear();
        AnyKey(44);
    }

    private void PrintTomb()
    {
        {
            DateTime ct = DateTime.Now;
            if (IsWinner.BoolValue)
            {
                SetBackground(BackgroundImageEnum.Sunset);
                PlayMusic(MusicTrackEnum.Victory);
            }
            else
            {
                SetBackground(BackgroundImageEnum.Tomb);
                PlayMusic(MusicTrackEnum.Death);
            }
            Screen.Clear();
            string buf = PlayerName.StringValue.Trim() + Generation.ToRoman(true);
            if (IsWinner.BoolValue || ExperienceLevel.IntValue > Constants.PyMaxLevel)
            {
                buf += " the Magnificent";
            }
            Screen.Print(buf, 39, 1);
            buf = $"Level {ExperienceLevel.IntValue} {BaseCharacterClass.ClassSubName(PrimaryRealm)}";
            Screen.Print(buf, 40, 1);
            string tmp = $"Killed on Level {CurrentDepth}".PadLeft(45);
            Screen.Print(tmp, 39, 34);
            tmp = $"by {DiedFrom}".PadLeft(45);
            Screen.Print(tmp, 40, 34);
            tmp = $"on {ct:dd MMM yyyy h.mm tt}".PadLeft(45);
            Screen.Print(tmp, 41, 34);
            AnyKey(44);
        }
    }

    private void ProcessPlayer()
    {
        if (GetFirstLevelMutation)
        {
            MsgPrint("You feel different!");
            RunScript(nameof(GainMutationScript));
            GetFirstLevelMutation = false;
        }
        Energy += ExtractEnergy[Speed.IntValue]; // TODO: This causes a runtime error for out of bounds
        if (Energy < 100)
        {
            return;
        }
        if (Resting < 0)
        {
            if (Resting == -1)
            {
                if (Health.IntValue == MaxHealth.IntValue && Mana.IntValue >= MaxMana.IntValue)
                {
                    Disturb(false);
                }
            }
            else if (Resting == -2)
            {
                if (Health.IntValue == MaxHealth.IntValue && Mana.IntValue == MaxMana.IntValue && BlindnessTimer.Value == 0 &&
                    ConfusionTimer.Value == 0 && PoisonTimer.Value == 0 && FearTimer.Value == 0 && StunTimer.Value == 0 &&
                    BleedingTimer.Value == 0 && SlowTimer.Value == 0 && ParalysisTimer.Value == 0 && HallucinationsTimer.Value == 0 &&
                    WordOfRecallDelay == 0)
                {
                    Disturb(false);
                }
            }
        }
        if (Running != 0 || CommandRepeat != 0 || (Resting != 0 && (Resting & 0x0F) == 0))
        {
            if (Inkey(true) != 0)
            {
                Disturb(false);
                MsgPrint("Cancelled.");
            }
        }
        while (Energy >= 100 && !Shutdown)
        {
            NoticeStuff();
            UpdateStuff();
            RedrawStuff();
            ConsoleView.MoveCursorTo(MapY.IntValue, MapX.IntValue);
            UpdateScreen();
            const int item = InventorySlotEnum.PackCount;
            Item? oPtr = GetInventoryItem(item);
            if (oPtr != null)
            { 
                Disturb(false);
                MsgPrint("Your pack overflows!");
                string oName = oPtr.GetFullDescription(true);
                MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
                DropNear(oPtr, null, MapY.IntValue, MapX.IntValue);
                oPtr.ModifyStackCount(-255);
                InvenItemDescribe(item);
                InvenItemOptimize(item);
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
            }
            EnergyUse = 0;
            if (ParalysisTimer.Value != 0 || StunTimer.Value >= 100)
            {
                EnergyUse = 100;
            }
            else if (Resting != 0)
            {
                if (Resting > 0)
                {
                    Resting--;
                    SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
                }
                EnergyUse = 100;
            }
            else if (Running != 0)
            {
                RunOneStep(0);
            }
            else if (CommandRepeat != 0)
            {
                CommandRepeat--;
                SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
                RedrawStuff();
                MsgClear();
                ProcessCommand(true);
            }
            else
            {
                ConsoleView.MoveCursorTo(MapY.IntValue, MapX.IntValue);

                // We need to track the current seed so that we can restore it if the game is saved and played later.  Also, we use this to enable the game replay.  The position of this process
                // has been placed strategically to record the seed before the player gets a chance to save and close the game but not before any and every keystroke.
                CurrentSequenceRandomSeed = Next(int.MaxValue - 1);
                _mainSequence = new Random(CurrentSequenceRandomSeed);

                RequestCommand(false);
                ProcessCommand(false);
                CloseBatchOfMessages();
            }
            if (EnergyUse != 0)
            {
                Energy -= EnergyUse;
                int i;
                if (ShimmerMonsters)
                {
                    ShimmerMonsters = false;
                    for (i = 1; i < MonsterMax; i++)
                    {
                        Monster mPtr = Monsters[i];
                        if (mPtr.Race == null)
                        {
                            continue;
                        }
                        MonsterRace rPtr = mPtr.Race;
                        if (!rPtr.AttrMulti)
                        {
                            continue;
                        }
                        ShimmerMonsters = true;
                        ConsoleView.RefreshMapLocation(mPtr.MapY, mPtr.MapX);
                    }
                }
                if (RepairMonsters)
                {
                    RepairMonsters = false;
                    for (i = 1; i < MonsterMax; i++)
                    {
                        Monster mPtr = Monsters[i];
                        if (mPtr.Race == null)
                        {
                            continue;
                        }
                        if ((mPtr.IndividualMonsterFlags & Constants.MflagNice) != 0)
                        {
                            mPtr.IndividualMonsterFlags &= ~Constants.MflagNice;
                        }
                        if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                        {
                            if ((mPtr.IndividualMonsterFlags & Constants.MflagShow) != 0)
                            {
                                mPtr.IndividualMonsterFlags &= ~Constants.MflagShow;
                                RepairMonsters = true;
                            }
                            else
                            {
                                mPtr.IndividualMonsterFlags &= ~Constants.MflagMark;
                                mPtr.IsVisible = false;
                                UpdateMonsterVisibility(i, false);
                                ConsoleView.RefreshMapLocation(mPtr.MapY, mPtr.MapX);
                            }
                        }
                    }
                }
            }
            if (!Playing || IsDead || NewLevelFlag)
            {
                break;
            }
        }
    }

    /// <summary>
    /// Processes a single world turn.
    /// </summary>
    private void ProcessWorld()
    {
        if (IsBirthday)
        {
            MsgPrint("Happy Birthday!");
            Acquirement(MapY.IntValue, MapX.IntValue, DieRoll(2) + 1, true);
            Age++;
        }
        if (IsNewYear)
        {
            MsgPrint("Happy New Year!");
            Acquirement(MapY.IntValue, MapX.IntValue, DieRoll(2) + 1, true);
        }
        if (IsHalloween)
        {
            MsgPrint("All Hallows Eve and the ghouls come out to play...");
            SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(UndeadMonsterRaceFilter)), true, false);
        }
        if (CurrentDepth <= 0)
        {
            if (IsDawn)
            {
                MsgPrint("The sun has risen.");
                for (int y = 0; y < CurHgt; y++)
                {
                    for (int x = 0; x < CurWid; x++)
                    {
                        GridTile cPtr = Map.Grid[y][x];
                        cPtr.SelfLit = true;
                        cPtr.PlayerMemorized = true;
                        NoteSpot(y, x);
                    }
                }
            }
            else if (IsDusk)
            {
                MsgPrint("The sun has fallen.");
                for (int y = 0; y < CurHgt; y++)
                {
                    for (int x = 0; x < CurWid; x++)
                    {
                        GridTile cPtr = Map.Grid[y][x];
                        if (cPtr.FeatureType.IsOpenFloor)
                        {
                            cPtr.SelfLit = false;
                            NoteSpot(y, x);
                        }
                    }
                }
            }
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget.  In this case, the Grid array was modified.
        }
        if (IsMidnight)
        {
            DecayFavour();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
            foreach (Town town in SingletonRepository.Get<Town>())
            {
                foreach (Store store in town.Stores)
                {
                    store.StoreMaint();
                }
            }
            if (RandomLessThan(Constants.StoreShuffle) == 0)
            {
                int town = RandomLessThan(SingletonRepository.Count<Town>());
                int store = RandomLessThan(12);
                SingletonRepository.Get<Town>(town).Stores[store].StoreShuffle();
            }
        }
        if (!IsTurnTen)
        {
            return;
        }
        if (RandomLessThan(Constants.MaxMAllocChance) == 0)
        {
            AllocMonster(Constants.MaxSight + 5, false);
        }
        if (IsTurnHundred)
        {
            RegenMonsters();
        }
        if (PoisonTimer.Value != 0 && InvulnerabilityTimer.Value == 0)
        {
            TakeHit(1, "poison");
        }
        bool caveNoRegen = false;

        // Allow all wield slots access to the process world.
        foreach (WieldSlot inventorySlot in SingletonRepository.Get<WieldSlot>())
        {
            ProcessWorldEventArgs inventorySlotProcessWorldEventArgs = new ProcessWorldEventArgs();
            inventorySlot.ProcessWorld(inventorySlotProcessWorldEventArgs);
            if (inventorySlotProcessWorldEventArgs.DisableRegeneration)
            {
                caveNoRegen = true;
            }
        }

        // Allow the race access to the process world.
        ProcessWorldEventArgs processWorldEventArgs = new ProcessWorldEventArgs();
        Race.ProcessWorld(processWorldEventArgs);
        if (processWorldEventArgs.DisableRegeneration)
        {
            caveNoRegen = true;
        }

        if (!GridPassable(MapY.IntValue, MapX.IntValue))
        {
            caveNoRegen = true;
            if (InvulnerabilityTimer.Value == 0 && EtherealnessTimer.Value == 0 && (Health.IntValue > ExperienceLevel.IntValue / 5 || Race.IsEthereal))
            {
                string damDesc;
                if (Race.IsEthereal)
                {
                    MsgPrint("Your body feels disrupted!");
                    damDesc = "density";
                }
                else
                {
                    MsgPrint("You are being crushed!");
                    damDesc = "solid rock";
                }
                TakeHit(1 + (ExperienceLevel.IntValue / 5), damDesc);
            }
        }
        if (BleedingTimer.Value != 0 && InvulnerabilityTimer.Value == 0)
        {
            int damage;
            if (BleedingTimer.Value > 200)
            {
                damage = 3;
            }
            else if (BleedingTimer.Value > 100)
            {
                damage = 2;
            }
            else
            {
                damage = 1;
            }
            TakeHit(damage, "a fatal wound");
        }
        if (Food.IntValue < Constants.PyFoodMax)
        {
            if (IsTurnHundred)
            {
                int additionalEnergy = ExtractEnergy[Speed.IntValue] * 2;
                if (HasRegeneration)
                {
                    additionalEnergy += 30;
                }
                if (HasSlowDigestion)
                {
                    additionalEnergy -= 10;
                }
                if (additionalEnergy < 1)
                {
                    additionalEnergy = 1;
                }
                SetFood(Food.IntValue - additionalEnergy);
            }
        }
        else
        {
            SetFood(Food.IntValue - 100);
        }
        if (Food.IntValue < Constants.PyFoodStarve)
        {
            int i = (Constants.PyFoodStarve - Food.IntValue) / 10;
            if (InvulnerabilityTimer.Value == 0)
            {
                TakeHit(i, "starvation");
            }
        }
        int regenAmount = Constants.PyRegenNormal;
        if (Food.IntValue < Constants.PyFoodWeak)
        {
            if (Food.IntValue < Constants.PyFoodStarve)
            {
                regenAmount = 0;
            }
            else if (Food.IntValue < Constants.PyFoodFaint)
            {
                regenAmount = Constants.PyRegenFaint;
            }
            else
            {
                regenAmount = Constants.PyRegenWeak;
            }
            if (Food.IntValue < Constants.PyFoodFaint)
            {
                if (ParalysisTimer.Value == 0 && RandomLessThan(100) < 10)
                {
                    MsgPrint("You faint from the lack of food.");
                    Disturb(true);
                    ParalysisTimer.AddTimer(1 + RandomLessThan(5));
                }
            }
        }
        if (HasRegeneration)
        {
            regenAmount *= 2;
        }
        if (IsSearching || Resting != 0)
        {
            regenAmount *= 2;
        }
        int upkeepFactor = 0;
        if (TotalFriends != 0)
        {
            int upkeepDivider = BaseCharacterClass.FriendsUpkeepDivider;
            if (TotalFriends > 1 + (ExperienceLevel.IntValue / upkeepDivider))
            {
                upkeepFactor = TotalFriendLevels;
                if (upkeepFactor > 100)
                {
                    upkeepFactor = 100;
                }
                else if (upkeepFactor < 10)
                {
                    upkeepFactor = 10;
                }
            }
        }
        if (Mana.IntValue < MaxMana.IntValue)
        {
            if (upkeepFactor != 0)
            {
                int upkeepRegen = (100 - upkeepFactor) * regenAmount / 100;
                RegenerateMana(upkeepRegen);
            }
            else
            {
                RegenerateMana(regenAmount);
            }
        }
        if (PoisonTimer.Value != 0)
        {
            regenAmount = 0;
        }
        if (BleedingTimer.Value != 0)
        {
            regenAmount = 0;
        }
        if (caveNoRegen)
        {
            regenAmount = 0;
        }
        if (Health.IntValue < MaxHealth.IntValue && !caveNoRegen)
        {
            RegenerateHealth(regenAmount);
        }
        if (GooPatron.MultiRew)
        {
            GooPatron.MultiRew = false;
        }

        // Every timer gets to process the world event.
        foreach (Timer timer in SingletonRepository.Get<Timer>())
        {
            timer.ProcessWorld();
        }

        SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        if (HasExperienceDrain)
        {
            if (RandomLessThan(100) < 10 && ExperiencePoints.IntValue > 0)
            {
                ExperiencePoints.IntValue--;
                MaxExperienceGained.IntValue--;
                CheckExperience();
            }
        }

        // Mutations get to proces the world turn.
        foreach (Mutation mutation in MutationsPossessed.ToArray()) // The list may be modified.  Use the ToArray to prevent an issue.
        {
            mutation.ProcessWorld();
        }

        RunScript(nameof(SenseInventoryScript));

        // Every dungeon grid gets to process the world event.
        for (int y = 1; y < CurHgt - 1; y++)
        {
            for (int x = 1; x < CurWid - 1; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                cPtr.ProcessWorld();
            }
        }

        // Every monster gets to process the world event.
        foreach (Monster monster in Monsters)
        {
            monster.ProcessWorld();
        }

        if (WordOfRecallDelay != 0)
        {
            WordOfRecallDelay--;
            if (WordOfRecallDelay == 0)
            {
                Disturb(false);
                if (CurrentDepth != 0)
                {
                    MsgPrint(CurDungeon.Tower ? "You feel yourself yanked downwards!" : "You feel yourself yanked upwards!");
                    DoCmdSaveGame(true);
                    RecallDungeon = CurDungeon;
                    CurrentDepth = 0;
                    if (TownWithHouse != null)
                    {
                        CurTown = TownWithHouse;
                        WildernessX = CurTown.X;
                        WildernessY = CurTown.Y;
                        NewLevelFlag = true;
                        CameFrom = LevelStartEnum.StartHouse;
                    }
                    else
                    {
                        WildernessX = CurTown.X;
                        WildernessY = CurTown.Y;
                        NewLevelFlag = true;
                        CameFrom = LevelStartEnum.StartRandom;
                    }
                }
                else
                {
                    MsgPrint(RecallDungeon.Tower ? "You feel yourself yanked upwards!" : "You feel yourself yanked downwards!");
                    DoCmdSaveGame(true);
                    CurDungeon = RecallDungeon;
                    WildernessX = CurDungeon.X;
                    WildernessY = CurDungeon.Y;
                    CurrentDepth = CurDungeon.RecallLevel;
                    if (CurrentDepth < 1)
                    {
                        CurrentDepth = 1;
                    }
                    NewLevelFlag = true;
                }
                PlaySound(SoundEffectEnum.TeleportLevel);
            }
        }
    }

    private void RedrawStuff()
    {
        if (FullScreenOverlay)
        {
            return;
        }

        ConsoleView.Refresh();

        SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(RedrawStatsFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Check();
        SingletonRepository.Get<FlaggedAction>(nameof(RedrawSpeedFlaggedAction)).Check();

        // Clear the change tracking flags.
        foreach (IChangeTracker changeTracker in SingletonRepository.Get<IChangeTracker>())
        {
            changeTracker.ClearChangedFlag();
        }
    }

    private void RegenMonsters()
    {
        for (int i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (mPtr.Health < mPtr.MaxHealth)
            {
                int frac = mPtr.MaxHealth / 100;
                if (frac == 0)
                {
                    frac = 1;
                }
                if (rPtr.Regenerate)
                {
                    frac *= 2;
                }
                mPtr.Health += frac;
                if (mPtr.Health > mPtr.MaxHealth)
                {
                    mPtr.Health = mPtr.MaxHealth;
                }
            }
        }
    }

    private bool Verify(string prompt, Item item)
    {
        string oName = item.GetFullDescription(true);
        string outVal = $"{prompt} {oName}? ";
        return GetCheck(outVal);
    }


    // SpellEffectsHandler
    public void AcidDam(int dam, string kbStr)
    {
        int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
        if (HasAcidImmunity || dam <= 0)
        {
            return;
        }
        if (HasElementalVulnerability)
        {
            dam *= 2;
        }
        if (HasAcidResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (AcidResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (AcidResistanceTimer.Value == 0 && !HasAcidResistance && DieRoll(HurtChance) == 1)
        {
            TryDecreasingAbilityScore(CharismaAbility);
        }
        if (MinusAc())
        {
            dam = (dam + 1) / 2;
        }
        TakeHit(dam, kbStr);
        if (AcidResistanceTimer.Value == 0 && !HasAcidResistance)
        {
            InvenDamage(SetAcidDestroy, inv);
        }
    }

    public void ActivateHiSummon()
    {
        int i;
        for (i = 0; i < DieRoll(9) + (Difficulty / 40); i++)
        {
            switch (DieRoll(26) + (Difficulty / 20))
            {
                case 1:
                case 2:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(AntMonsterRaceFilter)), true, false);
                    break;

                case 3:
                case 4:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(SpiderMonsterRaceFilter)), true, false);
                    break;

                case 5:
                case 6:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(HoundMonsterRaceFilter)), true, false);
                    break;

                case 7:
                case 8:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(HydraMonsterRaceFilter)), true, false);
                    break;

                case 9:
                case 10:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(CthuloidMonsterRaceFilter)), true, false);
                    break;

                case 11:
                case 12:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(UndeadMonsterRaceFilter)), true, false);
                    break;

                case 13:
                case 14:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(DragonMonsterRaceFilter)), true, false);
                    break;

                case 15:
                case 16:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(DemonMonsterRaceFilter)), true, false);
                    break;

                case 17:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(GreatOldOneMonsterRaceFilter)), true, false);
                    break;

                case 18:
                case 19:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(UniqueMonsterRaceFilter)), true, false);
                    break;

                case 20:
                case 21:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(HiUndeadMonsterRaceFilter)), true, false);
                    break;

                case 22:
                case 23:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, Difficulty, SingletonRepository.Get<MonsterRaceFilter>(nameof(HiDragonMonsterRaceFilter)), true, false);
                    break;

                case 24:
                case 25:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, 100, SingletonRepository.Get<MonsterRaceFilter>(nameof(ReaverMonsterRaceFilter)), true, false);
                    break;

                default:
                    SummonSpecific(MapY.IntValue, MapX.IntValue, (Difficulty * 3 / 2) + 5, null, true, false);
                    break;
            }
        }
    }

    public void AggravateMonsters(Monster? excludeMonster = null)
    {
        bool sleep = false;
        bool speed = false;
        for (int i = 0; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (excludeMonster != null && mPtr == excludeMonster)
            {
                continue;
            }
            if (mPtr.DistanceFromPlayer < Constants.MaxSight * 2)
            {
                if (mPtr.SleepLevel != 0)
                {
                    mPtr.SleepLevel = 0;
                    sleep = true;
                }
            }
            if (GridTileIsVisible(mPtr.MapY, mPtr.MapX))
            {
                if (mPtr.Speed < rPtr.Speed + 10)
                {
                    mPtr.Speed = rPtr.Speed + 10;
                    speed = true;
                }
                if (mPtr.IsPet)
                {
                    if (DieRoll(2) == 1)
                    {
                        mPtr.IsPet = false;
                    }
                }
            }
        }
        if (speed)
        {
            MsgPrint("You feel a sudden stirring nearby!");
        }
        else if (sleep)
        {
            MsgPrint("You hear a sudden stirring in the distance!");
        }
    }

    public void AlterReality()
    {
        MsgPrint("The world changes!");
        DoCmdSaveGame(true);
        NewLevelFlag = true;
        CameFrom = LevelStartEnum.StartRandom;
    }

    public void ApplyNexus(Monster mPtr)
    {
        switch (DieRoll(7))
        {
            case 1:
            case 2:
            case 3:
                {
                    RunScript(nameof(TeleportSelf200TeleportSelfScript));
                    break;
                }
            case 4:
            case 5:
                {
                    TeleportPlayerTo(mPtr.MapY, mPtr.MapX);
                    break;
                }
            case 6:
                {
                    if (RandomLessThan(100) < SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                        break;
                    }
                    RunScript(nameof(TeleportLevelScript));
                    break;
                }
            case 7:
                {
                    if (RandomLessThan(100) < SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                        break;
                    }
                    MsgPrint("Your body starts to scramble...");
                    ShuffleAbilityScores();
                    break;
                }
        }
    }

    public void ColdDam(int dam, string kbStr)
    {
        int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
        if (HasColdImmunity || dam <= 0)
        {
            return;
        }
        if (HasElementalVulnerability)
        {
            dam *= 2;
        }
        if (HasColdResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (ColdResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(ColdResistanceTimer.Value != 0 || HasColdResistance) && DieRoll(HurtChance) == 1)
        {
            TryDecreasingAbilityScore(StrengthAbility);
        }
        TakeHit(dam, kbStr);
        if (!(HasColdResistance && ColdResistanceTimer.Value != 0))
        {
            InvenDamage(SetColdDestroy, inv);
        }
    }

    public void DestroyArea(int y1, int x1, int r)
    {
        int y, x;
        bool flag = false;
        for (y = y1 - r; y <= y1 + r; y++)
        {
            for (x = x1 - r; x <= x1 + r; x++)
            {
                if (!InBounds(y, x))
                {
                    continue;
                }
                int k = Distance(y1, x1, y, x);
                if (k > r)
                {
                    continue;
                }
                GridTile cPtr = Map.Grid[y][x];
                cPtr.InVault = false;
                cPtr.InRoom = false;
                cPtr.PlayerMemorized = false;
                cPtr.SelfLit = false;
                if (x == MapX.IntValue && y == MapY.IntValue)
                {
                    flag = true;
                    continue;
                }
                if (y == y1 && x == x1)
                {
                    continue;
                }
                DeleteMonsterAtGridLocation(y, x);
                if (CaveValidBold(y, x))
                {
                    DeleteObject(y, x);
                    int t = RandomLessThan(200);
                    if (t < 20)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(WallBasicTile)));
                    }
                    else if (t < 70)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(QuartzTile)));
                    }
                    else if (t < 100)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(MagmaTile)));
                    }
                    else
                    {
                        cPtr.RevertToBackground();
                    }
                }
            }
        }
        if (flag)
        {
            MsgPrint("There is a searing blast of light!");
            if (!HasBlindnessResistance && !HasLightResistance)
            {
                BlindnessTimer.AddTimer(10 + DieRoll(10));
            }
        }
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget.  In this case, the grid was modified.
    }

    public bool DetectDoors()
    {
        bool detect = false;
        for (int y = PanelRowMin; y <= PanelRowMax; y++)
        {
            for (int x = PanelColMin; x <= PanelColMax; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                if (cPtr.FeatureType.IsSecretDoor)
                {
                    ReplaceSecretDoor(y, x);
                }
                if (cPtr.FeatureType.IsVisibleDoor || cPtr.FeatureType.IsOpenDoor)
                {
                    cPtr.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(y, x);
                    detect = true;
                }
            }
        }
        if (detect)
        {
            MsgPrint("You sense the presence of doors!");
        }
        return detect;
    }

    /// <summary>
    /// Reveals all invisible monsters within the viewport.
    /// </summary>
    /// <returns>True, if any monsters were revealed; false, otherwise.</returns>
    public bool DetectInvisibleMonsters()
    {
        bool flag = false;
        for (int i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (!PanelContains(y, x))
            {
                continue;
            }
            if (rPtr.Invisible)
            {
                rPtr.Knowledge.Characteristics.Invisible = true;
                RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                ConsoleView.RefreshMapLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            MsgPrint("You sense the presence of invisible creatures!");
        }
        return flag;
    }

    public bool DetectGold()
    {
        bool detect = false;
        for (int y = 1; y < CurHgt - 1; y++)
        {
            for (int x = 1; x < CurWid - 1; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                foreach (Item oPtr in cPtr.Items)
                {
                    if (!PanelContains(y, x))
                    {
                        continue;
                    }

                    // Any item that has associated gold pieces is considered detectable.
                    if (oPtr.GoldPieces > 0)
                    {
                        oPtr.WasNoticed = true;
                        ConsoleView.RefreshMapLocation(y, x);
                        detect = true;
                    }
                }
            }
        }

        if (detect)
        {
            MsgPrint("You sense the presence of treasure!");
        }
        if (DetectMonstersString("$*"))
        {
            detect = true;
        }
        return detect;
    }

    public bool DetectStairs()
    {
        bool detect = false;
        for (int y = PanelRowMin; y <= PanelRowMax; y++)
        {
            for (int x = PanelColMin; x <= PanelColMax; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                if (cPtr.FeatureType.IsRevealedWithDetectStairsScript)
                {
                    cPtr.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(y, x);
                    detect = true;
                }
            }
        }
        if (detect)
        {
            MsgPrint("You sense the presence of stairs!");
        }
        return detect;
    }

    /// <summary>
    /// Reveals traps that are within the viewport.
    /// </summary>
    /// <returns>True, if any traps were reveals; false, otherwise.</returns>
    public bool DetectTraps()
    {
        bool anyTrapsRevealed = false;
        for (int y = PanelRowMin; y <= PanelRowMax; y++)
        {
            for (int x = PanelColMin; x <= PanelColMax; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                cPtr.TrapsDetected = true;
                ConsoleView.RefreshMapLocation(y, x);
                if (cPtr.FeatureType.IsUnidentifiedTrap)
                {
                    PickTrap(y, x);
                }
                if (cPtr.FeatureType.IsTrap)
                {
                    cPtr.PlayerMemorized = true;
                    anyTrapsRevealed = true;
                }
            }
        }
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        if (anyTrapsRevealed)
        {
            MsgPrint("You sense the presence of traps!");
        }
        return anyTrapsRevealed;
    }

    /// <summary>
    /// Reveals any treasure that is within the viewport.
    /// </summary>
    /// <returns>True, if any treasure was revealed; false, otherwise.</returns>
    public bool DetectTreasure()
    {
        bool anyTreasureRevealed = false;
        for (int y = PanelRowMin; y <= PanelRowMax; y++)
        {
            for (int x = PanelColMin; x <= PanelColMax; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                if (cPtr.FeatureType.HiddenTreasureForTile != null)
                {
                    cPtr.SetFeature(cPtr.FeatureType.HiddenTreasureForTile);
                }
                if (cPtr.FeatureType.IsVisibleTreasure)
                {
                    cPtr.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(y, x);
                    anyTreasureRevealed = true;
                }
            }
        }
        if (anyTreasureRevealed)
        {
            MsgPrint("You sense the presence of buried treasure!");
        }
        return anyTreasureRevealed;
    }

    public void Earthquake(int cy, int cx, int r)
    {
        int i, y, x, yy, xx, dy, dx;
        int damage = 0;
        int sn = 0, sy = 0, sx = 0;
        bool hurt = false;
        GridTile cPtr;
        bool[][] map = new bool[32][];
        for (int j = 0; j < 32; j++)
        {
            map[j] = new bool[32];
        }
        if (r > 12)
        {
            r = 12;
        }
        for (y = 0; y < 32; y++)
        {
            for (x = 0; x < 32; x++)
            {
                map[y][x] = false;
            }
        }
        for (dy = -r; dy <= r; dy++)
        {
            for (dx = -r; dx <= r; dx++)
            {
                yy = cy + dy;
                xx = cx + dx;
                if (!InBounds(yy, xx))
                {
                    continue;
                }
                if (Distance(cy, cx, yy, xx) > r)
                {
                    continue;
                }
                cPtr = Map.Grid[yy][xx];
                cPtr.InVault = false;
                cPtr.InRoom = false;
                cPtr.PlayerMemorized = false;
                cPtr.SelfLit = false;
                if (dx == 0 && dy == 0)
                {
                    continue;
                }
                if (RandomLessThan(100) < 85)
                {
                    continue;
                }
                map[16 + yy - cy][16 + xx - cx] = true;
                if (yy == MapY.IntValue && xx == MapX.IntValue)
                {
                    hurt = true;
                }
            }
        }
        if (hurt)
        {
            for (i = 0; i < 8; i++)
            {
                y = MapY.IntValue + KeypadDirectionYOffset[i];
                x = MapX.IntValue + KeypadDirectionXOffset[i];
                if (!GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (map[16 + y - cy][16 + x - cx])
                {
                    continue;
                }
                sn++;
                if (RandomLessThan(sn) > 0)
                {
                    continue;
                }
                sy = y;
                sx = x;
            }
            switch (DieRoll(3))
            {
                case 1:
                    {
                        MsgPrint("The Grid ceiling collapses!");
                        break;
                    }
                case 2:
                    {
                        MsgPrint("The Grid floor twists in an unnatural way!");
                        break;
                    }
                default:
                    {
                        MsgPrint("The Grid quakes!  You are pummeled with debris!");
                        break;
                    }
            }
            if (sn == 0)
            {
                MsgPrint("You are severely crushed!");
                damage = 300;
            }
            else
            {
                switch (DieRoll(3))
                {
                    case 1:
                        {
                            MsgPrint("You nimbly dodge the blast!");
                            damage = 0;
                            break;
                        }
                    case 2:
                        {
                            MsgPrint("You are bashed by rubble!");
                            damage = DiceRoll(10, 4);
                            StunTimer.AddTimer(DieRoll(50));
                            break;
                        }
                    case 3:
                        {
                            MsgPrint("You are crushed between the floor and ceiling!");
                            damage = DiceRoll(10, 4);
                            StunTimer.AddTimer(DieRoll(50));
                            break;
                        }
                }
                int oy = MapY.IntValue;
                int ox = MapX.IntValue;
                MapY.IntValue = sy;
                MapX.IntValue = sx;
                ConsoleView.RefreshMapLocation(oy, ox);
                ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
                RecenterScreenAroundPlayer();
            }
            map[16 + MapY.IntValue - cy][16 + MapX.IntValue - cx] = false;
            if (damage != 0)
            {
                TakeHit(damage, "an earthquake");
            }
        }
        for (dy = -r; dy <= r; dy++)
        {
            for (dx = -r; dx <= r; dx++)
            {
                yy = cy + dy;
                xx = cx + dx;
                if (!map[16 + yy - cy][16 + xx - cx])
                {
                    continue;
                }
                cPtr = Map.Grid[yy][xx];
                if (cPtr.MonsterIndex != 0)
                {
                    Monster mPtr = Monsters[cPtr.MonsterIndex];
                    MonsterRace rPtr = mPtr.Race;
                    if (!rPtr.KillWall && !rPtr.PassWall)
                    {
                        sn = 0;
                        if (!rPtr.NeverMove)
                        {
                            for (i = 0; i < 8; i++)
                            {
                                y = yy + KeypadDirectionYOffset[i];
                                x = xx + KeypadDirectionXOffset[i];
                                if (!GridPassableNoCreature(y, x))
                                {
                                    continue;
                                }
                                if (Map.Grid[y][x].FeatureType.IsEarthquakeResistant)
                                {
                                    continue;
                                }
                                if (map[16 + y - cy][16 + x - cx])
                                {
                                    continue;
                                }
                                sn++;
                                if (RandomLessThan(sn) > 0)
                                {
                                    continue;
                                }
                                sy = y;
                                sx = x;
                            }
                        }
                        string mName = mPtr.Name;
                        MsgPrint($"{mName} wails out in pain!");
                        damage = sn != 0 ? DiceRoll(4, 8) : 200;
                        mPtr.SleepLevel = 0;
                        mPtr.Health -= damage;
                        if (mPtr.Health < 0)
                        {
                            MsgPrint($"{mName} is embedded in the rock!");
                            DeleteMonsterAtGridLocation(yy, xx);
                            sn = 0;
                        }
                        if (sn != 0)
                        {
                            int mIdx = Map.Grid[yy][xx].MonsterIndex;
                            Map.Grid[sy][sx].MonsterIndex = mIdx;
                            Map.Grid[yy][xx].MonsterIndex = 0;
                            mPtr.MapY = sy;
                            mPtr.MapX = sx;
                            UpdateMonsterVisibility(mIdx, true);
                            ConsoleView.RefreshMapLocation(yy, xx);
                            ConsoleView.RefreshMapLocation(sy, sx);
                        }
                    }
                }
            }
        }
        for (dy = -r; dy <= r; dy++)
        {
            for (dx = -r; dx <= r; dx++)
            {
                yy = cy + dy;
                xx = cx + dx;
                if (!map[16 + yy - cy][16 + xx - cx])
                {
                    continue;
                }
                cPtr = Map.Grid[yy][xx];
                if (yy == MapY.IntValue && xx == MapX.IntValue)
                {
                    continue;
                }
                if (CaveValidBold(yy, xx))
                {
                    bool floor = GridPassable(yy, xx);
                    DeleteObject(yy, xx);
                    int t = floor ? RandomLessThan(100) : 200;
                    if (t < 20)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(WallBasicTile)));
                    }
                    else if (t < 70)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(QuartzTile)));
                    }
                    else if (t < 100)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(MagmaTile)));
                    }
                    else
                    {
                        cPtr.RevertToBackground();
                    }
                }
            }
        }
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }

    public void ElecDam(int dam, string kbStr)
    {
        int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
        if (HasLightningImmunity || dam <= 0)
        {
            return;
        }
        if (HasElementalVulnerability)
        {
            dam *= 2;
        }
        if (LightningResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (HasLightningResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (!(LightningResistanceTimer.Value != 0 || HasLightningResistance) && DieRoll(HurtChance) == 1)
        {
            TryDecreasingAbilityScore(DexterityAbility);
        }
        TakeHit(dam, kbStr);
        if (!(LightningResistanceTimer.Value != 0 && HasLightningResistance))
        {
            InvenDamage(SetElecDestroy, inv);
        }
    }

    public bool Enchant(Item oPtr, int n, int eflag) // TODO: This needs to be refactored
    {
        int[] chanceIn1000 = {0, 10, 50, 100, 200, 300, 400, 500, 650, 800, 950, 987, 993, 995, 998, 1000};

        bool res = false;
        bool isArtifact = oPtr.IsArtifact;
        int prob = oPtr.StackCount * 100;
        prob /= oPtr.EnchantmentMaximumCount;
        for (int i = 0; i < n; i++)
        {
            if (RandomLessThan(prob) >= 100)
            {
                continue;
            }
            int chance;
            if ((eflag & Constants.EnchTohit) != 0)
            {
                if (oPtr.EffectivePropertySet.BonusHits < 0)
                {
                    chance = 0;
                }
                else if (oPtr.EffectivePropertySet.BonusHits > 15)
                {
                    chance = 1000;
                }
                else
                {
                    chance = chanceIn1000[oPtr.EffectivePropertySet.BonusHits];
                }
                if (DieRoll(1000) > chance && (!isArtifact || RandomLessThan(100) < 50))
                {
                    oPtr.EffectivePropertySet.BonusHits++;
                    res = true;
                    if (oPtr.EffectivePropertySet.IsCursed && !oPtr.EffectivePropertySet.PermaCurse && oPtr.EffectivePropertySet.BonusHits >= 0 && RandomLessThan(100) < 25)
                    {
                        MsgPrint("The curse is broken!");
                        oPtr.RemoveCurse();
                        oPtr.RemoveHeavyCurse();
                        oPtr.IdentSense = true;
                        oPtr.Inscription = "uncursed";
                    }
                }
            }
            if ((eflag & Constants.EnchTodam) != 0)
            {
                if (oPtr.EffectivePropertySet.BonusDamage < 0)
                {
                    chance = 0;
                }
                else if (oPtr.EffectivePropertySet.BonusDamage > 15)
                {
                    chance = 1000;
                }
                else
                {
                    chance = chanceIn1000[oPtr.EffectivePropertySet.BonusDamage];
                }
                if (DieRoll(1000) > chance && (!isArtifact || RandomLessThan(100) < 50))
                {
                    oPtr.EffectivePropertySet.BonusDamage++;
                    res = true;
                    if (oPtr.EffectivePropertySet.IsCursed && !oPtr.EffectivePropertySet.PermaCurse && oPtr.EffectivePropertySet.BonusDamage >= 0 && RandomLessThan(100) < 25)
                    {
                        MsgPrint("The curse is broken!");
                        oPtr.RemoveCurse();
                        oPtr.RemoveHeavyCurse();
                        oPtr.IdentSense = true;
                        oPtr.Inscription = "uncursed";
                    }
                }
            }
            if ((eflag & Constants.EnchToac) != 0)
            {
                if (oPtr.EffectivePropertySet.BonusArmorClass < 0)
                {
                    chance = 0;
                }
                else if (oPtr.EffectivePropertySet.BonusArmorClass > 15)
                {
                    chance = 1000;
                }
                else
                {
                    chance = chanceIn1000[oPtr.EffectivePropertySet.BonusArmorClass];
                }
                if (DieRoll(1000) > chance && (!isArtifact || RandomLessThan(100) < 50))
                {
                    oPtr.EffectivePropertySet.BonusArmorClass++;
                    res = true;
                    if (oPtr.EffectivePropertySet.IsCursed && !oPtr.EffectivePropertySet.PermaCurse && oPtr.EffectivePropertySet.BonusArmorClass >= 0 &&
                        RandomLessThan(100) < 25)
                    {
                        MsgPrint("The curse is broken!");
                        oPtr.RemoveCurse();
                        oPtr.RemoveHeavyCurse();
                        oPtr.IdentSense = true;
                        oPtr.Inscription = "uncursed";
                    }
                }
            }
        }
        if (!res)
        {
            return false;
        }
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Allows the player to selection an item from their inventory, equipment or the floor and attempts to enchant it.
    /// </summary>
    /// <param name="numHit"></param>
    /// <param name="numDam"></param>
    /// <param name="numAc"></param>
    /// <returns>False, if there are no items available to the player or the player cancels the selection.  True, otherwise.</returns>
    public bool EnchantItem(int numHit, int numDam, int numAc)
    {
        bool okay = false;
        IItemFilter itemFilter = numAc != 0 ? SingletonRepository.Get<ItemFilter>(nameof(ArmorItemFilter)) : SingletonRepository.Get<ItemFilter>(nameof(WeaponsItemFilter));
        if (!SelectItem(out Item? oPtr, "Enchant which item? ", true, true, true, itemFilter))
        {
            MsgPrint("You have nothing to enchant.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        string oName = oPtr.GetDescription(false);
        string your = oPtr.IsInInventory ? "Your" : "The";
        string s = oPtr.StackCount > 1 ? "" : "s"; // TODO: this plural looks wrong
        MsgPrint($"{your} {oName} glow{s} brightly!"); // TODO: this plural looks wrong
        if (Enchant(oPtr, numHit, Constants.EnchTohit))
        {
            okay = true;
        }
        if (Enchant(oPtr, numDam, Constants.EnchTodam))
        {
            okay = true;
        }
        if (Enchant(oPtr, numAc, Constants.EnchToac))
        {
            okay = true;
        }
        if (!okay)
        {
            MsgPrint("The enchantment failed.");
        }
        return true;
    }

    public IsNoticedEnum ScareMonster(int dir, int plev)
    {
        Projectile projectile = SingletonRepository.Get<Projectile>(nameof(TurnAllProjectile));
        return projectile.TargetedFire(dir, plev, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }

    /// <summary>
    /// Returns true, if the projectile actally hits and affects a monster.
    /// </summary>
    /// <param name="projectile"></param>
    /// <param name="dir"></param>
    /// <param name="dam"></param>
    /// <param name="rad"></param>
    /// <returns></returns>
    public IsNoticedEnum FireBall(Projectile projectile, int dir, int dam, int rad)
    {
        return projectile.TargetedFire(dir, dam, rad, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }

    public void FireBeam(Projectile projectile, int dir, int dam)
    {
        projectile.TargetedFire(dir, dam, 0, beam: true, kill: true, jump: false, stop: false, grid: false, item: false, thru: true, hide: false);
    }

    public void FireBolt(Projectile projectile, int dir, int dam)
    {
        projectile.TargetedFire(dir, dam, 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }

    public void FireBoltOrBeam(int prob, Projectile projectile, int dir, int dam)
    {
        if (RandomLessThan(100) < prob)
        {
            FireBeam(projectile, dir, dam);
        }
        else
        {
            FireBolt(projectile, dir, dam);
        }
    }

    public void FireDam(int dam, string killedByIndefiniteVisibleName)
    {
        int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
        if (HasFireImmunity || dam <= 0)
        {
            return;
        }
        if (HasElementalVulnerability)
        {
            dam *= 2;
        }
        if (HasFireResistance)
        {
            dam = (dam + 2) / 3;
        }
        if (FireResistanceTimer.Value != 0)
        {
            dam = (dam + 2) / 3;
        }
        if (!(FireResistanceTimer.Value != 0 || HasFireResistance) && DieRoll(HurtChance) == 1)
        {
            TryDecreasingAbilityScore(StrengthAbility);
        }
        TakeHit(dam, killedByIndefiniteVisibleName);
        if (!(HasFireResistance && FireResistanceTimer.Value != 0))
        {
            InvenDamage(SetFireDestroy, inv);
        }
    }

    public IsNoticedEnum HealMonster(int dir)
    {
        Projectile projectile = SingletonRepository.Get<Projectile>(nameof(OldHealProjectile));
        return projectile.TargetedFire(dir, DiceRoll(4, 6), 0, stop: true, kill: true, jump: false, beam: false, grid: false, item: false, thru: true, hide: false);
    }

    public bool LightArea(int dam, int rad)
    {
        if (BlindnessTimer.Value == 0)
        {
            MsgPrint("You are surrounded by a white light.");
        }
        Projectile projectile = SingletonRepository.Get<Projectile>(nameof(LightWeakProjectile));
        projectile.Fire(0, rad, MapY.IntValue, MapX.IntValue, dam, grid: true, kill: true, jump: false, beam: false, thru: false, hide: false, item: false, stop: false);
        LightRoom(MapY.IntValue, MapX.IntValue);
        return true;
    }

    public IsNoticedEnum LightLine(int dir)
    {
        Projectile projectile = SingletonRepository.Get<Projectile>(nameof(LightWeakProjectile));
        return projectile.TargetedFire(dir, DiceRoll(6, 8), 0, beam: true, grid: true, kill: true, jump: false, stop: false, item: false, thru: true, hide: false);
    }

    public bool LoseAllInfo()
    {
        for (int i = 0; i < InventorySlotEnum.Total; i++)
        {
            Item? oPtr = GetInventoryItem(i);
            if (oPtr == null)
            {
                continue;
            }
            if (oPtr.IdentMental)
            {
                continue;
            }
            if (string.IsNullOrEmpty(oPtr.Inscription) == false && oPtr.IdentSense)
            {
                string q = oPtr.Inscription;
                if (q == "cursed" || q == "broken" || q == "good" || q == "average" || q == "excellent" ||
                    q == "worthless" || q == "special" || q == "terrible")
                {
                    oPtr.Inscription = string.Empty;
                }
            }
            oPtr.IdentEmpty = false;
            oPtr.IdentityIsKnown = false;
            oPtr.IdentSense = false;
        }
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        RunScript(nameof(DarkScript));
        return true;
    }

    public int PolymorphMonsterRace(MonsterRace rPtr)
    {
        int index = rPtr.Index;
        if (rPtr.Unique || rPtr.Guardian)
        {
            return rPtr.Index;
        }
        int lev1 = rPtr.Level - ((DieRoll(20) / DieRoll(9)) + 1);
        int lev2 = rPtr.Level + (DieRoll(20) / DieRoll(9)) + 1;
        for (int i = 0; i < 1000; i++)
        {
            int r = GetMonNum(((Difficulty + rPtr.Level) / 2) + 5, null);
            if (r == 0)
            {
                break;
            }
            rPtr = SingletonRepository.Get<MonsterRace>(r);
            if (rPtr.Unique)
            {
                continue;
            }
            if (rPtr.Level < lev1 || rPtr.Level > lev2)
            {
                continue;
            }
            index = r;
            break;
        }
        return index;
    }

    public void Probing()
    {
        bool probe = false;
        for (int i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            if (mPtr.Race == null)
            {
                continue;
            }
            if (!GridTileIsVisible(mPtr.MapY, mPtr.MapX))
            {
                continue;
            }
            if (mPtr.IsVisible)
            {
                if (!probe)
                {
                    MsgPrint("Probing...");
                }
                string mName = mPtr.IndefiniteWhenHiddenName;
                MsgPrint($"{mName} has {mPtr.Health} hit points.");
                LoreDoProbe(i);
                probe = true;
            }
        }
        if (probe)
        {
            MsgPrint("That's all.");
        }
    }

    public bool SetAcidDestroy(Item oPtr)
    {
        if (!oPtr.HatesAcid)
        {
            return false;
        }
        if (oPtr.EffectivePropertySet.IgnoreAcid)
        {
            return false;
        }
        return true;
    }

    public bool SetColdDestroy(Item oPtr)
    {
        if (!oPtr.HatesCold)
        {
            return false;
        }
        if (oPtr.EffectivePropertySet.IgnoreCold)
        {
            return false;
        }
        return true;
    }

    public bool SetElecDestroy(Item oPtr)
    {
        if (!oPtr.HatesElectricity)
        {
            return false;
        }
        if (oPtr.EffectivePropertySet.IgnoreElec)
        {
            return false;
        }
        return true;
    }

    public bool SetFireDestroy(Item oPtr)
    {
        if (!oPtr.HatesFire)
        {
            return false;
        }
        if (oPtr.EffectivePropertySet.IgnoreFire)
        {
            return false;
        }
        return true;
    }

    public void SummonReaver()
    {
        int maxReaver = (Difficulty / 50) + DieRoll(6);
        for (int i = 0; i < maxReaver; i++)
        {
            SummonSpecific(MapY.IntValue, MapX.IntValue, 100, SingletonRepository.Get<MonsterRaceFilter>(nameof(ReaverMonsterRaceFilter)), true, false);
        }
    }

    public void TeleportPlayerTo(int ny, int nx)
    {
        int y, x, dis = 0, ctr = 0;
        if (HasAntiTeleport)
        {
            MsgPrint("A mysterious force prevents you from teleporting!");
            return;
        }
        while (true)
        {
            while (true)
            {
                y = RandomSpread(ny, dis);
                x = RandomSpread(nx, dis);
                if (InBounds(y, x))
                {
                    break;
                }
            }
            if (GridOpenNoItemOrCreature(y, x))
            {
                break;
            }
            if (++ctr > (4 * dis * dis) + (4 * dis) + 1)
            {
                ctr = 0;
                dis++;
            }
        }
        PlaySound(SoundEffectEnum.Teleport);
        int oy = MapY.IntValue;
        int ox = MapX.IntValue;
        MapY.IntValue = y;
        MapX.IntValue = x;
        ConsoleView.RefreshMapLocation(oy, ox);
        ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
        RecenterScreenAroundPlayer();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        HandleStuff();
    }

    public void TeleportSwap(int dir)
    {
        int tx, ty;
        tx = MapX.IntValue + KeypadDirectionXOffset[dir];
        ty = MapY.IntValue + KeypadDirectionYOffset[dir];

        if (dir == 5 && TargetWho != null)
        {
            GridCoordinate? target = TargetWho.GetTargetLocation();
            if (target != null)
            {
                tx = target.X;
                ty = target.Y;
            }
        }

        GridTile cPtr = Map.Grid[ty][tx];
        if (cPtr.MonsterIndex == 0)
        {
            MsgPrint("You can't trade places with that!");
        }
        else
        {
            Monster mPtr = Monsters[cPtr.MonsterIndex];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr.ResistTeleport)
            {
                MsgPrint("Your teleportation is blocked!");
            }
            else
            {
                PlaySound(SoundEffectEnum.Teleport);
                Map.Grid[MapY.IntValue][MapX.IntValue].MonsterIndex = cPtr.MonsterIndex;
                cPtr.MonsterIndex = 0;
                mPtr.MapY = MapY.IntValue;
                mPtr.MapX = MapX.IntValue;
                MapX.IntValue = tx;
                MapY.IntValue = ty;
                tx = mPtr.MapX;
                ty = mPtr.MapY;
                UpdateMonsterVisibility(Map.Grid[ty][tx].MonsterIndex, true);
                ConsoleView.RefreshMapLocation(ty, tx);
                ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
                RecenterScreenAroundPlayer();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
                HandleStuff();
            }
        }
    }

    public bool UnlightArea(int dam, int rad)
    {
        if (BlindnessTimer.Value == 0)
        {
            MsgPrint("Darkness surrounds you.");
        }
        Projectile projectile = SingletonRepository.Get<Projectile>(nameof(DarknessWeakProjectile));
        projectile.Fire(0, rad, MapY.IntValue, MapX.IntValue, dam, grid: true, kill: true, jump: false, beam: false, thru: false, hide: false, item: false, stop: false);
        UnlightRoom(MapY.IntValue, MapX.IntValue);
        return true;
    }

    public void UnlightRoom(int y1, int x1)
    {
        CaveTempRoomAux(y1, x1);
        for (int i = 0; i < TempN; i++)
        {
            int x = TempX[i];
            int y = TempY[i];
            if (!GridPassable(y, x))
            {
                continue;
            }
            CaveTempRoomAux(y + 1, x);
            CaveTempRoomAux(y - 1, x);
            CaveTempRoomAux(y, x + 1);
            CaveTempRoomAux(y, x - 1);
            CaveTempRoomAux(y + 1, x + 1);
            CaveTempRoomAux(y - 1, x - 1);
            CaveTempRoomAux(y - 1, x + 1);
            CaveTempRoomAux(y + 1, x - 1);
        }
        CaveTempRoomUnlight();
    }

    public void WallBreaker()
    {
        int dir;
        if (DieRoll(80 + ExperienceLevel.IntValue) < 70)
        {
            do
            {
                dir = DieRoll(9);
            } while (dir == 5 || dir == 0);
            RunIdentifiedScriptDirection(nameof(WallToMud1d30p20ProjectileScript), dir);
        }
        else if (DieRoll(100) > 30)
        {
            Earthquake(MapY.IntValue, MapX.IntValue, 1);
        }
        else
        {
            for (dir = 1; dir < 10; dir++)
            {
                if (dir != 5)
                {
                    RunIdentifiedScriptDirection(nameof(WallToMud1d30p20ProjectileScript), dir);
                }
            }
        }
    }

    private void CaveTempRoomAux(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.TempFlag)
        {
            return;
        }
        if (!cPtr.InRoom)
        {
            return;
        }
        if (TempN == Constants.TempMax)
        {
            return;
        }
        cPtr.TempFlag = true;
        TempY[TempN] = y;
        TempX[TempN] = x;
        TempN++;
    }

    private void CaveTempRoomLight()
    {
        for (int i = 0; i < TempN; i++)
        {
            int y = TempY[i];
            int x = TempX[i];
            GridTile cPtr = Map.Grid[y][x];
            cPtr.TempFlag = false;
            cPtr.SelfLit = true;
            if (cPtr.MonsterIndex != 0)
            {
                int chance = 25;
                Monster mPtr = Monsters[cPtr.MonsterIndex];
                MonsterRace rPtr = mPtr.Race;
                UpdateMonsterVisibility(cPtr.MonsterIndex, false);
                if (rPtr.Stupid)
                {
                    chance = 10;
                }
                if (rPtr.Smart)
                {
                    chance = 100;
                }
                if (mPtr.SleepLevel != 0 && RandomLessThan(100) < chance)
                {
                    mPtr.SleepLevel = 0;
                    if (mPtr.IsVisible)
                    {
                        string mName = mPtr.Name;
                        MsgPrint($"{mName} wakes up.");
                    }
                }
            }
            NoteSpot(y, x);
            ConsoleView.RefreshMapLocation(y, x);
        }
        TempN = 0;
    }

    private void CaveTempRoomUnlight()
    {
        for (int i = 0; i < TempN; i++)
        {
            int y = TempY[i];
            int x = TempX[i];
            GridTile cPtr = Map.Grid[y][x];
            cPtr.TempFlag = false;
            cPtr.SelfLit = false;
            if (cPtr.FeatureType.IsOpenFloor)
            {
                cPtr.PlayerMemorized = false;
                NoteSpot(y, x);
            }
            if (cPtr.MonsterIndex != 0)
            {
                UpdateMonsterVisibility(cPtr.MonsterIndex, false);
            }
            ConsoleView.RefreshMapLocation(y, x);
        }
        TempN = 0;
    }

    public bool DetectMonstersString(string match)
    {
        bool flag = false;
        for (int i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (!PanelContains(y, x))
            {
                continue;
            }
            if (match.Contains(rPtr.Symbol.Character.ToString()))
            {
                RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                ConsoleView.RefreshMapLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            MsgPrint("You sense the presence of monsters!");
        }
        return flag;
    }

    private void LightRoom(int y1, int x1)
    {
        CaveTempRoomAux(y1, x1);
        for (int i = 0; i < TempN; i++)
        {
            int x = TempX[i];
            int y = TempY[i];
            if (!GridPassable(y, x))
            {
                continue;
            }
            CaveTempRoomAux(y + 1, x);
            CaveTempRoomAux(y - 1, x);
            CaveTempRoomAux(y, x + 1);
            CaveTempRoomAux(y, x - 1);
            CaveTempRoomAux(y + 1, x + 1);
            CaveTempRoomAux(y - 1, x - 1);
            CaveTempRoomAux(y - 1, x + 1);
            CaveTempRoomAux(y + 1, x - 1);
        }
        CaveTempRoomLight();
    }

    private bool MinusAc()
    {
        // Generate a weighted random for armor wield slots.
        WeightedRandom<WieldSlot> wieldSlotsWeightedRandom = SingletonRepository.ToWeightedRandom<WieldSlot>(_inventorySlot => _inventorySlot.IsArmor);

        // Choose one of those wield slots.
        WieldSlot? wieldSlot = wieldSlotsWeightedRandom.ChooseOrDefault();

        if (wieldSlot == null)
        {
            // No wield slots are affected by acid or the slot is empty.
            return false;
        }
        Item? oPtr = GetInventoryItem(wieldSlot.WeightedRandom.ChooseOrDefault());
        if (oPtr == null)
        {
            return false;
        }
        if (oPtr.ArmorClass + oPtr.EffectivePropertySet.BonusArmorClass <= 0)
        {
            return false;
        }
        string oName = oPtr.GetDescription(false);
        if (oPtr.EffectivePropertySet.IgnoreAcid)
        {
            MsgPrint($"Your {oName} is unaffected!");
            return true;
        }
        MsgPrint($"Your {oName} is damaged!");
        oPtr.EffectivePropertySet.BonusArmorClass--;
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Fires a projectile at all monsters in the players line-of-sight and returns true, if the projectile actually hits a monster; false, otherwise.
    /// </summary>
    /// <param name="projectile"></param>
    /// <param name="dam"></param>
    /// <returns></returns>
    public IsNoticedEnum ProjectAtAllInLos(Projectile projectile, int dam)
    {
        IsNoticedEnum isNoticed = IsNoticedEnum.False;
        for (int i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            if (mPtr.Race == null) // TODO: This should never be.
            {
                continue;
            }
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (!GridTileIsVisible(y, x))
            {
                continue;
            }
            if (projectile.Fire(0, 0, y, x, dam, kill: true, jump: true, hide: true, beam: false, thru: false, grid: false, item: false, stop: false) == IsNoticedEnum.True)
            {
                isNoticed = IsNoticedEnum.True;
            }
        }
        return isNoticed;
    }

    public bool RemoveCurseAux(bool alsoRemoveHeavyCurse)
    {
        int cnt = 0;
        for (int i = InventorySlotEnum.MeleeWeapon; i < InventorySlotEnum.Total; i++)
        {
            Item? oPtr = GetInventoryItem(i);
            if (oPtr == null)
            {
                continue;
            }
            if (!oPtr.EffectivePropertySet.IsCursed)
            {
                continue;
            }
            if (!alsoRemoveHeavyCurse && oPtr.EffectivePropertySet.HeavyCurse)
            {
                continue;
            }
            if (oPtr.EffectivePropertySet.PermaCurse)
            {
                continue;
            }
            oPtr.RemoveCurse();
            oPtr.RemoveHeavyCurse();
            oPtr.IdentSense = true;
            oPtr.Inscription = "uncursed";
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            cnt++;
        }
        return cnt > 0;
    }

    /// <summary>
    /// Process the player's latest command
    /// </summary>
    public void ProcessCommand(bool isRepeated)
    {
        // Get the current command
        char c = CurrentCommand;

        // Process commands
        foreach (GameCommand command in SingletonRepository.Get<GameCommand>())
        {
            // TODO: The IF statement below can be converted into a dictionary with the applicable object 
            // attached for improved performance.
            if (command.IsEnabled && command.KeyChar == c)
            {
                bool isRepeatable = false;
                if (command.ExecuteScript != null)
                {
                    RepeatableResultEnum gameCommandResult = command.ExecuteScript.ExecuteGameCommandScript();
                    isRepeatable = gameCommandResult == RepeatableResultEnum.True;
                }

                if (!isRepeatable)
                {
                    Disturb(false);
                }
                else if (!isRepeated && command.Repeat.HasValue)
                {
                    // Apply the default repeat value.  This handles the 0, for no repeat and default repeat count (TBDocs+ ... count = 99).
                    // Only apply the default once.
                    CommandArgument = command.Repeat.Value;
                }

                if (CommandArgument > 0)
                {
                    CommandRepeat = CommandArgument - 1;
                    SingletonRepository.Get<FlaggedAction>(nameof(RedrawStateFlaggedAction)).Set();
                    CommandArgument = 0;
                }

                // The command was processed.  Skip the SWITCH statement.
                return;
            }
        }
        Screen.PrintLine("Type '?' for a list of commands.", 0, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns>Returns true, if the command can be repeated; false, if the command succeeds or is futile.</returns>
    public bool BashClosedDoor(int y, int x)
    {
        bool more = false;
        EnergyUse = 100;
        GridTile cPtr = Map.Grid[y][x];
        MsgPrint("You smash into the door!");
        int bash = StrengthAbility.StrAttackSpeedComponent;
        int temp = cPtr.FeatureType.LockLevel;
        temp = bash - (temp * 10);
        if (temp < 1)
        {
            temp = 1;
        }
        if (RandomLessThan(100) < temp)
        {
            MsgPrint("The door crashes open!");
            CaveSetFeat(y, x, RandomLessThan(100) < 50 ? SingletonRepository.Get<Tile>(nameof(BrokenDoorTile)) : SingletonRepository.Get<Tile>(nameof(OpenDoorTile)));
            PlaySound(SoundEffectEnum.OpenDoor);
            MovePlayer(y, x, false);
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        }
        else if (RandomLessThan(100) < DexterityAbility.DexTheftAvoidance + ExperienceLevel.IntValue)
        {
            MsgPrint("The door holds firm.");
            more = true;
        }
        else
        {
            MsgPrint("You are off-balance.");
            ParalysisTimer.AddTimer(2 + RandomLessThan(2));
        }
        return more;
    }

    /// <summary>
    /// Check to see if a racial power works
    /// </summary>
    /// <param name="minLevel"> The minimum level for the power </param>
    /// <param name="cost"> The cost in mana to use the power </param>
    /// <param name="useStat"> The ability score used for the power </param>
    /// <param name="difficulty"> The difficulty of the power to use </param>
    /// <returns> True if the power worked, false if it didn't </returns>
    public bool CheckIfRacialPowerWorks(int minLevel, int cost, Ability useStat, int difficulty)
    {
        // If we don't have enough mana we'll use health instead
        bool useHealth = Mana.IntValue < cost;
        // Can't use it if we're too low level
        if (ExperienceLevel.IntValue < minLevel)
        {
            MsgPrint($"You need to attain level {minLevel} to use this power.");
            EnergyUse = 0;
            return false;
        }
        // Can't use it if we're confused
        if (ConfusionTimer.Value != 0)
        {
            MsgPrint("You are too confused to use this power.");
            EnergyUse = 0;
            return false;
        }
        // If we're about to kill ourselves, give us chance to back out
        if (useHealth && Health.IntValue < cost)
        {
            if (!GetCheck("Really use the power in your weakened state? "))
            {
                EnergyUse = 0;
                return false;
            }
        }
        // Harder to use powers when you're stunned
        if (StunTimer.Value != 0)
        {
            difficulty += StunTimer.Value;
        }
        // Easier to use powers if you're higher level than you need to be
        else if (ExperienceLevel.IntValue > minLevel)
        {
            int levAdj = (ExperienceLevel.IntValue - minLevel) / 3;
            if (levAdj > 10)
            {
                levAdj = 10;
            }
            difficulty -= levAdj;
        }
        // We have a minimum difficulty
        if (difficulty < 5)
        {
            difficulty = 5;
        }
        // Using a power takes a turn
        EnergyUse = 100;
        // Reduce our health or mana
        if (useHealth)
        {
            TakeHit((cost / 2) + DieRoll(cost / 2), "concentrating too hard");
        }
        else
        {
            Mana.IntValue -= (cost / 2) + DieRoll(cost / 2);
        }

        // Check to see if we were successful
        if (DieRoll(useStat.Innate) >= (difficulty / 2) + DieRoll(difficulty / 2))
        {
            return true;
        }
        // Let us know we failed
        MsgPrint("You've failed to concentrate hard enough.");
        return false;
    }

    /// <summary>
    /// Close a door
    /// </summary>
    /// <param name="y"> The y map coordinate of the door </param>
    /// <param name="x"> The x map coordinate of the door </param>
    /// <returns>True if the command can be repeated; false, if the command succeeds or is futile.</returns>
    public bool CloseDoor(int y, int x)
    {
        EnergyUse = 100;
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.FeatureType.IsBrokenDoor)
        {
            MsgPrint("The door appears to be broken.");
        }
        else
        {
            CaveSetFeat(y, x, SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
            PlaySound(SoundEffectEnum.ShutDoor);
        }
        return false;
    }

    /// <summary>
    /// Count the number of chests adjacent to the player, filling in a map coordinate with the location of the last one found.
    /// </summary>
    /// <param name="mapCoordinate"> The coordinate to fill in with the location </param>
    /// <param name="trappedOnly"> True if we're only interested in trapped chests </param>
    /// <returns> The number of chests </returns>
    public int CountChests(out GridCoordinate? mapCoordinate, bool trappedOnly)
    {
        int count = 0;
        mapCoordinate = null;
        for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
        {
            int yy = MapY.IntValue + OrderedDirectionYOffset[orderedDirection];
            int xx = MapX.IntValue + OrderedDirectionXOffset[orderedDirection];
            // Get the index of first item in the tile that is a chest
            Item? chestItem = ChestCheck(yy, xx);
            if (chestItem == null)
            {
                // There wasn't a chest on the grid so skip
                continue;
            }
            // Get the actual item from the index
            if (chestItem.ContainerIsOpen)
            {
                continue;
            }
            // If we're only interested in trapped chests, skip those that aren't
            if (trappedOnly && (!chestItem.IsKnown() || chestItem.ContainerTraps.Length == 0))
            {
                continue;
            }
            count++;
            // Remember the coordinate
            mapCoordinate = new GridCoordinate(xx, yy);
        }
        return count;
    }

    /// <summary>
    /// Count the number of closed doors around the player, filling in a map coordinate with the
    /// location of the last one found
    /// </summary>
    /// <param name="mapCoordinate"> The location around which to search </param>
    /// <returns> The number of closed doors </returns>
    public int CountClosedDoors(out GridCoordinate? mapCoordinate)
    {
        int count = 0;
        mapCoordinate = null;
        for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
        {
            int yy = MapY.IntValue + OrderedDirectionYOffset[orderedDirection];
            int xx = MapX.IntValue + OrderedDirectionXOffset[orderedDirection];
            // We need to be aware of the door
            if (!Map.Grid[yy][xx].PlayerMemorized)
            {
                continue;
            }
            // It needs to be an actual door
            if (!Map.Grid[yy][xx].FeatureType.IsVisibleDoor)
            {
                continue;
            }
            // It can't be a secret door
            if (Map.Grid[yy][xx].FeatureType.IsSecretDoor)
            {
                continue;
            }
            count++;
            // Remember the coordinate
            mapCoordinate = new GridCoordinate(xx, yy);
        }
        return count;
    }

    /// <summary>
    /// Get the number of known traps around the player, storing the map coordinate of the last
    /// one found
    /// </summary>
    /// <param name="mapCoordinate">
    /// The coordinate in which to store the location of the last trap found
    /// </param>
    /// <returns> The number of traps found </returns>
    public int CountKnownTraps(out GridCoordinate? mapCoordinate)
    {
        int count = 0;
        mapCoordinate = null;
        for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
        {
            int yy = MapY.IntValue + OrderedDirectionYOffset[orderedDirection];
            int xx = MapX.IntValue + OrderedDirectionXOffset[orderedDirection];
            // We need to be aware of the trap
            if (!Map.Grid[yy][xx].PlayerMemorized)
            {
                continue;
            }
            // It needs to actually be a trap
            if (!Map.Grid[yy][xx].FeatureType.IsTrap)
            {
                continue;
            }
            count++;
            // Remember its location
            mapCoordinate = new GridCoordinate(xx, yy);
        }
        return count;
    }

    /// <summary>
    /// Heavily curse the players armor. 
    /// </summary>
    /// <returns>
    /// Returns true, if there was armor that was subjected to being cursed, even if the armor resisted the curse; false, if there was no
    /// armor capable of being cursed.
    /// </returns>
    public bool CurseArmor()
    {
        WieldSlot? inventorySlot = SingletonRepository.ToWeightedRandom<WieldSlot>(_inventorySlot => _inventorySlot.CanBeCursed).ChooseOrDefault();

        // Check to see if there are any slots capable of cursing.
        if (inventorySlot == null)
        {
            return false;
        }

        // Choose an item from the slot.
        Item? item = GetInventoryItem(inventorySlot.WeightedRandom.ChooseOrDefault());

        // If we're not wearing armor then nothing can happen
        if (item == null)
        {
            return false;
        }
        // Artifacts can't be cursed, and normal armor has a chance to save
        string itemName = item.GetFullDescription(false);
        if (item.IsArtifact && RandomLessThan(100) < 50)
        {
            MsgPrint($"A terrible black aura tries to surround your armor, but your {itemName} resists the effects!");
        }
        else
        {
            // Completely remake the armor into a set of blasted armor
            MsgPrint($"A terrible black aura blasts your {itemName}!");
            item.FixedArtifact = null;
            item.EffectivePropertySet.RemoveEnhancement("fixed");
            item.SetRareItem(SingletonRepository.Get<ItemEnhancement>(nameof(ArmorBlastedItemEnhancement)));
            item.EffectivePropertySet.BonusArmorClass = 0 - DieRoll(5) - DieRoll(5);
            item.EffectivePropertySet.BonusHits = 0;
            item.EffectivePropertySet.BonusDamage = 0;
            item.ArmorClass = 0;
            item.EffectivePropertySet.OverrideIntValue(PropertyEnum.DamageDice, 0);
            item.EffectivePropertySet.OverrideIntValue(PropertyEnum.DiceSides , 0);
            item.EffectivePropertySet.IsCursed = true;
            item.ResetCurse();
            item.IsBroken = true;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        }
        return true;
    }

    /// <summary>
    /// Heavily curse the player's weapon
    /// </summary>
    /// <returns> True if the player was carrying a weapon, false if not </returns>
    public bool CurseWeapon()
    {
        Item? item = GetInventoryItem(InventorySlotEnum.MeleeWeapon);
        // If we don't have a weapon then nothing happens
        if (item == null)
        {
            return false;
        }
        string itemName = item.GetFullDescription(false);
        // Artifacts can't be cursed, and other items have a chance to resist
        if (item.IsArtifact && RandomLessThan(100) < 50)
        {
            MsgPrint($"A terrible black aura tries to surround your weapon, but your {itemName} resists the effects!");
        }
        else
        {
            // Completely remake the item into a shattered weapon
            MsgPrint($"A terrible black aura blasts your {itemName}!");
            item.FixedArtifact = null;
            item.EffectivePropertySet.RemoveEnhancement("fixed");
            item.SetRareItem(SingletonRepository.Get<ItemEnhancement>(nameof(WeaponShatteredItemEnhancement)));
            item.EffectivePropertySet.BonusHits = 0 - DieRoll(5) - DieRoll(5);
            item.EffectivePropertySet.BonusDamage = 0 - DieRoll(5) - DieRoll(5);
            item.EffectivePropertySet.BonusArmorClass = 0;
            item.ArmorClass = 0;
            item.EffectivePropertySet.OverrideIntValue(PropertyEnum.DamageDice, 0);
            item.EffectivePropertySet.OverrideIntValue(PropertyEnum.DiceSides, 0);
            item.EffectivePropertySet.IsCursed = true;
            item.ResetCurse();
            item.IsBroken = true;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        }
        return true;
    }

    /// <summary>
    /// Disarm a chest at a given location
    /// </summary>
    /// <param name="y"> The y coordinate of the location </param>
    /// <param name="x"> The x coordinate of the location </param>
    /// <param name="itemIndex"> The index of the chest item </param>
    /// <returns> True, if the player is allowed to another attempt to disarm the trap.</returns>
    public bool DisarmChest(int y, int x, Item chestItem)
    {
        bool allowAdditionalDisarmAttempts = false;
        // Disarming a chest takes a turn
        EnergyUse = 100;
        int i = SkillDisarmTraps;
        // Disarming is tricky when you can't see
        if (BlindnessTimer.Value != 0 || NoLight())
        {
            i /= 10;
        }
        // Disarming is tricky when confused
        if (ConfusionTimer.Value != 0 || HallucinationsTimer.Value != 0)
        {
            i /= 10;
        }
        // Penalty for difficulty of trap
        int j = i - chestItem.LevelOfObjectsInContainer;
        if (j < 2)
        {
            j = 2;
        }
        // If we don't know about the traps, we don't know what to disarm
        if (!chestItem.IsKnown())
        {
            MsgPrint("I don't see any traps.");
        }
        // If it has no traps there's nothing to disarm
        else if (chestItem.ContainerIsOpen || chestItem.ContainerTraps == null || chestItem.ContainerTraps.Length == 0)
        {
            MsgPrint("The chest is not trapped.");
        }
        // If we made the skill roll then we disarmed it
        else if (RandomLessThan(100) < j)
        {
            MsgPrint("You have disarmed the chest.");
            GainExperience(chestItem.LevelOfObjectsInContainer);
            chestItem.ContainerTraps = new ChestTrap[] { };
        }
        // If we failed to disarm it there's a chance it goes off
        else if (i > 5 && DieRoll(i) > 5)
        {
            allowAdditionalDisarmAttempts = true;
            MsgPrint("You failed to disarm the chest.");
        }
        else
        {
            MsgPrint("You set off a trap!");
            ActivateChestTrap(y, x, chestItem);
        }
        return allowAdditionalDisarmAttempts;
    }

    /// <summary>
    /// Disarm a trap on the floor
    /// </summary>
    /// <param name="y"> The y coordinate of the trap </param>
    /// <param name="x"> The x coordinate of the trap </param>
    /// <param name="dir"> The direction the player should move in </param>
    /// <returns>True, if the command can be repeated; false if the disarm succeeds or is futile.</returns>
    public bool DisarmTrap(int y, int x)
    {
        bool more = false;
        // Disarming a trap costs a turn
        EnergyUse = 100;
        GridTile tile = Map.Grid[y][x];
        string trapName = tile.FeatureType.Description;
        int i = SkillDisarmTraps;
        // Difficult, but possible, to disarm by feel
        if (BlindnessTimer.Value != 0 || NoLight())
        {
            i /= 10;
        }
        // Difficult to disarm when we're confused
        if (ConfusionTimer.Value != 0 || HallucinationsTimer.Value != 0)
        {
            i /= 10;
        }
        const int power = 5;
        int j = i - power;
        if (j < 2)
        {
            j = 2;
        }
        // Check the modified disarm skill
        if (RandomLessThan(100) < j)
        {
            MsgPrint($"You have disarmed the {trapName}.");
            GainExperience(power);
            tile.PlayerMemorized = false;
            RevertTileToBackground(y, x);
            MovePlayer(y, x, true);
        }
        // We might set the trap off if we failed to disarm it
        else if (i > 5 && DieRoll(i) > 5)
        {
            MsgPrint($"You failed to disarm the {trapName}.");
            more = true;
        }
        else
        {
            MsgPrint($"You set off the {trapName}!");
            MovePlayer(y, x, true);
        }
        return more;
    }

    /// <summary>
    /// Channel mana to power an item instead
    /// </summary>
    /// <param name="item"> The item that we wish to power </param>
    /// <returns> True if we successfully channeled it, false if not </returns>
    public bool DoCmdChannel(Item item, int manaValue)
    {
        int manaNeeded;
        int itemCost = item.GetRealValue();

        // Never channel worthless items
        if (itemCost <= 0)
        {
            return false;
        }

        // Cost to channel is based on how much the item is worth and what type
        manaNeeded = itemCost / manaValue;
        // Always cost at least 1 mana
        if (manaNeeded < 1)
        {
            manaNeeded = 1;
        }

        // Spend the mana if we can
        if (manaNeeded <= Mana.IntValue)
        {
            MsgPrint("You channel mana to power the effect.");
            Mana.IntValue -= manaNeeded;
            return true;
        }

        // Use some mana in the attempt, even if we failed
        MsgPrint("You mana is insufficient to power the effect.");
        Mana.IntValue -= RandomLessThan(Mana.IntValue / 2);
        return false;
    }

    /// <summary>
    /// Find a spike in the player's inventory
    /// </summary>
    /// <param name="inventoryIndex"> The inventory index of the spike found (if any) </param>
    /// <returns> Whether or not a spike was found </returns>
    public bool GetSpike(out int inventoryIndex) // TODO: This can be generalized in a new method FindInventoryItems(ItemFilter itemFilter)
    {
        // Loop through the inventory
        for (int i = 0; i < InventorySlotEnum.PackCount; i++)
        {
            Item? item = GetInventoryItem(i);
            if (item == null)
            {
                continue;
            }
            // If the item is a spike, return it
            if (item.CanSpikeDoorClosed)
            {
                inventoryIndex = i;
                return true;
            }
        }
        // We found nothing, so return false
        inventoryIndex = -1;
        return false;
    }

    /// <summary>
    /// Attempt to move the player in the given direction
    /// </summary>
    /// <param name="direction"> The direction in which to move </param>
    /// <param name="dontPickup"> Whether or not to skip picking up any objects we step on </param>
    public void MovePlayer(int direction, bool dontPickup)
    {
        int newY = MapY.IntValue + KeypadDirectionYOffset[direction];
        int newX = MapX.IntValue + KeypadDirectionXOffset[direction];
        MovePlayer(newY, newX, dontPickup);
    }

    private void MovePlayer(int newY, int newX, bool dontPickup)
    { 
        bool canPassWalls = false;
        GridTile tile = Map.Grid[newY][newX];
        Monster monster = Monsters[tile.MonsterIndex];
        // Check if we can pass through walls
        if (EtherealnessTimer.Value != 0 || Race.IsEthereal)
        {
            canPassWalls = true;
            // Permanent features can't be passed through even if we could otherwise
            if (Map.Grid[newY][newX].FeatureType.IsPermanent)
            {
                canPassWalls = false;
            }
        }
        // If there's a monster we can see or an invisible monster on a tile we can move to,
        // deal with it
        if (tile.MonsterIndex != 0 && (monster.IsVisible || GridPassable(newY, newX) || canPassWalls))
        {
            // Check if it's a friend, and if we are in a fit state to distinguish friend from foe
            if (monster.IsPet && !(ConfusionTimer.Value != 0 || HallucinationsTimer.Value != 0 || !monster.IsVisible || StunTimer.Value != 0) && (GridPassable(newY, newX) || canPassWalls))
            {
                // Wake up the monster, and track it
                monster.SleepLevel = 0;
                string monsterName = monster.Name;
                // If we can see it, no need to mention it
                if (monster.IsVisible)
                {
                    HealthTrack(tile.MonsterIndex);
                }
                // If we can't see it then let us push past it and tell us what happened
                else if (GridPassable(MapY.IntValue, MapX.IntValue) || monster.Race.PassWall)
                {
                    MsgPrint($"You push past {monsterName}.");
                    monster.MapY = MapY.IntValue;
                    monster.MapX = MapX.IntValue;
                    Map.Grid[MapY.IntValue][MapX.IntValue].MonsterIndex = tile.MonsterIndex;
                    tile.MonsterIndex = 0;
                    UpdateMonsterVisibility(Map.Grid[MapY.IntValue][MapX.IntValue].MonsterIndex, true);
                }
                // If we couldn't push past it, tell us it was in the way
                else
                {
                    MsgPrint($"{monsterName} is in your way!");
                    EnergyUse = 0;
                    return;
                }
            }
            // If the monster wasn't friendly, attack it
            else
            {
                PlayerAttackMonster(newY, newX);
                return;
            }
        }
        // We didn't attack a monster or get blocked by one, so start testing terrain features
        if (!dontPickup && tile.FeatureType.IsTrap)
        {
            // If we're walking onto a known trap, assume we're trying to disarm it
            DisarmTrap(newY, newX);
            return;
        }
        // If the tile we're moving onto isn't passable then we can't move onto it
        if (!GridPassable(newY, newX) && !canPassWalls)
        {
            Disturb(false);
            // If we can't see it and haven't memories it, tell us what we bumped into
            if (!tile.PlayerMemorized && (BlindnessTimer.Value != 0 || !tile.PlayerLit))
            {
                if (tile.FeatureType.IsRubble)
                {
                    MsgPrint("You feel some rubble blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else if (tile.FeatureType.IsTree)
                {
                    MsgPrint($"You feel a {tile.FeatureType.Description} blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else if (tile.FeatureType.IsPillar)
                {
                    MsgPrint("You feel a pillar blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else if (tile.FeatureType.HasWater)
                {
                    MsgPrint("Your way seems to be blocked by water.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                // If we're moving onto a border, change wilderness location
                else if (tile.FeatureType.IsBorder)
                {
                    if (Wilderness[WildernessY][WildernessX].Town != null)
                    {
                        CurTown = Wilderness[WildernessY][WildernessX].Town;
                        MsgPrint($"You stumble out of {CurTown.Name}.");
                    }
                    if (newY == 0)
                    {
                        MapY.IntValue = CurHgt - 2;
                        WildernessY--;
                    }
                    if (newY == CurHgt - 1)
                    {
                        MapY.IntValue = 1;
                        WildernessY++;
                    }
                    if (newX == 0)
                    {
                        MapX.IntValue = CurWid - 2;
                        WildernessX--;
                    }
                    if (newX == CurWid - 1)
                    {
                        MapX.IntValue = 1;
                        WildernessX++;
                    }
                    if (Wilderness[WildernessY][WildernessX].Town != null)
                    {
                        CurTown = Wilderness[WildernessY][WildernessX].Town;
                        MsgPrint($"You stumble into {CurTown.Name}.");
                        CurTown.Visited = true;
                    }
                    // We'll need a new level
                    NewLevelFlag = true;
                    CameFrom = LevelStartEnum.StartWalk;
                    DoCmdSaveGame(true);
                }
                else if (tile.FeatureType.IsVisibleDoor)
                {
                    MsgPrint("You feel a closed door blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else
                {
                    MsgPrint($"You feel a {tile.FeatureType.Description} blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
            }
            // We can see it, so give a different message
            else
            {
                if (tile.FeatureType.IsRubble)
                {
                    MsgPrint("There is rubble blocking your way.");
                    if (!(ConfusionTimer.Value != 0 || StunTimer.Value != 0 || HallucinationsTimer.Value != 0))
                    {
                        EnergyUse = 0;
                    }
                }
                else if (tile.FeatureType.IsTree)
                {
                    MsgPrint($"There is a {tile.FeatureType.Description} blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else if (tile.FeatureType.IsPillar)
                {
                    MsgPrint("There is a pillar blocking your way.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                else if (tile.FeatureType.HasWater)
                {
                    MsgPrint("You cannot swim.");
                    tile.PlayerMemorized = true;
                    ConsoleView.RefreshMapLocation(newY, newX);
                }
                // Again, walking onto a border means a change of wilderness grid
                else if (tile.FeatureType.IsBorder)
                {
                    if (Wilderness[WildernessY][WildernessX].Town != null)
                    {
                        CurTown = Wilderness[WildernessY][WildernessX].Town;
                        MsgPrint($"You leave {CurTown.Name}.");
                        CurTown.Visited = true;
                    }
                    if (newY == 0)
                    {
                        MapY.IntValue = CurHgt - 2;
                        WildernessY--;
                    }
                    if (newY == CurHgt - 1)
                    {
                        MapY.IntValue = 1;
                        WildernessY++;
                    }
                    if (newX == 0)
                    {
                        MapX.IntValue = CurWid - 2;
                        WildernessX--;
                    }
                    if (newX == CurWid - 1)
                    {
                        MapX.IntValue = 1;
                        WildernessX++;
                    }
                    if (Wilderness[WildernessY][WildernessX].Town != null)
                    {
                        CurTown = Wilderness[WildernessY][WildernessX].Town;
                        MsgPrint($"You enter {CurTown.Name}.");
                        CurTown.Visited = true;
                    }
                    // We need a new map
                    NewLevelFlag = true;
                    CameFrom = LevelStartEnum.StartWalk;
                    DoCmdSaveGame(true);
                }
                // If we can see that we're walking into a closed door, try to open it
                else if (tile.FeatureType.IsVisibleDoor)
                {
                    if (OpenDoor(newY, newX))
                    {
                        return;
                    }
                }
                else
                {
                    MsgPrint($"There is a {tile.FeatureType.Description} blocking your way.");
                    if (!(ConfusionTimer.Value != 0 || StunTimer.Value != 0 || HallucinationsTimer.Value != 0))
                    {
                        EnergyUse = 0;
                    }
                }
            }
            PlaySound(SoundEffectEnum.BumpWall);
            return;
        }
        // Assuming we didn't bump into anything, maybe we can actually move
        bool oldTrapsDetected = Map.Grid[MapY.IntValue][MapX.IntValue].TrapsDetected;
        bool newTrapsDetected = Map.Grid[newY][newX].TrapsDetected;
        // If we're moving into or out of an area where we've detected traps, remember to redraw
        // the notification
        if (oldTrapsDetected != newTrapsDetected)
        {
        }
        // If we're leaving an area where we've detected traps at a run, then stop running
        if (Running != 0 && oldTrapsDetected && !newTrapsDetected)
        {
            if (!(ConfusionTimer.Value != 0 || StunTimer.Value != 0 || HallucinationsTimer.Value != 0))
            {
                EnergyUse = 0;
            }
            Disturb(false);
            return;
        }
        // We've run out of things that could prevent us moving, so do the move
        int oldY = MapY.IntValue;
        int oldX = MapX.IntValue;
        MapY.IntValue = newY;
        MapX.IntValue = newX;
        // Redraw our old and new locations
        ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
        ConsoleView.RefreshMapLocation(oldY, oldX);
        // Recenter the screen if we have to
        RecenterScreenAroundPlayer();
        // We'll need to update and redraw various things
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateDistancesFlaggedAction)).Set();
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        // If we're not actively searching, then have a chance of doing it passively
        if (SkillSearchFrequency >= 50 || 0 == RandomLessThan(50 - SkillSearchFrequency))
        {
            RunScript(nameof(SearchScript));
        }        
        else if (IsSearching) // If we're actively searching then always do it
        {
            RunScript(nameof(SearchScript));
        }
        // Pick up an object on our tile if there is one
        StepOnGrid(!dontPickup);
        // If we've just entered a shop tile, then enter the actual shop
        if (tile.FeatureType.IsShop)
        {
            Disturb(false);
            _artificialKeyBuffer += SingletonRepository.Get<GameCommand>(nameof(EnterStoreGameCommand)).KeyChar;
        }
        // If we've just stepped on an unknown trap then activate it
        else if (tile.FeatureType.IsInvisibleTrap)
        {
            Disturb(false);
            MsgPrint("You found a trap!");
            PickTrap(MapY.IntValue, MapX.IntValue);
            StepOnTrap();
        }
        // If it's a trap we couldn't (or didn't) disarm, then activate it
        else if (tile.FeatureType.IsTrap)
        {
            Disturb(false);
            StepOnTrap();
        }
    }

    /// <summary>
    /// Step onto a grid with an item, possibly picking it up and possibly stomping on it
    /// </summary>
    /// <param name="pickup">
    /// True if we should pick up the object, or false if we should leave it where it is
    /// </param>
    public void StepOnGrid(bool pickup)
    {
        GridTile tile = Map.Grid[MapY.IntValue][MapX.IntValue];
        foreach (Item item in tile.Items.ToArray()) // We need a ToArray to prevent the collection from being modified error
        {
            string itemName = item.GetFullDescription(true);
            Disturb(false);

            // We always pick up gold.
            if (item.GoldPieces > 0)
            {
                MsgPrint($"You collect {item.GoldPieces} gold pieces worth of {itemName}.");
                Gold.IntValue += item.GoldPieces;
                DeleteObject(item);
            }
            else
            {
                // If we're not interested, simply say that we see it
                if (!pickup)
                {
                    MsgPrint($"You see {itemName}.");
                }
                // If it's worthless, stomp on it
                else if (item.Stompable)
                {
                    DeleteObject(item);
                    MsgPrint($"You stomp on {itemName}.");
                }
                // If we can't carry the item, let us know
                else if (!item.CanCarry())
                {
                    MsgPrint($"You have no room for {itemName}.");
                }
                else
                {
                    // Actually pick up the item
                    Item? inventoryItem = InventoryCarry(item.Clone(item.StackCount));
                    if (inventoryItem == null)
                    {
                        throw new Exception("Unable to locate picked up item in the inventory."); // TODO: Clean this up
                    }
                    itemName = inventoryItem.GetFullDescription(true);
                    MsgPrint($"You have {itemName} ({inventoryItem.Label}).");
                    DeleteObject(item);
                }
            }
        }
    }

    /// <summary>
    /// Have the player attack a monster
    /// </summary>
    /// <param name="y"> The y coordinate of the location being attacked </param>
    /// <param name="x"> The x coordinate of the location being attacked </param>
    public void PlayerAttackMonster(int y, int x)
    {
        GridTile tile = Map.Grid[y][x];
        Monster monster = Monsters[tile.MonsterIndex];
        MonsterRace race = monster.Race;
        bool fear = false;
        bool backstab = false;
        bool stabFleeing = false;
        bool doQuake = false;
        const bool drainMsg = true;
        int drainResult = 0;
        const int drainLeft = _maxVampiricDrain;
        bool noExtra = false;
        Disturb(false);
        // If we're a rogue then we can backstab monsters
        if (BaseCharacterClass.CanBackstab)
        {
            if (monster.SleepLevel != 0 && monster.IsVisible)
            {
                backstab = true;
            }
            else if (monster.FearLevel != 0 && monster.IsVisible)
            {
                stabFleeing = true;
            }
        }
        Disturb(true);
        // Being attacked always wakes a monster
        monster.SleepLevel = 0;
        string monsterName = monster.Name;
        // If we can see the monster, track its health
        if (monster.IsVisible)
        {
            HealthTrack(tile.MonsterIndex);
        }
        // if the monster is our friend and we're not confused, we can avoid hitting it
        if (monster.IsPet && !(StunTimer.Value != 0 || ConfusionTimer.Value != 0 || HallucinationsTimer.Value != 0 || !monster.IsVisible))
        {
            MsgPrint($"You stop to avoid hitting {monsterName}.");
            return;
        }
        // Can't attack if we're afraid
        if (FearTimer.Value != 0)
        {
            MsgPrint(monster.IsVisible ? $"You are too afraid to attack {monsterName}!" : "There is something scary in your way!");
            return;
        }
        int bonus = Bonuses.AttackBonus;
        bool chaosEffect = false;
        Item? meleeItem = GetInventoryItem(InventorySlotEnum.MeleeWeapon);
        if (meleeItem != null)
        {
            bonus += meleeItem.EffectivePropertySet.BonusHits;
        }
        int chance = SkillMelee + (bonus * Constants.BthPlusAdj);
        // Attacking uses a full turn
        EnergyUse = 100;
        int num = 0;
        // We have a number of attacks per round
        while (num++ < MeleeAttacksPerRound)
        {
            // Check if we hit
            if (PlayerCheckHitOnMonster(chance, race.ArmorClass, monster.IsVisible))
            {
                PlaySound(SoundEffectEnum.MeleeHit);

                // Tell the player they hit it with the appropriate message
                if (!(backstab || stabFleeing))
                {
                    if (!IsMartialArtistAndNotWieldingAMeleeWeapon())
                    {
                        MsgPrint($"You hit {monsterName}.");
                    }
                }
                else if (backstab)
                {
                    MsgPrint(
                        $"You cruelly stab the helpless, sleeping {monster.Race.FriendlyName}!");
                }
                else
                {
                    MsgPrint(
                        $"You backstab the fleeing {monster.Race.FriendlyName}!");
                }
                // Default to 1 damage for an unarmed hit
                int totalDamage = 1;

                if (meleeItem != null)
                {
                    // Get our weapon's flags to see if we need to do anything special
                    chaosEffect = meleeItem.EffectivePropertySet.Chaotic && DieRoll(2) == 1;
                    if (meleeItem.EffectivePropertySet.Vampiric || (chaosEffect && DieRoll(5) < 3))
                    {
                        // Vampiric overrides chaotic
                        chaosEffect = false;
                        if (!(race.Undead || race.Nonliving))
                        {
                            drainResult = monster.Health;
                        }
                        else
                        {
                            drainResult = 0;
                        }
                    }
                }
                // If we're a martial artist then we have special attacks
                if (IsMartialArtistAndNotWieldingAMeleeWeapon())
                {
                    int times;
                    MartialArtsAttack martialArtsAttack = SingletonRepository.Get<MartialArtsAttack>().Single(_martialArtsAttack => _martialArtsAttack.IsDefault);
                    MartialArtsAttack oldMartialArtsAttack = martialArtsAttack;
                    // Monsters of various types resist being stunned by martial arts
                    int resistStun = 0;
                    if (race.Unique)
                    {
                        resistStun += 88;
                    }
                    if (race.ImmuneConfusion)
                    {
                        resistStun += 44;
                    }
                    if (race.ImmuneSleep)
                    {
                        resistStun += 44;
                    }
                    if (race.Undead || race.Nonliving)
                    {
                        resistStun += 88;
                    }
                    // Have a number of attempts to choose a martial arts attack
                    for (times = 0; times < (ExperienceLevel.IntValue < 7 ? 1 : ExperienceLevel.IntValue / 7); times++)
                    {
                        // Choose an attack randomly, but reject it and re-choose if it's too
                        // high level or we fail a chance roll
                        do
                        {
                            martialArtsAttack = SingletonRepository.ToWeightedRandom<MartialArtsAttack>().ChooseOrDefault();
                        } while (martialArtsAttack.MinLevel > ExperienceLevel.IntValue || DieRoll(ExperienceLevel.IntValue) < martialArtsAttack.Chance);
                        // We've chosen an attack, use it if it's better than the previous
                        // choice (unless we're stunned or confused in which case we're stuck
                        // with the weakest attack type
                        if (martialArtsAttack.MinLevel > oldMartialArtsAttack.MinLevel && !(StunTimer.Value != 0 || ConfusionTimer.Value != 0))
                        {
                            oldMartialArtsAttack = martialArtsAttack;
                        }
                        else
                        {
                            martialArtsAttack = oldMartialArtsAttack;
                        }
                    }

                    totalDamage = martialArtsAttack.MartialArtsAttackEffect.Execute(monster, martialArtsAttack, resistStun);
                }
                // We have a weapon
                else if (meleeItem != null)
                {
                    // Roll damage for the weapon
                    totalDamage = DiceRoll(meleeItem.EffectivePropertySet.DamageDice, meleeItem.EffectivePropertySet.DiceSides);
                    totalDamage = meleeItem.AdjustDamageForMonsterType(totalDamage, monster);
                    // Extra damage for backstabbing
                    if (backstab)
                    {
                        totalDamage *= 3 + (ExperienceLevel.IntValue / 40);
                    }
                    else if (stabFleeing)
                    {
                        totalDamage = 3 * totalDamage / 2;
                    }
                    // We might need to do an earthquake
                    if ((HasQuakeWeapon && (totalDamage > 50 || DieRoll(7) == 1)) || (chaosEffect && DieRoll(250) == 1))
                    {
                        doQuake = true;
                        chaosEffect = false;
                    }
                    // Check if we did a critical
                    totalDamage = PlayerCriticalMelee(meleeItem.EffectivePropertySet.Weight, meleeItem.EffectivePropertySet.BonusHits, totalDamage);

                    // Vorpal weapons have a chance of a deep cut.
                    bool vorpalCut = DieRoll(meleeItem.EffectivePropertySet.Vorpal1InChance) == 1;

                    // If we did a vorpal cut, do extra damage
                    if (vorpalCut)
                    {
                        int stepK = totalDamage;
                        string message = meleeItem.EffectivePropertySet.Vorpal1InChance == 0 ? $"Your weapon cuts deep into {monsterName}!" : "Your Vorpal Blade goes snicker-snack!";
                        MsgPrint(message);
                        do
                        {
                            totalDamage += stepK;
                        } while (meleeItem.EffectivePropertySet.VorpalExtraAttacks1InChance >= 1 && DieRoll(meleeItem.EffectivePropertySet.VorpalExtraAttacks1InChance) == 1);
                    }
                    // Add bonus damage for the weapon
                    totalDamage += meleeItem.EffectivePropertySet.BonusDamage;
                }
                // Add bonus damage for strength etc.
                totalDamage += Bonuses.DamageBonus;
                // Can't do negative damage
                if (totalDamage < 0)
                {
                    totalDamage = 0;
                }
                // Apply damage to the monster
                if (DamageMonster(tile.MonsterIndex, totalDamage, out fear, ""))
                {
                    // Can't have any more attacks because the monster's dead
                    noExtra = true;
                    break;
                }
                // Hitting a friend gets it angry
                if (monster.IsPet)
                {
                    MsgPrint($"{monsterName} gets angry!");
                    monster.IsPet = false;
                }
                // The monster might have an aura that hurts the player
                TouchZapPlayer(monster);
                // If we drain health, do so
                if (drainResult != 0)
                {
                    // drainResult was set to the monsters health before we hit it, so
                    // subtracting the monster's new health lets us know how much damage we've done
                    drainResult -= monster.Health;
                    if (drainResult > 0)
                    {
                        // Draining heals us
                        int drainHeal = DiceRoll(4, drainResult / 6);
                        // We have a maximum drain per round to prevent it from getting out of
                        // hand if we have multiple attacks
                        if (drainLeft != 0)
                        {
                            if (drainHeal >= drainLeft)
                            {
                                drainHeal = drainLeft;
                            }
                            if (drainMsg)
                            {
                                MsgPrint($"Your weapon drains life from {monsterName}!");
                            }
                            RestoreHealth(drainHeal);
                        }
                    }
                }
                // We might have a confusing touch (or have this effect from a chaos blade)
                if (HasConfusingTouch || (chaosEffect && DieRoll(10) != 1))
                {
                    // If it wasn't from a chaos blade, cancel the confusing touch and let us know
                    HasConfusingTouch = false;
                    if (!chaosEffect)
                    {
                        MsgPrint("Your hands stop glowing.");
                    }
                    // Some monsters are immune
                    if (race.ImmuneConfusion)
                    {
                        if (monster.IsVisible)
                        {
                            race.Knowledge.Characteristics.ImmuneConfusion = true;
                        }
                        MsgPrint($"{monsterName} is unaffected.");
                    }
                    // Even if not immune, the monster might resist
                    else if (RandomLessThan(100) < race.Level)
                    {
                        MsgPrint($"{monsterName} is unaffected.");
                    }
                    // It didn't resist, so it's confused
                    else
                    {
                        MsgPrint($"{monsterName} appears confused.");
                        monster.ConfusionLevel += 10 + (RandomLessThan(ExperienceLevel.IntValue) / 5);
                    }
                }
                // A chaos blade might teleport the monster away
                else if (chaosEffect && DieRoll(2) == 1)
                {
                    MsgPrint($"{monsterName} disappears!");
                    monster.TeleportAway(50);
                    // Can't have any more attacks because the monster isn't here any more
                    noExtra = true;
                    break;
                }
                // a chaos blade might polymorph the monsterf
                else if (chaosEffect && GridPassable(y, x) && DieRoll(90) > race.Level)
                {
                    // Can't polymorph a unique or a guardian
                    if (!(race.Unique || race.BreatheChaos ||
                          race.Guardian))
                    {
                        int newRaceIndex = PolymorphMonsterRace(monster.Race);
                        if (newRaceIndex != monster.Race.Index)
                        {
                            MsgPrint($"{monsterName} changes!");
                            DeleteMonsterByIndex(tile.MonsterIndex, true);
                            MonsterRace newRace = SingletonRepository.Get<MonsterRace>(newRaceIndex);
                            PlaceMonsterAux(y, x, newRace, false, false, false);
                            monster = Monsters[tile.MonsterIndex];
                            monsterName = monster.Name;
                            fear = false;
                        }
                    }
                    // Monster was immune to polymorph
                    else
                    {
                        MsgPrint($"{monsterName} is unaffected.");
                    }
                }
            }
            // We missed
            else
            {
                PlaySound(SoundEffectEnum.Miss);
                MsgPrint($"You miss {monsterName}.");
            }
        }
        // Only make extra attacks if the monster is still there
        foreach (Mutation naturalAttack in NaturalAttacks)
        {
            if (!noExtra && tile.MonsterIndex != 0)
            {
                PlayerNaturalAttackOnMonster(tile.MonsterIndex, naturalAttack, out fear, out noExtra);
            }
        }
        if (fear && monster.IsVisible && !noExtra)
        {
            PlaySound(SoundEffectEnum.MonsterFlees);
            MsgPrint($"{monsterName} flees in terror!");
        }
        if (doQuake)
        {
            Earthquake(MapY.IntValue, MapX.IntValue, 10);
        }
    }

    /// <summary>
    /// Check whether a ranged attack by the player hits a monster
    /// </summary>
    /// <param name="attackBonus"> The player's attack bonus </param>
    /// <param name="armorClass"> The monster's armor class </param>
    /// <param name="monsterIsVisible"> Whether or not the monster is visible </param>
    /// <returns> True if the player hit the monster, false otherwise </returns>
    public bool PlayerCheckRangedHitOnMonster(int attackBonus, int armorClass, bool monsterIsVisible)
    {
        int k = RandomLessThan(100);
        // Always a 5% chance to hit and a 5% chance to miss
        if (k < 10)
        {
            return k < 5;
        }
        // If we have no chance of hitting don't bother checking
        if (attackBonus <= 0)
        {
            return false;
        }
        // Invisible monsters are hard to hit
        if (!monsterIsVisible)
        {
            attackBonus = (attackBonus + 1) / 2;
        }
        // Return the hit or miss
        return RandomLessThan(attackBonus) >= armorClass * 3 / 4;
    }

    /// <summary>
    /// Work out whether the player's missile attack was a critical hit
    /// </summary>
    /// <param name="weight"> The weight of the player's weapon </param>
    /// <param name="plus"> The magical plusses on the weapon </param>
    /// <param name="damage"> The damage done </param>
    /// <returns> The modified damage based on the level of critical </returns>
    public int PlayerCriticalRanged(int weight, int plus, int damage)
    {
        // Chance of a critical is based on weight, level, and plusses
        int i = weight + ((Bonuses.AttackBonus + plus) * 4) + (ExperienceLevel.IntValue * 2);
        if (DieRoll(5000) <= i)
        {
            int k = weight + DieRoll(500);
            if (k < 500)
            {
                MsgPrint("It was a good hit!");
                damage = (2 * damage) + 5;
            }
            else if (k < 1000)
            {
                MsgPrint("It was a great hit!");
                damage = (2 * damage) + 10;
            }
            else
            {
                MsgPrint("It was a superb hit!");
                damage = (3 * damage) + 15;
            }
        }
        return damage;
    }

    /// <summary>
    /// Run a single step
    /// </summary>
    /// <param name="direction">
    /// The direction in which we wish to run, or 0 if we are already running
    /// </param>
    public void RunOneStep(int direction)
    {
        // Is this a new run?
        if (direction != 0)
        {
            // Check if we can actually run in that direction
            if (SeeWall(direction, MapY.IntValue, MapX.IntValue))
            {
                MsgPrint("You cannot run in that direction.");
                Disturb(false);
                return;
            }
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
            // Initialise our navigation state
            StartRun(direction);
        }
        else
        {
            // We're already running, so check if we have to stop
            if (NavigateNextStep())
            {
                Disturb(false);
                return;
            }
        }
        // Running has a limit, just in case, but in practice we'll never reach it
        if (--Running <= 0)
        {
            return;
        }
        // We can run, so use a move's worth of energy and actually make the move
        EnergyUse = 100;
        MovePlayer(CurrentRunDirection, false);
    }

    /// <summary>
    /// Returns an spell selected by the player.  If the player doesn't have any spells capable of being selected, false is returned; otherwise the spell selected by the user is returned on the output
    /// parameter.  If the user cancels the selection, a true value is returned and the output spell parameter is set to null.
    /// </summary>
    public bool GetSpell(out Spell? selectedSpell, string prompt, Item spellBook, bool known)
    {
        Spell[] OkaySpells(Item item, bool known)
        {
            List<Spell> okaySpells = new List<Spell>();
            foreach (Spell spell in item.Spells) // TODO: Spells is not nullable
            {
                if (SpellOkay(spell, known))
                {
                    okaySpells.Add(spell);
                }
            }
            return okaySpells.ToArray();
        }

        selectedSpell = null;
        Spell[] okaySpells = OkaySpells(spellBook, known);
        if (okaySpells.Length == 0)
        {
            return false;
        }
        string spellNoun = BaseCharacterClass.SpellNoun;
        ScreenBuffer? savedScreen = null;
        string outVal = $"({spellNoun}s {0.IndexToLetter()}-{(okaySpells.Length - 1).IndexToLetter()}, *=List, ESC=exit) {prompt} which {spellNoun}? ";
        while (selectedSpell == null && GetCom(outVal, out char choice) && !Shutdown)
        {
            if (choice == ' ' || choice == '*' || choice == '?')
            {
                if (savedScreen == null)
                {
                    savedScreen = Screen.Clone();
                    PrintSpells(okaySpells, 1, 20);
                }
                else
                {
                    Screen.Restore(savedScreen);
                    savedScreen = null;
                }
                continue;
            }
            bool ask = char.IsUpper(choice);
            if (ask)
            {
                choice = char.ToLower(choice);
            }
            int i = char.IsLower(choice) ? choice.LetterToNumber() : -1;
            if (i < 0 || i >= okaySpells.Length)
            {
                continue;
            }
            Spell spell = okaySpells[i];
            if (!SpellOkay(spell, known))
            {
                MsgPrint($"You may not {prompt} that {spellNoun}.");
                continue;
            }
            if (ask)
            {
                string tmpVal = $"{prompt} {spell.Name} ({spell.CharacterClassSpell.ManaCost} mana, {spell.FailureChance()}% fail)? ";
                if (!GetCheck(tmpVal))
                {
                    continue;
                }
            }
            selectedSpell = spell;
        }
        if (savedScreen != null)
        {
            Screen.Restore(savedScreen);
        }
        return true;
    }

    public void DoCmdThrow(int damageMultiplier)
    {
        // Get an item to throw
        if (!SelectItem(out Item? item, "Throw which item? ", false, true, true, null))
        {
            MsgPrint("You have nothing to throw.");
            return;
        }
        if (item == null)
        {
            return;
        }
        if (!GetDirectionWithAim(out int dir))
        {
            return;
        }
        // Copy a single item from the item stack as the thrown item
        Item missile = item.TakeFromStack(1);
        if (item.IsInInventory)
        {
            item.ItemDescribe();
        }
        item.ItemOptimize();
        string missileName = missile.GetFullDescription(false);
        ColorEnum missileColor = missile.FlavorColor;
        char missileCharacter = missile.FlavorSymbol.Character;
        // Thrown distance is based on the weight of the missile
        int multiplier = 10 + (2 * (damageMultiplier - 1));
        int divider = missile.EffectivePropertySet.Weight > 10 ? missile.EffectivePropertySet.Weight : 10;
        int throwDistance = (StrengthAbility.StrAttackSpeedComponent + 20) * multiplier / divider;
        if (throwDistance > 10)
        {
            throwDistance = 10;
        }
        // Work out the damage done
        int damage = DiceRoll(missile.EffectivePropertySet.DamageDice, missile.EffectivePropertySet.DiceSides) + missile.EffectivePropertySet.BonusDamage;
        damage *= damageMultiplier;
        int chance = SkillThrowing + (Bonuses.AttackBonus * Constants.BthPlusAdj);
        // Throwing something always uses a full turn, even if you can make multiple missile attacks
        EnergyUse = 100;
        int y = MapY.IntValue;
        int x = MapX.IntValue;
        int targetX = MapX.IntValue + (99 * KeypadDirectionXOffset[dir]); // TODO: Fix the 99*
        int targetY = MapY.IntValue + (99 * KeypadDirectionYOffset[dir]); // TODO: Fix the 99*

        if (dir == 5 && TargetWho != null)
        {
            GridCoordinate? target = TargetWho.GetTargetLocation();
            if (target != null)
            {
                targetX = target.X;
                targetY = target.Y;
            }
        }

        HandleStuff();
        int newY = MapY.IntValue;
        int newX = MapX.IntValue;
        bool hitBody = false;
        // Send the thrown object in the right direction one square at a time
        for (int curDis = 0; curDis <= throwDistance;)
        {
            // If we reach our limit, stop the object moving
            if (y == targetY && x == targetX)
            {
                break;
            }
            MoveOneStepTowards(out newY, out newX, y, x, MapY.IntValue, MapX.IntValue, targetY, targetX);
            // If we hit a wall or something stop moving
            if (!GridPassable(newY, newX))
            {
                break;
            }
            curDis++;
            x = newX;
            y = newY;
            const int msec = Constants.DelayFactorInMilliseconds;
            // If we can see, display the thrown item with a suitable delay
            if (PanelContains(y, x) && PlayerCanSeeBold(y, x))
            {
                ConsoleView.PutCharAtMapLocation(missileCharacter, missileColor, y, x);
                ConsoleView.MoveCursorTo(y, x);
                UpdateScreen();
                Pause(msec);
                ConsoleView.RefreshMapLocation(y, x);
                UpdateScreen();
            }
            else
            {
                // Delay even if we don't see it, so it doesn't look weird when it passes behind something
                Pause(msec);
            }
            // If there's a monster in the way, we might hit it regardless of whether or not it
            // is our intended target
            if (Map.Grid[y][x].MonsterIndex != 0)
            {
                GridTile tile = Map.Grid[y][x];
                Monster monster = Monsters[tile.MonsterIndex];
                MonsterRace race = monster.Race;
                bool visible = monster.IsVisible;
                hitBody = true;
                // See if it actually hit the monster
                if (PlayerCheckRangedHitOnMonster(chance - curDis, race.ArmorClass, monster.IsVisible))
                {
                    string noteDies = " dies.";
                    if (race.Demon || race.Undead ||
                        race.Cthuloid || race.Stupid ||
                        "Evg".Contains(race.Symbol.Character.ToString()))
                    {
                        noteDies = " is destroyed.";
                    }
                    // Let the player know what happened
                    if (!visible)
                    {
                        MsgPrint($"The {missileName} finds a mark.");
                    }
                    else
                    {
                        string mName = monster.Name;
                        MsgPrint($"The {missileName} hits {mName}.");
                        if (monster.IsVisible)
                        {
                            HealthTrack(tile.MonsterIndex);
                        }
                    }
                    // Adjust the damage for the particular monster type
                    damage = missile.AdjustDamageForMonsterType(damage, monster);
                    damage = PlayerCriticalRanged(missile.EffectivePropertySet.Weight, missile.EffectivePropertySet.BonusHits, damage);
                    if (damage < 0)
                    {
                        damage = 0;
                    }
                    if (DamageMonster(tile.MonsterIndex, damage, out bool fear, noteDies))
                    {
                        // The monster is dead, so don't add further statuses or messages
                    }
                    else
                    {
                        // Let the player know what happens to the monster
                        MessagePain(monster, damage);
                        if (monster.IsPet && missile.QuaffTuple == null)
                        {
                            string mName = monster.Name;
                            MsgPrint($"{mName} gets angry!");
                            monster.IsPet = false;
                        }
                        if (fear && monster.IsVisible)
                        {
                            PlaySound(SoundEffectEnum.MonsterFlees);
                            string mName = monster.Name;
                            MsgPrint($"{mName} flees in terror!");
                        }
                    }
                }
                break;
            }
        }
        // There's a chance of breakage if we hit a creature
        ProbabilityExpression? chanceToBreak = hitBody ? missile.BreakageChanceProbability : null;

        // If we hit with a potion, the potion might affect the creature
        if (missile.QuaffTuple != null)
        {
            if (hitBody || !GridPassable(newY, newX) || chanceToBreak.Test())
            {
                MsgPrint($"The {missileName} shatters!");
                if (missile.Smash(1, y, x))
                {
                    if (Map.Grid[y][x].MonsterIndex != 0 && Monsters[Map.Grid[y][x].MonsterIndex].IsPet)
                    {
                        string mName = Monsters[Map.Grid[y][x].MonsterIndex].Name;
                        MsgPrint($"{mName} gets angry!");
                        Monsters[Map.Grid[y][x].MonsterIndex].IsPet = false;
                    }
                }
                return;
            }
            chanceToBreak = null;
        }

        // Drop the item on the floor
        DropNear(missile, chanceToBreak, y, x);
    }

    public void RunScript(string scriptName)
    {
        // Get the script from the singleton repository.
        IScript castedScript = SingletonRepository.Get<IScript>(scriptName);
        castedScript.ExecuteScript();
    }

    public IdentifiedResultEnum RunIdentifiedScriptDirection(string scriptName, int dir)
    {
        IAimWandScript script = SingletonRepository.Get<IAimWandScript>(scriptName);
        return script.ExecuteAimWandScript(dir);
    }

    public void RunScriptBool(string scriptName, bool value)
    {
        // Get the script from the singleton repository.
        IScriptBool castedScript = SingletonRepository.Get<IScriptBool>(scriptName);
        castedScript.ExecuteScriptBool(value);
    }

    public bool RunIdentifiedScript(string scriptName) // TODO: Return IdentifiedResultEnum
    {
        // Get the script from the singleton repository.
        IEatOrQuaffScript castedScript = SingletonRepository.Get<IEatOrQuaffScript>(scriptName);
        return castedScript.ExecuteEatOrQuaffScript() == IdentifiedResultEnum.True; // TODO: Fix this
    }

    /// <summary>
    /// Summon an item to the player via telekinesis
    /// </summary>
    /// <param name="dir"> The direction to check for items </param>
    /// <param name="maxWeight"> The maximum weight we can summon </param>
    /// <param name="requireLos"> Whether or not we require line of sight to the item </param>
    public void SummonItem(int dir, int maxWeight, bool requireLos)
    {
        int targetY;
        int targetX;
        GridTile tile;
        // Can't summon something if we're already standing on something
        if (Map.Grid[MapY.IntValue][MapX.IntValue].Items.Count > 0)
        {
            MsgPrint("You can't fetch when you're already standing on something.");
            return;
        }
        // If we didn't have a direction, we might have an existing target
        if (dir == 5)
        {
            if (TargetWho == null)
            {
                // This direction is invalid for a summon and there is no target.
                return;
            }

            GridCoordinate? target = TargetWho.GetTargetLocation();
            if (target == null)
            {
                // This direction is invalid for a summon and there is no target.
                return;
            }

            targetX = target.X;
            targetY = target.Y;
            // Check the range
            if (Distance(MapY.IntValue, MapX.IntValue, targetY, targetX) > Constants.MaxRange)
            {
                MsgPrint("You can't fetch something that far away!");
                return;
            }
            // Check the line of sight if needed
            tile = Map.Grid[targetY][targetX];
            if (requireLos && !GridTileIsVisible(targetY, targetX))
            {
                MsgPrint("You have no direct line of sight to that location.");
                return;
            }
        }
        else
        {
            // We have a direction, so move along it until we find an item
            targetY = MapY.IntValue;
            targetX = MapX.IntValue;
            do
            {
                targetY += KeypadDirectionYOffset[dir];
                targetX += KeypadDirectionXOffset[dir];
                tile = Map.Grid[targetY][targetX];
                // Stop if we hit max range or we're blocked by something
                if (Distance(MapY.IntValue, MapX.IntValue, targetY, targetX) > Constants.MaxRange || !GridPassable(targetY, targetX))
                {
                    return;
                }
            } while (tile.Items.Count == 0);
        }
        Item item = tile.Items[0]; // TODO: We can only pull the top item?
        // Check the weight of the item
        if (item != null && item.EffectivePropertySet.Weight > maxWeight) // TODO: We are only measuring the weight of the first item?
        {
            MsgPrint("The object is too heavy.");
            return;
        }
        // Remove the entire item stack from the tile and move it to the player's tile
        Map.Grid[MapY.IntValue][MapX.IntValue].Items.Add(item);
        tile.Items.Remove(item);
        item.Y = MapY.IntValue;
        item.X = MapX.IntValue;
        NoteSpot(MapY.IntValue, MapX.IntValue);
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }

    /// <summary>
    /// Tunnel through a grid tile
    /// </summary>
    /// <param name="y"> The y coordinate of the tile to be tunneled through </param>
    /// <param name="x"> The x coordinate of the tile to be tunneled through </param>
    /// <returns>True, if the command should be allowed to be continued; false, if the command succeeded, or is futile.</returns>
    public bool TunnelThroughTile(int y, int x)
    {
        bool more = false;
        // Tunnelling uses an entire turn
        EnergyUse = 100;
        GridTile tile = Map.Grid[y][x];
        // Trees are easy to chop down
        if (tile.FeatureType.IsTree)
        {
            if (SkillDigging > 40 + RandomLessThan(100) && RemoveTileViaTunnelling(y, x))
            {
                MsgPrint($"You have chopped down the {tile.FeatureType.Description}.");
            }
            else
            {
                MsgPrint($"You hack away at the {tile.FeatureType.Description}.");
                more = true;
            }
        }
        // Pillars are a bit easier than walls
        else if (tile.FeatureType.IsPillar)
        {
            if (SkillDigging > 40 + RandomLessThan(300) && RemoveTileViaTunnelling(y, x))
            {
                MsgPrint("You have broken down the pillar.");
            }
            else
            {
                MsgPrint("You hack away at the pillar.");
                more = true;
            }
        }
        // We can't tunnel through water
        else if (tile.FeatureType.IsWater)
        {
            MsgPrint("The water fills up your tunnel as quickly as you dig!");
        }
        // Permanent features resist being tunneled through
        else if (tile.FeatureType.IsPermanent)
        {
            MsgPrint($"The {tile.FeatureType.Description} resists your attempts to tunnel through it.");
        }
        // It's a wall, so we tunnel normally
        else if (tile.FeatureType.IsWall)
        {
            if (SkillDigging > 40 + RandomLessThan(1600) && RemoveTileViaTunnelling(y, x))
            {
                MsgPrint("You have finished the tunnel.");
            }
            else
            {
                MsgPrint("You tunnel into the granite wall.");
                more = true;
            }
        }
        // It's a rock seam, so it might have treasure
        else if (tile.FeatureType.IsVein)
        {
            bool okay;
            bool hasValue = false;
            bool isMagma = false;
            if (tile.FeatureType.IsTreasure)
            {
                hasValue = true;
            }
            if (tile.FeatureType.IsMagma)
            {
                isMagma = true;
            }
            // Magma needs a higher tunneling skill than quartz
            if (isMagma)
            {
                okay = SkillDigging > 20 + RandomLessThan(800);
            }
            else
            {
                okay = SkillDigging > 10 + RandomLessThan(400);
            }
            // Do the actual tunnelling
            if (okay && RemoveTileViaTunnelling(y, x))
            {
                if (hasValue)
                {
                    PlaceGold(y, x);
                    MsgPrint("You have found something!");
                }
                else
                {
                    MsgPrint("You have finished the tunnel.");
                }
            }
            // Tunnelling failed, so let us know
            else if (isMagma)
            {
                MsgPrint("You tunnel into the magma vein.");
                more = true;
            }
            else
            {
                MsgPrint("You tunnel into the quartz vein.");
                more = true;
            }
        }
        // Rubble is easy to tunnel through
        else if (tile.FeatureType.IsRubble)
        {
            if (SkillDigging > RandomLessThan(200) && RemoveTileViaTunnelling(y, x))
            {
                MsgPrint("You have removed the rubble.");
                // 10% chance of finding something
                if (RandomLessThan(100) < 10)
                {
                    PlaceObject(Difficulty, y, x, false, false);
                    if (PlayerCanSeeBold(y, x))
                    {
                        MsgPrint("You have found something!");
                    }
                }
            }
            else
            {
                MsgPrint("You dig in the rubble.");
                more = true;
            }
        }
        // We don't recognise what we're tunnelling into, so just assume it's permanent
        else
        {
            MsgPrint($"The {tile.FeatureType.Description} resists your attempts to tunnel through it.");
            more = true;
            RunScript(nameof(SearchScript));
        }
        // If we successfully made the tunnel,
        if (!GridPassable(y, x))
        {
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        }
        if (!more)
        {
            PlaySound(SoundEffectEnum.Dig);
        }
        return more;
    }

    /// <summary>
    /// Open a door at a given location
    /// </summary>
    /// <param name="y"> The y coordinate of the door tile </param>
    /// <param name="x"> The x coordinate of the door tile </param>
    /// <returns> True if we opened it, false otherwise </returns>
    public bool OpenDoor(int y, int x)
    {
        GridTile tile = Map.Grid[y][x];

        // If it's jammed we'll need to bash it
        if (tile.FeatureType.IsJammedClosedDoor)
        {
            MsgPrint("The door appears to be stuck.");
        }
        // Most doors are locked, so try to pick the lock
        else if (tile.FeatureType.IsClosedDoor && tile.FeatureType.LockLevel == 0)
        {
            int skill = SkillDisarmTraps;
            // Lockpicking is hard in the dark
            if (BlindnessTimer.Value != 0 || NoLight())
            {
                skill /= 10;
            }
            // Lockpicking is hard when you're confused
            if (ConfusionTimer.Value != 0 || HallucinationsTimer.Value != 0)
            {
                skill /= 10;
            }
            int chance = tile.FeatureType.LockLevel;
            chance = skill - (chance * 4);
            if (chance < 2)
            {
                chance = 2;
            }
            // See if we succeed
            if (RandomLessThan(100) < chance)
            {
                MsgPrint("You have picked the lock.");
                CaveSetFeat(y, x, SingletonRepository.Get<Tile>(nameof(OpenDoorTile)));
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
                PlaySound(SoundEffectEnum.LockpickSuccess);
                GainExperience(1);
            }
            // If we failed, simply let us know
            else
            {
                MsgPrint("You failed to pick the lock.");
                return true;
            }
        }
        // It wasn't locked, so simply open it
        else
        {
            CaveSetFeat(y, x, SingletonRepository.Get<Tile>(nameof(OpenDoorTile)));
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
            PlaySound(SoundEffectEnum.OpenDoor);
        }
        return false;
    }

    /// <summary>
    /// Determine if a player's attack hits a monster
    /// </summary>
    /// <param name="power"> The strength of the attack </param>
    /// <param name="armorClass"> The monster's armor class </param>
    /// <param name="isVisible"> Whether or not the monster is visible </param>
    /// <returns> True if the attack hit, false if not </returns>
    private bool PlayerCheckHitOnMonster(int power, int armorClass, bool isVisible)
    {
        // Always have a 5% chance to hit or miss
        int roll = RandomLessThan(100);
        if (roll < 10)
        {
            return roll < 5;
        }
        if (power <= 0)
        {
            return false;
        }
        // It's hard to hit invisible monsters
        if (!isVisible)
        {
            power = (power + 1) / 2;
        }
        // Work out whether we hit or not
        return RandomLessThan(power) >= armorClass * 3 / 4;
    }

    /// <summary>
    /// Work out the level of critical hit the player did in melee
    /// </summary>
    /// <param name="weight"> The weight of the player's weapon </param>
    /// <param name="plus"> The bonuses to hit the player has </param>
    /// <param name="damage"> The amount of base damage that was done </param>
    /// <returns> The damage total modified for a critical hit </returns>
    public int PlayerCriticalMelee(int weight, int plus, int damage)
    {
        int i = weight + ((Bonuses.AttackBonus + plus) * 5) + (ExperienceLevel.IntValue * 3);
        if (DieRoll(5000) <= i)
        {
            int k = weight + DieRoll(650);
            if (k < 400)
            {
                MsgPrint("It was a good hit!");
                damage = (2 * damage) + 5;
            }
            else if (k < 700)
            {
                MsgPrint("It was a great hit!");
                damage = (2 * damage) + 10;
            }
            else if (k < 900)
            {
                MsgPrint("It was a superb hit!");
                damage = (3 * damage) + 15;
            }
            else if (k < 1300)
            {
                MsgPrint("It was a *GREAT* hit!");
                damage = (3 * damage) + 20;
            }
            else
            {
                MsgPrint("It was a *SUPERB* hit!");
                damage = (7 * damage / 2) + 25;
            }
        }
        return damage;
    }

    /// <summary>
    /// Resolve a natural attack the player has from a mutation
    /// </summary>
    /// <param name="monsterIndex"> The monster being attacked </param>
    /// <param name="mutation"> The mutation being used to attack </param>
    /// <param name="fear"> Whether or not the monster is scared by the attack </param>
    /// <param name="monsterDies"> Whether or not the monster is killed by the attack </param>
    private void PlayerNaturalAttackOnMonster(int monsterIndex, Mutation mutation, out bool fear, out bool monsterDies)
    {
        fear = false;
        monsterDies = false;
        Monster monster = Monsters[monsterIndex];
        MonsterRace race = monster.Race;
        int damageSides = mutation.DamageDiceSize;
        int damageDice = mutation.DamageDiceNumber;
        int effectiveWeight = mutation.EquivalentWeaponWeight;
        string attackDescription = mutation.AttackDescription;
        string monsterName = monster.Name;
        // See if the player hit the monster
        int bonus = Bonuses.AttackBonus;
        int chance = SkillMelee + (bonus * Constants.BthPlusAdj);
        if (PlayerCheckHitOnMonster(chance, race.ArmorClass, monster.IsVisible))
        {
            // It was a hit, so let the player know
            PlaySound(SoundEffectEnum.MeleeHit);
            MsgPrint($"You hit {monsterName} with your {attackDescription}.");
            // Roll the damage, with possible critical damage
            int damage = DiceRoll(damageDice, damageSides);
            damage = PlayerCriticalMelee(effectiveWeight, Bonuses.AttackBonus, damage);
            damage += Bonuses.DamageBonus;
            // Can't have negative damage
            if (damage < 0)
            {
                damage = 0;
            }
            // If it's a friend, it will get angry
            if (monster.IsPet)
            {
                MsgPrint($"{monsterName} gets angry!");
                monster.IsPet = false;
            }
            // Apply damage of the correct type to the monster
            switch (mutation.MutationAttackType)
            {
                case MutationAttackTypeEnum.Physical:
                    monsterDies = DamageMonster(monsterIndex, damage, out fear, "");
                    break;

                case MutationAttackTypeEnum.Poison:
                    Projectile poisonProjectile = SingletonRepository.Get<Projectile>(nameof(PoisonGasProjectile));
                    poisonProjectile.Fire(0, 0, monster.MapY, monster.MapX, damage, kill : true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false, stop: false);
                    break;

                case MutationAttackTypeEnum.Hellfire:
                    Projectile hellFireProjectile = SingletonRepository.Get<Projectile>(nameof(HellfireProjectile));
                    hellFireProjectile.Fire(0, 0, monster.MapY, monster.MapX, damage, kill: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false, stop: false);
                    break;
            }
            // The monster might hurt when we touch it
            TouchZapPlayer(monster);
        }
        else
        {
            // We missed, so just let us know
            PlaySound(SoundEffectEnum.Miss);
            MsgPrint($"You miss {monsterName}.");
        }
    }

    /// <summary>
    /// Remove a tile by tunnelling through it
    /// </summary>
    /// <param name="y"> The y coordinate of the tile </param>
    /// <param name="x"> The x coordinate of the tile </param>
    /// <returns> True if the tunnel succeeded, false if not </returns>
    private bool RemoveTileViaTunnelling(int y, int x)
    {
        GridTile tile = Map.Grid[y][x];
        // If we can already get through it, we can't tunnel through it
        if (GridPassable(y, x))
        {
            return false;
        }
        // Clear the tile
        tile.PlayerMemorized = false;
        RevertTileToBackground(y, x);
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Handle the player stepping on a trap
    /// </summary>
    private void StepOnTrap()
    {
        Disturb(false);
        GridTile tile = Map.Grid[MapY.IntValue][MapX.IntValue];
        // Check the type of trap
        tile.FeatureType.StepOnScript.ExecuteScript();
    }

    /// <summary>
    /// Check to see if a monster has damaging aura, and if so damage the player with it
    /// </summary>
    /// <param name="monster"> The monster to check </param>
    private void TouchZapPlayer(Monster monster)
    {
        int auraDamage;
        MonsterRace race = monster.Race;
        // If we have a fire aura, apply it
        if (race.FireAura)
        {
            if (!HasFireImmunity)
            {
                auraDamage = DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
                string auraDam = monster.IndefiniteVisibleName;
                MsgPrint("You are suddenly very hot!");
                if (FireResistanceTimer.Value != 0)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                if (HasFireResistance)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                TakeHit(auraDamage, auraDam);
                race.Knowledge.Characteristics.FireAura = true;
                HandleStuff();
            }
        }
        // If we have a lightning aura, apply it
        if (race.LightningAura && !HasLightningImmunity)
        {
            auraDamage = DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
            string auraDam = monster.IndefiniteVisibleName;
            if (LightningResistanceTimer.Value != 0)
            {
                auraDamage = (auraDamage + 2) / 3;
            }
            if (HasLightningResistance)
            {
                auraDamage = (auraDamage + 2) / 3;
            }
            MsgPrint("You get zapped!");
            TakeHit(auraDamage, auraDam);
            race.Knowledge.Characteristics.LightningAura = true;
            HandleStuff();
        }
    }

    /// <summary>
    /// Check to see if a trap hits a player
    /// </summary>
    /// <param name="attackStrength"> The power of the trap's attack </param>
    /// <returns> True if the player was hit, false otherwise </returns>
    public bool TrapCheckHitOnPlayer(int attackStrength)
    {
        // Always a 5% chance to hit and 5% chance to miss
        int k = RandomLessThan(100);
        if (k < 10)
        {
            return k < 5;
        }
        // If negative chance we miss
        if (attackStrength <= 0)
        {
            return false;
        }
        // Roll for the attack
        int armorClass = Bonuses.BaseArmorClass + ArmorClassBonus;
        return DieRoll(attackStrength) > armorClass * 3 / 4;
    }

    // Artificial Intelligence
    /// <summary>
    /// Process all the monsters on the level
    /// </summary>
    public void ProcessAllMonsters()
    {
        // The noise the player is making is based on their stealth score
        uint noise = 1u << (30 - SkillStealth);
        // Go through all the monster slots on the level
        for (int i = MonsterMax - 1; i >= 1; i--)
        {
            Monster monster = Monsters[i];
            // If the monster slot is empty, skip it
            if (monster.Race == null)
            {
                continue;
            }
            // Keep count of how many are our friends
            if (monster.IsPet)
            {
                TotalFriends++;
                TotalFriendLevels += monster.Race.Level;
            }
            // Monsters that have just been spawned don't act in their first turn
            if ((monster.IndividualMonsterFlags & Constants.MflagBorn) != 0)
            {
                monster.IndividualMonsterFlags &= ~Constants.MflagBorn;
                continue;
            }
            // Check the monster's speed to see if it should get a turn
            monster.Energy += ExtractEnergy[monster.Speed];
            if (monster.Energy < 100)
            {
                continue;
            }
            // The monster is going to take a turn, even if it does nothing
            monster.Energy -= 100;
            // If the monster is too far away, don't even bother
            if (monster.DistanceFromPlayer >= 100)
            {
                continue;
            }
            MonsterRace race = monster.Race;
            int monsterX = monster.MapX;
            int monsterY = monster.MapY;
            bool test = false;
            // Check to see if the monster notices the player
            // 1) We're in range
            if (monster.DistanceFromPlayer <= race.NoticeRange)
            {
                test = true;
            }
            // 2) We're aggravating
            else if (monster.DistanceFromPlayer <= Constants.MaxSight && (GridTileIsVisible(monsterY, monsterX) || HasAggravation))
            {
                test = true;
            }
            // 3) We've left scent where the monster is so it can smell us
            else if (Map.Grid[MapY.IntValue][MapX.IntValue].ScentAge == Map.Grid[monsterY][monsterX].ScentAge &&
                     Map.Grid[monsterY][monsterX].ScentStrength < Constants.MonsterFlowDepth &&
                     Map.Grid[monsterY][monsterX].ScentStrength < race.NoticeRange)
            {
                test = true;
            }
            // If it didn't notice us, skip to the next monster
            if (!test)
            {
                continue;
            }
            CurrentlyActingMonster = i;
            // Process the individual monster
            monster.ProcessMonster(noise);
            // If the monster killed the player or sent us to a new level, then stop processing
            if (!Playing || IsDead || NewLevelFlag)
            {
                break;
            }
        }
        CurrentlyActingMonster = 0;
    }

    /// <summary>
    /// Use the same algorithm that we use for missiles to see if we have a clean shot between
    /// two locations, but without actually shooting anything
    /// </summary>
    /// <param name="startY"> The start Y </param>
    /// <param name="startX"> The start X </param>
    /// <param name="targetY"> The Target Y </param>
    /// <param name="targetX"> The Target X </param>
    /// <returns> </returns>
    public bool CleanShot(int startY, int startX, int targetY, int targetX)
    {
        int y = startY;
        int x = startX;
        // Loop from the start to the maximumm range allowed
        for (int distance = 0; distance <= Constants.MaxRange; distance++)
        {
            // If our location is blocked, give up
            if (distance != 0 && !GridPassable(y, x))
            {
                break;
            }
            // If there's another monster in the way and it is friendly, give up
            if (distance != 0 && Map.Grid[y][x].MonsterIndex > 0)
            {
                if (!Monsters[Map.Grid[y][x].MonsterIndex].IsPet)
                {
                    break;
                }
            }
            // If we've reached the target then we have a clean shot
            if (x == targetX && y == targetY)
            {
                return true;
            }
            // Move closer
            MoveOneStepTowards(out y, out x, y, x, startY, startX, targetY, targetX);
        }
        // If we gave up or ran out of distance we don't have a clean shot
        return false;
    }

    /// <summary>
    /// Check whether there's room to summon something next to a location
    /// </summary>
    /// <param name="targetY"> The target Y coordinate </param>
    /// <param name="targetX"> The target X coordinate </param>
    /// <returns> True if there is room, or false if there is not </returns>
    public bool SummonPossible(int targetY, int targetX)
    {
        int y;
        for (y = targetY - 2; y <= targetY + 2; y++)
        {
            int x;
            for (x = targetX - 2; x <= targetX + 2; x++)
            {
                // Can't summon out of bounds
                if (!InBounds(y, x))
                {
                    continue;
                }
                // Can't summon too far away from the target location
                if (Distance(targetY, targetX, y, x) > 2)
                {
                    continue;
                }
                // Can't summon onto an Elder Sign
                if (Map.Grid[y][x].FeatureType.IsElderSignSigil)
                {
                    continue;
                }
                // Can't summon onto a Yellow Sign
                if (Map.Grid[y][x].FeatureType.IsYellowSignSigil)
                {
                    continue;
                }
                // An empty tile in line of sight is acceptable
                if (GridPassableNoCreature(y, x) && Los(targetY, targetX, y, x))
                {
                    return true;
                }
            }
        }
        // We didn't find anywhere and ran out of places to look
        return false;
    }

    /// GUI
    /// <summary>
    /// Prints a 'press any key' message and waits for a key press
    /// </summary>
    /// <param name="row"> The row on which to print the message </param>
    public void AnyKey(int row)
    {
        Screen.PrintLine("", row, 0);
        Screen.Print(ColorEnum.Orange, "[Press any key to continue]", row, 27);
        Inkey();
        Screen.PrintLine("", row, 0);
    }

    public string? AskforAux(string initial, int len)
    {
        string buf = initial;
        char i = '\0';
        int k = 0;
        bool done = false;
        GridCoordinate cursorPosition = Screen.CursorPosition;
        if (len < 1)
        {
            len = 1;
        }
        if (cursorPosition.X < 0 || cursorPosition.X >= Screen.Width)
        {
            cursorPosition = new GridCoordinate(0, cursorPosition.Y);
        }
        if (cursorPosition.X + len > Screen.Width)
        {
            len = Screen.Width - cursorPosition.X;
        }
        Screen.Erase(cursorPosition.Y, cursorPosition.X, len);
        Screen.Print(ColorEnum.Grey, buf, cursorPosition.Y, cursorPosition.X);
        while (!done && !Shutdown)
        {
            Screen.Goto(cursorPosition.Y, cursorPosition.X + k);
            Screen.UpdateScreen();
            i = Inkey();
            switch (i)
            {
                case '\x1b':
                    k = 0;
                    done = true;
                    break;

                case '\n':
                case '\r':
                    k = buf.Length;
                    done = true;
                    break;

                case (char)8:
                    if (k > 0)
                    {
                        k--;
                    }
                    buf = buf.Substring(0, k);
                    break;

                default:
                    if (k < len && (char.IsLetterOrDigit(i) || i == ' ' || char.IsPunctuation(i)))
                    {
                        buf = buf.Substring(0, k) + i;
                        k++;
                    }
                    break;
            }
            Screen.Erase(cursorPosition.Y, cursorPosition.X, len);
            Screen.Print(ColorEnum.Black, buf, cursorPosition.Y, cursorPosition.X);
        }
        if (i == '\x1b')
        {
            return null;
        }
        return buf;
    }

    public bool GetCheck(string prompt)
    {
        int i = 0;
        MsgPrint(null);
        string buf = $"{prompt}[Y/n]";
        Screen.PrintLine(buf, 0, 0);
        while (!Shutdown)
        {
            i = Inkey();
            switch (i)
            {
                case 'y':
                case 'Y':
                case 'n':
                case 'N':
                case 13:
                case 27:
                    break;

                default:
                    continue;
            }
            break;
        }
        MsgClear();
        return i == 'Y' || i == 'y' || i == 13;
    }

    public bool GetCom(string prompt, out char command)
    {
        MsgPrint(null);
        if (prompt.Length > 1)
        {
            prompt = char.ToUpper(prompt[0]) + prompt.Substring(1);
        }
        Screen.PrintLine(prompt, 0, 0);
        command = Inkey();
        MsgClear();
        return command != '\x1b';
    }

    public int GetKeymapDir(char ch)
    {
        int d = 0;
        string act = _keymapAct[Constants.KeymapModeOrig][ch];
        while (true)
        {
            if (act.Length == 0)
            {
                return 0;
            }
            if (act[0] >= '1' && act[0] <= '9')
            {
                break;
            }
            act = act.Remove(0, 1);
        }
        if (!string.IsNullOrEmpty(act))
        {
            if (!int.TryParse(act, out d))
            {
                d = 0;
            }
        }
        return d;
    }

    public int GetQuantity(int max, bool allbydefault)
    {
        int amt;
        if (CommandArgument != 0)
        {
            amt = CommandArgument;
            CommandArgument = 0;
            if (amt > max)
            {
                amt = max;
            }
            return amt;
        }

        amt = 1;
        if (allbydefault)
        {
            amt = max;
        }
        string def = amt.ToString();
        if (!GetString($"Quantity (1-{max}): ", out string buf, def, 6))
        {
            return 0;
        }
        if (int.TryParse(buf, out int test))
        {
            amt = test;
        }
        if (string.IsNullOrEmpty(buf))
        {
            amt = max;
        }
        else if (char.IsLetter(buf[0]))
        {
            amt = max;
        }
        if (amt > max)
        {
            amt = max;
        }
        if (amt < 0)
        {
            amt = 0;
        }
        return amt;
    }

    public bool GetString(string prompt, out string buf, string initial, int len)
    {
        MsgPrint(null);
        Screen.PrintLine(prompt, 0, 0);
        string? buffer = AskforAux(initial, len);
        buf = buffer;
        MsgClear();
        if (buffer == null)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Pauses for a duration
    /// </summary>
    /// <param name="duration"> The duration of the pause, in milliseconds </param>
    [Obsolete("Use Pause(Timespan)")]
    public void Pause(int duration)
    {
        Thread.Sleep(duration);
    }

    public void Pause(TimeSpan timeSpan)
    {
        Thread.Sleep(timeSpan);
    }

    /// <summary>
    /// Plays a sound
    /// </summary>
    /// <param name="val"> The sound to play </param>
    public void PlaySound(SoundEffectEnum sound)
    {
        ConsoleViewPort.PlaySound(sound);
    }

    /// <summary>
    /// Update the screen using a double buffer, drawing all queued print and erase requests.
    /// </summary>
    public void UpdateScreen()
    {
        Screen.UpdateScreen();
    }

    public void PlayMusic(MusicTrackEnum musicTrack)
    {
        ConsoleViewPort.PlayMusic(musicTrack);
    }

    public void RequestCommand(bool shopping)
    {
        const int mode = Constants.KeymapModeOrig;
        CurrentCommand = (char)0;
        CommandArgument = 0;
        CommandDirection = 0;
        while (!Shutdown)
        {
            char cmd;
            HideCursorOnFullScreenInkey = true;
            cmd = Inkey();
            MsgClear();
            if (cmd == '0')
            {
                int oldArg = CommandArgument;
                CommandArgument = 0;
                Screen.PrintLine("Count: ", 0, 0);
                while (!Shutdown)
                {
                    cmd = Inkey();
                    if (cmd == 0x7F || cmd == 0x08)
                    {
                        CommandArgument /= 10;
                        Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                    }
                    else if (cmd >= '0' && cmd <= '9')
                    {
                        if (CommandArgument >= 1000)
                        {
                            CommandArgument = 9999;
                        }
                        else
                        {
                            CommandArgument = (CommandArgument * 10) + int.Parse(cmd.ToString());
                        }
                        Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                    }
                    else
                    {
                        break;
                    }
                }
                if (CommandArgument == 0)
                {
                    CommandArgument = 99;
                    Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                }
                if (oldArg != 0)
                {
                    CommandArgument = oldArg;
                    Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                }
                if (cmd == ' ' || cmd == '\n' || cmd == '\r')
                {
                    if (!GetCom("Command: ", out cmd))
                    {
                        CommandArgument = 0;
                        continue;
                    }
                }
            }
            if (cmd == '\\')
            {
                GetCom("Command: ", out cmd);
            }
            string act = _keymapAct[mode][cmd];
            if (!string.IsNullOrEmpty(act))
            {
                cmd = act[0];
                _artificialKeyBuffer = act.Substring(1);
            }
            if (cmd == 0)
            {
                continue;
            }
            CurrentCommand = cmd;
            break;
        }
        MsgClear();
    }

    public void ShowManual() // TODO: Needs to be deleted
    {
    }

    internal void SetBackground(BackgroundImageEnum image)
    {
        ConsoleViewPort.SetBackground(image);
    }

    /// <summary>
    /// Returns the maximum elapsed time to submit a replay keystroke or null, to impose no limit.
    /// </summary>
    public TimeSpan? MaxKeystrokeReplayElapsedTime = new TimeSpan(0, 0, 0, 0, 0);

    /// <summary>
    /// Adds a keypress to the internal queue, sends a notification to the <see cref="ConsoleViewPort" and updates the <see cref="LastInputReceived"/> property./>
    /// </summary>
    /// <param name="k"> The keypress to add </param>
    private void WaitAndEnqueueKey()
    {
        char k;

        // Check to see if we are in playback mode.
        if (ReplayQueueIndex < ReplayQueue.Count)
        {
            // Retrieve the replay step that needs to be replayed.  This is a non-destructive (non-dequeue) peek.  We only increment the replay index pointer.
            GameReplayStep gameReplayStep = ReplayQueue[ReplayQueueIndex];

            // Compute how much elapsed time occured since the last keystroke.
            TimeSpan keystrokeElapsedTime = ReplayQueueIndex == 0 ? TimeSpan.Zero : ReplayQueue[ReplayQueueIndex].DateTime - ReplayQueue[ReplayQueueIndex - 1].DateTime;
            ReplayQueueIndex++;

            // Retrieve the current date and time for the computations.
            DateTime now = DateTime.Now;

            // Check to see if the last keystroke date and time needs to be initialized.
            if (LastKeystrokeDateTime == null)
            {
                LastKeystrokeDateTime = now;
            }

            // Determine when the next keystroke should be submitted.
            DateTime nextKeystrokeSubmitTime = LastKeystrokeDateTime.Value + keystrokeElapsedTime;

            // Compute how much time we need to wait and wait that time out.
            TimeSpan waitTime = nextKeystrokeSubmitTime - now;

            // Enforce a maximum elapsed keystroke wait time.
            if (MaxKeystrokeReplayElapsedTime.HasValue && waitTime > MaxKeystrokeReplayElapsedTime)
            {
                waitTime = MaxKeystrokeReplayElapsedTime.Value;
            }

            // Force a wait.
            if (waitTime > TimeSpan.Zero)
            {
                Pause(waitTime);
            }

            // Deliver the keystroke.
            k = gameReplayStep.Keystroke;

            // Update the running keystroke submit time.  If the wait time was shortened due to exceeding the maximum elapsed time, we set the time to the target time.
            LastKeystrokeDateTime = nextKeystrokeSubmitTime;
        }
        else
        {
            // Detect if we just entered the popup menu.
            bool enteredPopupMenu = InPopupMenu && !PreviousInPopupMenu;
            bool exitedPopupMenu = !InPopupMenu && PreviousInPopupMenu;
            bool popupMenuCommand = InPopupMenu && PreviousInPopupMenu;
            if (enteredPopupMenu || exitedPopupMenu || popupMenuCommand)
            {
                // Remove the keystroke.
                ReplayQueue.RemoveAt(ReplayQueue.Count - 1);
            }
            PreviousInPopupMenu = InPopupMenu;

            // Wait for a keystroke from the console and record it and the elapsed time in milliseconds for replay.
            k = ConsoleViewPort.WaitForKey();

            // Append the replay step.
            ReplayQueue.Add(new GameReplayStep(DateTime.Now, k));

            // We are in recording mode.  Keep the replay queue index up to date.
            ReplayQueueIndex = ReplayQueue.Count;
        }

        if (k == 0) // TODO: This should never be
        {
            return;
        }
        KeyQueue[KeyHead++] = k;
        if (KeyHead == KeyQueue.Length)
        {
            KeyHead = 0;
        }

        LastInputReceived = DateTime.Now;
        ConsoleViewPort.InputReceived();
    }

    /// <summary>
    /// Attempts to gets a keypress from the <see cref="ConsoleViewport"/> queue.  Returns true, if a keypress was returned.  Returns false, if the <paramref name="wait"/> is true and the <see cref="ConsoleViewPort"/>
    /// queue is empty.
    /// </summary>
    /// <param name="ch"> The next key from the queue </param>
    /// <param name="wait"> Whether to wait for a key if one isn't already available </param>
    /// <param name="take"> Whether to take the keypress out of the queue </param>
    /// <returns> True if a keypress was available, false otherwise </returns>
    private bool GetKeypress(out char ch, bool wait, bool take)
    {
        ch = '\0';
        if (wait)
        {
            UpdateScreen();
            while (KeyHead == KeyTail && !Shutdown) // TODO: should this yield?
            {
                WaitAndEnqueueKey();
            }
        }
        else
        {
            if (!ConsoleViewPort.KeyQueueIsEmpty())
            {
                WaitAndEnqueueKey();
            }
        }
        if (KeyHead == KeyTail)
        {
            return false;
        }
        ch = KeyQueue[KeyTail];
        if (take && ++KeyTail == KeyQueue.Length)
        {
            KeyTail = 0;
        }
        return true;
    }

    /// <summary>
    /// Returns the next keystoke from either the artificial keystroke buffer, or the <see cref="ConsoleViewPort"/>.  The artificial keystroke buffer will always be processed before the <see cref="ConsoleViewPort"/>
    /// keystrokes are retrieved.
    /// </summary>
    /// <returns>The next key pressed.</returns>
    public char Inkey(bool doNotWaitOnInkey = false) // TODO: Change the signature to return null when Shutdown == true
    {
        char ch = '\0';
        if (_artificialKeyBuffer.Length > 0)
        {
            ch = _artificialKeyBuffer[0];
            _artificialKeyBuffer = _artificialKeyBuffer.Remove(0, 1);
            HideCursorOnFullScreenInkey = false;
            return ch;
        }
        bool v = Screen.CursorVisible;
        if (!doNotWaitOnInkey && (!HideCursorOnFullScreenInkey || FullScreenOverlay))
        {
            Screen.CursorVisible = true;
        }
        if (InPopupMenu)
        {
            Screen.CursorVisible = false;
        }
        while (ch == 0 && !Shutdown)
        {
            if (doNotWaitOnInkey && GetKeypress(out char kk, false, false))
            {
                ch = kk;
                break;
            }
            if (doNotWaitOnInkey)
            {
                break;
            }
            GetKeypress(out ch, true, true);
            if (ch == 29)
            {
                ch = '\0';
                continue;
            }
            if (ch == '`')
            {
                ch = '\x1b';
            }
            if (ch == 30)
            {
                ch = '\0';
            }
        }
        Screen.CursorVisible = v;
        HideCursorOnFullScreenInkey = false;
        return ch;
    }

    private void MapMovementKeys()
    {
        _keymapAct = new string[Constants.KeymapModes][];
        for (int i = 0; i < Constants.KeymapModes; i++)
        {
            _keymapAct[i] = new string[256];
            for (int j = 0; j < 256; j++)
            {
                _keymapAct[i][j] = string.Empty;
            }
        }
        _keymapAct[0]['1'] = ";1";
        _keymapAct[0]['2'] = ";2";
        _keymapAct[0]['3'] = ";3";
        _keymapAct[0]['4'] = ";4";
        _keymapAct[0]['5'] = ",";
        _keymapAct[0]['6'] = ";6";
        _keymapAct[0]['7'] = ";7";
        _keymapAct[0]['8'] = ";8";
        _keymapAct[0]['9'] = ";9";
    }

    ////////////////// PLAYER FACTORY
    /// <summary>
    /// Represents the previous character class.
    /// </summary>
    public BaseCharacterClass _prevCharacterClass;

    public int _prevGeneration;
    public string _prevName;

    /// <summary>
    /// Returns the race of the previous character.  Used as a default during the birthing process.  Set to HumanRace if there is no previous character.  Returns
    /// null, before the birthing process is started.
    /// </summary>
    public Race? _prevRace = null;

    public Realm? _prevPrimaryRealm;
    public Realm? _prevSecondaryRealm;

    public Gender _prevSex;

    /// <summary>
    /// The players inventory.
    /// </summary>
    public Item?[] Inventory;
    public int _invenCnt;

    public void DisplayAPlusB(int x, int y, int initial, int bonus)
    {
        string buf = $"{initial:00}% + {bonus / 10}.{bonus % 10}%/lv";
        Screen.Print(ColorEnum.Black, buf, y, x);
    }

    public void DisplayRealmInfo(Realm prealm)
    {
        int y = 30;
        foreach (string info in prealm.Info)
        {
            Screen.Print(ColorEnum.Purple, info, y, 20);
            y++;
        }
    }

    public void DisplayStatBonus(int x, int y, int bonus)
    {
        string buf;
        if (bonus == 0)
        {
            Screen.Print(ColorEnum.Black, "+0", y, x);
        }
        else if (bonus < 0)
        {
            buf = bonus.ToString();
            Screen.Print(ColorEnum.BrightRed, buf, y, x);
        }
        else
        {
            buf = "+" + bonus;
            Screen.Print(ColorEnum.Green, buf, y, x);
        }
    }
    public TimeSpan ElapsedGameTime
    {
        get
        {
            return CurrentGameDateTime.DateAndTimeValue - _gameStartDateTime;
        }
    }

    public string BirthdayText
    {
        get
        {
            return _gameStartDateTime.ToString("MMM d");
        }
    }

    public bool IsLight
    {
        get
        {
            return (CurrentGameDateTime.DateAndTimeValue >= _dawn) && (CurrentGameDateTime.DateAndTimeValue <= _dusk);
        }
    }

    public bool IsTurnHundred
    {
        get
        {
            return _currentTurn % 100 == 0;
        }
    }

    public bool IsTurnTen
    {
        get
        {
            return _currentTurn % 10 == 0;
        }
    }

    public bool LevelFeel
    {
        get
        {
            return (_currentTurn - _levelEntryTurn) >= LevelFeelDelay;
        }
    }

    public int Turn
    {
        get
        {
            return _currentTurn;
        }
    }

    public void MarkLevelEntry()
    {
        _levelEntryTurn = _currentTurn;
    }

    public void Tick()
    {
        var oldDay = CurrentGameDateTime.DateAndTimeValue.DayOfYear;
        _currentTurn++;
        var oldDateTime = CurrentGameDateTime.DateAndTimeValue;
        CurrentGameDateTime.DateAndTimeValue += _tick;
        var newDay = CurrentGameDateTime.DateAndTimeValue.DayOfYear;
        IsBirthday = false;
        IsDawn = false;
        IsDusk = false;
        IsFeelTime = false;
        IsHalloween = false;
        IsMidnight = false;
        IsNewYear = false;
        if (_currentTurn - _levelEntryTurn == LevelFeelDelay)
        {
            IsFeelTime = true;
        }
        if (oldDay != newDay)
        {
            IsMidnight = true;
            RecalculateDawnAndDusk();
            if (newDay == 1)
            {
                IsNewYear = true;
            }
            if (newDay == _birthday)
            {
                IsBirthday = true;
            }
            if (newDay == 305)
            {
                IsHalloween = true;
            }
        }
        if (oldDateTime < _dawn && CurrentGameDateTime.DateAndTimeValue >= _dawn)
        {
            IsDawn = true;
        }
        if (oldDateTime < _dusk && CurrentGameDateTime.DateAndTimeValue >= _dusk)
        {
            IsDusk = true;
        }
        var year = CurrentGameDateTime.DateAndTimeValue.Year;
        if (year > 1297)
        {
            CurrentGameDateTime.DateAndTimeValue = CurrentGameDateTime.DateAndTimeValue.AddYears(1297 - year);
        }

        // Send an update to the calling application, that the game time has changed.
        ConsoleViewPort.GameTimeElapsed();
    }

    public void ToNextDawn()
    {
        var midnight = new DateTime(CurrentGameDateTime.DateAndTimeValue.Year, CurrentGameDateTime.DateAndTimeValue.Month, CurrentGameDateTime.DateAndTimeValue.Day, 0, 0, 0);
        midnight += new TimeSpan(1, 0, 0, 0);
        CurrentGameDateTime.DateAndTimeValue = midnight;
        RecalculateDawnAndDusk();
        CurrentGameDateTime.DateAndTimeValue = _dawn;
        ReverseEngineerTurn();
        Tick();
    }

    public void ToNextDusk()
    {
        var midnight = new DateTime(CurrentGameDateTime.DateAndTimeValue.Year, CurrentGameDateTime.DateAndTimeValue.Month, CurrentGameDateTime.DateAndTimeValue.Day, 0, 0, 0);
        midnight += new TimeSpan(1, 0, 0, 0);
        CurrentGameDateTime.DateAndTimeValue = midnight;
        RecalculateDawnAndDusk();
        CurrentGameDateTime.DateAndTimeValue = _dusk;
        ReverseEngineerTurn();
        Tick();
    }

    private void RecalculateDawnAndDusk()
    {
        var midnight = new DateTime(CurrentGameDateTime.DateAndTimeValue.Year, CurrentGameDateTime.DateAndTimeValue.Month, CurrentGameDateTime.DateAndTimeValue.Day, 0, 0, 0);
        var n = midnight.DayOfYear;
        var delta = 23.45 * Math.Sin((360.0 / 365.0 * (n + 284)) * (Math.PI / 180.0)) * (Math.PI / 180.0);
        const double phi = 50.838 * (Math.PI / 180.0);
        var omega = Math.Acos(Math.Tan(delta) * -Math.Tan(phi)) * (180.0 / Math.PI);
        var sunriseHoursBeforeNoon = omega / 15.0;
        var sunrise = TimeSpan.FromHours(12.0 - sunriseHoursBeforeNoon);
        sunrise = new TimeSpan(0, 0, 0, (int)sunrise.TotalSeconds, 0);
        var sunset = TimeSpan.FromHours(12.0 + sunriseHoursBeforeNoon);
        sunset = new TimeSpan(0, 0, 0, (int)sunset.TotalSeconds, 0);
        _dawn = midnight + sunrise;
        _dusk = midnight + sunset;
    }

    private void ReverseEngineerTurn()
    {
        var totalTime = CurrentGameDateTime.DateAndTimeValue - _gameStartDateTime;
        var milliseconds = totalTime.TotalMilliseconds;
        _currentTurn = (int)(milliseconds / MillisecondsPerTurn);
    }

    public void GetAhw()
    {
        Age = Race.BaseAge + DieRoll(Race.AgeRange);

        bool startAtDusk = Race.RestsTillDuskInsteadOfDawn;
        int startDate = DieRoll(365);
        CurrentGameDateTime.DateAndTimeValue = new DateTime(1297, 1, 1, 0, 0, 0, 0);
        CurrentGameDateTime.DateAndTimeValue = CurrentGameDateTime.DateAndTimeValue.AddDays(startDate - 1);
        _birthday = startDate;
        RecalculateDawnAndDusk();
        if (startAtDusk)
        {
            _gameStartDateTime = _dusk;
        }
        else
        {
            _gameStartDateTime = _dawn;
        }
        CurrentGameDateTime.DateAndTimeValue = _gameStartDateTime;
        Tick();

        RefreshHeightAndWeight();
    }

    private void RefreshHeightAndWeight()
    {
        RaceGender raceGender = SingletonRepository.Get<RaceGender>(RaceGender.GetCompositeKey(Race, Gender));
        PhysicalAttributeSet physicalAttributeSet = raceGender.PhysicalAttributesWeightedRandom.Choose();
        Height = RandomNormal(physicalAttributeSet.BaseHeight, physicalAttributeSet.HeightRange);
        Weight = RandomNormal(physicalAttributeSet.BaseWeight, physicalAttributeSet.WeightRange);
    }

    public void GetExtra()
    {
        int i;
        MaxLevelGained = 1;
        ExperienceLevel.IntValue = 1;
        ExperienceMultiplier.IntValue = Race.ExperienceFactor + BaseCharacterClass.ExperienceFactor;
        HitDie = Race.HitDieBonus + BaseCharacterClass.HitDieBonus;
        MaxHealth.IntValue = HitDie;
        PlayerHp[0] = HitDie;
        int lastroll = HitDie;
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            PlayerHp[i] = lastroll;
            lastroll--;
            if (lastroll < 1)
            {
                lastroll = HitDie;
            }
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            int j = DieRoll(Constants.PyMaxLevel - 1);
            lastroll = PlayerHp[i];
            PlayerHp[i] = PlayerHp[j];
            PlayerHp[j] = lastroll;
        }
        for (i = 1; i < Constants.PyMaxLevel; i++)
        {
            PlayerHp[i] = PlayerHp[i - 1] + PlayerHp[i];
        }
    }

    public void GetStartingGold()
    {
        int gold = (SocialClass * 6) + DieRoll(100) + 300;
        foreach (Ability ability in SingletonRepository.Get<Ability>())
        {
            if (ability.Adjusted >= 18 + 50)
            {
                gold -= 300;
            }
            else if (ability.Adjusted >= 18 + 20)
            {
                gold -= 200;
            }
            else if (ability.Adjusted > 18)
            {
                gold -= 150;
            }
            else
            {
                gold -= (ability.Adjusted - 8) * 10;
            }
        }
        if (gold < 100)
        {
            gold = 100;
        }
        Gold.IntValue = gold;
    }

    public void GetStats()
    {
        while (true)
        {
            List<int> maxList = new List<int>() { 17, 16, 14, 12, 11, 10 };
            foreach (Ability ability in SingletonRepository.Get<Ability>()) // There are six abilities
            {
                int maxIndex = RandomLessThan(maxList.Count); // Choose a random max from the maxList
                int max = maxList[maxIndex];
                maxList.RemoveAt(maxIndex);
                ability.InnateMax = max;
                RaceAbility raceAbility = SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Race, ability));
                CharacterClassAbility characterClassAbility = SingletonRepository.Get<CharacterClassAbility>(CharacterClassAbility.GetCompositeKey(BaseCharacterClass, ability));
                int bonus = raceAbility.Bonus + characterClassAbility.Bonus;
                ability.Innate = ability.InnateMax;
                ability.Adjusted = ability.ModifyStatValue(ability.InnateMax, bonus);
            }
            if (BaseCharacterClass.PrimeStat.InnateMax > 13)
            {
                break;
            }
        }
    }

    public void MenuDisplay(int current, string[] menuItems)
    {
        Screen.Clear(30);
        Screen.Print(ColorEnum.Orange, "=>", 35, 0);
        for (int i = 0; i < menuItems.Length; i++)
        {
            int row = 35 + i - current;
            if (row >= 30 && row <= 40)
            {
                ColorEnum a = ColorEnum.Purple;
                if (i == current)
                {
                    a = ColorEnum.Pink;
                }
                Screen.Print(a, menuItems[i], row, 2);
            }
        }
    }

    private void PlayerOutfit()
    {
        if (Race.OutfitsWithScrollsOfSatisfyHunger)
        {
            ItemFactory scrollSatisfyHungerItemClass = SingletonRepository.Get<ItemFactory>(nameof(SatisfyHungerScrollItemFactory));
            Item item = scrollSatisfyHungerItemClass.GenerateItem();
            item.StackCount = (char)RandomBetween(2, 5);
            item.IsFlavorAware = true;
            item.BecomeKnown();
            item.IdentityIsStoreBought = true;
            InventoryCarry(item);
        }
        else
        {
            ItemFactory rationFoodItemClass = SingletonRepository.Get<ItemFactory>(nameof(RationFoodItemFactory));
            Item item = rationFoodItemClass.GenerateItem();
            item.StackCount = RandomBetween(3, 7);
            item.IsFlavorAware = true;
            item.BecomeKnown();
            InventoryCarry(item);
        }
        if (Race.OutfitsWithScrollsOfLight || BaseCharacterClass.OutfitsWithScrollsOfLight)
        {
            ItemFactory scrollLightItemClass = SingletonRepository.Get<ItemFactory>(nameof(LightScrollItemFactory));
            Item item = scrollLightItemClass.GenerateItem();
            item.StackCount = RandomBetween(3, 7);
            item.IsFlavorAware = true;
            item.BecomeKnown();
            item.IdentityIsStoreBought = true;
            InventoryCarry(item);
        }
        else
        {
            ItemFactory woodenTorchItemClass = SingletonRepository.Get<ItemFactory>(nameof(WoodenTorchLightSourceItemFactory));
            Item item = woodenTorchItemClass.GenerateItem();
            item.StackCount = RandomBetween(3, 7);
            item.TurnsOfLightRemaining = RandomBetween(3, 7) * 500;
            item.IsFlavorAware = true;
            item.BecomeKnown();
            InventoryCarry(item);
            Item carried = item.TakeFromStack(1);
            LightsourceWieldSlot lightsourceInventorySlot = (LightsourceWieldSlot)SingletonRepository.Get<WieldSlot>(nameof(LightsourceWieldSlot));
            SetInventoryItem(lightsourceInventorySlot.WeightedRandom.ChooseOrDefault(), carried);
            WeightCarried += carried.EffectivePropertySet.Weight;
        }
        BaseCharacterClass.OutfitPlayer();

        // If the character chosen has religion, outfit the player with books.
        if (PrimaryRealm != null)
        {
            PrimaryRealm.OutfitPlayer();
            if (SecondaryRealm != null)
            {
                SecondaryRealm.OutfitPlayer();
            }
        }
    }

    /// <summary>
    /// Adds an item to the players inventory.
    /// </summary>
    /// <param name="item"></param>

    public void OutfitPlayerWithItem(Item item)
    {
        item.IdentityIsStoreBought = true;
        item.IsFlavorAware = true;
        item.BecomeKnown();

        if (!item.Wield())
        {
            throw new Exception($"The {item.GetDescription(false)} cannot be outfit because the all of the wield slots are currently in use.");
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
        // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan hair color 52->53->End
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
        // Group 56: Elf/High-Elf color 56->End
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
        // Group 59: Dwarf/Nibelung hair color 59->60->61->End
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
        // Group 65: Half-Troll/Zombie skin color 65->66->End
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
        // Group 91: Draconian color 91->End
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
        // Group 111: Cyclops hair color 111->112->End
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
        new PlayerHistory("blue eyes, and skin the color of pine.", 25, 128, 0, 50),
        new PlayerHistory("blue eyes, and skin the color of ash.", 50, 128, 0, 50),
        new PlayerHistory("blue eyes, and skin the color of oak.", 75, 128, 0, 50),
        new PlayerHistory("blue eyes, and skin the color of mahogany.", 100, 128, 0, 50),
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
        // Group 132: Miri-Nigri skin color 132->133->End
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
        // Group 135: Yeek fur color 135->136->137->End
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
    public void GetHistory()
    {
        int i;
        for (i = 0; i < 4; i++)
        {
            History[i] = string.Empty;
        }
        string fullHistory = string.Empty;
        int socialClass = DieRoll(4);
        // Start on a chart based on the character's race
        int chart = Race.Chart;

        // Keep going till we get to an end
        while (chart != 0)
        {
            i = 0;
            // Roll percentile for which background to use within each chart
            int roll = DieRoll(100);
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
        SocialClass = socialClass;
        // Split the buffer into four strings to fit on four lines of the screen
        string s = fullHistory.Trim();
        i = 0;
        while (true)
        {
            int n = s.Length;
            if (n < 60)
            {
                History[i] = s;
                break;
            }
            for (n = 60; n > 0 && s[n - 1] != ' '; n--)
            {
            }
            History[i++] = s.Substring(0, n).Trim();
            s = s.Substring(n).Trim();
        }
    }

    public void GenerateNewLevel()
    {
        // Reset all of the monsters.
        Monsters = new Monster[Constants.MaxMIdx];
        for (int j = 0; j < Constants.MaxMIdx; j++)
        {
            Monsters[j] = new Monster(this);
        }

        // Loop until we are able to build the level and keep track of the number of attempts.
        for (int generateAttemptNumber = 0; ; generateAttemptNumber++)
        {
            bool okay = true;

            // Allocate and reset the grid tiles.
            Map.Initialize();

            PanelRowMin = 0;
            PanelRowMax = 0;
            PanelColMin = 0;
            PanelColMax = 0;
            MonsterLevel = Difficulty;
            SpecialTreasure = false;
            SpecialDanger = false;
            TreasureRating = 0;
            DangerRating = 0;
            if (CurrentDepth == 0)
            {
                if (Wilderness[WildernessY][WildernessX].Town != null)
                {
                    CurTown = Wilderness[WildernessY][WildernessX].Town;
                    DungeonDifficulty = 0;
                    DunBias = null;
                    if (Wilderness[WildernessY][WildernessX].Town.Char == 'K')
                    {
                        DungeonDifficulty = 35;
                        DunBias = SingletonRepository.Get<MonsterRaceFilter>(nameof(CthuloidMonsterRaceFilter));
                    }
                }
                else if (Wilderness[WildernessY][WildernessX].Dungeon != null)
                {
                    DungeonDifficulty = Wilderness[WildernessY][WildernessX].Dungeon.Offset / 2;
                    if (DungeonDifficulty < 4)
                    {
                        DungeonDifficulty = 4;
                    }
                    DunBias = Wilderness[WildernessY][WildernessX].Dungeon.BiasMonsterFilter;
                }
                else
                {
                    DungeonDifficulty = 2;
                    DunBias = SingletonRepository.Get<MonsterRaceFilter>(nameof(AnimalMonsterRaceFilter));
                }
                CurHgt = Constants.PlayableScreenHeight;
                CurWid = Constants.PlayableScreenWidth;
                MaxPanelRows = (CurHgt / Constants.PlayableScreenHeight * 2) - 2;
                MaxPanelCols = (CurWid / Constants.PlayableScreenWidth * 2) - 2;
                PanelRow = MaxPanelRows;
                PanelCol = MaxPanelCols;
                if (Wilderness[WildernessY][WildernessX].Town != null)
                {
                    TownGen();
                }
                else
                {
                    WildernessGen();
                }
            }
            else
            {
                if (!DungeonGenerator.GenerateDungeon(Difficulty))
                {
                    okay = false;
                }
            }
            if (TreasureRating > 100)
            {
                TreasureFeeling = 2;
            }
            else if (TreasureRating > 80)
            {
                TreasureFeeling = 3;
            }
            else if (TreasureRating > 60)
            {
                TreasureFeeling = 4;
            }
            else if (TreasureRating > 40)
            {
                TreasureFeeling = 5;
            }
            else if (TreasureRating > 30)
            {
                TreasureFeeling = 6;
            }
            else if (TreasureRating > 20)
            {
                TreasureFeeling = 7;
            }
            else if (TreasureRating > 10)
            {
                TreasureFeeling = 8;
            }
            else if (TreasureRating > 0)
            {
                TreasureFeeling = 9;
            }
            else
            {
                TreasureFeeling = 10;
            }
            if (SpecialTreasure)
            {
                TreasureRating = 1;
            }
            if (DangerRating > 100)
            {
                DangerFeeling = 2;
            }
            else if (DangerRating > 80)
            {
                DangerFeeling = 3;
            }
            else if (DangerRating > 60)
            {
                DangerFeeling = 4;
            }
            else if (DangerRating > 40)
            {
                DangerFeeling = 5;
            }
            else if (DangerRating > 30)
            {
                DangerFeeling = 6;
            }
            else if (DangerRating > 20)
            {
                DangerFeeling = 7;
            }
            else if (DangerRating > 10)
            {
                DangerFeeling = 8;
            }
            else if (DangerRating > 0)
            {
                DangerFeeling = 9;
            }
            else
            {
                DangerFeeling = 10;
            }
            if (SpecialDanger)
            {
                DangerFeeling = 1;
            }
            if (CurrentDepth <= 0)
            {
                TreasureFeeling = 0;
                DangerFeeling = 0;
            }
            if (MonsterMax >= Constants.MaxMIdx)
            {
                okay = false;
            }
            if (generateAttemptNumber < 100)
            {
                int totalFeeling = TreasureFeeling + DangerFeeling;
                if (totalFeeling > 18 ||
                    (Difficulty >= 5 && totalFeeling > 16) ||
                    (Difficulty >= 10 && totalFeeling > 14) ||
                    (Difficulty >= 20 && totalFeeling > 12) ||
                    (Difficulty >= 40 && totalFeeling > 10))
                {
                    okay = false;
                }
            }
            if (okay)
            {
                break;
            }

            // Reset the level so that we can attempt again.
            WipeMList();
        }
        MarkLevelEntry();
    }

    private void BuildField(int yy, int xx)
    {
        int y0 = (yy * 9) + 8;
        int x0 = (xx * 15) + 10;
        int y1 = y0 - DieRoll(2) - 1;
        int y2 = y0 + DieRoll(2) + 1;
        int x1 = x0 - DieRoll(3) - 2;
        int x2 = x0 + DieRoll(3) + 2;
        Tile fieldTile = SingletonRepository.Get<Tile>(nameof(FieldTile));
        for (int x = x1; x < x2; x++)
        {
            for (int y = y1; y < y2; y++)
            {
                Map.Grid[y][x].SetFeature(fieldTile);
                Map.Grid[y][x].SetBackgroundFeature(fieldTile);
            }
        }
        if (DieRoll(5) == 4)
        {
            int x = RandomBetween(x1, x2);
            int y = RandomBetween(y1, y2);
            Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(ScarecrowTile)));
        }
    }

    private void BuildGraveyard(int yy, int xx)
    {
        int y0 = (yy * 9) + 8;
        int x0 = (xx * 15) + 10;
        int y1 = y0 - DieRoll(2) - 1;
        int y2 = y0 + DieRoll(2) + 1;
        int x1 = x0 - DieRoll(3) - 2;
        int x2 = x0 + DieRoll(3) + 2;
        for (int i = 0; i < RandomBetween(10, 20); i++)
        {
            int x = (RandomBetween(x1, x2) / 2 * 2) + 1;
            int y = (RandomBetween(y1, y2) / 2 * 2) + 1;
            Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(GraveTile)));
        }
    }

    private void BuildStore(Store store, int yy, int xx)
    {
        int y, x;
        GridTile cPtr;

        if (store.StoreFactory.IsEmptyLot)
        {
            switch (DieRoll(10))
            {
                case 3:
                case 7:
                case 9:
                    break;

                case 6:
                    BuildGraveyard(yy, xx);
                    break;

                default:
                    BuildField(yy, xx);
                    break;
            }
            return;
        }

        int y0 = (yy * 9) + 6;
        int x0 = (xx * 15) + 10;
        int y1 = y0 - DieRoll(2);
        int y2 = y0 + DieRoll(2) + 1;
        int x1 = x0 - DieRoll(3) - 2;
        int x2 = x0 + DieRoll(3) + 2;
        if ((y2 - y1) % 2 == 0)
        {
            y2++;
        }
        for (y = y1; y <= y2; y++)
        {
            for (x = x1; x <= x2; x++)
            {
                cPtr = Map.Grid[y][x];
                if (!store.StoreFactory.BuildingsMadeFromPermanentRock)
                {
                    switch (DieRoll(6))
                    {
                        case 1:
                            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(WallInnerTile)));
                            break;

                        case 2:
                        case 3:
                        case 4:
                            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(RubbleTile)));
                            break;
                    }
                }
                else
                {
                    if (y == y2)
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                    }
                    else
                    {
                        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(RoofTile)));
                    }
                }
                cPtr.PlayerMemorized = true;
                cPtr.SelfLit = true;
            }
        }
        y = y2;
        x = RandomBetween(x1 + 1, x2 - 2);
        cPtr = Map.Grid[y][x];
        if (store.StoreFactory.StoreEntranceDoorsAreBlownOff)
        {
            if (DieRoll(8) == 6)
            {
                PlaceRandomDoor(y, x);
            }
        }
        else
        {
            cPtr.SetFeature(store.StoreFactory.Tile);
        }
        store.SetLocation(x, y);
        for (++y; y < y0 + 7; y++)
        {
            cPtr = Map.Grid[y][x];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        }
        y--;
        int dX = Math.Sign((CurWid / 2) - x);
        for (x += dX; x != CurWid / 2; x += dX)
        {
            cPtr = Map.Grid[y][x];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        }
    }

    private void MakeCornerTowers(int wildX, int wildY)
    {
        int height = CurHgt;
        int width = CurWid;
        if ((Wilderness[wildY][wildX].Town != null) || (Wilderness[wildY - 1][wildX].Town != null) ||
            (Wilderness[wildY][wildX - 1].Town != null) || (Wilderness[wildY - 1][wildX - 1].Town != null))
        {
            Map.Grid[0][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][0].PlayerMemorized = true;
            Map.Grid[0][0].SelfLit = true;
            Map.Grid[1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][0].PlayerMemorized = true;
            Map.Grid[1][0].SelfLit = true;
            Map.Grid[1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][1].PlayerMemorized = true;
            Map.Grid[1][1].SelfLit = true;
            Map.Grid[0][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][1].PlayerMemorized = true;
            Map.Grid[0][1].SelfLit = true;
            Map.Grid[0][0].RevertToBackground();
            Map.Grid[0][0].PlayerMemorized = true;
            Map.Grid[0][0].SelfLit = true;
            Map.Grid[1][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][0].PlayerMemorized = true;
            Map.Grid[1][0].SelfLit = true;
            Map.Grid[1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][1].PlayerMemorized = true;
            Map.Grid[1][1].SelfLit = true;
            Map.Grid[0][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][1].PlayerMemorized = true;
            Map.Grid[0][1].SelfLit = true;
        }
        if ((Wilderness[wildY][wildX].Town != null) || (Wilderness[wildY - 1][wildX].Town != null) ||
            (Wilderness[wildY][wildX + 1].Town != null) || (Wilderness[wildY - 1][wildX + 1].Town != null))
        {
            Map.Grid[0][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][width - 1].PlayerMemorized = true;
            Map.Grid[0][width - 1].SelfLit = true;
            Map.Grid[1][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][width - 1].PlayerMemorized = true;
            Map.Grid[1][width - 1].SelfLit = true;
            Map.Grid[1][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][width - 2].PlayerMemorized = true;
            Map.Grid[1][width - 2].SelfLit = true;
            Map.Grid[0][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][width - 2].PlayerMemorized = true;
            Map.Grid[0][width - 2].SelfLit = true;
            Map.Grid[0][width - 1].RevertToBackground();
            Map.Grid[0][width - 1].PlayerMemorized = true;
            Map.Grid[0][width - 1].SelfLit = true;
            Map.Grid[1][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][width - 1].PlayerMemorized = true;
            Map.Grid[1][width - 1].SelfLit = true;
            Map.Grid[1][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][width - 2].PlayerMemorized = true;
            Map.Grid[1][width - 2].SelfLit = true;
            Map.Grid[0][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][width - 2].PlayerMemorized = true;
            Map.Grid[0][width - 2].SelfLit = true;
        }
        if ((Wilderness[wildY][wildX].Town != null) || (Wilderness[wildY + 1][wildX].Town != null) ||
            (Wilderness[wildY][wildX + 1].Town != null) || (Wilderness[wildY + 1][wildX + 1].Town != null))
        {
            Map.Grid[height - 1][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][width - 1].PlayerMemorized = true;
            Map.Grid[height - 1][width - 1].SelfLit = true;
            Map.Grid[height - 2][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][width - 1].PlayerMemorized = true;
            Map.Grid[height - 2][width - 1].SelfLit = true;
            Map.Grid[height - 2][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][width - 2].PlayerMemorized = true;
            Map.Grid[height - 2][width - 2].SelfLit = true;
            Map.Grid[height - 1][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][width - 2].PlayerMemorized = true;
            Map.Grid[height - 1][width - 2].SelfLit = true;
            Map.Grid[height - 1][width - 1].RevertToBackground();
            Map.Grid[height - 1][width - 1].PlayerMemorized = true;
            Map.Grid[height - 1][width - 1].SelfLit = true;
            Map.Grid[height - 2][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][width - 1].PlayerMemorized = true;
            Map.Grid[height - 2][width - 1].SelfLit = true;
            Map.Grid[height - 2][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][width - 2].PlayerMemorized = true;
            Map.Grid[height - 2][width - 2].SelfLit = true;
            Map.Grid[height - 1][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][width - 2].PlayerMemorized = true;
            Map.Grid[height - 1][width - 2].SelfLit = true;
        }
        if ((Wilderness[wildY][wildX].Town != null) || (Wilderness[wildY + 1][wildX].Town != null) ||
            (Wilderness[wildY][wildX - 1].Town != null) || (Wilderness[wildY + 1][wildX - 1].Town != null))
        {
            Map.Grid[height - 1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][0].PlayerMemorized = true;
            Map.Grid[height - 1][0].SelfLit = true;
            Map.Grid[height - 2][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][0].PlayerMemorized = true;
            Map.Grid[height - 2][0].SelfLit = true;
            Map.Grid[height - 2][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][1].PlayerMemorized = true;
            Map.Grid[height - 2][1].SelfLit = true;
            Map.Grid[height - 1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][1].PlayerMemorized = true;
            Map.Grid[height - 1][1].SelfLit = true;
            Map.Grid[height - 1][0].RevertToBackground();
            Map.Grid[height - 1][0].PlayerMemorized = true;
            Map.Grid[height - 1][0].SelfLit = true;
            Map.Grid[height - 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][0].PlayerMemorized = true;
            Map.Grid[height - 2][0].SelfLit = true;
            Map.Grid[height - 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][1].PlayerMemorized = true;
            Map.Grid[height - 2][1].SelfLit = true;
            Map.Grid[height - 1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][1].PlayerMemorized = true;
            Map.Grid[height - 1][1].SelfLit = true;
        }
    }

    private Tile? _downStaircaseTile = null;
    public Tile GetDownStaircaseTile
    {
        get
        {
            if (_downStaircaseTile == null)
            {
                _downStaircaseTile = SingletonRepository.Get<Tile>().Single(_tile => _tile.IsDownStaircase);
            }
            return _downStaircaseTile;
        }
    }

    private Tile? _upStaircaseTile = null;
    public Tile GetUpStaircaseTile
    {
        get
        {
            if (_upStaircaseTile == null)
            {
                _upStaircaseTile = SingletonRepository.Get<Tile>().Single(_tile => _tile.IsUpStaircase);
            }
            return _upStaircaseTile;
        }
    }

    private Tile? _grassTile = null;
    public Tile GetGrassTile
    {
        get
        {
            if (_grassTile == null)
            {
                _grassTile = SingletonRepository.Get<Tile>().Single(_tile => _tile.IsGrass);
            }
            return _grassTile;
        }
    }

    private Tile? _rockTile = null;
    public Tile GetRockTile
    {
        get
        {
            if (_rockTile == null)
            {
                _rockTile = SingletonRepository.Get<Tile>().Single(_tile => _tile.IsRock);
            }
            return _rockTile;
        }
    }

    private Tile? _waterTile = null;
    public Tile GetWaterTile
    {
        get
        {
            if (_waterTile == null)
            {
                _waterTile = SingletonRepository.Get<Tile>().Single(_tile => _tile.IsWater);
            }
            return _waterTile;
        }
    }

    private void MakeDungeonEntrance(int left, int top, int width, int height, out int stairX, out int stairY)
    {
        int dummy = 0;
        int x = 1;
        int y = 1;
        while (dummy < SafeMaxAttempts)
        {
            dummy++;
            y = RandomBetween(top, top + height);
            x = RandomBetween(left, left + width);
            if (GridOpenNoItemOrCreature(y, x))
            {
                break;
            }
        }
        Map.Grid[y - 2][x].RevertToBackground();
        Map.Grid[y - 1][x - 1].RevertToBackground();
        Map.Grid[y - 1][x].RevertToBackground();
        Map.Grid[y - 1][x + 1].RevertToBackground();
        Map.Grid[y][x - 2].RevertToBackground();
        Map.Grid[y][x - 1].RevertToBackground();
        Map.Grid[y][x].SetFeature(GetDownStaircaseTile);
        stairX = x;
        stairY = y;
        Map.Grid[y][x + 1].RevertToBackground();
        Map.Grid[y][x + 2].RevertToBackground();
        Map.Grid[y + 1][x - 1].RevertToBackground();
        Map.Grid[y + 1][x].RevertToBackground();
        Map.Grid[y + 1][x + 1].RevertToBackground();
        Map.Grid[y + 2][x].RevertToBackground();
    }

    private void MakeHenge(int left, int top, int width, int height)
    {
        int midX = left + (width / 2);
        int midY = top + (height / 2);
        for (int y = midY - 3; y < midY + 3; y++)
        {
            Map.Grid[y][midX - 7].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 7].SetFeature(GetGrassTile);
        }
        for (int y = midY - 5; y < midY + 5; y++)
        {
            Map.Grid[y][midX - 6].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 6].SetFeature(GetGrassTile);
        }
        for (int y = midY - 6; y < midY + 6; y++)
        {
            Map.Grid[y][midX - 5].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 5].SetFeature(GetGrassTile);
        }
        for (int y = midY - 6; y < midY + 6; y++)
        {
            Map.Grid[y][midX - 4].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 4].SetFeature(GetGrassTile);
        }
        for (int y = midY - 7; y < midY + 6; y++)
        {
            Map.Grid[y][midX - 3].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 3].SetFeature(GetGrassTile);
        }
        for (int y = midY - 7; y < midY + 6; y++)
        {
            Map.Grid[y][midX - 2].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 2].SetFeature(GetGrassTile);
        }
        for (int y = midY - 6; y < midY + 6; y++)
        {
            Map.Grid[y][midX - 1].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX - 1].SetFeature(GetGrassTile);
        }
        for (int y = midY - 7; y < midY + 6; y++)
        {
            Map.Grid[y][midX].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX].SetFeature(GetGrassTile);
        }
        for (int y = midY - 7; y < midY + 6; y++)
        {
            Map.Grid[y][midX + 1].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 1].SetFeature(GetGrassTile);
        }
        for (int y = midY - 6; y < midY + 6; y++)
        {
            Map.Grid[y][midX + 2].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 2].SetFeature(GetGrassTile);
        }
        for (int y = midY - 7; y < midY + 6; y++)
        {
            Map.Grid[y][midX + 3].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 3].SetFeature(GetGrassTile);
        }
        for (int y = midY - 6; y < midY + 6; y++)
        {
            Map.Grid[y][midX + 4].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 4].SetFeature(GetGrassTile);
        }
        for (int y = midY - 5; y < midY + 5; y++)
        {
            Map.Grid[y][midX + 5].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 5].SetFeature(GetGrassTile);
        }
        for (int y = midY - 3; y < midY + 3; y++)
        {
            Map.Grid[y][midX + 6].SetBackgroundFeature(GetGrassTile);
            Map.Grid[y][midX + 6].SetFeature(GetGrassTile);
        }
        Map.Grid[midY - 6][midX].SetFeature(GetRockTile);
        Map.Grid[midY - 6][midX - 1].SetFeature(GetRockTile);
        Map.Grid[midY - 5][midX - 4].SetFeature(GetRockTile);
        Map.Grid[midY - 4][midX - 5].SetFeature(GetRockTile);
        Map.Grid[midY - 1][midX - 6].SetFeature(GetRockTile);
        Map.Grid[midY][midX - 6].SetFeature(GetRockTile);
        Map.Grid[midY + 3][midX - 5].SetFeature(GetRockTile);
        Map.Grid[midY + 4][midX - 4].SetFeature(GetRockTile);
        Map.Grid[midY + 5][midX - 1].SetFeature(GetRockTile);
        Map.Grid[midY + 5][midX].SetFeature(GetRockTile);
        Map.Grid[midY + 4][midX + 3].SetFeature(GetRockTile);
        Map.Grid[midY + 3][midX + 4].SetFeature(GetRockTile);
        Map.Grid[midY][midX + 5].SetFeature(GetRockTile);
        Map.Grid[midY - 1][midX + 5].SetFeature(GetRockTile);
        Map.Grid[midY - 4][midX + 4].SetFeature(GetRockTile);
        Map.Grid[midY - 5][midX + 3].SetFeature(GetRockTile);
    }

    private void MakeLake(int minX, int minY, int width, int height)
    {
        PerlinNoise perlinNoise = new PerlinNoise(RandomBetween(0, int.MaxValue - 1));
        double widthDivisor = 1 / (double)width;
        double heightDivisor = 1 / (double)height;
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GridTile cPtr = Map.Grid[minY + y][minX + x];
                double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                v = (v + 1) / 2;
                double dX = Math.Abs(x - (width / 2)) * widthDivisor;
                double dY = Math.Abs(y - (height / 2)) * heightDivisor;
                double d = Math.Max(dX, dY);
                const double elevation = 0.05;
                const double steepness = 6.0;
                const double dropoff = 50.0;
                v += elevation - (dropoff * Math.Pow(d, steepness));
                v = Math.Min(1, Math.Max(0, v));
                int rounded = (int)(v * 10);
                if (rounded > 3)
                {
                    cPtr.SetBackgroundFeature(GetWaterTile);
                    cPtr.SetFeature(GetWaterTile);
                }
                else if (rounded == 3)
                {
                    cPtr.SetBackgroundFeature(GetGrassTile);
                    cPtr.SetFeature(GetGrassTile);
                }
            }
        }
    }

    private void MakeTower(int left, int top, int width, int height, out int stairX, out int stairY)
    {
        int i;
        int y = top + height;
        int x = left + (width / 2);
        stairX = x;
        stairY = y;
        for (i = -2; i < 3; i++)
        {
            Map.Grid[y][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y][x + i].PlayerMemorized = true;
            Map.Grid[y][x + i].SelfLit = true;
        }
        for (i = -4; i < 5; i++)
        {
            Map.Grid[y - 1][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 1][x + i].PlayerMemorized = true;
            Map.Grid[y - 1][x + i].SelfLit = true;
        }
        for (i = -5; i < 6; i++)
        {
            Map.Grid[y - 2][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 2][x + i].PlayerMemorized = true;
            Map.Grid[y - 2][x + i].SelfLit = true;
        }
        for (i = -6; i < 7; i++)
        {
            Map.Grid[y - 3][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 3][x + i].PlayerMemorized = true;
            Map.Grid[y - 3][x + i].SelfLit = true;
        }
        for (i = -6; i < 7; i++)
        {
            Map.Grid[y - 4][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 4][x + i].PlayerMemorized = true;
            Map.Grid[y - 4][x + i].SelfLit = true;
        }
        for (i = -7; i < 8; i++)
        {
            Map.Grid[y - 5][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 5][x + i].PlayerMemorized = true;
            Map.Grid[y - 5][x + i].SelfLit = true;
        }
        for (i = -7; i < 8; i++)
        {
            Map.Grid[y - 6][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 6][x + i].PlayerMemorized = true;
            Map.Grid[y - 6][x + i].SelfLit = true;
        }
        for (i = -7; i < 8; i++)
        {
            Map.Grid[y - 7][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 7][x + i].PlayerMemorized = true;
            Map.Grid[y - 7][x + i].SelfLit = true;
        }
        for (i = -7; i < 8; i++)
        {
            Map.Grid[y - 8][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 8][x + i].PlayerMemorized = true;
            Map.Grid[y - 8][x + i].SelfLit = true;
        }
        for (i = -7; i < 8; i++)
        {
            Map.Grid[y - 9][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 9][x + i].PlayerMemorized = true;
            Map.Grid[y - 9][x + i].SelfLit = true;
        }
        for (i = -6; i < 7; i++)
        {
            Map.Grid[y - 10][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 10][x + i].PlayerMemorized = true;
            Map.Grid[y - 10][x + i].SelfLit = true;
        }
        for (i = -6; i < 7; i++)
        {
            Map.Grid[y - 11][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 11][x + i].PlayerMemorized = true;
            Map.Grid[y - 11][x + i].SelfLit = true;
        }
        for (i = -5; i < 6; i++)
        {
            Map.Grid[y - 12][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 12][x + i].PlayerMemorized = true;
            Map.Grid[y - 12][x + i].SelfLit = true;
        }
        for (i = -4; i < 5; i++)
        {
            Map.Grid[y - 13][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 13][x + i].PlayerMemorized = true;
            Map.Grid[y - 13][x + i].SelfLit = true;
        }
        for (i = -2; i < 4; i++)
        {
            Map.Grid[y - 14][x + i].SetFeature(SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
            Map.Grid[y - 14][x + i].PlayerMemorized = true;
            Map.Grid[y - 14][x + i].SelfLit = true;
        }
        Map.Grid[y][x].SetFeature(GetUpStaircaseTile);
        Map.Grid[y][x].PlayerMemorized = true;
        Map.Grid[y][x].SelfLit = true;
        for (i = -3; i < 4; i++)
        {
            if (Map.Grid[y + 1][x + i].FeatureType.IsTree)
            {
                Map.Grid[y + 1][x + i].RevertToBackground();
            }
        }
        for (i = -2; i < 3; i++)
        {
            if (Map.Grid[y + 2][x + i].FeatureType.IsTree)
            {
                Map.Grid[y + 2][x + i].RevertToBackground();
            }
        }
    }

    private void MakeTownCentre()
    {
        int xx = CurWid / 2;
        int yy = CurHgt / 2;
        switch (DieRoll(12))
        {
            case 1:
            case 3:
                Map.Grid[yy - 1][xx - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy][xx - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy + 1][xx - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy - 1][xx].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy + 1][xx].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy - 1][xx + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy][xx + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Map.Grid[yy + 1][xx + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                switch (DieRoll(6))
                {
                    case 4:
                    case 1:
                        Map.Grid[yy][xx].RevertToBackground();
                        break;

                    case 2:
                        Map.Grid[yy][xx].SetFeature(SingletonRepository.Get<Tile>(nameof(StatueTile)));
                        break;

                    default:
                        Map.Grid[yy][xx].SetFeature(SingletonRepository.Get<Tile>(nameof(FountainTile)));
                        break;
                }
                return;

            case 2:
            case 8:
            case 9:
            case 12:
                int x = xx - 1;
                if (DieRoll(2) == 1)
                {
                    x = xx + 1;
                }
                int y = yy - 1;
                if (DieRoll(2) == 1)
                {
                    y = yy + 1;
                }
                Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(SignpostTile)));
                break;

            default:
                return;
        }
    }

    private void BuildStores()
    {
        List<string> occupied = new List<string>();
        for (int i = 0; i < CurTown.Stores.Length; i++)
        {
            int x;
            int y;
            do
            {
                x = RandomBetween(0, 3);
                y = RandomBetween(0, 3);
                if ((x == 1 || x == 2 || y == 1 || y == 2) && !occupied.Contains($"{x},{y}"))
                {
                    break;
                }
            } while (true);
            occupied.Add($"{x},{y}");
            BuildStore(CurTown.Stores[i], y, x);
        }

        int maxSpacesRemaining = 4 * 4 - CurTown.Stores.Length;
        for (int i = 0; i < maxSpacesRemaining; i++)
        {
            switch (DieRoll(10))
            {
                case 3:
                case 7:
                case 9:
                    break;

                default:
                    int x;
                    int y;
                    do
                    {
                        x = RandomBetween(0, 3);
                        y = RandomBetween(0, 3);
                        if (!occupied.Contains($"{x},{y}"))
                        {
                            break;
                        }
                    } while (true);
                    occupied.Add($"{x},{y}");

                    if (CurTown.UnusedStoreLotsAreGraveyards)
                    {
                        BuildGraveyard(y, x);
                    }
                    else
                    {
                        BuildField(y, x);
                    }
                    break;
            }
        }
    }

    private void BuildPath()
    {
        int yy = CurHgt / 2;
        for (int x = 1; x < CurWid - 1; x++)
        {
            Map.Grid[yy][x].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        }
        int xx = CurWid / 2;
        for (int y = 1; y < CurHgt - 1; y++)
        {
            Map.Grid[y][xx].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        }
    }

    private void BuildRocks()
    {
        GridTile cPtr;
        for (int n = 0; n < RandomBetween(1, 10) - 6; n++)
        {
            int x = RandomBetween(1, CurWid - 2);
            int y = RandomBetween(1, CurHgt - 2);
            cPtr = Map.Grid[y][x];
            if (cPtr.FeatureType == cPtr.BackgroundFeature)
            {
                cPtr.SetFeature(GetRockTile);
                cPtr.PlayerMemorized = true;
            }
        }
    }

    private void BuildTrees()
    {
        GridTile cPtr;
        for (int n = 0; n < RandomBetween(5, 10); n++)
        {
            int x = RandomBetween(1, CurWid - 2);
            int y = RandomBetween(1, CurHgt - 2);
            cPtr = Map.Grid[y][x];
            if (cPtr.FeatureType == cPtr.BackgroundFeature)
            {
                cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(TreeTile)));
                cPtr.PlayerMemorized = true;
            }
        }
    }

    private void BuildBushes()
    {
        GridTile cPtr;
        for (int n = 0; n < RandomBetween(5, 10); n++)
        {
            int x = RandomBetween(1, CurWid - 2);
            int y = RandomBetween(1, CurHgt - 2);
            cPtr = Map.Grid[y][x];
            if (cPtr.FeatureType == cPtr.BackgroundFeature)
            {
                cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(BushTile)));
                cPtr.PlayerMemorized = true;
            }
        }
    }

    private void AddPaths()
    {
        GridTile cPtr;
        int x = CurWid / 2;
        cPtr = Map.Grid[0][x];
        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
        cPtr.PlayerMemorized = true;
        x = CurWid - 2;
        int y = CurHgt / 2;
        cPtr = Map.Grid[y][x + 1];
        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
        cPtr.PlayerMemorized = true;
        x = CurWid / 2;
        y = CurHgt - 2;
        cPtr = Map.Grid[y + 1][x];
        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
        cPtr.PlayerMemorized = true;
        x = 1;
        y = CurHgt / 2;
        cPtr = Map.Grid[y][0];
        cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
        cPtr.PlayerMemorized = true;
    }

    private GridCoordinate AddStairsDown()
    {
        GridTile cPtr;
        int dummy = 0;
        int x;
        int y;
        do
        {
            dummy++;
            y = RandomBetween(12, 29);
            x = RandomBetween(17, 46);
            if (GridOpenNoItemOrCreature(y, x))
            {
                break;
            }
        } while (true);
        cPtr = Map.Grid[y][x];
        cPtr.SetFeature(GetDownStaircaseTile);
        cPtr.PlayerMemorized = true;
        return new GridCoordinate(x, y);
    }

    private void SetStartingLocation(GridCoordinate downStairsLocation)
    {
        UseFixed = false;
        switch (CameFrom)
        {
            case LevelStartEnum.StartRandom:
                NewPlayerSpot();
                break;

            case LevelStartEnum.StartStairs:
                MapY.IntValue = downStairsLocation.Y;
                MapX.IntValue = downStairsLocation.X;
                break;

            case LevelStartEnum.StartWalk:
                break;

            case LevelStartEnum.StartHouse:
                foreach (Store store in CurTown.Stores)
                {
                    if (store.GetType() != typeof(HomeStoreFactory))
                    {
                        continue;
                    }
                    MapY.IntValue = store.Y;
                    MapX.IntValue = store.X;
                }
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void MakeTownContents()
    {
        UseFixed = true;
        FixedSeed = CurTown.Seed;

        BuildPath();
        BuildStores();
        BuildRocks();
        BuildTrees();
        BuildBushes();
        MakeTownCentre();
        AddPaths();
        GridCoordinate downStairsLocation = AddStairsDown();
        SetStartingLocation(downStairsLocation);
    }

    private void MakeTownWalls()
    {
        int x;
        int y;
        GridTile cPtr;
        for (x = 0; x < CurWid; x++)
        {
            cPtr = Map.Grid[0][x];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            cPtr.PlayerMemorized = true;
            cPtr.SelfLit = true;
            cPtr = Map.Grid[CurHgt - 1][x];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            cPtr.PlayerMemorized = true;
            cPtr.SelfLit = true;
        }
        for (y = 0; y < CurHgt; y++)
        {
            cPtr = Map.Grid[y][0];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            cPtr.PlayerMemorized = true;
            cPtr.SelfLit = true;
            cPtr = Map.Grid[y][CurWid - 1];
            cPtr.SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            cPtr.PlayerMemorized = true;
            cPtr.SelfLit = true;
        }
        Map.Grid[0][(CurWid / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[0][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[0][(CurWid / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[0][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[0][(CurWid / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[0][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[0][(CurWid / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[0][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[1][(CurWid / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[1][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[1][(CurWid / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[1][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[1][(CurWid / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[1][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[1][(CurWid / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[1][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[0][(CurWid / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[0][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[0][(CurWid / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[0][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[0][CurWid / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
        Map.Grid[0][CurWid / 2].PlayerMemorized = true;
        Map.Grid[0][CurWid / 2].SelfLit = true;
        Map.Grid[0][(CurWid / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[0][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[0][(CurWid / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[0][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[0][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[1][(CurWid / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[1][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[1][(CurWid / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[1][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[1][CurWid / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        Map.Grid[1][CurWid / 2].PlayerMemorized = true;
        Map.Grid[1][CurWid / 2].SelfLit = true;
        Map.Grid[1][(CurWid / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[1][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[1][(CurWid / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[1][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[1][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[CurHgt - 1][CurWid / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
        Map.Grid[CurHgt - 1][CurWid / 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][CurWid / 2].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 1][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 2].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) - 1].SelfLit = true;
        Map.Grid[CurHgt - 2][CurWid / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        Map.Grid[CurHgt - 2][CurWid / 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][CurWid / 2].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 1].SelfLit = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].PlayerMemorized = true;
        Map.Grid[CurHgt - 2][(CurWid / 2) + 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 2][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 1][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 1][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 2][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 2][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 1][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 1][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 2][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 2][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 1][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][0].SelfLit = true;
        Map.Grid[CurHgt / 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
        Map.Grid[CurHgt / 2][0].PlayerMemorized = true;
        Map.Grid[CurHgt / 2][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 1][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 2][0].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][0].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 2][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 1][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][1].SelfLit = true;
        Map.Grid[CurHgt / 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        Map.Grid[CurHgt / 2][1].PlayerMemorized = true;
        Map.Grid[CurHgt / 2][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 1][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 2][1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 1].SelfLit = true;
        Map.Grid[CurHgt / 2][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
        Map.Grid[CurHgt / 2][CurWid - 1].PlayerMemorized = true;
        Map.Grid[CurHgt / 2][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 1].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 2][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) - 1][CurWid - 2].SelfLit = true;
        Map.Grid[CurHgt / 2][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        Map.Grid[CurHgt / 2][CurWid - 2].PlayerMemorized = true;
        Map.Grid[CurHgt / 2][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 1][CurWid - 2].SelfLit = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].PlayerMemorized = true;
        Map.Grid[(CurHgt / 2) + 2][CurWid - 2].SelfLit = true;
    }

    private void MakeWildernessFeatures(int wildx, int wildy, out int stairX, out int stairY)
    {
        stairX = CurWid / 2;
        stairY = CurHgt / 2;
        if (wildx == 1 || wildx == 10 || wildy == 1 || wildy == 10)
        {
            return;
        }
        int dungeonX = 0;
        int dungeonY = 0;
        switch (DieRoll(4))
        {
            case 1:
                dungeonX = 0;
                dungeonY = 0;
                break;

            case 2:
                dungeonX = CurWid / 2;
                dungeonY = 0;
                break;

            case 3:
                dungeonX = 0;
                dungeonY = CurHgt / 2;
                break;

            case 4:
                dungeonX = CurWid / 2;
                dungeonY = CurHgt / 2;
                break;
        }
        for (int offsetX = 0; offsetX < CurWid - 1; offsetX += CurWid / 2)
        {
            for (int offsetY = 0; offsetY < CurHgt - 1; offsetY += CurHgt / 2)
            {
                if (offsetX == dungeonX && offsetY == dungeonY)
                {
                    if (Wilderness[wildy][wildx].Dungeon != null)
                    {
                        if (Wilderness[wildy][wildx].Dungeon.Tower)
                        {
                            MakeTower(offsetX + 4, offsetY + 4, (CurWid / 2) - 8, (CurHgt / 2) - 8, out int x, out int y);
                            stairX = x;
                            stairY = y;
                        }
                        else
                        {
                            MakeDungeonEntrance(offsetX + 4, offsetY + 4, (CurWid / 2) - 8, (CurHgt / 2) - 8, out int x, out int y);
                            stairX = x;
                            stairY = y;
                        }
                    }
                }
                else
                {
                    switch (DieRoll(30))
                    {
                        case 7:
                        case 22:
                            MakeLake(offsetX + 4, offsetY + 4, (CurWid / 2) - 8, (CurHgt / 2) - 8);
                            break;

                        case 15:
                            MakeHenge(offsetX + 4, offsetY + 4, (CurWid / 2) - 8, (CurHgt / 2) - 8);
                            break;
                    }
                }
            }
        }
    }

    private void MakeWildernessPaths(int wildx, int wildy)
    {
        int x;
        int y;

        int midX = CurWid / 2;
        int midY = CurHgt / 2;
        if (Wilderness[wildy][wildx].RoadMap == 0)
        {
            return;
        }
        Map.Grid[midY - 1][midX - 1].SetFeature(GetGrassTile);
        Map.Grid[midY - 1][midX].SetFeature(GetGrassTile);
        Map.Grid[midY - 1][midX + 1].SetFeature(GetGrassTile);
        Map.Grid[midY][midX - 1].SetFeature(GetGrassTile);
        Map.Grid[midY][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
        Map.Grid[midY][midX + 1].SetFeature(GetGrassTile);
        Map.Grid[midY + 1][midX - 1].SetFeature(GetGrassTile);
        Map.Grid[midY + 1][midX].SetFeature(GetGrassTile);
        Map.Grid[midY + 1][midX + 1].SetFeature(GetGrassTile);
        if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadUp) != 0)
        {
            x = 0;
            Map.Grid[0][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
            Map.Grid[1][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[midY - 1][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            for (y = 2; y < midY - 1; y++)
            {
                x += RandomBetween(-2, 2) / 2;
                if (x > midY - 1 - y)
                {
                    x = midY - 1 - y;
                }
                if (x < -(midY - 1 - y))
                {
                    x = -(midY - 1 - y);
                }
                if (!Map.Grid[y][midX - 1 + x].FeatureType.IsWildPath)
                {
                    Map.Grid[y][midX - 1 + x].SetFeature(GetGrassTile);
                }
                Map.Grid[y][midX + x].SetFeature(SingletonRepository.Get<Tile>(nameof(WildPathNSTile)));
                if (!Map.Grid[y][midX + 1 + x].FeatureType.IsWildPath)
                {
                    Map.Grid[y][midX + 1 + x].SetFeature(GetGrassTile);
                }
            }
        }
        if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadDown) != 0)
        {
            x = 0;
            Map.Grid[CurHgt - 1][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
            Map.Grid[CurHgt - 2][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[midY + 1][midX].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            for (y = CurHgt - 3; y > midY + 1; y--)
            {
                x += RandomBetween(-2, 2) / 2;
                if (x > y - (midY + 1))
                {
                    x = y - (midY + 1);
                }
                if (x < -(y - (midY + 1)))
                {
                    x = -(y - (midY + 1));
                }
                if (!Map.Grid[y][midX - 1 + x].FeatureType.IsWildPath)
                {
                    Map.Grid[y][midX - 1 + x].SetFeature(GetGrassTile);
                }
                Map.Grid[y][midX + x].SetFeature(SingletonRepository.Get<Tile>(nameof(WildPathNSTile)));
                if (!Map.Grid[y][midX + 1 + x].FeatureType.IsWildPath)
                {
                    Map.Grid[y][midX + 1 + x].SetFeature(GetGrassTile);
                }
            }
        }
        if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadLeft) != 0)
        {
            y = 0;
            Map.Grid[midY][0].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
            Map.Grid[midY][1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[midY][midX - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            for (x = 2; x < midX - 1; x++)
            {
                y += RandomBetween(-2, 2) / 2;
                if (y > midX - 1 - x)
                {
                    y = midX - 1 - x;
                }
                if (y < -(midX - 1 - x))
                {
                    y = -(midX - 1 - x);
                }
                if (!Map.Grid[midY - 1 + y][x].FeatureType.IsWildPath)
                {
                    Map.Grid[midY - 1 + y][x].SetFeature(GetGrassTile);
                }
                Map.Grid[midY + y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(WildPathEWTile)));
                if (!Map.Grid[midY + 1 + y][x].FeatureType.IsWildPath)
                {
                    Map.Grid[midY + 1 + y][x].SetFeature(GetGrassTile);
                }
            }
        }
        if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadRight) != 0)
        {
            y = 0;
            Map.Grid[midY][CurWid - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
            Map.Grid[midY][CurWid - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[midY][midX + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            for (x = CurWid - 3; x > midX + 1; x--)
            {
                y += RandomBetween(-2, 2) / 2;
                if (y > x - (midX + 1))
                {
                    y = x - (midX + 1);
                }
                if (y < -(x - (midX + 1)))
                {
                    y = -(x - (midX + 1));
                }
                if (!Map.Grid[midY - 1 + y][x].FeatureType.IsWildPath)
                {
                    Map.Grid[midY - 1 + y][x].SetFeature(GetGrassTile);
                }
                Map.Grid[midY + y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(WildPathEWTile)));
                if (!Map.Grid[midY + 1 + y][x].FeatureType.IsWildPath)
                {
                    Map.Grid[midY + 1 + y][x].SetFeature(GetGrassTile);
                }
            }
        }
    }

    private void MakeWildernessWalls(int wildX, int wildY)
    {
        int height = CurHgt;
        int width = CurWid;
        if (Wilderness[wildY - 1][wildX].Town != null)
        {
            for (int x = 0; x < width; x++)
            {
                Map.Grid[0][x].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Map.Grid[0][x].PlayerMemorized = true;
                Map.Grid[0][x].SelfLit = true;
            }
            Map.Grid[0][(width / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[0][(width / 2) - 2].SelfLit = true;
            Map.Grid[0][(width / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[0][(width / 2) - 1].SelfLit = true;
            Map.Grid[0][(width / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[0][(width / 2) + 1].SelfLit = true;
            Map.Grid[0][(width / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[0][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[0][(width / 2) + 2].SelfLit = true;
            Map.Grid[1][(width / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[1][(width / 2) - 2].SelfLit = true;
            Map.Grid[1][(width / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[1][(width / 2) - 1].SelfLit = true;
            Map.Grid[1][(width / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[1][(width / 2) + 1].SelfLit = true;
            Map.Grid[1][(width / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[1][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[1][(width / 2) + 2].SelfLit = true;
            Map.Grid[0][(width / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[0][(width / 2) - 2].SelfLit = true;
            Map.Grid[0][(width / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[0][(width / 2) - 1].SelfLit = true;
            Map.Grid[0][width / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
            Map.Grid[0][width / 2].PlayerMemorized = true;
            Map.Grid[0][width / 2].SelfLit = true;
            Map.Grid[0][(width / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[0][(width / 2) + 1].SelfLit = true;
            Map.Grid[0][(width / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[0][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[0][(width / 2) + 2].SelfLit = true;
            Map.Grid[1][(width / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[1][(width / 2) - 2].SelfLit = true;
            Map.Grid[1][(width / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[1][(width / 2) - 1].SelfLit = true;
            Map.Grid[1][width / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[1][width / 2].PlayerMemorized = true;
            Map.Grid[1][width / 2].SelfLit = true;
            Map.Grid[1][(width / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[1][(width / 2) + 1].SelfLit = true;
            Map.Grid[1][(width / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[1][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[1][(width / 2) + 2].SelfLit = true;
        }
        if (Wilderness[wildY + 1][wildX].Town != null)
        {
            for (int x = 0; x < width; x++)
            {
                Map.Grid[height - 1][x].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Map.Grid[height - 1][x].PlayerMemorized = true;
                Map.Grid[height - 1][x].SelfLit = true;
            }
            Map.Grid[height - 1][(width / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) - 2].SelfLit = true;
            Map.Grid[height - 1][(width / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) - 1].SelfLit = true;
            Map.Grid[height - 1][(width / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) + 1].SelfLit = true;
            Map.Grid[height - 1][(width / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 1][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) + 2].SelfLit = true;
            Map.Grid[height - 2][(width / 2) - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) - 2].SelfLit = true;
            Map.Grid[height - 2][(width / 2) - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) - 1].SelfLit = true;
            Map.Grid[height - 2][(width / 2) + 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) + 1].SelfLit = true;
            Map.Grid[height - 2][(width / 2) + 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[height - 2][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) + 2].SelfLit = true;
            Map.Grid[height - 1][(width / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) - 2].SelfLit = true;
            Map.Grid[height - 1][(width / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) - 1].SelfLit = true;
            Map.Grid[height - 1][width / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
            Map.Grid[height - 1][width / 2].PlayerMemorized = true;
            Map.Grid[height - 1][width / 2].SelfLit = true;
            Map.Grid[height - 1][(width / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) + 1].SelfLit = true;
            Map.Grid[height - 1][(width / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 1][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[height - 1][(width / 2) + 2].SelfLit = true;
            Map.Grid[height - 2][(width / 2) - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][(width / 2) - 2].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) - 2].SelfLit = true;
            Map.Grid[height - 2][(width / 2) - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][(width / 2) - 1].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) - 1].SelfLit = true;
            Map.Grid[height - 2][width / 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[height - 2][width / 2].PlayerMemorized = true;
            Map.Grid[height - 2][width / 2].SelfLit = true;
            Map.Grid[height - 2][(width / 2) + 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][(width / 2) + 1].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) + 1].SelfLit = true;
            Map.Grid[height - 2][(width / 2) + 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[height - 2][(width / 2) + 2].PlayerMemorized = true;
            Map.Grid[height - 2][(width / 2) + 2].SelfLit = true;
        }
        if (Wilderness[wildY][wildX - 1].Town != null)
        {
            for (int y = 0; y < height; y++)
            {
                Map.Grid[y][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Map.Grid[y][0].PlayerMemorized = true;
                Map.Grid[y][0].SelfLit = true;
            }
            Map.Grid[(height / 2) - 2][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 2][0].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][0].SelfLit = true;
            Map.Grid[(height / 2) - 1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 1][0].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][0].SelfLit = true;
            Map.Grid[(height / 2) + 1][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 1][0].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][0].SelfLit = true;
            Map.Grid[(height / 2) + 2][0].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 2][0].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][0].SelfLit = true;
            Map.Grid[(height / 2) - 2][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 2][1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][1].SelfLit = true;
            Map.Grid[(height / 2) - 1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 1][1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][1].SelfLit = true;
            Map.Grid[(height / 2) + 1][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 1][1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][1].SelfLit = true;
            Map.Grid[(height / 2) + 2][1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 2][1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][1].SelfLit = true;
            Map.Grid[(height / 2) - 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 2][0].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][0].SelfLit = true;
            Map.Grid[(height / 2) - 1][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 1][0].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][0].SelfLit = true;
            Map.Grid[height / 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
            Map.Grid[height / 2][0].PlayerMemorized = true;
            Map.Grid[height / 2][0].SelfLit = true;
            Map.Grid[(height / 2) + 1][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 1][0].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][0].SelfLit = true;
            Map.Grid[(height / 2) + 2][0].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 2][0].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][0].SelfLit = true;
            Map.Grid[(height / 2) - 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 2][1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][1].SelfLit = true;
            Map.Grid[(height / 2) - 1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 1][1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][1].SelfLit = true;
            Map.Grid[height / 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[height / 2][1].PlayerMemorized = true;
            Map.Grid[height / 2][1].SelfLit = true;
            Map.Grid[(height / 2) + 1][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 1][1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][1].SelfLit = true;
            Map.Grid[(height / 2) + 2][1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 2][1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][1].SelfLit = true;
        }
        if (Wilderness[wildY][wildX + 1].Town != null)
        {
            for (int y = 0; y < height; y++)
            {
                Map.Grid[y][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Map.Grid[y][width - 1].PlayerMemorized = true;
                Map.Grid[y][width - 1].SelfLit = true;
            }
            Map.Grid[(height / 2) - 2][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 2][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][width - 1].SelfLit = true;
            Map.Grid[(height / 2) - 1][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 1][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][width - 1].SelfLit = true;
            Map.Grid[(height / 2) + 1][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 1][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][width - 1].SelfLit = true;
            Map.Grid[(height / 2) + 2][width - 1].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 2][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][width - 1].SelfLit = true;
            Map.Grid[(height / 2) - 2][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 2][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][width - 2].SelfLit = true;
            Map.Grid[(height / 2) - 1][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) - 1][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][width - 2].SelfLit = true;
            Map.Grid[(height / 2) + 1][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 1][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][width - 2].SelfLit = true;
            Map.Grid[(height / 2) + 2][width - 2].SetBackgroundFeature(SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
            Map.Grid[(height / 2) + 2][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][width - 2].SelfLit = true;
            Map.Grid[(height / 2) - 2][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 2][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][width - 1].SelfLit = true;
            Map.Grid[(height / 2) - 1][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 1][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][width - 1].SelfLit = true;
            Map.Grid[height / 2][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
            Map.Grid[height / 2][width - 1].PlayerMemorized = true;
            Map.Grid[height / 2][width - 1].SelfLit = true;
            Map.Grid[(height / 2) + 1][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 1][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][width - 1].SelfLit = true;
            Map.Grid[(height / 2) + 2][width - 1].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 2][width - 1].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][width - 1].SelfLit = true;
            Map.Grid[(height / 2) - 2][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 2][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) - 2][width - 2].SelfLit = true;
            Map.Grid[(height / 2) - 1][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) - 1][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) - 1][width - 2].SelfLit = true;
            Map.Grid[height / 2][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
            Map.Grid[height / 2][width - 2].PlayerMemorized = true;
            Map.Grid[height / 2][width - 2].SelfLit = true;
            Map.Grid[(height / 2) + 1][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 1][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) + 1][width - 2].SelfLit = true;
            Map.Grid[(height / 2) + 2][width - 2].SetFeature(SingletonRepository.Get<Tile>(nameof(TownWallTile)));
            Map.Grid[(height / 2) + 2][width - 2].PlayerMemorized = true;
            Map.Grid[(height / 2) + 2][width - 2].SelfLit = true;
        }
    }

    public bool NewPlayerSpot()
    {
        int y = 0;
        int x = 0;
        int maxAttempts = 5000;
        while (maxAttempts-- != 0)
        {
            y = RandomBetween(1, CurHgt - 2);
            x = RandomBetween(1, CurWid - 2);
            if (!GridOpenNoItemOrCreature(y, x))
            {
                continue;
            }
            if (Map.Grid[y][x].InVault)
            {
                continue;
            }
            break;
        }
        if (maxAttempts < 1)
        {
            return false;
        }
        MapY.IntValue = y;
        MapX.IntValue = x;
        return true;
    }

    public void PlaceRandomDoor(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        WeightedRandom<Tile> doorTiles = new WeightedRandom<Tile>(this);
        doorTiles.Add(2400, SingletonRepository.Get<Tile>(nameof(OpenDoorTile)));
        doorTiles.Add(800, SingletonRepository.Get<Tile>(nameof(BrokenDoorTile)));
        doorTiles.Add(1600, SingletonRepository.Get<Tile>(nameof(SecretDoorTile)));
        doorTiles.Add(2400, SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor1Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor2Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor3Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor4Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor5Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor6Tile)));
        doorTiles.Add(136, SingletonRepository.Get<Tile>(nameof(LockedDoor7Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor0Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor1Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor2Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor3Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor4Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor5Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor6Tile)));
        doorTiles.Add(1, SingletonRepository.Get<Tile>(nameof(JammedDoor7Tile)));
        Tile door = doorTiles.Choose();
        cPtr.SetFeature(door);
    }

    private void ResolvePaths()
    {
        for (int x = 1; x < CurWid - 1; x++)
        {
            for (int y = 1; y < CurHgt - 1; y++)
            {
                if (!Map.Grid[y][x].FeatureType.IsPathBase)
                {
                    continue;
                }
                int map = 0;
                if (Map.Grid[y - 1][x].FeatureType.IsPath)
                {
                    map++;
                }
                if (Map.Grid[y][x + 1].FeatureType.IsPath)
                {
                    map += 2;
                }
                if (Map.Grid[y + 1][x].FeatureType.IsPath)
                {
                    map += 4;
                }
                if (Map.Grid[y][x - 1].FeatureType.IsPath)
                {
                    map += 8;
                }
                switch (map)
                {
                    case 1:
                    case 4:
                    case 5:
                        Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(PathNSTile)));
                        break;

                    case 2:
                    case 8:
                    case 10:
                        Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(PathEWTile)));
                        break;

                    default:
                        Map.Grid[y][x].SetFeature(SingletonRepository.Get<Tile>(nameof(PathJunctionTile)));
                        break;
                }
            }
        }
    }

    private void TownGen()
    {
        for (int y = 0; y < CurHgt; y++)
        {
            for (int x = 0; x < CurWid; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
        MakeTownWalls();
        MakeCornerTowers(WildernessX, WildernessY);
        MakeTownContents();
        ResolvePaths();
        if (IsLight)
        {
            for (int y = 0; y < CurHgt; y++)
            {
                for (int x = 0; x < CurWid; x++)
                {
                    GridTile cPtr = Map.Grid[y][x];
                    cPtr.SelfLit = true;
                    cPtr.PlayerMemorized = true;
                }
            }
            for (int i = 0; i < Constants.MinMAllocTd; i++)
            {
                AllocMonster(3, true);
            }
        }
        else
        {
            for (int i = 0; i < Constants.MinMAllocTn; i++)
            {
                AllocMonster(3, true);
            }
        }
    }

    private void WildernessGen()
    {
        UseFixed = true;
        FixedSeed = this.Wilderness[this.WildernessY][this.WildernessX].Seed;
        int x;
        int y;
        for (y = 0; y < CurHgt; y++)
        {
            for (x = 0; x < CurWid; x++)
            {
                byte elevation = Elevation(WildernessY, WildernessX, y, x);
                Tile floorTile = GetWaterTile;
                Tile featureTile = GetWaterTile;
                if (elevation > 0)
                {
                    floorTile = GetGrassTile;
                    if (DieRoll(10) < elevation)
                    {
                        if (DieRoll(10) < elevation)
                        {
                            featureTile = SingletonRepository.Get<Tile>(nameof(TreeTile));
                        }
                        else
                        {
                            featureTile = SingletonRepository.Get<Tile>(nameof(BushTile));
                        }
                    }
                    else
                    {
                        featureTile = GetGrassTile;
                    }
                }
                Map.Grid[y][x].SetFeature(featureTile);
                Map.Grid[y][x].SetBackgroundFeature(floorTile);
            }
        }
        for (x = 0; x < CurWid; x++)
        {
            GridTile cPtr = Map.Grid[0][x];
            cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
            cPtr = Map.Grid[CurHgt - 1][x];
            cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
        }
        for (y = 0; y < CurHgt; y++)
        {
            GridTile cPtr = Map.Grid[y][0];
            cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
            cPtr = Map.Grid[y][CurWid - 1];
            cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
        }
        MakeWildernessWalls(this.WildernessX, this.WildernessY);
        MakeCornerTowers(this.WildernessX, this.WildernessY);
        MakeWildernessPaths(this.WildernessX, this.WildernessY);
        MakeWildernessFeatures(this.WildernessX, this.WildernessY, out int stairX, out int stairY);
        int rocks = RandomBetween(1, 10);
        for (int i = 0; i < rocks; i++)
        {
            x = DieRoll(CurWid - 2);
            y = DieRoll(CurHgt - 2);
            if (!Map.Grid[y][x].FeatureType.IsGrass)
            {
                continue;
            }
            Map.Grid[y][x].SetFeature(GetRockTile);
        }
        UseFixed = false;
        if (CameFrom == LevelStartEnum.StartRandom)
        {
            NewPlayerSpot();
        }
        else if (CameFrom == LevelStartEnum.StartStairs)
        {
            this.MapY.IntValue = stairY;
            this.MapX.IntValue = stairX;
        }
        else if (CameFrom == LevelStartEnum.StartWalk)
        {
            if (Map.Grid[this.MapY.IntValue][this.MapX.IntValue].FeatureType.IsTree || Map.Grid[this.MapY.IntValue][this.MapX.IntValue].FeatureType.IsWater)
            {
                Map.Grid[this.MapY.IntValue][this.MapX.IntValue].RevertToBackground();
            }
        }
        ResolvePaths();
        for (y = 1; y < CurHgt - 1; y++)
        {
            for (x = 1; x < CurWid - 1; x++)
            {
                if (Map.Grid[y][x].FeatureType.IsOpenFloor)
                {
                    Map.Grid[y][x].InRoom = true;
                }
            }
        }
        if (IsLight)
        {
            for (y = 0; y < CurHgt; y++)
            {
                for (x = 0; x < CurWid; x++)
                {
                    Map.Grid[y][x].SelfLit = true;
                    Map.Grid[y][x].PlayerMemorized = true;
                }
            }
        }
        for (x = 0; x < Constants.MinMAllocLevel; x++)
        {
            AllocMonster(3, true);
        }
        ///LEVEL FACTORY
    }

    public bool GetDirectionNoAim(out int dp)
    {
        dp = 0;
        int dir = CommandDirection;
        while (dir == 0)
        {
            if (!GetCom("Direction (Escape to cancel)? ", out char ch))
            {
                break;
            }
            dir = GetKeymapDir(ch);
        }
        if (dir == 5)
        {
            dir = 0;
        }
        if (dir == 0)
        {
            return false;
        }
        CommandDirection = dir;
        if (ConfusionTimer.Value != 0)
        {
            if (RandomLessThan(100) < 75)
            {
                dir = OrderedDirection[RandomLessThan(8)]; // Choose a random direction
            }
        }
        if (CommandDirection != dir)
        {
            MsgPrint("You are confused.");
        }
        dp = dir;
        return true;
    }

    public bool GetDirectionWithAim(out int dp)
    {
        dp = 0;
        int dir = 0;
        while (dir == 0)
        {
            string p = "Direction ('*' to choose a target, Escape to cancel)? ";
            if (TargetWho != null && TargetWho.GetTargetLocation() != null)
            {
                p = "Direction ('5' for target, '*' to re-target, Escape to cancel)? ";
            }
            if (!GetCom(p, out char command))
            {
                break;
            }
            switch (command)
            {
                case 'T':
                case 't':
                case '.':
                case '5':
                case '0':
                    {
                        dir = 5;
                        break;
                    }
                case '*':
                    {
                        if (TargetSet(Constants.TargetKill))
                        {
                            dir = 5;
                        }
                        break;
                    }
                default:
                    {
                        dir = GetKeymapDir(command);
                        break;
                    }
            }
            if (dir == 5 && (TargetWho == null || TargetWho.GetTargetLocation() == null))
            {
                dir = 0;
            }
        }
        if (dir == 0)
        {
            return false;
        }
        CommandDirection = dir;
        if (ConfusionTimer.Value != 0)
        {
            dir = OrderedDirection[RandomLessThan(8)]; // Choose a random direction.
        }
        if (CommandDirection != dir)
        {
            MsgPrint("You are confused.");
        }
        dp = dir;
        return true;
    }

    public bool TargetSet(int mode)
    {
        int y = MapY.IntValue;
        int x = MapX.IntValue;
        bool done = false;
        TargetWho = null;
        TargetSetPrepare(mode);
        int m = 0;
        if (TempN != 0)
        {
            y = TempY[m];
            x = TempX[m];
        }
        while (!done)
        {
            GridTile cPtr = Map.Grid[y][x];
            string info = "l,*";
            if (TargetAble(cPtr.MonsterIndex))
            {
                info = $"t,{info}";
            }
            char query = TargetSetAux(y, x, mode | Constants.TargetLook, info);
            switch (query)
            {
                case '\x1b':
                    {
                        done = true;
                        break;
                    }
                case 't':
                    {
                        if (TargetAble(cPtr.MonsterIndex))
                        {
                            HealthTrack(cPtr.MonsterIndex);
                            TargetWho = new MonsterTarget(this, Monsters[cPtr.MonsterIndex]);
                            done = true;
                        }
                        break;
                    }
                case 'l':
                    TargetWho = new LocationTarget(new GridCoordinate(x, y));
                    done = true;
                    break;

                case '*':
                    {
                        if (x == TempX[m] && y == TempY[m])
                        {
                            if (++m >= TempN)
                            {
                                m = 0;
                                done = true;
                            }
                            else
                            {
                                y = TempY[m];
                                x = TempX[m];
                            }
                        }
                        else
                        {
                            y = TempY[m];
                            x = TempX[m];
                        }
                        break;
                    }
                default:
                    {
                        int d = GetKeymapDir(query);
                        if (d != 0)
                        {
                            x += KeypadDirectionXOffset[d];
                            y += KeypadDirectionYOffset[d];
                            if (x >= CurWid - 1 || x > PanelColMax)
                            {
                                x--;
                            }
                            else if (x <= 0 || x < PanelColMin)
                            {
                                x++;
                            }
                            if (y >= CurHgt - 1 || y > PanelRowMax)
                            {
                                y--;
                            }
                            else if (y <= 0 || y < PanelRowMin)
                            {
                                y++;
                            }
                        }
                        break;
                    }
            }
        }
        TempN = 0;
        MsgClear();
        return TargetWho != null;
    }

    public bool TgtPt(out int x, out int y)
    {
        char ch = '\0';
        bool success = false;
        x = MapX.IntValue;
        y = MapY.IntValue;
        bool cv = Screen.CursorVisible;
        Screen.CursorVisible = true;
        MsgPrint("Select a point and press space.");
        while (ch != 27 && ch != ' ' && !Shutdown)
        {
            ConsoleView.MoveCursorTo(y, x);
            ch = Inkey();
            switch (ch)
            {
                case '\x1b':
                    break;

                case ' ':
                    success = true;
                    break;

                default:
                    {
                        int d = GetKeymapDir(ch);
                        if (d == 0)
                        {
                            break;
                        }
                        x += KeypadDirectionXOffset[d];
                        y += KeypadDirectionYOffset[d];
                        if (x >= CurWid - 1 || x >= PanelColMin + Constants.PlayableScreenWidth)
                        {
                            x--;
                        }
                        else if (x <= 0 || x < PanelColMin)
                        {
                            x++;
                        }
                        if (y >= CurHgt - 1 || y >= PanelRowMin + Constants.PlayableScreenHeight)
                        {
                            y--;
                        }
                        else if (y <= 0 || y < PanelRowMin)
                        {
                            y++;
                        }
                        break;
                    }
            }
        }
        Screen.CursorVisible = cv;
        UpdateScreen();
        return success;
    }

    private string LookMonDesc(int mIdx)
    {
        Monster mPtr = Monsters[mIdx];
        MonsterRace rPtr = mPtr.Race;
        bool living = !rPtr.Undead;
        if (rPtr.Demon)
        {
            living = false;
        }
        if (rPtr.Cthuloid)
        {
            living = false;
        }
        if (rPtr.Nonliving)
        {
            living = false;
        }
        if ("Egv".Contains(rPtr.Symbol.Character.ToString()))
        {
            living = false;
        }
        if (mPtr.Health >= mPtr.MaxHealth)
        {
            return living ? "unhurt" : "undamaged";
        }
        int perc = 100 * mPtr.Health / mPtr.MaxHealth;
        if (perc >= 60)
        {
            return living ? "somewhat wounded" : "somewhat damaged";
        }
        if (perc >= 25)
        {
            return living ? "wounded" : "damaged";
        }
        if (perc >= 10)
        {
            return living ? "badly wounded" : "badly damaged";
        }
        return living ? "almost dead" : "almost destroyed";
    }

    /// <summary>
    /// Returns true, if a monster can be targeted; false, otherwise.  Monsters cannot be targeted in they are not visible, is within a maximum range, has a line-of-sight
    /// that is passable and that the line-of-sight does not pass through a YellowSignSigilTile and the player is not hallucinating.
    /// </summary>
    /// <param name="mIdx"></param>
    /// <returns></returns>
    [Obsolete("Use TargetAble(Monster)")]
    private bool TargetAble(int mIdx)
    {
        Monster mPtr = Monsters[mIdx];
        return TargetAble(mPtr);
    }

    public bool TargetAble(Monster mPtr)
    {
        if (mPtr.Race == null)
        {
            return false;
        }
        if (!mPtr.IsVisible)
        {
            return false;
        }
        if (!Projectable(MapY.IntValue, MapX.IntValue, mPtr.MapY, mPtr.MapX))
        {
            return false;
        }
        if (HallucinationsTimer.Value != 0)
        {
            return false;
        }
        return true;
    }

    private bool TargetSetAccept(int y, int x)
    {
        if (y == MapY.IntValue && x == MapX.IntValue)
        {
            return true;
        }
        if (HallucinationsTimer.Value != 0)
        {
            return false;
        }
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.MonsterIndex != 0)
        {
            Monster mPtr = Monsters[cPtr.MonsterIndex];
            if (mPtr.IsVisible)
            {
                return true;
            }
        }
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.WasNoticed)
            {
                return true;
            }
        }
        if (cPtr.PlayerMemorized)
        {
            return cPtr.FeatureType.IsInteresting;
        }
        return false;
    }

    private char TargetSetAux(int y, int x, int mode, string info)
    {
        GridTile cPtr = Map.Grid[y][x];
        char query;
        do
        {
            query = ' ';
            bool boring = true;
            string s1 = "You see ";
            string s2 = "";
            string s3 = "";
            if (y == MapY.IntValue && x == MapX.IntValue)
            {
                s1 = "You are ";
                s2 = "on ";
            }
            string outVal;
            if (HallucinationsTimer.Value != 0)
            {
                const string name = "something strange";
                outVal = $"{s1}{s2}{s3}{name} [{info}]";
                Screen.PrintLine(outVal, 0, 0);
                ConsoleView.MoveCursorTo(y, x);
                query = Inkey();
                if (!Shutdown)
                {
                    break;
                }

                if (query != '\r' && query != '\n')
                {
                    break;
                }
                continue;
            }
            if (cPtr.MonsterIndex != 0)
            {
                Monster mPtr = Monsters[cPtr.MonsterIndex];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.IsVisible)
                {
                    bool recall = false;
                    boring = false;
                    string mName = mPtr.IndefinitionWhenVisibleName;
                    HealthTrack(cPtr.MonsterIndex);
                    HandleStuff();
                    while (!Shutdown)
                    {
                        if (recall)
                        {
                            ScreenBuffer savedScreen = Screen.Clone();
                            rPtr.Knowledge.Display();
                            Screen.Print(ColorEnum.White, $"  [r,{info}]");
                            query = Inkey();
                            Screen.Restore(savedScreen);
                        }
                        else
                        {
                            string c = mPtr.SmCloned ? " (clone)" : "";
                            string a = mPtr.IsPet ? " (allied) " : " ";
                            outVal = $"{s1}{s2}{s3}{mName} ({LookMonDesc(cPtr.MonsterIndex)}){c}{a}[r,{info}]";
                            Screen.PrintLine(outVal, 0, 0);
                            ConsoleView.MoveCursorTo(y, x);
                            query = Inkey();
                        }
                        if (query != 'r')
                        {
                            break;
                        }
                        recall = !recall;
                    }
                    if (query != '\r' && query != '\n' && query != ' ')
                    {
                        break;
                    }
                    if (query == ' ' && (mode & Constants.TargetLook) == 0)
                    {
                        break;
                    }
                    s1 = "It is ";
                    if (rPtr.Female)
                    {
                        s1 = "She is ";
                    }
                    else if (rPtr.Male)
                    {
                        s1 = "He is ";
                    }
                    s2 = "carrying ";
                    bool exitWhile = false;
                    foreach (Item oPtr in mPtr.Items) 
                    {
                        string oName = oPtr.GetFullDescription(true);
                        outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                        Screen.PrintLine(outVal, 0, 0);
                        Screen.UpdateScreen();
                        ConsoleView.MoveCursorTo(y, x);
                        query = Inkey();
                        if (query != '\r' && query != '\n' && query != ' ')
                        {
                            exitWhile = true;
                            break;
                        }
                        if (query == ' ' && (mode & Constants.TargetLook) == 0)
                        {
                            exitWhile = true;
                            break;
                        }
                        s2 = "also carrying ";
                    }
                    if (exitWhile)
                    {
                        break;
                    }
                    s2 = "on ";
                }
            }
            bool exitDo = false;
            foreach (Item oPtr in cPtr.Items)
            {
                if (oPtr.WasNoticed)
                {
                    boring = false;
                    string oName = oPtr.GetFullDescription(true);
                    outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                    Screen.PrintLine(outVal, 0, 0);
                    ConsoleView.MoveCursorTo(y, x);
                    query = Inkey();
                    if (query != '\r' && query != '\n' && query != ' ')
                    {
                        exitDo = true;
                        break;
                    }
                    if (query == ' ' && (mode & Constants.TargetLook) == 0)
                    {
                        exitDo = true;
                        break;
                    }
                    s1 = "It is ";
                    if (oPtr.StackCount != 1)
                    {
                        s1 = "They are ";
                    }
                    s2 = "on ";
                }
            }
            if (exitDo)
            {
                break;
            }
            Tile? feat = cPtr.FeatureType.MimicTile == null ? cPtr.FeatureType : cPtr.FeatureType.MimicTile;
            if (!cPtr.PlayerMemorized && !PlayerCanSeeBold(y, x))
            {
                feat = null;
            }
            if (boring || (!cPtr.FeatureType.IsOpenFloor))
            {
                string name = "unknown grid";
                if (feat != null)
                {
                    name = feat.Description;
                    if (s2 != "" && cPtr.FeatureType.BlocksLos)
                    {
                        s2 = "in ";
                    }
                }
                s3 = name[0].IsVowel() ? "an " : "a ";
                if (cPtr.FeatureType.IsShop)
                {
                    s3 = name[0].IsVowel() ? "the entrance to an " : "the entrance to a ";
                }
                outVal = $"{s1}{s2}{s3}{name} [{info}]";
                Screen.PrintLine(outVal, 0, 0);
                ConsoleView.MoveCursorTo(y, x);
                query = Inkey();
                if (query != '\r' && query != '\n' && query != ' ')
                {
                    break;
                }
            }
        }
        while (query == '\r' || query == '\n');
        return query;
    }

    private void TargetSetPrepare(int mode)
    {
        int y;
        TempN = 0;
        for (y = PanelRowMin; y <= PanelRowMax; y++)
        {
            int x;
            for (x = PanelColMin; x <= PanelColMax; x++)
            {
                GridTile cPtr = Map.Grid[y][x];
                if (!GridTileIsVisible(y, x))
                {
                    continue;
                }
                if (!TargetSetAccept(y, x))
                {
                    continue;
                }
                if ((mode & Constants.TargetKill) != 0 && !TargetAble(cPtr.MonsterIndex))
                {
                    continue;
                }
                TempX[TempN] = x;
                TempY[TempN] = y;
                TempN++;
            }
        }
        List<TargetLocation> list = new List<TargetLocation>();
        for (int i = 0; i < TempN; i++)
        {
            int distance = Distance(TempY[i], TempX[i], MapY.IntValue, MapX.IntValue);
            list.Add(new TargetLocation(TempY[i], TempX[i], distance));
        }
        list.Sort();
        for (int i = 0; i < TempN; i++)
        {
            TempX[i] = list[i].X;
            TempY[i] = list[i].Y;
        }
    }

    public bool IsMartialArtistAndNotWieldingAMeleeWeapon()
    {
        return BaseCharacterClass.IsMartialArtist && GetInventoryItem(InventorySlotEnum.MeleeWeapon) == null;
    }

    public bool MartialArtistHeavyArmor()
    {
        int martialArtistArmWgt = 0;
        if (!BaseCharacterClass.IsMartialArtist)
        {
            return false;
        }
        foreach (WieldSlot inventorySlot in SingletonRepository.Get<WieldSlot>())
        {
            if (inventorySlot.IsArmor)
            {
                foreach (int index in inventorySlot)
                {
                    Item? item = GetInventoryItem(index);
                    if (item != null)
                    {
                        martialArtistArmWgt += item.EffectivePropertySet.Weight;
                    }
                    //foreach (Item item in inventorySlot)
                    //{
                    //    martialArtistArmWgt += item.Weight;
                    //}
                }
            }
        }
        return martialArtistArmWgt > 100 + (ExperienceLevel.IntValue * 4);
    }

    public string RealmNames(Realm? primaryRealm, Realm? secondaryRealm, string defaultTitle = "None")
    {
        if (primaryRealm != null && secondaryRealm != null)
        {
            return primaryRealm.Name + "/" + secondaryRealm.Name;
        }
        else if (primaryRealm != null)
        {
            return primaryRealm.Name;
        }
        else
        {
            return defaultTitle;
        }
    }

    public void SummonNamedMonster(bool slp)
    {
        int rIdx = CommandArgument;
        if (rIdx >= SingletonRepository.Count<MonsterRace>() - 1)
        {
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            const int d = 1;
            (int y, int x) = Scatter(MapY.IntValue, MapX.IntValue, d);
            if (!GridPassableNoCreature(y, x))
            {
                continue;
            }
            if (PlaceMonsterByIndex(y, x, rIdx, slp, true, false))
            {
                break;
            }
        }
    }

    public void DoCmdWizNamedFriendly(bool slp)
    {
        int rIdx = CommandArgument;
        if (rIdx >= SingletonRepository.Count<MonsterRace>() - 1)
        {
            return;
        }
        for (int i = 0; i < 10; i++)
        {
            const int d = 1;
            (int y, int x) = Scatter(MapY.IntValue, MapX.IntValue, d);
            if (!GridPassableNoCreature(y, x))
            {
                continue;
            }
            if (PlaceMonsterByIndex(y, x, rIdx, slp, true, true))
            {
                break;
            }
        }
    }
 
    /// <summary>
    /// Returns the quest number for the current dungeon and the current 
    /// </summary>
    /// <returns></returns>
    public int GetQuestNumber()
    {
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].Level == CurrentDepth &&
                Quests[i].Dungeon == CurDungeon)
            {
                return i;
            }
        }
        return -1;
    }

    public bool IsQuest(int level)
    {
        // Town levels cannot be quest levels.
        if (level == 0)
        {
            return false;
        }
        foreach (Quest quest in Quests)
        {
            if (quest.Level == level && quest.Dungeon == CurDungeon)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// 1. Resets the OnlyGuardian flag for all monster races.  
    /// 2. Clears the quests and creates _maxQuests (50) quests.
    /// 3. Creates a quest for all of the quests (24) for all of the dungeons (20).
    /// </summary>
    private void InitializeQuests()
    {
        ResetUniqueOnlyGuardianStatus();
        int questIndex = 0;
        Quests.Clear();
        for (int i = 0; i < _maxQuests; i++)
        {
            Quests.Add(new Quest(this));
        }

        // These are the fixed quests
        for (int i = 0; i < DungeonCount; i++)
        {
            foreach (DungeonGuardian dungeonGuardian in SingletonRepository.Get<Dungeon>(i).DungeonGuardians)
            {
                Quests[questIndex].Level = dungeonGuardian.LevelFound;
                Quests[questIndex].RIdx = dungeonGuardian.MonsterRace.Index;
                SingletonRepository.Get<MonsterRace>(Quests[questIndex].RIdx).OnlyGuardian = true;
                Quests[questIndex].Dungeon = SingletonRepository.Get<Dungeon>(i);
                Quests[questIndex].ToKill = 1;
                Quests[questIndex].Killed = 0;
                questIndex++;
            }
        }

        // These are the random quests
        for (int i = 0; i < _maxQuests - questIndex; i++)
        {
            do
            {
                bool sameLevel;
                do
                {
                    // Find a valid random quest monster.
                    do
                    {
                        Quests[questIndex].RIdx = GetRandomQuestMonster(questIndex);
                    } while (Quests[questIndex].RIdx == 0);

                    // Assign the quest level as the level of the monster that was chosen.
                    Quests[questIndex].Level = SingletonRepository.Get<MonsterRace>(Quests[questIndex].RIdx).Level;

                    // Adjust the quest level between 2 and 1/6 the quest levels.
                    Quests[questIndex].Level -= RandomBetween(2, 3 + (Quests[questIndex].Level / 6));

                    // Scan all of the previous quests to see if a quest is already on the same level.  Do not allow same level quests.
                    sameLevel = false;
                    for (int j = 0; j < questIndex; j++)
                    {
                        if (Quests[questIndex].Level == Quests[j].Level)
                        {
                            sameLevel = true;
                            break;
                        }
                    }
                } while (sameLevel);

                // If the monster race select is a unique, turn on the only guardian flag.
                if (SingletonRepository.Get<MonsterRace>(Quests[questIndex].RIdx).Unique)
                {
                    SingletonRepository.Get<MonsterRace>(Quests[questIndex].RIdx).OnlyGuardian = true;
                }

                // We need to attach the quest to a dungeon.  To do this, we need to find a qualifying dungeon.  To qualify, a dungeon:
                // 1. cannot start at a level that is at or past the quest level; the dungeon must have at least one level prior to the start of the quest;
                // 2. has to have enough levels that it includes the quest level
                // 3. the random quest cannot be on the same level as any of the dungeon guardians for that dungeon

                // Determine which dungeons are still available to choose from.
                List<Dungeon> dungeonList = new List<Dungeon>();
                foreach (Dungeon dungeon in SingletonRepository.Get<Dungeon>())
                {
                    if (Quests[questIndex].Level <= dungeon.Offset)
                    {
                        continue;
                    }
                    if (Quests[questIndex].Level > dungeon.MaxLevel + dungeon.Offset)
                    {
                        continue;
                    }
                    if (dungeon.DungeonGuardians.Where(_dungeonGuardian => _dungeonGuardian.LevelFound + dungeon.Offset == Quests[questIndex].Level).Count() > 0)
                    {
                        continue;
                    }
                    dungeonList.Add(dungeon);
                }

                // Check to see if there are any dungeons to choose from.
                if (dungeonList.Count > 0)
                {
                    // Choose a dungeon.
                    int ii = RandomLessThan(dungeonList.Count);
                    Dungeon chosenDungeon = dungeonList[ii];

                    // Attach the random quest to the dungeon.
                    Quests[questIndex].Dungeon = chosenDungeon;
                    Quests[questIndex].Level -= chosenDungeon.Offset;
                    Quests[questIndex].ToKill = GetNumberMonster(questIndex);
                    Quests[questIndex].Killed = 0;
                    questIndex++;
                    break;
                }
            } while (true);
        }
    }

    public void PrintQuestMessage()
    {
        int qIdx = GetQuestNumber();
        MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(Quests[qIdx].RIdx);
        string name = rPtr.FriendlyName;
        int qNum = Quests[qIdx].ToKill - Quests[qIdx].Killed;
        if (Quests[qIdx].ToKill == 1)
        {
            MsgPrint($"You still have to kill {name}.");
        }
        else if (qNum > 1)
        {
            string plural = name.PluralizeMonsterName();
            MsgPrint($"You still have to kill {qNum} {plural}.");
        }
        else
        {
            MsgPrint($"You still have to kill 1 {name}.");
        }
    }

    private void QuestDiscovery()
    {
        int qIdx = GetQuestNumber();
        MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(Quests[qIdx].RIdx);
        string name = rPtr.FriendlyName;
        int qNum = Quests[qIdx].ToKill;
        MsgPrint(new WeightedRandom<string>(this, FindQuests).ChooseOrDefault());
        MsgPrint(null);
        if (qNum == 1)
        {
            MsgPrint($"Beware, this level is protected by {name}!");
        }
        else
        {
            string plural = name.PluralizeMonsterName();
            MsgPrint($"Be warned, this level is guarded by {qNum} {plural}!");
        }
        Quests[qIdx].Discovered = true;
    }

    private int GetNumberMonster(int i)
    {
        if (SingletonRepository.Get<MonsterRace>(Quests[i].RIdx).Unique || SingletonRepository.Get<MonsterRace>(Quests[i].RIdx).Multiply)
        {
            return 1;
        }
        int num = SingletonRepository.Get<MonsterRace>(Quests[i].RIdx).Friends ? 10 : 5;
        num += RandomBetween(1, (Quests[i].Level / 3) + 5);
        return num;
    }

    private int GetRandomQuestMonster(int qIdx)
    {
        // Pick a minimum monster index and 1/3 of the monsters.
        int minIndex = SingletonRepository.Count<MonsterRace>() / 3;

        // Do not allow monster zero.
        if (minIndex == 0)
        {
            minIndex = 1;
        }
        int rIdx = RandomBetween(minIndex, SingletonRepository.Count<MonsterRace>() - 2); // TODO: We need to -1 the nobody monster

        // Do not allow a monster that can multiply.
        if (SingletonRepository.Get<MonsterRace>(rIdx).Multiply)
        {
            return 0;
        }

        // Do not allow the quest monster to be the same as another quest (except quests 0 and 1???? huh)
        for (int j = 2; j < qIdx; j++)
        {
            if (Quests[j].RIdx == rIdx)
            {
                return 0;
            }
        }
        return rIdx;
    }

    /// <summary>
    /// Display the 'Equippy' characters (the visual representation of a characters' equipment)
    /// </summary>
    /// <param name="player"> The player whose equippy characters should be displayed </param>
    /// <param name="screenRow"> The row on which to print the characters </param>
    /// <param name="screenCol"> The column in which to start printing the characters </param>
    public void DisplayPlayerEquippy(int screenRow, int screenCol)
    {
        int column = 0;
        foreach (WieldSlot inventorySlot in SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment).OrderBy(_inventorySlot => _inventorySlot.SortOrder))
        {
            foreach (int index in inventorySlot.InventorySlots)
            {
                Item? item = GetInventoryItem(index);
                ColorEnum color = ColorEnum.Background;
                char character = ' ';
                // Only print items that exist
                if (item != null)
                {
                    color = item.FlavorColor;
                    character = item.FlavorSymbol.Character;
                }
                Screen.Print(color, character, screenRow, screenCol + column);
                column++;
            }
        }
    }

    public void RecenterScreenAroundPlayer()
    {
        int y = MapY.IntValue;
        int x = MapX.IntValue;
        int maxProwMin = MaxPanelRows * (Constants.PlayableScreenHeight / 2);
        int maxPcolMin = MaxPanelCols * (Constants.PlayableScreenWidth / 2);
        int prowMin = y - (Constants.PlayableScreenHeight / 2);
        if (prowMin > maxProwMin)
        {
            prowMin = maxProwMin;
        }
        else if (prowMin < 0)
        {
            prowMin = 0;
        }
        int pcolMin = x - (Constants.PlayableScreenWidth / 2);
        if (pcolMin > maxPcolMin)
        {
            pcolMin = maxPcolMin;
        }
        else if (pcolMin < 0)
        {
            pcolMin = 0;
        }
        if (prowMin == PanelRowMin && pcolMin == PanelColMin)
        {
            return;
        }
        PanelRowMin = prowMin;
        PanelColMin = pcolMin;
        PanelBoundsCenter();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
    }

    public void ChangeRace(Race newRace)
    {
        Race = newRace;
        ExperienceMultiplier.IntValue = Race.ExperienceFactor + BaseCharacterClass.ExperienceFactor;
        RefreshHeightAndWeight();
        CheckExperience();
        MaxLevelGained = ExperienceLevel.IntValue;
        SingletonRepository.Get<FlaggedAction>(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        HandleStuff();
    }

    public void CheckExperience()
    {
        bool levelReward = false;
        bool levelMutation = false;
        if (ExperiencePoints.IntValue < 0)
        {
            ExperiencePoints.IntValue = 0;
        }
        if (MaxExperienceGained.IntValue < 0)
        {
            MaxExperienceGained.IntValue = 0;
        }
        if (ExperiencePoints.IntValue > Constants.PyMaxExp)
        {
            ExperiencePoints.IntValue = Constants.PyMaxExp;
        }
        if (MaxExperienceGained.IntValue > Constants.PyMaxExp)
        {
            MaxExperienceGained.IntValue = Constants.PyMaxExp;
        }
        if (ExperiencePoints.IntValue > MaxExperienceGained.IntValue)
        {
            MaxExperienceGained.IntValue = ExperiencePoints.IntValue;
        }
        HandleStuff();
        while (ExperienceLevel.IntValue > 1 && ExperiencePoints.IntValue < RequiredExperiencePerLevel[ExperienceLevel.IntValue - 2] * ExperienceMultiplier.IntValue / 100L)
        {
            ExperienceLevel.IntValue--;
            ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            HandleStuff();
        }
        while (ExperienceLevel.IntValue < Constants.PyMaxLevel && ExperiencePoints.IntValue >= RequiredExperiencePerLevel[ExperienceLevel.IntValue - 1] * ExperienceMultiplier.IntValue / 100L)
        {
            ExperienceLevel.IntValue++;
            ConsoleView.RefreshMapLocation(MapY.IntValue, MapX.IntValue);
            if (ExperienceLevel.IntValue > MaxLevelGained)
            {
                MaxLevelGained = ExperienceLevel.IntValue;
                if (BaseCharacterClass.ReceivesLevelRewards)
                {
                    levelReward = true;
                }
                if (ChaosGift)
                {
                    levelReward = true;
                }
                if (Race.AutomaticallyGainsFirstLevelMutationAtBirth)
                {
                    if (DieRoll(5) == 1)
                    {
                        levelMutation = true;
                    }
                }
            }
            PlaySound(SoundEffectEnum.LevelGain);
            MsgPrint($"Welcome to level {ExperienceLevel.IntValue}.");
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateSpellsFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            HandleStuff();
            if (levelReward)
            {
                RunScript(nameof(GainLevelRewardScript));
                levelReward = false;
            }
            if (levelMutation)
            {
                MsgPrint("You feel different...");
                RunScript(nameof(GainMutationScript));
                levelMutation = false;
            }
        }
    }

    public void CurseEquipment(int chance, int heavyChance)
    {
        bool changed = false;
        if (DieRoll(100) > chance)
        {
            return;
        }
        Item? oPtr = GetInventoryItem(InventorySlotEnum.MeleeWeapon - 1 + DieRoll(12));
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.EffectivePropertySet.Blessed && DieRoll(888) > chance)
        {
            string oName = oPtr.GetDescription(false);
            string s = oPtr.StackCount > 1 ? "" : "s";
            MsgPrint($"Your {oName} resist{s} cursing!");
            return;
        }
        if (DieRoll(100) <= heavyChance && (oPtr.IsArtifact || oPtr.IsRare))
        {
            if (!oPtr.EffectivePropertySet.HeavyCurse)
            {
                changed = true;
            }
            oPtr.EffectivePropertySet.IsCursed = true;
            oPtr.EffectivePropertySet.HeavyCurse = true;
            oPtr.ResetCurse();
            oPtr.ResetHeavyCurse();
        }
        else
        {
            if (!oPtr.EffectivePropertySet.IsCursed)
            {
                changed = true;
            }
            oPtr.EffectivePropertySet.IsCursed = true;
            oPtr.ResetCurse();
        }
        if (changed)
        {
            MsgPrint("There is a malignant black aura surrounding you...");
            if (!string.IsNullOrEmpty(oPtr.Inscription))
            {
                if (oPtr.Inscription == "uncursed")
                {
                    oPtr.Inscription = string.Empty;
                }
            }
        }
    }

    public bool DecreaseAbilityScore(Ability stat, int amount, bool permanent)
    {
        int loss;
        bool res = false;
        int cur = stat.Innate;
        int max = stat.InnateMax;
        bool same = cur == max;
        if (cur > 3)
        {
            if (cur <= 18)
            {
                if (amount > 90)
                {
                    cur--;
                }
                if (amount > 50)
                {
                    cur--;
                }
                if (amount > 20)
                {
                    cur--;
                }
                cur--;
            }
            else
            {
                loss = ((((cur - 18) / 2) + 1) / 2) + 1;
                if (loss < 1)
                {
                    loss = 1;
                }
                loss = (DieRoll(loss) + loss) * amount / 100;
                if (loss < amount / 2)
                {
                    loss = amount / 2;
                }
                cur -= loss;
                if (cur < 18)
                {
                    cur = amount <= 20 ? 18 : 17;
                }
            }
            if (cur < 3)
            {
                cur = 3;
            }
            if (cur != stat.Innate)
            {
                res = true;
            }
        }
        if (permanent && max > 3)
        {
            if (max <= 18)
            {
                if (amount > 90)
                {
                    max--;
                }
                if (amount > 50)
                {
                    max--;
                }
                if (amount > 20)
                {
                    max--;
                }
                max--;
            }
            else
            {
                loss = ((((max - 18) / 2) + 1) / 2) + 1;
                loss = (DieRoll(loss) + loss) * amount / 100;
                if (loss < amount / 2)
                {
                    loss = amount / 2;
                }
                max -= loss;
                if (max < 18)
                {
                    max = amount <= 20 ? 18 : 17;
                }
            }
            if (same || max < cur)
            {
                max = cur;
            }
            if (max != stat.InnateMax)
            {
                res = true;
            }
        }
        if (res)
        {
            stat.Innate = cur;
            stat.InnateMax = max;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        }
        return res;
    }

    public void GainExperience(int amount)
    {
        ExperiencePoints.IntValue += amount;
        if (ExperiencePoints.IntValue < MaxExperienceGained.IntValue)
        {
            MaxExperienceGained.IntValue += amount / 5;
        }
        CheckExperience();
    }

    public EffectivePropertySet GetAbilitiesAsItemFlags()
    {
        EffectivePropertySet itemCharacteristics = new EffectivePropertySet();
        if (BaseCharacterClass.InstantFearResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantFearResistanceLevel)
        {
            itemCharacteristics.ResFear = true;
        }
        if (BaseCharacterClass.InstantChaosResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantChaosResistanceLevel)
        {
            itemCharacteristics.ResChaos = true;
        }
        if (BaseCharacterClass.InstantSustainWisdomLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainWisdomLevel)
        {
            itemCharacteristics.SustWis = true;
        }
        if (BaseCharacterClass.InstantConfusionResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantConfusionResistanceLevel)
        {
            itemCharacteristics.ResConf = true;
        }
        if (BaseCharacterClass.InstantTelepathyLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantTelepathyLevel)
        {
            itemCharacteristics.Telepathy = true;
        }
        if (BaseCharacterClass.InstantSpeedLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSpeedLevel && !MartialArtistHeavyArmor())
        {
            itemCharacteristics.BonusSpeed++;
        }
        if (BaseCharacterClass.InstantFreeActionLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantFreeActionLevel && !MartialArtistHeavyArmor())
        {
            itemCharacteristics.FreeAct = true;
        }
        if (BaseCharacterClass.InstantBlindnessResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantBlindnessResistanceLevel)
        {
            itemCharacteristics.ResBlind = true;
        }
        if (BaseCharacterClass.InstantFeatherFallingLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantFeatherFallingLevel)
        {
            itemCharacteristics.Feather = true;
        }
        if (BaseCharacterClass.InstantSeeInvisibilityLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSeeInvisibilityLevel)
        {
            itemCharacteristics.SeeInvis = true;
        }
        if (BaseCharacterClass.InstantSlowDigestionLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSlowDigestionLevel)
        {
            itemCharacteristics.SlowDigest = true;
        }
        if (BaseCharacterClass.InstantSustainConstitutionLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainConstitutionLevel)
        {
            itemCharacteristics.SustCon = true;
        }
        if (BaseCharacterClass.InstantPoisonResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantPoisonResistanceLevel)
        {
            itemCharacteristics.ResPois = true;
        }
        if (BaseCharacterClass.InstantSustainDexterityLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainDexterityLevel)
        {
            itemCharacteristics.SustDex = true;
        }
        if (BaseCharacterClass.InstantSustainStrengthLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainStrengthLevel)
        {
            itemCharacteristics.SustStr = true;
        }
        if (BaseCharacterClass.InstantHoldLifeLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantHoldLifeLevel)
        {
            itemCharacteristics.HoldLife = true;
        }
        if (BaseCharacterClass.InstantDarknessResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantDarknessResistanceLevel)
        {
            itemCharacteristics.ResDark = true;
        }
        if (BaseCharacterClass.InstantLightResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantLightResistanceLevel)
        {
            itemCharacteristics.ResLight = true;
        }
        if (BaseCharacterClass.InstantSustainCharismaLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainCharismaLevel)
        {
            itemCharacteristics.SustCha = true;
        }
        if (BaseCharacterClass.InstantSoundResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSoundResistanceLevel)
        {
            itemCharacteristics.ResSound = true;
        }
        if (BaseCharacterClass.InstantDisenchantmentResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantDisenchantmentResistanceLevel)
        {
            itemCharacteristics.ResDisen = true;
        }
        if (BaseCharacterClass.InstantRegenerationLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantRegenerationLevel)
        {
            itemCharacteristics.Regen = true;
        }
        if (BaseCharacterClass.InstantSustainIntelligenceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantSustainIntelligenceLevel)
        {
            itemCharacteristics.SustInt = true;
        }
        if (BaseCharacterClass.InstantNexusResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantNexusResistanceLevel)
        {
            itemCharacteristics.ResNexus = true;
        }
        if (BaseCharacterClass.InstantShardsResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantShardsResistanceLevel)
        {
            itemCharacteristics.ResShards = true;
        }
        if (BaseCharacterClass.InstantNetherResistanceLevel.HasValue && ExperienceLevel.IntValue >= BaseCharacterClass.InstantNetherResistanceLevel)
        {
            itemCharacteristics.ResNether = true;
        }
        if (BaseCharacterClass.ItemRadiusOverride.HasValue)
        {
            itemCharacteristics.Radius = BaseCharacterClass.ItemRadiusOverride.Value;
        }

        Race.UpdateRacialAbilities(ExperienceLevel.IntValue, itemCharacteristics);
        if (Regen)
        {
            itemCharacteristics.Regen = true;
        }
        if (SuppressRegen)
        {
            itemCharacteristics.Regen = false;
        }
        if (SpeedBonus != 0)
        {
            itemCharacteristics.BonusSpeed++;
        }
        if (ElecHit)
        {
            itemCharacteristics.ShElec = true;
        }
        if (FireHit)
        {
            itemCharacteristics.ShFire = true;
            itemCharacteristics.Radius = 2;
        }
        if (FeatherFall)
        {
            itemCharacteristics.Feather = true;
        }
        if (ResFear)
        {
            itemCharacteristics.ResFear = true;
        }
        if (Esp)
        {
            itemCharacteristics.Telepathy = true;
        }
        if (FreeAction)
        {
            itemCharacteristics.FreeAct = true;
        }
        if (SustainAll)
        {
            itemCharacteristics.SustCon = true;
            if (ExperienceLevel.IntValue > 9)
            {
                itemCharacteristics.SustStr = true;
            }
            if (ExperienceLevel.IntValue > 19)
            {
                itemCharacteristics.SustDex = true;
            }
            if (ExperienceLevel.IntValue > 29)
            {
                itemCharacteristics.SustWis = true;
            }
            if (ExperienceLevel.IntValue > 39)
            {
                itemCharacteristics.SustInt = true;
            }
            if (ExperienceLevel.IntValue > 49)
            {
                itemCharacteristics.SustCha = true;
            }
        }
        return itemCharacteristics;
    }

    public int GetScore(Game game)
    {
        int score = (MaxLevelGained - 1) * 100;
        foreach (Dungeon dungeon in SingletonRepository.Get<Dungeon>())
        {
            if (dungeon.RecallLevel > 0)
            {
                score += ((dungeon.RecallLevel + dungeon.Offset) * 10);
            }
        }
        for (int i = 0; i < Quests.Count; i++)
        {
            if (Quests[i].Level == 0)
            {
                score += 100;
            }
        }
        if (IsWinner.BoolValue)
        {
            score += 1000;
        }
        if (MaxLevelGained < 50)
        {
            int prev = 0;
            if (MaxLevelGained > 1)
            {
                prev = RequiredExperiencePerLevel[MaxLevelGained - 2] * ExperienceMultiplier.IntValue / 100;
            }
            int next = RequiredExperiencePerLevel[MaxLevelGained - 1] * ExperienceMultiplier.IntValue / 100;
            int numerator = MaxExperienceGained.IntValue - prev;
            int denominator = next - prev;
            int fraction = 100 * numerator / denominator;
            score += fraction;
        }
        return score;
    }

    public void InputPlayerName()
    {
        Screen.Clear(42);
        Screen.PrintLine(ColorEnum.Orange, "[Enter your player's name above, or hit ESCAPE]", 43, 2);
        const int col = 15;
        while (!Shutdown)
        {
            Screen.Goto(2, col);
            string? newName = AskforAux(PlayerName.StringValue, 12);
            if (newName != null)
            {
                PlayerName.StringValue = newName;

                // Check to see if the name has actually changed (excluding any leading or trailing spaces).
                if (newName.Trim() != PlayerName.StringValue.Trim())
                {
                    Generation = 1;
                }
            }

            break;
        }
        PlayerName.StringValue = PlayerName.StringValue.PadRight(12);
        Screen.Print(ColorEnum.Brown, PlayerName.StringValue, 2, col);
        //Screen.Clear(22);
    }

    public void LoseExperience(int amount)
    {
        if (amount > ExperiencePoints.IntValue)
        {
            amount = ExperiencePoints.IntValue;
        }
        ExperiencePoints.IntValue -= amount;
        CheckExperience();
    }

    public void PrintSpells(Spell[] spells, int y, int x)
    {
        int i;
        Screen.PrintLine("", y, x);
        Screen.Print("Name", y, x + 5);
        Screen.Print("Lv Mana Fail Info", y, x + 35);
        for (i = 0; i < spells.Length; i++)
        {
            Spell spell = spells[i];
            Screen.PrintLine($"{i.IndexToLetter()}) {spell.Title()}", y + i + 1, x);
        }
        Screen.PrintLine("", y + i + 1, x);
    }

    public void RegenerateHealth(int percent)
    {
        int oldHealth = Health.IntValue;
        int newHealth = (MaxHealth.IntValue * percent) + Constants.PyRegenHpbase;
        Health.IntValue += newHealth >> 16;
        if (Health.IntValue < 0 && oldHealth > 0)
        {
            Health.IntValue = Constants.MaxShort;
        }
        int newFractionalHealth = (newHealth & 0xFFFF) + FractionalHealth;
        if (newFractionalHealth >= 0x10000)
        {
            FractionalHealth = newFractionalHealth - 0x10000;
            Health.IntValue++;
        }
        else
        {
            FractionalHealth = newFractionalHealth;
        }
        if (Health.IntValue >= MaxHealth.IntValue)
        {
            Health.IntValue = MaxHealth.IntValue;
            FractionalHealth = 0;
        }
    }

    public void RegenerateMana(int percent)
    {
        int oldMana = Mana.IntValue;
        int newMana = (MaxMana.IntValue * percent) + Constants.PyRegenMnbase;
        Mana.IntValue += newMana >> 16;
        if (Mana.IntValue < 0 && oldMana > 0)
        {
            Mana.IntValue = Constants.MaxShort;
        }
        int newFractionalMana = (newMana & 0xFFFF) + FractionalMana;
        if (newFractionalMana >= 0x10000L)
        {
            FractionalMana = newFractionalMana - 0x10000;
            Mana.IntValue++;
        }
        else
        {
            FractionalMana = newFractionalMana;
        }
        if (Mana.IntValue >= MaxMana.IntValue)
        {
            Mana.IntValue = MaxMana.IntValue;
            FractionalMana = 0;
        }
    }

    /// <summary>
    /// Restores an ability.
    /// </summary>
    /// <param name="stat"></param>
    /// <returns>Returns true, if the ability was less than max and was restored back to max; false, otherwise.</returns>
    public bool RestoreAbilityScore(Ability stat)
    {
        if (stat.Innate != stat.InnateMax)
        {
            stat.Innate = stat.InnateMax;
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Adds a specific amount of health to the player up to the maximum health allows and returns true, if health was added; false, otherwise.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public bool RestoreHealth(int num)
    {
        if (Health.IntValue < MaxHealth.IntValue)
        {
            Health.IntValue += num;
            if (Health.IntValue >= MaxHealth.IntValue)
            {
                Health.IntValue = MaxHealth.IntValue;
                FractionalHealth = 0;
            }
            if (num < 5)
            {
                MsgPrint("You feel a little better.");
            }
            else if (num < 15)
            {
                MsgPrint("You feel better.");
            }
            else if (num < 35)
            {
                MsgPrint("You feel much better.");
            }
            else
            {
                MsgPrint("You feel very good.");
            }
            return true;
        }
        return false;
    }

    public bool SetFood(int v)
    {
        int oldAux, newAux;
        bool notice = false;
        v = v > 20000 ? 20000 : v < 0 ? 0 : v;
        if (Food.IntValue < Constants.PyFoodFaint)
        {
            oldAux = 0;
        }
        else if (Food.IntValue < Constants.PyFoodWeak)
        {
            oldAux = 1;
        }
        else if (Food.IntValue < Constants.PyFoodAlert)
        {
            oldAux = 2;
        }
        else if (Food.IntValue < Constants.PyFoodFull)
        {
            oldAux = 3;
        }
        else if (Food.IntValue < Constants.PyFoodMax)
        {
            oldAux = 4;
        }
        else
        {
            oldAux = 5;
        }
        if (v < Constants.PyFoodFaint)
        {
            newAux = 0;
        }
        else if (v < Constants.PyFoodWeak)
        {
            newAux = 1;
        }
        else if (v < Constants.PyFoodAlert)
        {
            newAux = 2;
        }
        else if (v < Constants.PyFoodFull)
        {
            newAux = 3;
        }
        else if (v < Constants.PyFoodMax)
        {
            newAux = 4;
        }
        else
        {
            newAux = 5;
        }
        if (newAux > oldAux)
        {
            switch (newAux)
            {
                case 1:
                    MsgPrint("You are still weak.");
                    break;

                case 2:
                    MsgPrint("You are still hungry.");
                    break;

                case 3:
                    MsgPrint("You are no longer hungry.");
                    break;

                case 4:
                    MsgPrint("You are full!");
                    break;

                case 5:
                    MsgPrint("You have gorged yourself!");
                    break;
            }
            notice = true;
        }
        else if (newAux < oldAux)
        {
            switch (newAux)
            {
                case 0:
                    MsgPrint("You are getting faint from hunger!");
                    break;

                case 1:
                    MsgPrint("You are getting weak from hunger!");
                    break;

                case 2:
                    MsgPrint("You are getting hungry.");
                    break;

                case 3:
                    MsgPrint("You are no longer full.");
                    break;

                case 4:
                    MsgPrint("You are no longer gorged.");
                    break;
            }
            notice = true;
        }
        Food.IntValue = v;
        if (!notice)
        {
            return false;
        }
        Disturb(false);
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        HandleStuff();
        return true;
    }

    public void ShuffleAbilityScores()
    {
        int jj;
        int abilityCount = SingletonRepository.Count<Ability>();
        int ii = RandomLessThan(abilityCount);
        for (jj = ii; jj != ii; jj = RandomLessThan(abilityCount))
        {
        }
        Ability iiAbility = SingletonRepository.Get<Ability>(ii);
        Ability jjAbility = SingletonRepository.Get<Ability>(ii);
        int max1 = iiAbility.InnateMax;
        int cur1 = iiAbility.Innate;
        int max2 = jjAbility.InnateMax;
        int cur2 = jjAbility.Innate;
        iiAbility.InnateMax = max2;
        iiAbility.Innate = cur2;
        jjAbility.InnateMax = max1;
        jjAbility.Innate = cur1;
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
    }

    public bool SpellOkay(Spell sPtr, bool known)
    {
        if (sPtr.CharacterClassSpell.Level > ExperienceLevel.IntValue)
        {
            return false;
        }
        if (sPtr.Forgotten)
        {
            return false;
        }
        if (sPtr.Learned)
        {
            return known;
        }
        return !known;
    }

    public void TakeHit(int damage, string hitFrom)
    {
        bool penInvuln = false;
        int warning = MaxHealth.IntValue * Constants.HitpointWarn / 10;
        if (IsDead)
        {
            return;
        }
        Disturb(true);
        if (InvulnerabilityTimer.Value != 0 && damage < 9000)
        {
            if (DieRoll(Constants.PenetrateInvulnerability) == 1)
            {
                penInvuln = true;
            }
            else
            {
                return;
            }
        }
        if (EtherealnessTimer.Value != 0)
        {
            damage /= 10;
            if (damage == 0 && DieRoll(10) == 1)
            {
                damage = 1;
            }
        }
        Health.IntValue -= damage;
        if (penInvuln)
        {
            MsgPrint("The attack penetrates your shield of invulnerability!");
        }
        if (Health.IntValue < 0)
        {
            if (DieRoll(10) <= SingletonRepository.Get<God>(nameof(ZoKalarGod)).AdjustedFavour)
            {
                MsgPrint("Zo-Kalar's favour saves you from death!");
                Health.IntValue += damage;
            }
            else
            {
                if (IsWizard.BoolValue && !GetCheck("Die? "))
                {
                    Health.IntValue += damage;
                }
                else
                {
                    PlaySound(SoundEffectEnum.PlayerDeath);
                    MsgPrint("You die.");
                    MsgPrint(null);
                    DiedFrom = hitFrom;
                    if (HallucinationsTimer.Value != 0)
                    {
                        DiedFrom += "(?)";
                    }
                    IsWinner.BoolValue = false;
                    IsDead = true;
                    return;
                }
            }
        }
        if (Health.IntValue < warning)
        {
            PlaySound(SoundEffectEnum.HealthWarning);
            MsgPrint("*** LOW HITPOINT WARNING! ***");
            MsgPrint(null);
        }
    }

    public IdentifiedResultEnum TryDecreasingAbilityScore(Ability stat)
    {
        bool sust = stat.HasSustain;
        if (sust)
        {
            MsgPrint($"You feel {stat.DescStatNeg} for a moment, but the feeling passes.");
            return IdentifiedResultEnum.True;
        }
        if (DieRoll(10) <= SingletonRepository.Get<God>(nameof(LobonGod)).AdjustedFavour)
        {
            MsgPrint($"You feel {stat.DescStatNeg} for a moment, but Lobon's favour protects you.");
            return IdentifiedResultEnum.True;
        }
        if (DecreaseAbilityScore(stat, 10, false))
        {
            MsgPrint($"You feel very {stat.DescStatNeg}.");
            return IdentifiedResultEnum.True;
        }
        return IdentifiedResultEnum.False;
    }

    public IdentifiedResultEnum TryIncreasingAbilityScore(Ability stat)
    {
        bool res = RestoreAbilityScore(stat);
        if (IncreaseAbilityScore(stat))
        {
            MsgPrint($"Wow!  You feel very {stat.DescStatPos}!");
            return IdentifiedResultEnum.True;
        }
        if (res)
        {
            MsgPrint($"You feel less {stat.DescStatNeg}.");
            return IdentifiedResultEnum.True;
        }
        return IdentifiedResultEnum.False;
    }

    /// <summary>
    /// Attempts to restore an ability and renders a message to player, if the ability was restored.
    /// </summary>
    /// <param name="stat"></param>
    /// <returns>Returns true, if the ability was less than max and was restored back to max; false, otherwise.</returns>
    public bool TryRestoringAbilityScore(Ability stat)
    {
        if (RestoreAbilityScore(stat))
        {
            MsgPrint($"You feel less {stat.DescStatNeg}.");
            return true;
        }
        return false;
    }

    private bool IncreaseAbilityScore(Ability which)
    {
        int value = which.Innate;
        if (value < 18 + 100)
        {
            int gain;
            if (value < 18)
            {
                gain = RandomLessThan(100) < 75 ? 1 : 2;
                value += gain;
            }
            else if (value < 18 + 98)
            {
                gain = (((18 + 100 - value) / 2) + 3) / 2;
                if (gain < 1)
                {
                    gain = 1;
                }
                value += DieRoll(gain) + (gain / 2);
                if (value > 18 + 99)
                {
                    value = 18 + 99;
                }
            }
            else
            {
                value++;
            }
            which.Innate = value;
            if (value > which.InnateMax)
            {
                which.InnateMax = value;
            }
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            return true;
        }
        return false;
    }

    public bool GetItemOkay(Item? item, IItemFilter? itemFilter)
    {
        if (item == null)
        {
            return false;
        }
        return ItemMatchesFilter(item, itemFilter);
    }

    /// <summary>
    /// Puts an item in the players pack inventory and returns the item being carried.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public Item? InventoryCarry(Item oPtr)
    {
        int j;
        int n = -1; // TODO: This is bad.
        for (j = 0; j < InventorySlotEnum.PackCount; j++) // TODO: Why is this < PackCount and not <= PackCount.  This prevents us from grouping items in the last slot
        {
            Item? jPtr = GetInventoryItem(j);

            // Check to see if this slot is empty.
            if (jPtr == null)
            {
                // It is empty, lets use it.
                continue;
            }
            n = j;

            // Check to see if the item is the same as an existing item, so that it can be grouped.
            if (oPtr.CanAbsorb(jPtr))
            {
                // Group it together.
                jPtr.Absorb(oPtr);
                WeightCarried += oPtr.StackCount * oPtr.EffectivePropertySet.Weight;
                SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
                return jPtr;
            }
        }

        // Check to see if we scanned every slot.
        if (_invenCnt >= InventorySlotEnum.PackCount)
        {
            return null;
        }
        for (j = 0; j <= InventorySlotEnum.PackCount; j++)
        {
            Item? jPtr = GetInventoryItem(j);
            if (jPtr == null)
            {
                break;
            }
        }
        int i = j;
        if (i < InventorySlotEnum.PackCount)
        {
            // Use a merge sort to insert the item into the pack based on the sorting rules.
            for (j = 0; j < InventorySlotEnum.PackCount; j++)
            {
                Item? jPtr = GetInventoryItem(j);
                if (jPtr == null)
                {
                    break;
                }
                int compare = oPtr.CompareTo(jPtr);
                if (compare == -1)
                {
                    break;
                }
            }
            i = j;
            for (int k = n; k >= i; k--)
            {
                SetInventoryItem(k + 1, GetInventoryItem(k));
            }
            SetInventoryItem(i, null);
        }

        SetInventoryItem(i, oPtr);
        oPtr.Y = 0;
        oPtr.X = 0;
        oPtr.HoldingMonsterIndex = 0;
        WeightCarried += oPtr.StackCount * oPtr.EffectivePropertySet.Weight;
        _invenCnt++;
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return oPtr;
    }

    public int InvenDamage(Func<Item, bool> testerFunc, int perc)
    {
        int k = 0;
        for (int i = 0; i < InventorySlotEnum.PackCount; i++)
        {
            Item oPtr = GetInventoryItem(i);
            if (oPtr != null && !oPtr.IsArtifact && testerFunc(oPtr))
            {
                int j;
                int amt;
                for (amt = j = 0; j < oPtr.StackCount; ++j)
                {
                    if (RandomLessThan(100) < perc)
                    {
                        amt++;
                    }
                }
                if (amt != 0)
                {
                    string oName = oPtr.GetFullDescription(false);
                    string y = oPtr.StackCount > 1 ? (amt == oPtr.StackCount ? "All of y" : (amt > 1 ? "Some of y" : "One of y")) : "Y";
                    string w = amt > 1 ? "were" : "was";
                    MsgPrint($"{y}our {oName} ({i.IndexToLabel()}) {w} destroyed!");
                    if (oPtr.QuaffTuple != null)
                    {
                        oPtr.Smash(0, MapY.IntValue, MapX.IntValue);
                    }
                    oPtr.ModifyStackCount(-amt);
                    InvenItemOptimize(i);
                    k += amt;
                }
            }
        }
        return k;
    }
    public void InvenDrop(Item oPtr, int amt)
    {
        if (amt <= 0)
        {
            return;
        }
        if (amt > oPtr.StackCount)
        {
            amt = oPtr.StackCount;
        }
        if (oPtr.IsInEquipment)
        {
            // Take the item off first.
            Item? removedItem = oPtr.Takeoff(amt);
            if (removedItem == null)
            {
                return;
            }
            oPtr = removedItem;
        }
        Item qPtr = oPtr.TakeFromStack(amt);
        string oName = qPtr.GetFullDescription(true);
        MsgPrint($"You drop {oName} ({oPtr.Label}).");
        DropNear(qPtr, null, MapY.IntValue, MapX.IntValue);
        oPtr.ItemDescribe();
        oPtr.ItemOptimize();
    }

    [Obsolete("Use InvenDrop(Item, int)")]
    public void InvenDrop(int item, int amt)
    {
        Item? oPtr = GetInventoryItem(item);
        if (oPtr == null)
        {
            return;
        }
        InvenDrop(oPtr, amt);
    }

    public void InvenItemDescribe(int item)
    {
        Item? oPtr = GetInventoryItem(item);
        if (oPtr == null)
        {
            return;
        }
        string oName = oPtr.GetFullDescription(true);
        MsgPrint($"You have {oName}.");
    }

    public void InvenItemOptimize(int item)
    {
        Item? oPtr = GetInventoryItem(item);
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.StackCount > 0)
        {
            return;
        }
        if (item < InventorySlotEnum.MeleeWeapon)
        {
            int i;
            _invenCnt--;
            for (i = item; i < InventorySlotEnum.PackCount; i++)
            {
                SetInventoryItem(i, GetInventoryItem(i + 1));
            }
            SetInventoryItem(i, null);
        }
        else
        {
            SetInventoryItem(item, null);
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
            SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        }
    }

    public bool ItemMatchesFilter(Item item, IItemFilter? itemFilter)
    {
        if (item.GoldPieces > 0)
        {
            throw new Exception("The ItemMatchesFilter with an item of gold shouldn't have been possible.");
        }
        return (itemFilter == null || itemFilter.Matches(item));
    }

    public int LabelToEquip(char c)
    {
        int i = (char.IsLower(c) ? c.LetterToNumber() : -1) + InventorySlotEnum.MeleeWeapon;
        if (i < InventorySlotEnum.MeleeWeapon || i >= InventorySlotEnum.Total)
        {
            return -1; // TODO: Return null
        }
        if (GetInventoryItem(i) == null)
        {
            return -1; // TODO: Return null
        }
        return i;
    }

    public int LabelToInven(char c)
    {
        int i = char.IsLower(c) ? c.LetterToNumber() : -1;
        if (i < 0 || i > InventorySlotEnum.PackCount)
        {
            return -1; // TODO: Return null
        }
        if (GetInventoryItem(i) == null)
        {
            return -1; // TODO: Return null
        }
        return i;
    }

    public void ShowEquipment(IItemFilter? itemFilter)
    {
        ShowInven(_inventorySlot => _inventorySlot.IsEquipment, itemFilter, true, true, true);
    }

    /// <summary>
    /// Shows the players inventory on the screen.  Returns false, if the player has nothing in their inventory.
    /// </summary>
    /// <param name="inventorySlotPredicate"></param>
    /// <param name="itemFilter"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public bool ShowInven(Func<WieldSlot, bool> inventorySlotPredicate, IItemFilter? itemFilter, bool ShowEmptySlotsAsNothing = false, bool ShowFlavorColumn = false, bool ShowUsageColumn = false)
    {
        WieldSlot[] inventorySlots = SingletonRepository.Get<WieldSlot>()
            .Where(_inventorySlot => inventorySlotPredicate(_inventorySlot))
            .OrderBy(_inventorySlot => _inventorySlot.SortOrder)
            .ToArray();

        const string labels = "abcdefghijklmnopqrstuvwxyz";
        ConsoleTable consoleTable = new ConsoleTable("label", "flavor", "usage", "description", "weight");
        consoleTable.Column("flavor").IsVisible = ShowFlavorColumn;
        consoleTable.Column("usage").IsVisible = ShowFlavorColumn;
        consoleTable.Column("weight").Alignment = new ConsoleTopRightAlignment();
        foreach (WieldSlot inventorySlot in inventorySlots)
        {
            bool slotIsEmpty = true;
            foreach (int index in inventorySlot.InventorySlots)
            {
                Item? oPtr = GetInventoryItem(index);
                if (oPtr != null && (itemFilter == null || itemFilter.Matches(oPtr)))
                {
                    ConsoleTableRow consoleRow = consoleTable.AddRow();
                    consoleRow["label"] = new ConsoleString(ColorEnum.White, $"{index.IndexToLabel()})");

                    // Apply flavor visuals
                    consoleRow["flavor"] = new ConsoleChar(oPtr.FlavorColor, oPtr.FlavorSymbol.Character);
                    consoleRow["usage"] = new ConsoleString(ColorEnum.White, $"{inventorySlot.MentionUse(index)}:");

                    ColorEnum color = oPtr.EffectivePropertySet.Color;
                    consoleRow["description"] = new ConsoleString(color, oPtr.GetFullDescription(true));

                    int wgt = oPtr.EffectivePropertySet.Weight * oPtr.StackCount;
                    consoleRow["weight"] = new ConsoleString(ColorEnum.White, $"{wgt / 10}.{wgt % 10} lb");
                    slotIsEmpty = false;
                }
            }
            if (ShowEmptySlotsAsNothing && slotIsEmpty)
            {
                ConsoleTableRow consoleRow = consoleTable.AddRow();
                consoleRow["label"] = new ConsoleString(ColorEnum.White, $"{labels[consoleTable.Rows.Count() - 1]})");
                consoleRow["usage"] = new ConsoleString(ColorEnum.White, $"{inventorySlot.MentionUse(null)}:");
                consoleRow["description"] = new ConsoleString(ColorEnum.White, "(nothing)");
                consoleRow["weight"] = new ConsoleString(ColorEnum.White, $"0.0 lb");
            }
        }

        if (consoleTable.Rows.Count() > 0)
        {
            if (consoleTable.Width < 29)
            {
                ConsoleWindow container = new ConsoleWindow(50, 1, 79, consoleTable.Height);
                container.Clear(this, ColorEnum.Background);
                consoleTable.Render(this, container, new ConsoleTopLeftAlignment());
            }
            else
            {
                consoleTable.Render(this, new ConsoleWindow(0, 1, 79, 26), new ConsoleTopRightAlignment());
            }
            return true;
        }
        return false;
    }

    public void PanelBoundsCenter()
    {
        PanelRow = PanelRowMin / (Constants.PlayableScreenHeight / 2);
        PanelRowMax = PanelRowMin + Constants.PlayableScreenHeight - 1;
        PanelCol = PanelColMin / (Constants.PlayableScreenWidth / 2);
        PanelColMax = PanelColMin + Constants.PlayableScreenWidth - 1;
    }

    public void Acquirement(int y1, int x1, int num, bool great)
    {
        while (num-- != 0)
        {
            Item? qPtr = MakeObject(Difficulty, true, great, false);
            if (qPtr == null)
            {
                continue;
            }
            DropNear(qPtr, null, y1, x1);
        }
    }

    public void CaveSetFeat(int y, int x, Tile tile)
    {
        GridTile cPtr = Map.Grid[y][x];
        cPtr.FeatureType = tile;
        NoteSpot(y, x);
        ConsoleView.RefreshMapLocation(y, x);
    }

    public bool CaveValidBold(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.FeatureType.IsPermanent)
        {
            return false;
        }
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.IsArtifact)
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Checks the stack of items at a grid coordinate for a chest and returns the first chest item found.   Returns null, if no chest is found.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public Item? ChestCheck(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.IsContainer)
            {
                return oPtr;
            }
        }
        return null;
    }

    public int CoordsToDir(int y, int x)
    {
        int[][] d = { new[] { 7, 4, 1 }, new[] { 8, 5, 2 }, new[] { 9, 6, 3 } };
        int dy = y - MapY.IntValue;
        int dx = x - MapX.IntValue;
        if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
        {
            return 0;
        }
        return d[dx + 1][dy + 1];
    }

    public void DeleteMonsterAtGridLocation(int y, int x)
    {
        if (!InBounds(y, x))
        {
            return;
        }
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.MonsterIndex != 0)
        {
            DeleteMonsterByIndex(cPtr.MonsterIndex, true);
        }
    }

    public void DeleteObject(Item jPtr)
    {
        ExciseObject(jPtr);
        if (jPtr.HoldingMonsterIndex == 0)
        {
            int y = jPtr.Y;
            int x = jPtr.X;
            ConsoleView.RefreshMapLocation(y, x);
        }
    }

    public int Distance(int y1, int x1, int y2, int x2)
    {
        int dy = y1 > y2 ? y1 - y2 : y2 - y1;
        int dx = x1 > x2 ? x1 - x2 : x2 - x1;
        int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
        return d;
    }

    public void DropNear(Item jPtr, ProbabilityExpression? chance, int y, int x)
    {
        int ty, tx;
        GridTile cPtr;
        bool flag = false;
        bool done = false;
        bool plural = jPtr.StackCount != 1;
        string oName = jPtr.GetDescription(false);
        if (!jPtr.IsArtifact && chance != null && chance.Test())
        {
            string p = plural ? "" : "s";
            MsgPrint($"The {oName} disappear{p}.");
            return;
        }
        int bs = -1;
        int bn = 0;
        int by = y;
        int bx = x;
        for (int dy = -3; dy <= 3; dy++)
        {
            for (int dx = -3; dx <= 3; dx++)
            {
                bool comb = false;
                int d = (dy * dy) + (dx * dx);
                if (d > 10)
                {
                    continue;
                }
                ty = y + dy;
                tx = x + dx;
                if (!InBounds(ty, tx))
                {
                    continue;
                }
                if (!Los(y, x, ty, tx))
                {
                    continue;
                }
                cPtr = Map.Grid[ty][tx];
                if (!cPtr.FeatureType.IsOpenFloor)
                {
                    continue;
                }
                int k = 0;
                foreach (Item oPtr in cPtr.Items)
                {
                    if (oPtr.CanAbsorb(jPtr))
                    {
                        comb = true;
                    }
                    k++;
                }
                if (!comb)
                {
                    k++;
                }
                if (k > 99)
                {
                    continue;
                }
                int s = 1000 - (d + (k * 5));
                if (s < bs)
                {
                    continue;
                }
                if (s > bs)
                {
                    bn = 0;
                }
                if (++bn >= 2 && RandomLessThan(bn) != 0)
                {
                    continue;
                }
                bs = s;
                by = ty;
                bx = tx;
                flag = true;
            }
        }
        if (!flag && !jPtr.IsArtifact)
        {
            string p = plural ? "" : "s";
            MsgPrint($"The {oName} disappear{p}.");
            return;
        }
        for (int i = 0; !flag; i++)
        {
            if (i < 1000)
            {
                ty = RandomSpread(by, 1);
                tx = RandomSpread(bx, 1);
            }
            else
            {
                ty = RandomLessThan(CurHgt);
                tx = RandomLessThan(CurWid);
            }
            cPtr = Map.Grid[ty][tx];
            if (!cPtr.FeatureType.IsOpenFloor)
            {
                continue;
            }
            by = ty;
            bx = tx;
            if (!GridOpenNoItem(by, bx))
            {
                continue;
            }
            flag = true;
        }
        cPtr = Map.Grid[by][bx];
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.CanAbsorb(jPtr))
            {
                oPtr.Absorb(jPtr);
                done = true;
                break;
            }
        }

        if (!done)
        {
            if (!AddItemToGrid(jPtr, bx, by))
            {
                string p = plural ? "" : "s";
                MsgPrint($"The {oName} disappear{p}.");
                if (jPtr.FixedArtifact != null)
                {
                    jPtr.FixedArtifact.CurNum = 0;
                }
                return;
            }
        }
        NoteSpot(by, bx);
        ConsoleView.RefreshMapLocation(by, bx);
        PlaySound(SoundEffectEnum.Drop);
        if (chance != null && by == MapY.IntValue && bx == MapX.IntValue)
        {
            MsgPrint("You feel something roll beneath your feet.");
        }
    }

    public void ExciseObject(Item jPtr)
    {
        // Check to see if the object is being held by a monster.
        if (jPtr.HoldingMonsterIndex != 0)
        {
            // It is.  Get the monster.
            Monster mPtr = Monsters[jPtr.HoldingMonsterIndex];

            mPtr.Items.Remove(jPtr);
        }
        else
        {
            // The object is not being held by a monster.
            int y = jPtr.Y;
            int x = jPtr.X;
            GridTile cPtr = Map.Grid[y][x];
            cPtr.Items.Remove(jPtr);
        }
    }

    public bool GridOpenNoItem(int y, int x)
    {
        return Map.Grid[y][x].FeatureType.IsOpenFloor && Map.Grid[y][x].Items.Count == 0;
    }

    public bool GridOpenNoItemOrCreature(int y, int x)
    {
        return Map.Grid[y][x].FeatureType.IsOpenFloor && Map.Grid[y][x].Items.Count == 0 && Map.Grid[y][x].MonsterIndex == 0 && !(y == MapY.IntValue && x == MapX.IntValue);
    }

    public bool GridPassable(int y, int x)
    {
        return Map.Grid[y][x].FeatureType.IsPassable;
    }

    public bool GridPassableNoCreature(int y, int x)
    {
        return GridPassable(y, x) && Map.Grid[y][x].MonsterIndex == 0 && !(y == MapY.IntValue && x == MapX.IntValue);
    }

    // TODO: Convert to zero based
    // TODO: Rename to InboundsOneBased
    /// <summary>
    /// Check coordinates for being inbounds based on a one-based coordinate system.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool InBounds(int y, int x)
    {
        return y > 0 && x > 0 && y < CurHgt - 1 && x < CurWid - 1;
    }

    // TODO: Rename to InboundsZeroBased
    /// <summary>
    /// Check coordinates for being inbounds based on a zero-based coordinate system.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <returns></returns>
    public bool InBounds2(int y, int x)
    {
        return y >= 0 && x >= 0 && y < CurHgt && x < CurWid;
    }

    public bool Los(int y1, int x1, int y2, int x2)
    {
        int tx, ty;
        int m;
        int dy = y2 - y1;
        int dx = x2 - x1;
        int ay = Math.Abs(dy);
        int ax = Math.Abs(dx);
        if (ax < 2 && ay < 2)
        {
            return true;
        }
        if (dx == 0)
        {
            if (dy > 0)
            {
                for (ty = y1 + 1; ty < y2; ty++)
                {
                    if (GridBlocksLos(ty, x1))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (ty = y1 - 1; ty > y2; ty--)
                {
                    if (GridBlocksLos(ty, x1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        if (dy == 0)
        {
            if (dx > 0)
            {
                for (tx = x1 + 1; tx < x2; tx++)
                {
                    if (GridBlocksLos(y1, tx))
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (tx = x1 - 1; tx > x2; tx--)
                {
                    if (GridBlocksLos(y1, tx))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        int sx = dx < 0 ? -1 : 1;
        int sy = dy < 0 ? -1 : 1;
        if (ax == 1)
        {
            if (ay == 2)
            {
                if (!GridBlocksLos(y1 + sy, x1))
                {
                    return true;
                }
            }
        }
        else if (ay == 1)
        {
            if (ax == 2)
            {
                if (!GridBlocksLos(y1, x1 + sx))
                {
                    return true;
                }
            }
        }
        int f2 = ax * ay;
        int f1 = f2 << 1;
        if (ax >= ay)
        {
            int qy = ay * ay;
            m = qy << 1;
            tx = x1 + sx;
            if (qy == f2)
            {
                ty = y1 + sy;
                qy -= f1;
            }
            else
            {
                ty = y1;
            }
            while (x2 - tx != 0)
            {
                if (GridBlocksLos(ty, tx))
                {
                    return false;
                }
                qy += m;
                if (qy < f2)
                {
                    tx += sx;
                }
                else if (qy > f2)
                {
                    ty += sy;
                    if (GridBlocksLos(ty, tx))
                    {
                        return false;
                    }
                    qy -= f1;
                    tx += sx;
                }
                else
                {
                    ty += sy;
                    qy -= f1;
                    tx += sx;
                }
            }
        }
        else
        {
            int qx = ax * ax;
            m = qx << 1;
            ty = y1 + sy;
            if (qx == f2)
            {
                tx = x1 + sx;
                qx -= f1;
            }
            else
            {
                tx = x1;
            }
            while (y2 - ty != 0)
            {
                if (GridBlocksLos(ty, tx))
                {
                    return false;
                }
                qx += m;
                if (qx < f2)
                {
                    ty += sy;
                }
                else if (qx > f2)
                {
                    tx += sx;
                    if (GridBlocksLos(ty, tx))
                    {
                        return false;
                    }
                    qx -= f1;
                    ty += sy;
                }
                else
                {
                    tx += sx;
                    qx -= f1;
                    ty += sy;
                }
            }
        }
        return true;
    }

    public void MoveOneStepTowards(out int newY, out int newX, int currentY, int currentX, int startY, int startX, int targetY, int targetX)
    {
        newY = currentY;
        newX = currentX;
        int shift;
        int dY = newY < startY ? startY - newY : newY - startY;
        int dX = newX < startX ? startX - newX : newX - startX;
        int distance = dY > dX ? dY : dX;
        distance++;
        dY = targetY < startY ? startY - targetY : targetY - startY;
        dX = targetX < startX ? startX - targetX : targetX - startX;
        if (dY == 0 && dX == 0)
        {
            return;
        }
        if (dY > dX)
        {
            shift = ((distance * dX) + ((dY - 1) / 2)) / dY;
            newX = targetX < startX ? startX - shift : startX + shift;
            newY = targetY < startY ? startY - distance : startY + distance;
        }
        else
        {
            shift = ((distance * dY) + ((dX - 1) / 2)) / dX;
            newY = targetY < startY ? startY - shift : startY + shift;
            newX = targetX < startX ? startX - distance : startX + distance;
        }
    }

    public bool NoLight()
    {
        return !PlayerCanSeeBold(MapY.IntValue, MapX.IntValue);
    }

    public void NoteSpot(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        if (BlindnessTimer.Value != 0)
        {
            return;
        }
        if (!cPtr.PlayerLit)
        {
            if (!cPtr.IsVisible)
            {
                return;
            }
            if (!cPtr.SelfLit)
            {
                return;
            }
        }
        foreach (Item oPtr in cPtr.Items)
        {
            oPtr.WasNoticed = true;
        }
        if (!cPtr.PlayerMemorized)
        {
            if (cPtr.FeatureType.IsOpenFloor)
            {
                cPtr.PlayerMemorized = true;
            }
            else if (cPtr.FeatureType.IsPassable)
            {
                cPtr.PlayerMemorized = true;
            }
            else if (cPtr.PlayerLit)
            {
                cPtr.PlayerMemorized = true;
            }
            else
            {
                int yy = y < MapY.IntValue ? y + 1 : y > MapY.IntValue ? y - 1 : y;
                int xx = x < MapX.IntValue ? x + 1 : x > MapX.IntValue ? x - 1 : x;
                if (Map.Grid[yy][xx].SelfLit)
                {
                    cPtr.PlayerMemorized = true;
                }
            }
        }
    }

    public bool PanelContains(int y, int x)
    {
        return y >= PanelRowMin && y <= PanelRowMax && x >= PanelColMin && x <= PanelColMax;
    }

    public void PickTrap(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        if (!cPtr.FeatureType.IsInvisibleTrap)
        {
            return;
        }
        int trapType = DieRoll(16);
        if (IsQuest(CurrentDepth))
        {
            trapType = DieRoll(15);
        }
        if (CurrentDepth >= CurDungeon.MaxLevel)
        {
            trapType = DieRoll(15);
        }
        WeightedRandom<Tile> traps = new WeightedRandom<Tile>(this);
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(AcidTrapTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(FireTrapTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(StrengthDartTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(ConstitutionDartTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(DexterityDartTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(SlowDartTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(PoisonGasTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(ConfuseGasTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(SleepGasTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(BlindGasTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(SummonRuneTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(TeleportRuneTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(PitTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(SpikedPitTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(PoisonPitTile)));
        traps.Add(1, SingletonRepository.Get<Tile>(nameof(TrapDoorTile)));
        Tile? trapTile = traps.ChooseOrDefault();
        if (trapTile == null)
        {
            throw new Exception("No trap selected for PickTrap.");
        }
        CaveSetFeat(y, x, trapTile);
    }

    public void PlaceGold(int y, int x)
    {
        if (!InBounds(y, x))
        {
            return;
        }
        if (!GridOpenNoItem(y, x))
        {
            return;
        }
        Item? oPtr = MakeGold(Difficulty);
        if (oPtr != null)
        {
            if (AddItemToGrid(oPtr, x, y))
            {
                NoteSpot(y, x);
                ConsoleView.RefreshMapLocation(y, x);
            }
        }
    }

    public void PlaceObject(int objectLevel, int y, int x, bool good, bool great)
    {
        if (!InBounds(y, x))
        {
            return;
        }
        if (!GridOpenNoItem(y, x))
        {
            return;
        }
        Item? qPtr = MakeObject(objectLevel, good, great, false);
        if (qPtr == null)
        {
            return;
        }

        if (AddItemToGrid(qPtr, x, y))
        {
            NoteSpot(y, x);
            ConsoleView.RefreshMapLocation(y, x);
        }
        else
        {
            if (qPtr.FixedArtifact != null)
            {
                qPtr.FixedArtifact.CurNum = 0;
            }
        }
    }

    public void PlaceTrap(int y, int x)
    {
        if (!InBounds(y, x))
        {
            return;
        }
        if (!GridOpenNoItemOrCreature(y, x))
        {
            return;
        }
        CaveSetFeat(y, x, SingletonRepository.Get<Tile>(nameof(InvisibleTrap)));
    }

    public bool PlayerCanSeeBold(int y, int x)
    {
        if (BlindnessTimer.Value != 0)
        {
            return false;
        }
        GridTile cPtr = Map.Grid[y][x];
        if (cPtr.PlayerLit)
        {
            return true;
        }
        if (!GridTileIsVisible(y, x))
        {
            return false;
        }
        if (!cPtr.SelfLit)
        {
            return false;
        }
        if (GridPassable(y, x))
        {
            return true;
        }
        int yy = y < MapY.IntValue ? y + 1 : y > MapY.IntValue ? y - 1 : y;
        int xx = x < MapX.IntValue ? x + 1 : x > MapX.IntValue ? x - 1 : x;
        return Map.Grid[yy][xx].SelfLit;
    }

    public bool GridTileIsVisible(int y, int x)
    {
        return Map.Grid[y][x].IsVisible;
    }

    public bool Projectable(int y1, int x1, int y2, int x2)
    {
        int y = y1;
        int x = x1;
        for (int dist = 0; dist <= Constants.MaxRange; dist++)
        {
            if (x == x2 && y == y2)
            {
                return true;
            }
            if (dist != 0 && !GridPassable(y, x) && !Map.Grid[y][x].FeatureType.IsYellowSignSigil)
            {
                break;
            }
            MoveOneStepTowards(out y, out x, y, x, y1, x1, y2, x2);
        }
        return false;
    }

    public void ReplacePets(int y, int x, List<Monster> petList)
    {
        foreach (Monster monster in petList)
        {
            ReplacePet(y, x, monster);
        }
    }

    public void ReplaceSecretDoor(int y, int x)
    {
        WeightedRandom<Tile> doorTiles = new WeightedRandom<Tile>(this);
        doorTiles.Add(300, SingletonRepository.Get<Tile>(nameof(LockedDoor0Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor1Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor2Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor3Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor4Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor5Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor6Tile)));
        doorTiles.Add(16, SingletonRepository.Get<Tile>(nameof(LockedDoor7Tile)));
        Tile doorTile = doorTiles.Choose();
        CaveSetFeat(y, x, doorTile);
    }

    public void RevertTileToBackground(int y, int x)
    {
        GridTile cPtr = Map.Grid[y][x];
        cPtr.RevertToBackground();
        NoteSpot(y, x);
        ConsoleView.RefreshMapLocation(y, x);
    }

    public (int yp, int xp) Scatter(int y, int x, int d)
    {
        int nx = 0;
        int ny = 0;
        int yp = y;
        int xp = x;
        int attemptsLeft = 5000;
        while (--attemptsLeft != 0)
        {
            ny = RandomSpread(y, d);
            nx = RandomSpread(x, d);
            if (!InBounds(y, x))
            {
                continue;
            }
            if (d > 1 && Distance(y, x, ny, nx) > d)
            {
                continue;
            }
            if (Los(y, x, ny, nx))
            {
                break;
            }
        }
        if (attemptsLeft > 0)
        {
            return (ny, nx);
        }
        return (yp, xp);
    }

    private ColorEnum DimColor(ColorEnum a)
    {
        switch (a)
        {
            case ColorEnum.BrightBlue:
                return ColorEnum.Blue;

            case ColorEnum.BrightGreen:
                return ColorEnum.Green;

            case ColorEnum.BrightRed:
                return ColorEnum.Red;

            case ColorEnum.BrightWhite:
                return ColorEnum.White;

            case ColorEnum.BrightBeige:
                return ColorEnum.Beige;

            case ColorEnum.BrightChartreuse:
                return ColorEnum.Chartreuse;

            case ColorEnum.BrightGrey:
                return ColorEnum.Grey;

            case ColorEnum.BrightOrange:
                return ColorEnum.Orange;

            case ColorEnum.BrightYellow:
                return ColorEnum.Yellow;

            case ColorEnum.BrightBrown:
                return ColorEnum.Brown;

            case ColorEnum.BrightTurquoise:
                return ColorEnum.Turquoise;

            case ColorEnum.BrightPink:
                return ColorEnum.Pink;

            case ColorEnum.Grey:
                return ColorEnum.Black;

            case ColorEnum.White:
                return ColorEnum.Grey;

            case ColorEnum.Yellow:
                return ColorEnum.BrightBrown;

            default:
                return a;
        }
    }

    private bool GridBlocksLos(int y, int x)
    {
        return Map.Grid[y][x].FeatureType.BlocksLos;
    }

    private void ImageMonster(out ColorEnum ap, out char cp)
    {
        cp = SingletonRepository.Get<MonsterRace>(DieRoll(SingletonRepository.Count<MonsterRace>() - 2)).Symbol.Character;
        ap = SingletonRepository.Get<MonsterRace>(DieRoll(SingletonRepository.Count<MonsterRace>() - 2)).Color;
    }

    private void ImageObject(out ColorEnum ap, out char cp)
    {
        cp = SingletonRepository.Get<ItemFactory>(DieRoll(SingletonRepository.Count<ItemFactory>() - 1)).FlavorSymbol.Character;
        ap = SingletonRepository.Get<ItemFactory>(DieRoll(SingletonRepository.Count<ItemFactory>() - 1)).FlavorColor;
    }

    private void ImageRandom(out ColorEnum ap, out char cp)
    {
        if (RandomLessThan(100) < 75)
        {
            ImageMonster(out ap, out cp);
        }
        else
        {
            ImageObject(out ap, out cp);
        }
    }

    public int CountTraps(int x, int y)
    {
        int count = 0;
        if (Map.Grid[y - 1][x].TrapsDetected)
        {
            count++;
        }
        if (Map.Grid[y + 1][x].TrapsDetected)
        {
            count++;
        }
        if (Map.Grid[y][x - 1].TrapsDetected)
        {
            count++;
        }
        if (Map.Grid[y][x + 1].TrapsDetected)
        {
            count++;
        }
        return count;
    }

    /// <summary>
    /// Returns the color and character of the symbol to be rendered at a specific map location.  No validation for the map coordinates is performed.
    /// </summary>
    /// <param name="y"></param>
    /// <param name="x"></param>
    /// <param name="color"></param>
    /// <param name="character"></param>
    public void MapInfo(int y, int x, out ColorEnum color, out char character)
    {
        ColorEnum a;
        char c;
        GridTile cPtr = Map.Grid[y][x];
        Tile feat = cPtr.FeatureType;
        if (feat.IsOpenFloor)
        {
            if (cPtr.PlayerMemorized || ((cPtr.PlayerLit || (cPtr.SelfLit && cPtr.IsVisible)) && BlindnessTimer.Value == 0))
            {
                c = feat.Symbol.Character;
                a = feat.Color;
                if (feat.DimsOutsideLOS)
                {
                    if (BlindnessTimer.Value != 0)
                    {
                        a = ColorEnum.Black;
                    }
                    else if (cPtr.PlayerLit)
                    {
                        if (feat.YellowInTorchlight)
                        {
                            a = ColorEnum.BrightYellow;
                        }
                    }
                    else if (!cPtr.SelfLit)
                    {
                        a = ColorEnum.Black;
                    }
                    else if (!cPtr.IsVisible)
                    {
                        a = DimColor(a);
                    }
                    if (cPtr.TrapsDetected)
                    {
                        int count = CountTraps(x, y);
                        if (count != 4)
                        {
                            a = ColorEnum.BrightChartreuse;
                        }
                    }
                }
            }
            else
            {
                a = SingletonRepository.Get<Tile>(nameof(NothingTile)).Color;
                c = SingletonRepository.Get<Tile>(nameof(NothingTile)).Symbol.Character;
            }
        }
        else
        {
            if (cPtr.PlayerMemorized)
            {
                feat = cPtr.FeatureType.MimicTile == null ? cPtr.FeatureType : cPtr.FeatureType.MimicTile;
                c = feat.Symbol.Character;
                a = feat.Color;
                if (feat.DimsOutsideLOS)
                {
                    if (BlindnessTimer.Value != 0)
                    {
                        a = ColorEnum.Black;
                    }
                    else if (cPtr.PlayerLit)
                    {
                        if (feat.YellowInTorchlight)
                        {
                            a = ColorEnum.Yellow;
                        }
                    }
                    else
                    {
                        if (!cPtr.IsVisible)
                        {
                            a = DimColor(a);
                        }
                        else if (!cPtr.SelfLit)
                        {
                            a = DimColor(a);
                        }
                        else
                        {
                            int yy = y < MapY.IntValue ? y + 1 : y > MapY.IntValue ? y - 1 : y;
                            int xx = x < MapX.IntValue ? x + 1 : x > MapX.IntValue ? x - 1 : x;
                            if (!Map.Grid[yy][xx].SelfLit)
                            {
                                a = DimColor(a);
                            }
                        }
                    }
                }
            }
            else
            {
                a = SingletonRepository.Get<Tile>(nameof(NothingTile)).Color;
                c = SingletonRepository.Get<Tile>(nameof(NothingTile)).Symbol.Character;
            }
        }
        if (HallucinationsTimer.Value != 0 && RandomLessThan(256) == 0 && (!cPtr.FeatureType.IsWall))
        {
            ImageRandom(out color, out character);
        }
        else
        {
            color = a;
            character = c;
        }
        foreach (Item oPtr in cPtr.Items)
        {
            if (oPtr.WasNoticed)
            {
                character = oPtr.FlavorSymbol.Character;
                color = oPtr.FlavorColor;
                if (HallucinationsTimer.Value != 0)
                {
                    ImageObject(out color, out character);
                }
                break;
            }
        }
        if (cPtr.MonsterIndex != 0)
        {
            Monster mPtr = Monsters[cPtr.MonsterIndex];
            if (mPtr.IsVisible)
            {
                MonsterRace rPtr = mPtr.Race;
                a = rPtr.Color;
                c = rPtr.Symbol.Character;
                if (rPtr.AttrMulti)
                {
                    if (rPtr.Shapechanger)
                    {
                        character = DieRoll(25) == 1
                            ? _imageObjectHack[RandomLessThan(_imageObjectHack.Length)]
                            : _imageMonsterHack[RandomLessThan(_imageMonsterHack.Length)];
                    }
                    else
                    {
                        character = c;
                    }
                    if (rPtr.AttrAny)
                    {
                        color = (ColorEnum)DieRoll(15);
                    }
                    else
                    {
                        switch (DieRoll(7))
                        {
                            case 1:
                                color = ColorEnum.Red;
                                break;

                            case 2:
                                color = ColorEnum.BrightRed;
                                break;

                            case 3:
                                color = ColorEnum.White;
                                break;

                            case 4:
                                color = ColorEnum.BrightGreen;
                                break;

                            case 5:
                                color = ColorEnum.Blue;
                                break;

                            case 6:
                                color = ColorEnum.Black;
                                break;

                            case 7:
                                color = ColorEnum.Green;
                                break;
                        }
                    }
                }
                else if (!rPtr.AttrClear && !rPtr.CharClear)
                {
                    character = c;
                    color = a;
                }
                else
                {
                    if (!rPtr.CharClear)
                    {
                        character = c;
                    }
                    else if (!rPtr.AttrClear)
                    {
                        color = a;
                    }
                }
                if (HallucinationsTimer.Value != 0)
                {
                    ImageMonster(out color, out character);
                }
            }
        }
        if (y == MapY.IntValue && x == MapX.IntValue)
        {
            MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(0);
            a = rPtr.Color;
            c = rPtr.Symbol.Character;
            color = a;
            character = c;
        }
    }

    public bool AllocHorde(int y, int x)
    {
        MonsterRace? rPtr = null;
        int attempts = 1000;
        while (--attempts != 0)
        {
            int rIdx = GetMonNum(MonsterLevel, null);
            if (rIdx == 0)
            {
                return false;
            }
            rPtr = SingletonRepository.Get<MonsterRace>(rIdx);
            if (!rPtr.Unique && !rPtr.EscortsGroup)
            {
                break;
            }
        }
        if (attempts < 1)
        {
            return false;
        }
        attempts = 1000;
        while (--attempts == 0)
        {
            if (PlaceMonsterAux(y, x, rPtr, false, false, false))
            {
                break;
            }
        }
        if (attempts < 1)
        {
            return false;
        }
        Monster mPtr = Monsters[_hackMIdxIi];
        for (attempts = DieRoll(10) + 5; attempts != 0; attempts--)
        {
            SummonSpecific(mPtr.MapY, mPtr.MapX, Difficulty, new KinSystemMonsterRaceFilter(this, rPtr.Symbol.Character), true, false);
        }
        return true;
    }

    public void AllocMonster(int dis, bool slp)
    {
        int y = 0;
        int x = 0;
        int attemptsLeft = 10000;
        while (attemptsLeft != 0)
        {
            y = RandomLessThan(CurHgt);
            x = RandomLessThan(CurWid);
            if (!GridOpenNoItemOrCreature(y, x))
            {
                continue;
            }
            if (Distance(y, x, MapY.IntValue, MapX.IntValue) > dis)
            {
                break;
            }
            attemptsLeft--;
        }
        if (attemptsLeft == 0)
        {
            return;
        }
        if (DieRoll(5000) <= Difficulty)
        {
            if (AllocHorde(y, x))
            {
            }
        }
        else
        {
            if (DunBias != null && RandomBetween(1, 10) > 6)
            {
                if (SummonSpecific(y, x, Difficulty, DunBias, true, false))
                {
                }
            }
            else
            {
                if (PlaceMonster(y, x, slp, true))
                {
                }
            }
        }
    }

    public void CompactMonsters(int size)
    {
        int i, num, cnt;
        if (size != 0)
        {
            MsgPrint("Compacting monsters...");
        }
        for (num = 0, cnt = 1; num < size; cnt++)
        {
            int curLev = 5 * cnt;
            int curDis = 5 * (20 - cnt);
            for (i = 1; i < MonsterMax; i++)
            {
                Monster mPtr = Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (rPtr.Level > curLev)
                {
                    continue;
                }
                if (curDis > 0 && mPtr.DistanceFromPlayer < curDis)
                {
                    continue;
                }
                int chance = 90;
                if (rPtr.Unique)
                {
                    chance = 99;
                }
                if (rPtr.Guardian && cnt < 1000)
                {
                    chance = 100;
                }
                if (RandomLessThan(100) < chance)
                {
                    continue;
                }
                DeleteMonsterByIndex(i, true);
                num++;
            }
        }
        for (i = MonsterMax - 1; i >= 1; i--)
        {
            Monster mPtr = Monsters[i];
            if (mPtr.Race != null)
            {
                continue;
            }
            CompactMonstersAux(MonsterMax - 1, i);
            MonsterMax--;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mIdx"></param>
    /// <param name="dam"></param>
    /// <param name="fear"></param>
    /// <param name="note"></param>
    /// <returns>True, if the monster dies; false, otherwise.</returns>
    public bool DamageMonster(int mIdx, int dam, out bool fear, string note)
    {
        fear = false;
        Monster mPtr = Monsters[mIdx];
        MonsterRace rPtr = mPtr.Race;
        mPtr.SleepLevel = 0;
        mPtr.Health -= dam;
        if (mPtr.Health < 0)
        {
            string mName = mPtr.Name;
            if (rPtr.GreatOldOne && DieRoll(2) == 1)
            {
                MsgPrint($"{mName} retreats into another dimension!");
                if (DieRoll(5) == 1)
                {
                    int curses = 1 + DieRoll(3);
                    MsgPrint("Nyarlathotep puts a terrible curse on you!");
                    CurseEquipment(100, 50);
                    do
                    {
                        ActivateDreadCurse();
                    } while (--curses != 0);
                }
            }
            PlaySound(SoundEffectEnum.MonsterDies);
            if (!string.IsNullOrEmpty(note))
            {
                MsgPrint($"{mName}{note}");
            }
            else if (!mPtr.IsVisible)
            {
                MsgPrint($"You have killed {mName}.");
            }
            else if (rPtr.Demon || rPtr.Undead ||
                     rPtr.Cthuloid || rPtr.Stupid ||
                     rPtr.Nonliving || "Evg".Contains(rPtr.Symbol.Character.ToString()))
            {
                MsgPrint($"You have destroyed {mName}.");
            }
            else
            {
                MsgPrint($"You have slain {mName}.");
            }
            int div = 10 * MaxLevelGained;
            if (rPtr.Knowledge.RPkills >= 19)
            {
                div *= 2;
            }
            if (rPtr.Knowledge.RPkills == 0)
            {
                div /= 3;
            }
            if (rPtr.Knowledge.RPkills == 1)
            {
                div /= 2;
            }
            if (rPtr.Knowledge.RPkills == 2)
            {
                div /= 2;
            }
            if (div < 1)
            {
                div = 1;
            }
            int newExp = rPtr.Mexp * rPtr.Level * 10 / div;
            int newExpFrac = (rPtr.Mexp * rPtr.Level % div * 0x10000 / div) + FractionalExperiencePoints;
            if (newExpFrac >= 0x10000)
            {
                newExp++;
                FractionalExperiencePoints = newExpFrac - 0x10000;
            }
            else
            {
                FractionalExperiencePoints = newExpFrac;
            }
            GainExperience(newExp);
            MonsterDeath(mPtr);
            if (rPtr.Unique)
            {
                rPtr.MaxNum = 0;
            }
            if (mPtr.IsVisible || rPtr.Unique)
            {
                if (rPtr.Knowledge.RPkills < int.MaxValue)
                {
                    rPtr.Knowledge.RPkills++;
                }
                if (rPtr.Knowledge.RTkills < int.MaxValue)
                {
                    rPtr.Knowledge.RTkills++;
                }
            }
            DeleteMonsterByIndex(mIdx, true);
            fear = false;
            return true;
        }
        if (mPtr.FearLevel != 0 && dam > 0)
        {
            int tmp = DieRoll(dam);
            if (tmp < mPtr.FearLevel)
            {
                mPtr.FearLevel -= tmp;
            }
            else
            {
                mPtr.FearLevel = 0;
                fear = false;
            }
        }
        if (mPtr.FearLevel == 0 && !rPtr.ImmuneFear)
        {
            int percentage = 100 * mPtr.Health / mPtr.MaxHealth;
            if ((percentage <= 10 && RandomLessThan(10) < percentage) || (dam >= mPtr.Health && RandomLessThan(100) < 80))
            {
                fear = true;
                mPtr.FearLevel = DieRoll(10) + (dam >= mPtr.Health && percentage > 7 ? 20 : (11 - percentage) * 5);
            }
        }
        return false;
    }

    public void DeleteMonsterByIndex(int i, bool visibly)
    {
        Monster mPtr = Monsters[i];
        MonsterRace rPtr = mPtr.Race;
        if (rPtr == null)
        {
            return;
        }
        int y = mPtr.MapY;
        int x = mPtr.MapX;
        rPtr.CurNum--;
        if (rPtr.Multiply)
        {
            NumRepro--;
        }

        // Check to see if this is the monster the player is tracking so that we can stop tracking the monster.
        if (TargetWho != null && TargetWho.TargetedMonster == mPtr)
        {
            TargetWho = null;
        }
        if (TrackedMonster.Value != null && TrackedMonster.Value == mPtr)
        {
            HealthTrack(null);
        }
        Map.Grid[y][x].MonsterIndex = 0;
        mPtr.Items.Clear();
        Monsters[i] = new Monster(this);
        MCnt--;
        if (visibly)
        {
            ConsoleView.RefreshMapLocation(y, x);
        }
    }

    /// <summary>
    /// Returns the index of a monster.
    /// </summary>
    /// <param name="level"></param>
    /// <param name="monsterFilter"></param>
    /// <returns></returns>
    public int GetMonNum(int level, MonsterRaceFilter? monsterFilter)
    {
        int i, j;
        AllocationEntry[] table = AllocRaceTable;
        if (level > 0)
        {
            if (RandomLessThan(Constants.NastyMon) == 0)
            {
                int d = (level / 4) + 2;
                level += d < 5 ? d : 5;
            }
            if (RandomLessThan(Constants.NastyMon) == 0)
            {
                int d = (level / 4) + 2;
                level += d < 5 ? d : 5;
            }
        }
        int total = 0;
        for (i = 0; i < AllocRaceSize; i++)
        {
            if (table[i].Level > level)
            {
                break;
            }
            table[i].FinalProbability = 0;
            if (level > 0 && table[i].Level <= 0)
            {
                continue;
            }
            int rIdx = table[i].Index;
            MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(rIdx);

            // Do not allow more than 1 unique of this type to be created.
            if (rPtr.Unique && rPtr.CurNum >= rPtr.MaxNum)
            {
                continue;
            }

            if (monsterFilter == null || monsterFilter.Matches(rPtr))
            {
                table[i].FinalProbability = table[i].BaseProbability;
            }
            else
            {
                table[i].FinalProbability = 0;
            }

            total += table[i].FinalProbability;
        }
        if (total <= 0)
        {
            return 0;
        }
        long value = RandomLessThan(total);
        for (i = 0; i < AllocRaceSize; i++)
        {
            if (value < table[i].FinalProbability)
            {
                break;
            }
            value -= table[i].FinalProbability;
        }
        int p = RandomLessThan(100);
        if (p < 60)
        {
            j = i;
            value = RandomLessThan(total);
            for (i = 0; i < AllocRaceSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            if (table[i].Level < table[j].Level)
            {
                i = j;
            }
        }
        if (p < 10)
        {
            j = i;
            value = RandomLessThan(total);
            for (i = 0; i < AllocRaceSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            if (table[i].Level < table[j].Level)
            {
                i = j;
            }
        }
        return table[i].Index;
    }

    public List<Monster> GetPets()
    {
        List<Monster> list = new List<Monster>();
        foreach (Monster monster in Monsters)
        {
            if (monster.IsPet)
            {
                list.Add(monster);
            }
        }
        return list;
    }

    public void LoreDoProbe(int mIdx)
    {
        Monster mPtr = Monsters[mIdx];
        MonsterRace rPtr = mPtr.Race;
        var knowledge = rPtr.Knowledge;
        for (var m = 0; m < rPtr.Attacks.Length; m++)
        {
            if (rPtr.Attacks[m].Effect != null || rPtr.Attacks[m].Method != null)
            {
                knowledge.RBlows[m] = Constants.MaxUchar;
            }
        }
        knowledge.RProbed = true;
        knowledge.RWake = Constants.MaxUchar;
        knowledge.RIgnore = Constants.MaxUchar;
        knowledge.RDropItem = (rPtr.Drop_4D2 ? 8 : 0) +
                              (rPtr.Drop_3D2 ? 6 : 0) +
                              (rPtr.Drop_2D2 ? 4 : 0) +
                              (rPtr.Drop_1D2 ? 2 : 0) +
                              (rPtr.Drop90 ? 1 : 0) +
                              (rPtr.Drop60 ? 1 : 0);
        knowledge.RDropGold = knowledge.RDropItem;
        if (rPtr.OnlyDropGold)
        {
            knowledge.RDropItem = 0;
        }
        if (rPtr.OnlyDropItem)
        {
            knowledge.RDropGold = 0;
        }
        knowledge.RCastInate = Constants.MaxUchar;
        knowledge.RCastSpell = Constants.MaxUchar;
        knowledge.Characteristics = new MonsterCharacteristics(rPtr);
        knowledge.RSpells = rPtr.Spells;
    }

    public void LoreTreasure(Monster mPtr, int numItem, int numGold)
    {
        MonsterRace rPtr = mPtr.Race;
        if (numItem > rPtr.Knowledge.RDropItem)
        {
            rPtr.Knowledge.RDropItem = numItem;
        }
        if (numGold > rPtr.Knowledge.RDropGold)
        {
            rPtr.Knowledge.RDropGold = numGold;
        }
        if (rPtr.DropGood)
        {
            rPtr.Knowledge.Characteristics.DropGood = true;
        }
        if (rPtr.DropGreat)
        {
            rPtr.Knowledge.Characteristics.DropGreat = true;
        }
    }

    public void MessagePain(Monster mPtr, int dam)
    {
        MonsterRace rPtr = mPtr.Race;
        string mName = mPtr.Name;
        if (dam == 0)
        {
            MsgPrint($"{mName} is unharmed.");
            return;
        }
        long newhp = mPtr.Health;
        long oldhp = newhp + dam;
        long tmp = newhp * 100L / oldhp;
        int percentage = (int)tmp;
        if ("jmvQ".Contains(rPtr.Symbol.Character.ToString()))
        {
            if (percentage > 95)
            {
                MsgPrint($"{mName} barely notices.");
            }
            else if (percentage > 75)
            {
                MsgPrint($"{mName} flinches.");
            }
            else if (percentage > 50)
            {
                MsgPrint($"{mName} squelches.");
            }
            else if (percentage > 35)
            {
                MsgPrint($"{mName} quivers in pain.");
            }
            else if (percentage > 20)
            {
                MsgPrint($"{mName} writhes about.");
            }
            else if (percentage > 10)
            {
                MsgPrint($"{mName} writhes in agony.");
            }
            else
            {
                MsgPrint($"{mName} jerks limply.");
            }
        }
        else if ("CZ".Contains(rPtr.Symbol.Character.ToString()))
        {
            if (percentage > 95)
            {
                MsgPrint($"{mName} shrugs off the attack.");
            }
            else if (percentage > 75)
            {
                MsgPrint($"{mName} snarls with pain.");
            }
            else if (percentage > 50)
            {
                MsgPrint($"{mName} yelps in pain.");
            }
            else if (percentage > 35)
            {
                MsgPrint($"{mName} howls in pain.");
            }
            else if (percentage > 20)
            {
                MsgPrint($"{mName} howls in agony.");
            }
            else if (percentage > 10)
            {
                MsgPrint($"{mName} writhes in agony.");
            }
            else
            {
                MsgPrint($"{mName} yelps feebly.");
            }
        }
        else if ("FIKMRSXabclqrst".Contains(rPtr.Symbol.Character.ToString()))
        {
            if (percentage > 95)
            {
                MsgPrint($"{mName} ignores the attack.");
            }
            else if (percentage > 75)
            {
                MsgPrint($"{mName} grunts with pain.");
            }
            else if (percentage > 50)
            {
                MsgPrint($"{mName} squeals in pain.");
            }
            else if (percentage > 35)
            {
                MsgPrint($"{mName} shrieks in pain.");
            }
            else if (percentage > 20)
            {
                MsgPrint($"{mName} shrieks in agony.");
            }
            else if (percentage > 10)
            {
                MsgPrint($"{mName} writhes in agony.");
            }
            else
            {
                MsgPrint($"{mName} cries out feebly.");
            }
        }
        else
        {
            if (percentage > 95)
            {
                MsgPrint($"{mName} shrugs off the attack.");
            }
            else if (percentage > 75)
            {
                MsgPrint($"{mName} grunts with pain.");
            }
            else if (percentage > 50)
            {
                MsgPrint($"{mName} cries out in pain.");
            }
            else if (percentage > 35)
            {
                MsgPrint($"{mName} screams in pain.");
            }
            else if (percentage > 20)
            {
                MsgPrint($"{mName} screams in agony.");
            }
            else if (percentage > 10)
            {
                MsgPrint($"{mName} writhes in agony.");
            }
            else
            {
                MsgPrint($"{mName} cries out feebly.");
            }
        }
    }

    public bool MultiplyMonster(Monster mPtr, bool charm, bool clone)
    {
        bool result = false;
        for (int i = 0; i < 18; i++)
        {
            int d = 1;
            (int y, int x) = Scatter(mPtr.MapY, mPtr.MapX, d);
            if (!GridPassableNoCreature(y, x))
            {
                continue;
            }
            result = PlaceMonsterAux(y, x, mPtr.Race, false, false, charm);
            break;
        }
        if (clone && result)
        {
            Monsters[_hackMIdxIi].SmCloned = true;
        }
        mPtr.Generation++;
        Monsters[_hackMIdxIi].Generation = mPtr.Generation; // TODO: This should be needed ... it is a self assignment
        return result;
    }

    public bool PlaceMonster(int y, int x, bool slp, bool grp)
    {
        int rIdx = GetMonNum(MonsterLevel, null);
        if (rIdx == 0)
        {
            return false;
        }
        if (PlaceMonsterByIndex(y, x, rIdx, slp, grp, false))
        {
            return true;
        }
        return false;
    }

    public bool PlaceMonsterAux(int y, int x, MonsterRace rPtr, bool slp, bool grp, bool pet)
    {
        if (!PlaceMonsterOne(y, x, rPtr, slp, pet))
        {
            return false;
        }
        if (rPtr.Escorted)
        {
            for (int i = 0; i < 50; i++)
            {
                int d = 3;
                (int ny, int nx) = Scatter(y, x, d);
                if (!GridPassableNoCreature(ny, nx))
                {
                    continue;
                }
                int z = GetMonNum(rPtr.Level, new PlaceOkaySystemMonsterRaceFilter(this, rPtr.Index));
                if (z == 0)
                {
                    break;
                }
                MonsterRace race = SingletonRepository.Get<MonsterRace>(z);
                PlaceMonsterOne(ny, nx, race, slp, pet);
                if (race.Friends ||
                    rPtr.EscortsGroup)
                {
                    PlaceMonsterGroup(ny, nx, z, slp, pet);
                }
            }
        }
        if (!grp)
        {
            return true;
        }
        if (rPtr.Friends)
        {
            PlaceMonsterGroup(y, x, rPtr.Index, slp, pet);
        }
        return true;
    }

    public bool PlaceMonsterByIndex(int y, int x, int index, bool slp, bool grp, bool charm)
    {
        return PlaceMonsterAux(y, x, SingletonRepository.Get<MonsterRace>(index), slp, grp, charm);
    }

    public void ReplacePet(int y1, int x1, Monster monster)
    {
        int i;
        int x = x1;
        int y = y1;
        for (i = 0; i < 20; ++i)
        {
            int d = (i / 15) + 1;
            (y, x) = Scatter(y1, x1, d);
            if (!GridPassableNoCreature(y, x))
            {
                continue;
            }
            if (!Map.Grid[y][x].FeatureType.AllowMonsterToOccupy)
            {
                continue;
            }
            break;
        }
        if (i == 20)
        {
            MsgPrint($"You lose sight of {monster.Name}.");
            return;
        }
        GridTile cPtr = Map.Grid[y][x];
        cPtr.MonsterIndex = MPop();
        if (cPtr.MonsterIndex == 0)
        {
            MsgPrint($"You lose sight of {monster.Name}.");
            return;
        }
        Monsters[cPtr.MonsterIndex] = monster;
        monster.MapY = y;
        monster.MapX = x;
        MonsterRace rPtr = monster.Race;
        if (rPtr.Multiply)
        {
            NumRepro++;
        }
        if (rPtr.AttrMulti)
        {
            ShimmerMonsters = true;
        }
    }

    /// <summary>
    /// Generates a monster near the coordinaes <paramref name="x1"/> and <paramref name="y1"/> that belongs to the specified <paramref name="monsterFilter"/>, if specified.
    /// </summary>
    /// <param name="y1"></param>
    /// <param name="x1"></param>
    /// <param name="lev"></param>
    /// <param name="monsterFilter"></param>
    /// <param name="groupOk"></param>
    /// <param name="pet"></param>
    /// <returns>True, if a monster was summoned; false, otherwise.</returns>
    public bool SummonSpecific(int y1, int x1, int lev, MonsterRaceFilter? monsterFilter, bool groupOk, bool pet)
    {
        int i;
        int x = x1;
        int y = y1;
        for (i = 0; i < 20; ++i) // TODO: This is a hard coded value
        {
            int d = (i / 15) + 1;
            (y, x) = Scatter(y1, x1, d);
            if (!GridPassableNoCreature(y, x))
            {
                continue;
            }
            if (!Map.Grid[y][x].FeatureType.AllowMonsterToOccupy)
            {
                continue;
            }
            break;
        }
        if (i == 20)
        {
            return false;
        }
        int rIdx = GetMonNum(((Difficulty + lev) / 2) + 5, monsterFilter);
        if (rIdx == 0)
        {
            return false;
        }
        MonsterRace race = SingletonRepository.Get<MonsterRace>(rIdx);
        if (!PlaceMonsterAux(y, x, race, false, groupOk, pet))
        {
            return false;
        }
        return true;
    }

    public void UpdateMonsterVisibility(int mIdx, bool full)
    {
        Monster mPtr = Monsters[mIdx];
        MonsterRace rPtr = mPtr.Race;
        if (rPtr == null)
        {
            return;
        }
        int fy = mPtr.MapY;
        int fx = mPtr.MapX;
        if (full)
        {
            int dy = MapY.IntValue > fy
                ? MapY.IntValue - fy
                : fy - MapY.IntValue;
            int dx = MapX.IntValue > fx
                ? MapX.IntValue - fx
                : fx - MapX.IntValue;
            int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
            mPtr.DistanceFromPlayer = d < 255 ? d : 255;
        }
        bool flag = false;
        bool easy = false;
        bool hard = false;
        bool doEmptyMind = false;
        bool doWeirdMind = false;
        bool doInvisible = false;
        bool doColdBlood = false;
        bool oldMl = mPtr.IsVisible;
        if (mPtr.DistanceFromPlayer > Constants.MaxSight)
        {
            if (!mPtr.IsVisible)
            {
                return;
            }
            if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
            {
                flag = true;
            }
        }
        else if (PanelContains(fy, fx))
        {
            GridTile cPtr = Map.Grid[fy][fx];
            if (cPtr.IsVisible && BlindnessTimer.Value == 0)
            {
                if (mPtr.DistanceFromPlayer <= InfravisionRange)
                {
                    if (rPtr.ColdBlood)
                    {
                        doColdBlood = true;
                    }
                    if (!doColdBlood)
                    {
                        easy = true;
                        flag = true;
                    }
                }
                if (cPtr.PlayerLit && cPtr.SelfLit)
                {
                    if (rPtr.Invisible)
                    {
                        doInvisible = true;
                    }
                    if (!doInvisible || HasSeeInvisibility)
                    {
                        easy = true;
                        flag = true;
                    }
                }
            }
            if (HasTelepathy)
            {
                if (rPtr.EmptyMind)
                {
                    doEmptyMind = true;
                }
                else if (rPtr.WeirdMind)
                {
                    doWeirdMind = true;
                    if (RandomLessThan(100) < 10)
                    {
                        hard = true;
                        flag = true;
                    }
                }
                else
                {
                    hard = true;
                    flag = true;
                }
            }
            if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
            {
                flag = true;
            }
            if (IsWizard.BoolValue)
            {
                flag = true;
            }
        }
        if (flag)
        {
            if (!mPtr.IsVisible)
            {
                mPtr.IsVisible = true;
                ConsoleView.RefreshMapLocation(fy, fx);
                if (rPtr.Knowledge.RSights < Constants.MaxShort)
                {
                    rPtr.Knowledge.RSights++;
                }
            }
            if (hard)
            {
                if (rPtr.Smart)
                {
                    rPtr.Knowledge.Characteristics.Smart = true;
                }
                if (rPtr.Stupid)
                {
                    rPtr.Knowledge.Characteristics.Stupid = true;
                }
            }
            if (doEmptyMind)
            {
                rPtr.Knowledge.Characteristics.EmptyMind = true;
            }
            if (doWeirdMind)
            {
                rPtr.Knowledge.Characteristics.WeirdMind = true;
            }
            if (doColdBlood)
            {
                rPtr.Knowledge.Characteristics.ColdBlood = true;
            }
            if (doInvisible)
            {
                rPtr.Knowledge.Characteristics.Invisible = true;
            }
        }
        else
        {
            if (mPtr.IsVisible)
            {
                mPtr.IsVisible = false;
                ConsoleView.RefreshMapLocation(fy, fx);
            }
        }
        if (easy)
        {
            if (mPtr.IsVisible != oldMl)
            {
                if (rPtr.EldritchHorror)
                {
                    mPtr.SanityBlast(false);
                }
            }
            if ((mPtr.IndividualMonsterFlags & Constants.MflagView) == 0)
            {
                mPtr.IndividualMonsterFlags |= Constants.MflagView;
                if (!mPtr.IsPet)
                {
                    Disturb(true);
                }
            }
        }
        else
        {
            if ((mPtr.IndividualMonsterFlags & Constants.MflagView) != 0)
            {
                mPtr.IndividualMonsterFlags &= ~Constants.MflagView;
                if (!mPtr.IsPet)
                {
                    Disturb(true);
                }
            }
        }
    }

    public void UpdateSmartLearn(Monster monster, SpellResistantDetection what)
    {
        MonsterRace rPtr = monster.Race;
        if (rPtr == null)
        {
            return;
        }
        if (rPtr.Stupid)
        {
            return;
        }
        if (!rPtr.Smart && RandomLessThan(100) < 50)
        {
            return;
        }
        what.Learn(monster);
    }

    public void WipeMList()
    {
        for (int i = MonsterMax - 1; i >= 1; i--)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            rPtr.CurNum--;
            Map.Grid[mPtr.MapY][mPtr.MapX].MonsterIndex = 0;
            Monsters[i] = new Monster(this);
        }
        MonsterMax = 1;
        MCnt = 0;
        NumRepro = 0;
        TargetWho = null;
        HealthTrack(null);
    }

    private void CompactMonstersAux(int i1, int i2)
    {
        if (i1 == i2)
        {
            return;
        }
        Monster mPtr = Monsters[i1];
        int y = mPtr.MapY;
        int x = mPtr.MapX;
        GridTile cPtr = Map.Grid[y][x];
        cPtr.MonsterIndex = i2;
        Monster mPtr2 = Monsters[i2];
        mPtr2.Items.AddRange(mPtr.Items);
        if (TargetWho != null && TargetWho.TargetedMonster == mPtr)
        {
            TargetWho = new MonsterTarget(this, mPtr2);
        }
        if (TrackedMonster.Value != null && TrackedMonster.Value == mPtr)
        {
            HealthTrack(i2);
        }
        Monsters[i2] = Monsters[i1];
        Monsters[i1] = new Monster(this);
    }

    private int MPop()
    {
        int i;
        if (MonsterMax < Constants.MaxMIdx)
        {
            i = MonsterMax;
            MonsterMax++;
            MCnt++;
            return i;
        }
        for (i = 1; i < MonsterMax; i++)
        {
            Monster mPtr = Monsters[i];
            if (mPtr.Race != null)
            {
                continue;
            }
            MCnt++;
            return i;
        }
        MsgPrint("Too many monsters!");
        return 0;
    }

    private void PlaceMonsterGroup(int y, int x, int rIdx, bool slp, bool charm)
    {
        MonsterRace rPtr = SingletonRepository.Get<MonsterRace>(rIdx);
        int extra = 0;
        int[] hackY = new int[Constants.GroupMax];
        int[] hackX = new int[Constants.GroupMax];
        int total = DieRoll(13);
        if (rPtr.Level > Difficulty)
        {
            extra = rPtr.Level - Difficulty;
            extra = 0 - DieRoll(extra);
        }
        else if (rPtr.Level < Difficulty)
        {
            extra = Difficulty - rPtr.Level;
            extra = DieRoll(extra);
        }
        if (extra > 12)
        {
            extra = 12;
        }
        total += extra;
        if (total < 1)
        {
            total = 1;
        }
        if (total > Constants.GroupMax)
        {
            total = Constants.GroupMax;
        }
        int old = DangerRating;
        int hackN = 1;
        hackX[0] = x;
        hackY[0] = y;
        for (int n = 0; n < hackN && hackN < total; n++)
        {
            int hx = hackX[n];
            int hy = hackY[n];
            for (int i = 0; i < 8 && hackN < total; i++)
            {
                int mx = hx + OrderedDirectionXOffset[i];
                int my = hy + OrderedDirectionYOffset[i];
                if (!GridPassableNoCreature(my, mx))
                {
                    continue;
                }
                if (PlaceMonsterOne(my, mx, rPtr, slp, charm))
                {
                    hackY[hackN] = my;
                    hackX[hackN] = mx;
                    hackN++;
                }
            }
        }
        DangerRating = old;
    }

    private bool PlaceMonsterOne(int y, int x, MonsterRace rPtr, bool slp, bool pet)
    {
        // Monster must be provided.
        if (rPtr == null)
        {
            return false;
        }

        // Monster cannot be the player.
        if (rPtr.FriendlyName.StartsWith("Player"))
        {
            return false;
        }

        // Ensure the placement is within the bounds of the level.
        if (!InBounds(y, x))
        {
            return false;
        }

        // Ensure the grid level is open.
        if (!GridPassableNoCreature(y, x))
        {
            return false;
        }

        // Do not place monster on a sigil.
        if (!Map.Grid[y][x].FeatureType.AllowMonsterToOccupy)
        {
            return false;
        }

        // Ensure the monster name is not empty or null.
        string name = rPtr.FriendlyName;
        if (string.IsNullOrEmpty(rPtr.FriendlyName))
        {
            return false;
        }

        // Do not place more than one if the monster is unique and already allocated.
        if (rPtr.Unique && rPtr.CurNum >= rPtr.MaxNum)
        {
            return false;
        }

        // Check to see if this is a quest guardian.
        if (rPtr.OnlyGuardian || rPtr.Guardian)
        {
            int qIdx = GetQuestNumber();
            if (qIdx < 0)
            {
                return false;
            }
            if (rPtr.Index != Quests[qIdx].RIdx)
            {
                return false;
            }
            if (rPtr.CurNum >= Quests[qIdx].ToKill - Quests[qIdx].Killed)
            {
                return false;
            }
        }
        if (rPtr.Level > Difficulty)
        {
            if (rPtr.Unique)
            {
                DangerRating += (rPtr.Level - Difficulty) * 2;
            }
            else
            {
                DangerRating += rPtr.Level - Difficulty;
            }
        }
        GridTile cPtr = Map.Grid[y][x];
        cPtr.MonsterIndex = MPop();
        _hackMIdxIi = cPtr.MonsterIndex;
        if (cPtr.MonsterIndex == 0)
        {
            return false;
        }
        Monster mPtr = Monsters[cPtr.MonsterIndex];
        mPtr.Race = rPtr;
        mPtr.MapY = y;
        mPtr.MapX = x;
        mPtr.Generation = 1;
        mPtr.StunLevel = 0;
        mPtr.ConfusionLevel = 0;
        mPtr.FearLevel = 0;
        if (pet)
        {
            mPtr.IsPet = true;
        }
        mPtr.SleepLevel = 0;
        if (slp && rPtr.Sleep != 0)
        {
            int val = rPtr.Sleep;
            mPtr.SleepLevel = (val * 2) + DieRoll(val * 10);
        }
        mPtr.DistanceFromPlayer = 0;
        mPtr.IndividualMonsterFlags = 0;
        mPtr.IsVisible = false;
        mPtr.MaxHealth = rPtr.ForceMaxHp ? rPtr.Hdice * rPtr.Hside : DiceRoll(rPtr.Hdice, rPtr.Hside);
        mPtr.Health = mPtr.MaxHealth;
        mPtr.Speed = rPtr.Speed;
        if (!rPtr.Unique)
        {
            int i = ExtractEnergy[rPtr.Speed] / 10;
            if (i != 0)
            {
                mPtr.Speed += RandomSpread(0, i);
            }
        }
        mPtr.Energy = RandomLessThan(100);
        if (rPtr.ForceSleep)
        {
            mPtr.IndividualMonsterFlags |= Constants.MflagNice;
            RepairMonsters = true;
        }
        if (cPtr.MonsterIndex < CurrentlyActingMonster)
        {
            mPtr.IndividualMonsterFlags |= Constants.MflagBorn;
        }
        UpdateMonsterVisibility(cPtr.MonsterIndex, true);
        rPtr.CurNum++;
        if (rPtr.Multiply)
        {
            NumRepro++;
        }
        if (rPtr.AttrMulti)
        {
            ShimmerMonsters = true;
        }
        return true;
    }

    public static bool ValidateTupleSorting<T>(T[] items, Func<T, T, bool> testPredicate)
    {
        for (int i = 0; i < items.Length - 1; i++)
        {
            if (!testPredicate(items[i], items[i + 1]))
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Returns a dice roll of (num)d(sides)
    /// </summary>
    /// <param name="num"> The number of dice to roll </param>
    /// <param name="sides"> The number of sides per die </param>
    /// <returns> </returns>
    public int DiceRoll(int num, int sides)
    {
        int sum = 0;
        for (int i = 0; i < num; i++)
        {
            sum += DieRoll(sides);
        }
        return sum;
    }

    /// <summary>
    /// Returns a random number greater or equal to one and less than or equal to max
    /// </summary>
    /// <param name="max"> The upper limit (inclusive) </param>
    /// <returns> A random number </returns>
    public int DieRoll(int max)
    {
        return Next(max) + 1;
    }

    /// <summary>
    /// Returns a die roll based on a percentage change
    /// </summary>
    /// <param name="chance"> The chance of success (inclusive) </param>
    /// <returns> Whether the roll succeeded </returns>
    public bool PercentileRoll(int chance)
    {
        return Next(100) < chance;
    }

    /// <summary>
    /// Returns a random number greater than or equal to min and less than or equal to max
    /// </summary>
    /// <param name="min"> The lower limit (inclusive) </param>
    /// <param name="max"> The upper limit (inclusive) </param>
    /// <returns> A random number </returns>
    public int RandomBetween(int min, int max)
    {
        return min + Next(1 + max - min);
    }

    /// <summary>
    /// Returns a random number greater than or equal to zero and less than <paramref name="max"/>.
    /// </summary>
    /// <param name="max"> The upper limit (exclusive) </param>
    /// <returns> A random number </returns>
    public int RandomLessThan(int max)
    {
        // There is a special case here, where the
        if (max == 0)
        {
            return 0;
        }

        return Next(max);
    }

    /// <summary>
    /// Returns an integer based on a normal distribution
    /// </summary>
    /// <param name="mean"> The mean value for the distribution </param>
    /// <param name="stand"> The standard deviation of the distribution </param>
    /// <returns> A random value </returns>
    public int RandomNormal(int mean, int stand)
    {
        int low = 0;
        int high = _randnorNum;
        if (stand < 1)
        {
            return mean;
        }
        int tmp = (short)Next(32768);
        while (low < high)
        {
            int mid = (low + high) >> 1;
            if (_randnorTable[mid] < tmp)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }
        int offset = stand * low / _randnorStd;
        if (RandomLessThan(100) < 50)
        {
            return mean - offset;
        }
        return mean + offset;
    }

    /// <summary>
    /// Returns a random number with a flat distrubution around centre and within width of it
    /// </summary>
    /// <param name="centre"> The central value </param>
    /// <param name="width"> The maximum distance (inclusive) from the centre </param>
    /// <returns> A random number </returns>
    public int RandomSpread(int centre, int width)
    {
        return centre + Next(1 + width + width) - width;
    }

    /// <summary>
    /// Generates a random number less than the max value.  The max value must be greater than 0.
    /// </summary>
    /// <param name="max"> </param>
    /// <returns> </returns>
    private int Next(int max)
    {
        if (max <= 0)
        {
            return 0; // TODO: This defys the stated purpose
        }
        Random use = UseFixed ? _fixed : _mainSequence;
        return use.Next(max);
    }

    public void InitializeMutations()
    {
        MutationsPossessed.Clear();
        // Active Mutations
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BanishActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BerserkActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BlinkActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BrFireActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ColdTouchActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(DazzleActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(DetCurseActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(EarthquakeActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(EatMagicActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(EatRockActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(GrowMoldActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HypnGazeActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(IllumineActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(LaserEyeActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(LauncherActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(MidasTchActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(MindBlstActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(PanicHitActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(PolymorphActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(RadiationActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(RecallActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ResistActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ShriekActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SmellMetActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SmellMonActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SpitAcidActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SterilityActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SwapPosActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(TelekinesActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(VampirismActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(VteleportActiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WeighMagActiveMutation)));
        // Passive Mutations
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(AlbinoPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ArthritisPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BlankFacPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ElecToucPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(EspPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(FearlessPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(FireBodyPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(FleshRotPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HyperIntPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HyperStrPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(IllNormPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(InfravisPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(IronSkinPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(LimberPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(MagicResPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(MoronicPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(MotionPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(PunyPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(RegenPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ResilientPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ResTimePassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ScalesPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ShortLegPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SillyVoiPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SusStatsPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(VulnElemPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WartSkinPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WingsPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(XtraEyesPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(XtraFatPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(XtraLegsPassiveMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(XtraNoisPassiveMutation)));
        // Random Mutations
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(AlcoholRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(AttAnimalRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(AttDemonRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(AttDragonRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BanishAllRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BeakRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(BersRageRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ChaosGiftRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(CowardiceRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(DisarmRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(EatLightRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(FlatulentRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HalluRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HornsRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(HpToSpRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(InvulnRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(NauseaRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(NormalityRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(PolyWoundRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ProdManaRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(RawChaosRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(RteleportRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(ScorTailRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SpeedFluxRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(SpToHpRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(TentaclesRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(TrunkRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WalkShadRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WarningRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WastingRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WeirdMindRandomMutation)));
        MutationsNotPossessed.Add(SingletonRepository.Get<Mutation>(nameof(WraithRandomMutation)));
    }

    public bool HasMutations => MutationsPossessed.Count > 0;

    public string[] GetMutationList()
    {
        if (MutationsPossessed.Count == 0)
        {
            return new string[0];
        }
        string[] list = new string[MutationsPossessed.Count];
        for (int i = 0; i < MutationsPossessed.Count; i++)
        {
            list[i] = MutationsPossessed[i].HaveMessage;
        }
        return list;
    }

    public void LoseAllMutations()
    {
        if (MutationsPossessed.Count == 0)
        {
            return;
        }
        MsgPrint("You change...");
        do
        {
            Mutation mutation = MutationsPossessed[0];
            MutationsPossessed.RemoveAt(0);
            mutation.OnLose();
            MutationsNotPossessed.Add(mutation);
            MsgPrint(mutation.LoseMessage);
        } while (MutationsPossessed.Count > 0);
        SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        HandleStuff();
    }

    public string Pluralize(string singular)
    {
        return Pluralize(singular, 0);
    }

    public string Pluralize(string singular, int count)
    {
        if (count == 1)
        {
            return singular;
        }
        else
        {
            Plural? plural = SingletonRepository.TryGet<Plural>(singular);
            if (plural != null)
            {
                return plural.PluralForm;
            }

            if ("sh".IndexOf(singular[singular.Length - 1]) >= 0)
            {
                return $"{singular}es";
            }
            else if (singular.EndsWith("ey"))
            {
                return $"{singular}s";
            }
            else if (singular.EndsWith("y"))
            {
                return $"{singular.Substring(0, singular.Length - 1)}ies";
            }
            else
            {
                return $"{singular}s";
            }
        }
    }

    public void RefreshGods()
    {
        if (God == null)
        {
            foreach (God god in SingletonRepository.Get<God>())
            {
                god.IsPatron = false;
                god.RestingFavor = 0;
                god.Favor = 0;
            }
        }
        else
        {
            foreach (God god in SingletonRepository.Get<God>())
            {
                if (god == God)
                {
                    god.IsPatron = true;
                    god.RestingFavor = PatronRestingFavour * 4;
                    god.Favor = PatronRestingFavour * 4;
                }
                else
                {
                    god.IsPatron = false;
                    god.RestingFavor = -PatronRestingFavour;
                    god.Favor = -PatronRestingFavour;
                }
            }
        }
    }

    public void AddFavor(God god, int amount)
    {
        foreach (God thisGod in SingletonRepository.Get<God>())
        {
            if (god == thisGod)
            {
                god.Favor += (4 * amount);
            }
            else
            {
                god.Favor -= amount;
            }
        }
    }

    public void DecayFavour()
    {
        var max = 0;
        God? isMax = null;
        foreach (God god in SingletonRepository.Get<God>())
        {
            if (god.Favor - god.RestingFavor > max)
            {
                max = god.Favor - god.RestingFavor;
                isMax = god;
            }
        }
        if (isMax != null)
        {
            var decrement = Math.Max((max / DecayRate), 1);
            AddFavor(isMax, -decrement);
        }
    }

    /// <summary>
    /// Parses an expression and returns a <see cref="BooleanExpression"/> expression.  An exception is thrown, if the result does not result in an <see cref="BooleanExpression"/> expression.
    /// </summary>
    /// <param name="expressionText"></param>
    /// <returns></returns>
    public Expression ParseBooleanExpression(string expressionText)
    {
        Expression expression = ExpressionParser.ParseExpression(expressionText);
        if (!expression.ResultTypes.Contains(typeof(BooleanExpression)))
        {
            throw new Exception($"Invalid expression type expected.  {expressionText} does not return a boolean result.");
        }
        return expression;
    }

    /// <summary>
    /// Parses an expression and returns either an <see cref="IntegerExpression"/> or <see cref="DecimalExpression"/> expression.  An exception is thrown, if the result does not result in an
    /// <see cref="IntegerExpression"/> or <see cref="DecimalExpression"/> expression.
    /// </summary>
    /// <param name="expressionText"></param>
    /// <returns></returns>
    public Expression ParseNumericExpression(string expressionText)
    {
        Expression expression = ExpressionParser.ParseExpression(expressionText);
        if (!expression.ResultTypes.Contains(typeof(IntegerExpression)) && !expression.ResultTypes.Contains(typeof(DecimalExpression)))
        {
            throw new Exception($"Invalid expression type expected.  {expressionText} does not return a numeric result.");
        }
        return expression;
    }

    /// <summary>
    /// Parses an expression and returns either an <see cref="IntegerExpression"/> or <see cref="DecimalExpression"/> expression.  If the expression is null, null is returned.  An exception is thrown,
    /// if the result does not result in an <see cref="IntegerExpression"/> or <see cref="DecimalExpression"/> expression.
    /// </summary>
    /// <param name="expressionText"></param>
    /// <returns></returns>
    public Expression? ParseNullableNumericExpression(string? expressionText)
    {
        if (expressionText == null)
        {
            return null;
        }

        return ParseNumericExpression(expressionText);
    }

    /// <summary>
    /// Parses a numeric expression and returns a <see cref="ProbabilityExpression"/>.  If the expression is null, null is returned.  The expression must return a <see cref="DecimalExpression"/> value between
    /// 0 and 1.  
    /// </summary>
    /// <param name="expressionText"></param>
    /// <returns></returns>
    public ProbabilityExpression? ParseNullableProbabilityExpression(string? expressionText)
    {
        if (expressionText == null)
        {
            return null;
        }
        return ParseProbabilityExpression(expressionText);
    }

    /// <summary>
    /// Parses a numeric expression and returns a <see cref="ProbabilityExpression"/>.  The expression must return a <see cref="DecimalExpression"/> value between
    /// 0 and 1.  
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public ProbabilityExpression ParseProbabilityExpression(string expressionText)
    {
        Expression expression = ParseNumericExpression(expressionText);
        return new ProbabilityExpression(this, expression);
    }
}