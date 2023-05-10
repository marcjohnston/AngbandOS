[Serializable]
internal class HighMageMindVisionCorporealSpell : ClassSpell
{
    private HighMageMindVisionCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMindVision);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 3;
    public override int BaseFailure => 25;
    public override int FirstCastExperience => 5;
}