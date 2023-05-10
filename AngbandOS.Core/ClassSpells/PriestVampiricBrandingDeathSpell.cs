[Serializable]
internal class PriestVampiricBrandingDeathSpell : ClassSpell
{
    private PriestVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 95;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 90;
}