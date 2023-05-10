internal class CultistPoisonBrandingDeathSpell : ClassSpell
{
    private CultistPoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 75;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 30;
}