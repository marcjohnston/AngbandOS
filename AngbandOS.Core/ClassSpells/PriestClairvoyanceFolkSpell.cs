[Serializable]
internal class PriestClairvoyanceFolkSpell : ClassSpell
{
    private PriestClairvoyanceFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellClairvoyance);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 120;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}