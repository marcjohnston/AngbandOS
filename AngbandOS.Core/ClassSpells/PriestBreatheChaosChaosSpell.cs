[Serializable]
internal class PriestBreatheChaosChaosSpell : ClassSpell
{
    private PriestBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 95;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}