[Serializable]
internal class MageSeeMagicCorporealSpell : ClassSpell
{
    private MageSeeMagicCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeMagic);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 10;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}