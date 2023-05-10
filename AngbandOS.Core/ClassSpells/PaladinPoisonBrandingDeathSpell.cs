[Serializable]
internal class PaladinPoisonBrandingDeathSpell : ClassSpell
{
    private PaladinPoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 75;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 30;
}