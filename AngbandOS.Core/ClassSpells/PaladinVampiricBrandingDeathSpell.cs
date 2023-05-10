[Serializable]
internal class PaladinVampiricBrandingDeathSpell : ClassSpell
{
    private PaladinVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 100;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 100;
}