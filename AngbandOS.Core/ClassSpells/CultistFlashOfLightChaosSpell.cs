internal class CultistFlashOfLightChaosSpell : ClassSpell
{
    private CultistFlashOfLightChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlashOfLight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 4;
}