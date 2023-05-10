internal class MageCallChaosChaosSpell : ClassSpell
{
    private MageCallChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellCallChaos);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 41;
    public override int ManaCost => 42;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 100;
}