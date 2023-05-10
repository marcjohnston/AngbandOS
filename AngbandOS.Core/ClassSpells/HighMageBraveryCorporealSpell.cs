[Serializable]
internal class HighMageBraveryCorporealSpell : ClassSpell
{
    private HighMageBraveryCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBravery);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 15;
    public override int FirstCastExperience => 1;
}