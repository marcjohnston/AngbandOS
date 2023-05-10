internal class FanaticInvokeChaosChaosSpell : ClassSpell
{
    private FanaticInvokeChaosChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellInvokeChaos);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 45;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 40;
}