[Serializable]
internal class HighMageWraithformCorporealSpell : ClassSpell
{
    private HighMageWraithformCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellWraithform);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 70;
}