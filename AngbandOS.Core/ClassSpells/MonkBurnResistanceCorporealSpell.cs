[Serializable]
internal class MonkBurnResistanceCorporealSpell : ClassSpell
{
    private MonkBurnResistanceCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBurnResistance);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 9;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}