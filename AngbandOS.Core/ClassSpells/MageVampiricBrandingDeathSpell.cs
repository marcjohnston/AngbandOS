internal class MageVampiricBrandingDeathSpell : ClassSpell
{
    private MageVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 90;
}