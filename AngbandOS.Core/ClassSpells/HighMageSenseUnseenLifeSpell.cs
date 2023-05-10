internal class HighMageSenseUnseenLifeSpell : ClassSpell
{
    private HighMageSenseUnseenLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSenseUnseen);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}