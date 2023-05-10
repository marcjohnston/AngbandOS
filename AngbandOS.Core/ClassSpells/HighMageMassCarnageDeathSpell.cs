[Serializable]
internal class HighMageMassCarnageDeathSpell : ClassSpell
{
    private HighMageMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 66;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 100;
}