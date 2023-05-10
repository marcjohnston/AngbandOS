[Serializable]
internal class MonkWraithformCorporealSpell : ClassSpell
{
    private MonkWraithformCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellWraithform);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 70;
}