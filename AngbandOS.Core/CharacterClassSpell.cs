// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal class CharacterClassSpell : IGetKey
{
    protected readonly Game Game;
    public CharacterClassSpell(Game game, CharacterClassSpellGameConfiguration classSpellGameConfiguration)
    {
        Game = game;
        SpellName = classSpellGameConfiguration.SpellName;
        CharacterClassName = classSpellGameConfiguration.CharacterClassName;
        Level = classSpellGameConfiguration.Level;
        ManaCost = classSpellGameConfiguration.ManaCost;
        BaseFailure = classSpellGameConfiguration.BaseFailure;
        FirstCastExperience = classSpellGameConfiguration.FirstCastExperience;
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

    protected virtual string SpellName { get; }
    protected virtual string CharacterClassName { get; }
    public virtual int Level { get; }
    public virtual int ManaCost { get; }
    public virtual int BaseFailure { get; }
    public virtual int FirstCastExperience { get; }

    public static string GetCompositeKey(BaseCharacterClass t1, Spell t2) => Game.GetCompositeKey(t1.GetKey, t2.GetKey);
    /// <summary>
    /// Returns the a composite key created from the character class name and spell name with a period between them.
    /// </summary>
    public string GetKey => Game.GetCompositeKey(CharacterClassName, SpellName);

    public virtual void Bind() { }
}