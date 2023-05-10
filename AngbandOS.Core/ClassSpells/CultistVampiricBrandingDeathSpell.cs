internal class CultistVampiricBrandingDeathSpell : ClassSpell
{
    private CultistVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 90;
}