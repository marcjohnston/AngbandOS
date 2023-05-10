[Serializable]
internal class MonkSeeMagicCorporealSpell : ClassSpell
{
    private MonkSeeMagicCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeMagic);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}