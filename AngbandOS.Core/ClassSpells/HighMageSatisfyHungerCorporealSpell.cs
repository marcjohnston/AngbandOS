[Serializable]
internal class HighMageSatisfyHungerCorporealSpell : ClassSpell
{
    private HighMageSatisfyHungerCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSatisfyHunger);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 9;
}