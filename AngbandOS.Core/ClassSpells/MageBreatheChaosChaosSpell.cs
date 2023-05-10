[Serializable]
internal class MageBreatheChaosChaosSpell : ClassSpell
{
    private MageBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 75;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}