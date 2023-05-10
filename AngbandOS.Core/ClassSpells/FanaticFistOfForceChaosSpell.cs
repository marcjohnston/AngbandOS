[Serializable]
internal class FanaticFistOfForceChaosSpell : ClassSpell
{
    private FanaticFistOfForceChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFistOfForce);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 9;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 6;
}