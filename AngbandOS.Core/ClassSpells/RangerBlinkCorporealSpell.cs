[Serializable]
internal class RangerBlinkCorporealSpell : ClassSpell
{
    private RangerBlinkCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBlink);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 2;
}