[Serializable]
internal class HighMageExorcismLifeSpell : ClassSpell
{
    private HighMageExorcismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellExorcism);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 75;
}