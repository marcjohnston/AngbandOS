[Serializable]
internal class FanaticDisintegrateChaosSpell : ClassSpell
{
    private FanaticDisintegrateChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellDisintegrate);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 35;
}