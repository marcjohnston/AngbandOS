[Serializable]
internal class FanaticChaosBoltChaosSpell : ClassSpell
{
    private FanaticChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 14;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}