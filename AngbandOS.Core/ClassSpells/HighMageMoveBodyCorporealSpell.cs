[Serializable]
internal class HighMageMoveBodyCorporealSpell : ClassSpell
{
    private HighMageMoveBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMoveBody);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}