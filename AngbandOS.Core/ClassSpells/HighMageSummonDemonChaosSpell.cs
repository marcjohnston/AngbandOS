internal class HighMageSummonDemonChaosSpell : ClassSpell
{
    private HighMageSummonDemonChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellSummonDemon);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 90;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 250;
}