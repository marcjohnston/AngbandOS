internal class HighMagePoisonBrandingDeathSpell : ClassSpell
{
    private HighMagePoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 65;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 30;
}