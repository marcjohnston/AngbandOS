[Serializable]
internal class WarriorMageTheFoolTarotSpell : ClassSpell
{
    private WarriorMageTheFoolTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTheFool);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 18;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 20;
}