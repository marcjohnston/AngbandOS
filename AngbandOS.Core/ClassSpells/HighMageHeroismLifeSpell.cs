[Serializable]
internal class HighMageHeroismLifeSpell : ClassSpell
{
    private HighMageHeroismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHeroism);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 40;
}