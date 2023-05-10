internal class HighMageVampiricBrandingDeathSpell : ClassSpell
{
    private HighMageVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 80;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 90;
}