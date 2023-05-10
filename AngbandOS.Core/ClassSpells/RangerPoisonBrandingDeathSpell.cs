internal class RangerPoisonBrandingDeathSpell : ClassSpell
{
    private RangerPoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 80;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 20;
}