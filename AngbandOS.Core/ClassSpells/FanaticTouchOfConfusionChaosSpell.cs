internal class FanaticTouchOfConfusionChaosSpell : ClassSpell
{
    private FanaticTouchOfConfusionChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTouchOfConfusion);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 6;
}