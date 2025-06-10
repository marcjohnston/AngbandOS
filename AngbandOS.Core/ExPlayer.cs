// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// A dead player character, holding just the bare bones needed for the high score table and
/// game preview, or to create a new character based on the previous one.
/// </summary>
[Serializable]
internal class ExPlayer
{
    /// <summary>
    /// The index of the character's gender
    /// </summary>
    public readonly Gender Gender;

    /// <summary>
    /// The character's generation, to be appended to their name
    /// </summary>
    public readonly int Generation;

    /// <summary>
    /// The level at which the character died
    /// </summary>
    public readonly int Level;

    /// <summary>
    /// The name of the character
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// Represents the name of the previous character class.
    /// </summary>
    public readonly string CharacterClassName;

    /// <summary>
    /// The race of the character
    /// </summary>
    public readonly Race Race;

    /// <summary>
    /// The race the character was born with (they might have been polymorphed or mutated)
    /// </summary>
    public readonly Race RaceAtBirth;

    /// <summary>
    /// The character's first realm of magic (if any)
    /// </summary>
    public readonly Realm? PrimaryRealm;

    /// <summary>
    /// The character's second realm of magic (if any)
    /// </summary>
    public readonly Realm? SecondaryRealm;

    /// <summary>
    /// Make an ex-player from a player, remembering the essential information about the character
    /// </summary>
    /// <param name="player"> The player character from which to create the ex player </param>
    public ExPlayer(Gender gender, Race race, Race raceAtBirth, string characterClassName, Realm? primaryRealm, Realm? secondaryRealm, string name, int experienceLevel, int generation)
    {
        Gender = gender;
        Race = race;
        RaceAtBirth = raceAtBirth;
        CharacterClassName = characterClassName;
        PrimaryRealm = primaryRealm;
        SecondaryRealm = secondaryRealm;
        Name = name;
        Level = experienceLevel;
        Generation = generation;
    }
}