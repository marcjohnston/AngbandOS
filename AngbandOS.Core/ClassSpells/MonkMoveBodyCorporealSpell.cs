[Serializable]
internal class MonkMoveBodyCorporealSpell : ClassSpell
{
    private MonkMoveBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMoveBody);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 12;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}