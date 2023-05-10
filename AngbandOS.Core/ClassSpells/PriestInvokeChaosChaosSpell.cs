internal class PriestInvokeChaosChaosSpell : ClassSpell
{
    private PriestInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 37;
    public override int ManaCost => 42;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 40;
}