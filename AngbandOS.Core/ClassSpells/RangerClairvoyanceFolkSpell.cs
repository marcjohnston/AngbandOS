[Serializable]
internal class RangerClairvoyanceFolkSpell : ClassSpell
{
    private RangerClairvoyanceFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellClairvoyance);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 99;
    public override int ManaCost => 0;
    public override int BaseFailure => 0;
    public override int FirstCastExperience => 0;
}