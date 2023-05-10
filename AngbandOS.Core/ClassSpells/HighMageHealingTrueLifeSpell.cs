[Serializable]
internal class HighMageHealingTrueLifeSpell : ClassSpell
{
    private HighMageHealingTrueLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHealingTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 75;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 115;
}