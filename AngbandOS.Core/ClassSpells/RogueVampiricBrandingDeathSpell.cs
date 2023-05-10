internal class RogueVampiricBrandingDeathSpell : ClassSpell
{
    private RogueVampiricBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampiricBranding);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 100;
}