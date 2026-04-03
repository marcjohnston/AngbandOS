// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class CharacterClassSpell : IGetKey, IToJson
{
    private Game Game { get; }
    public CharacterClassSpell(Game game, CharacterClassSpellGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        SpellName = gameConfiguration.SpellName;
        CharacterClassName = gameConfiguration.CharacterClassName;
        Level = gameConfiguration.Level;
        ManaCost = gameConfiguration.ManaCost;
        BaseFailure = gameConfiguration.BaseFailure;
        FirstCastExperience = gameConfiguration.FirstCastExperience;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        CharacterClassSpellGameConfiguration classSpellDefinition = new()
        {
            SpellName = SpellName,
            CharacterClassName = CharacterClassName,
            Level = Level,
            ManaCost = ManaCost,
            BaseFailure = BaseFailure,
            FirstCastExperience = FirstCastExperience
        };
        return JsonSerializer.Serialize(classSpellDefinition, Game.GetJsonSerializerOptions());
    }

    private string SpellName { get; } // TODO: This is only used for the key
    private string CharacterClassName { get; } // TODO: This is only used for the key
    public int Level { get; }
    public int ManaCost { get; }
    public int BaseFailure { get; }
    public int FirstCastExperience { get; }

    public static string GetCompositeKey(CharacterClass characterClass, Spell spell) => GameConfiguration.GetCompositeKey(characterClass.GetKey, spell.GetKey);
    public string Key { get; }

    /// <summary>
    /// Returns the a composite key created from the character class name and spell name with a period between them.
    /// </summary>
    public string GetKey => Key;

    public void Bind(RestoreGameState? restoreGameState) { }
}