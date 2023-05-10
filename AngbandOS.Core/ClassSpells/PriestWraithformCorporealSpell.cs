[Serializable]
internal class PriestWraithformCorporealSpell : ClassSpell
{
    private PriestWraithformCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellWraithform);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 70;
}