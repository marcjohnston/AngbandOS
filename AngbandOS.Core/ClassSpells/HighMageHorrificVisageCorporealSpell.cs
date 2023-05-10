[Serializable]
internal class HighMageHorrificVisageCorporealSpell : ClassSpell
{
    private HighMageHorrificVisageCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHorrificVisage);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 15;
}