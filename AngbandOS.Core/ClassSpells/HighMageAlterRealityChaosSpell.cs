internal class HighMageAlterRealityChaosSpell : ClassSpell
{
    private HighMageAlterRealityChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellAlterReality);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 22;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 150;
}