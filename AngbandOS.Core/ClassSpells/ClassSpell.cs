internal abstract class ClassSpell
{
    protected readonly SaveGame SaveGame;
    protected ClassSpell(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public abstract Type Spell { get; }
    public abstract Type CharacterClass { get; }
    public abstract int Level { get; }
    public abstract int ManaCost { get; }
    public abstract int BaseFailure { get; }
    public abstract int FirstCastExperience { get; }
}