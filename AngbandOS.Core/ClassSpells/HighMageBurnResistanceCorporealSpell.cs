[Serializable]
internal class HighMageBurnResistanceCorporealSpell : ClassSpell
{
    private HighMageBurnResistanceCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBurnResistance);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 8;
}