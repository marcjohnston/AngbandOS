[Serializable]
internal class RangerMoveBodyCorporealSpell : ClassSpell
{
    private RangerMoveBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMoveBody);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 25;
}