[Serializable]
internal class FanaticSummonDemonChaosSpell : ClassSpell
{
    private FanaticSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 47;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}