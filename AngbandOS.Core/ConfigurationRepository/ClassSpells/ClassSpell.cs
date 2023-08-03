// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ClassSpells;

[Serializable]
internal abstract class ClassSpell : IConfigurationRepository
{
    protected readonly SaveGame SaveGame;
    protected ClassSpell(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <inheritdoc />
    public virtual void Loaded() { }    
    
    /// <inheritdoc />
    public virtual bool ExcludeFromRepository => false;

    public abstract Type Spell { get; }
    public abstract Type CharacterClass { get; }
    public abstract int Level { get; }
    public abstract int ManaCost { get; }
    public abstract int BaseFailure { get; }
    public abstract int FirstCastExperience { get; }
}