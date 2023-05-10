[Serializable]
internal class HighMageHolyWordLifeSpell : ClassSpell
{
    private HighMageHolyWordLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyWord);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 125;
}