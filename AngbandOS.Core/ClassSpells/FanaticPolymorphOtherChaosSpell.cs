[Serializable]
internal class FanaticPolymorphOtherChaosSpell : ClassSpell
{
    private FanaticPolymorphOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellPolymorphOther);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}