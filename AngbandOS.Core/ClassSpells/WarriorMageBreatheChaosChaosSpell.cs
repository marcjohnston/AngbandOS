[Serializable]
internal class WarriorMageBreatheChaosChaosSpell : ClassSpell
{
    private WarriorMageBreatheChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellBreatheChaos);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}