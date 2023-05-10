[Serializable]
internal class RangerSeeMagicCorporealSpell : ClassSpell
{
    private RangerSeeMagicCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeMagic);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 20;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}