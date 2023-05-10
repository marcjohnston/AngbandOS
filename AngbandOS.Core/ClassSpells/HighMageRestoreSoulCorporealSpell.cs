[Serializable]
internal class HighMageRestoreSoulCorporealSpell : ClassSpell
{
    private HighMageRestoreSoulCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreSoul);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 175;
}