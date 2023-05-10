[Serializable]
internal class CultistFlameStrikeChaosSpell : ClassSpell
{
    private CultistFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 32;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 40;
}