[Serializable]
internal class MonkResistTrueCorporealSpell : ClassSpell
{
    private MonkResistTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellResistTrue);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 20;
}