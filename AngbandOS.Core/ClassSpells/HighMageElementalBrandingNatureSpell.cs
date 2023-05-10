[Serializable]
internal class HighMageElementalBrandingNatureSpell : ClassSpell
{
    private HighMageElementalBrandingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellElementalBranding);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 80;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}