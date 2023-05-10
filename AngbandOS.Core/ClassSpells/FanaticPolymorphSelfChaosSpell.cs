[Serializable]
internal class FanaticPolymorphSelfChaosSpell : ClassSpell
{
    private FanaticPolymorphSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphSelf);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 50;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 250;
}