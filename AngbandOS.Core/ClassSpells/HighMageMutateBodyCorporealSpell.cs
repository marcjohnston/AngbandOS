[Serializable]
internal class HighMageMutateBodyCorporealSpell : ClassSpell
{
    private HighMageMutateBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMutateBody);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 9;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 25;
}