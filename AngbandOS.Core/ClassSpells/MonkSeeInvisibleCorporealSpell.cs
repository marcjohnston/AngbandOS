[Serializable]
internal class MonkSeeInvisibleCorporealSpell : ClassSpell
{
    private MonkSeeInvisibleCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeInvisible);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}