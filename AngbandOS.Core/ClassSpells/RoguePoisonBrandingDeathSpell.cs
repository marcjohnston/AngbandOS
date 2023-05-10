internal class RoguePoisonBrandingDeathSpell : ClassSpell
{
    private RoguePoisonBrandingDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellPoisonBranding);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 5;
}