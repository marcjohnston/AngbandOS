internal class FanaticWonderChaosSpell : ClassSpell
{
    private FanaticWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 12;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 7;
}