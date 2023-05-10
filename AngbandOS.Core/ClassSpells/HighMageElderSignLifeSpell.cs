[Serializable]
internal class HighMageElderSignLifeSpell : ClassSpell
{
    private HighMageElderSignLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellElderSign);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 50;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 5;
}