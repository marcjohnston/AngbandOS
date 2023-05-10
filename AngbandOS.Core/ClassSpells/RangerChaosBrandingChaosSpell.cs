internal class RangerChaosBrandingChaosSpell : ClassSpell
{
    private RangerChaosBrandingChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBranding);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}