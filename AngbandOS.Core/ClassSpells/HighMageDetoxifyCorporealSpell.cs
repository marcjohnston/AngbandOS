[Serializable]
internal class HighMageDetoxifyCorporealSpell : ClassSpell
{
    private HighMageDetoxifyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellDetoxify);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 8;
}