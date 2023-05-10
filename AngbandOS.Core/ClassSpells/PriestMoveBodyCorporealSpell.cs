[Serializable]
internal class PriestMoveBodyCorporealSpell : ClassSpell
{
    private PriestMoveBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMoveBody);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}