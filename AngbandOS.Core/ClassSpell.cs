// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal abstract class ClassSpell : IGetKey
{
    protected readonly Game Game;
    protected ClassSpell(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        ClassSpellGameConfiguration classSpellDefinition = new()
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

    public abstract string SpellName { get; }
    public abstract string CharacterClassName { get; }
    public abstract int Level { get; }
    public abstract int ManaCost { get; }
    public abstract int BaseFailure { get; }
    public abstract int FirstCastExperience { get; }

    /// <summary>
    /// Returns the a composite key created from the character class name and spell name with a period between them.
    /// </summary>
    public string GetKey => $"{CharacterClassName}.{SpellName}";

    public virtual void Bind() { }
}