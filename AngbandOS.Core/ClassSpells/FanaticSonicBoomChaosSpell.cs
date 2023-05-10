internal class FanaticSonicBoomChaosSpell : ClassSpell
{
    private FanaticSonicBoomChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSonicBoom);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 17;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 20;
}