[Serializable]
internal class RogueTheFoolTarotSpell : ClassSpell
{
    private RogueTheFoolTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTheFool);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 15;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 20;
}