[Serializable]
internal class HighMageDispelUndeadAndDemonsLifeSpell : ClassSpell
{
    private HighMageDispelUndeadAndDemonsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelUndeadAndDemons);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}