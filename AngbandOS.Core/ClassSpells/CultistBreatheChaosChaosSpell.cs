[Serializable]
internal class CultistBreatheChaosChaosSpell : ClassSpell
{
    private CultistBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 43;
    public override int ManaCost => 55;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 200;
}