[Serializable]
internal class MonkBreatheChaosChaosSpell : ClassSpell
{
    private MonkBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}