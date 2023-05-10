[Serializable]
internal class HighMageEnslaveUndeadDeathSpell : ClassSpell
{
    private HighMageEnslaveUndeadDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEnslaveUndead);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}