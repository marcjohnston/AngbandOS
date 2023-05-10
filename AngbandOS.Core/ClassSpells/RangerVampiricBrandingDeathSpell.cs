internal class RangerVampiricBrandingDeathSpell : ClassSpell
{
    private RangerVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}