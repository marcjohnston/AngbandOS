[Serializable]
internal class HighMageRestorationLifeSpell : ClassSpell
{
    private HighMageRestorationLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRestoration);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 225;
}