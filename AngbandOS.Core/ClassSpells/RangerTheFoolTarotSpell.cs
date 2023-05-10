[Serializable]
internal class RangerTheFoolTarotSpell : ClassSpell
{
    private RangerTheFoolTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTheFool);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 20;
}