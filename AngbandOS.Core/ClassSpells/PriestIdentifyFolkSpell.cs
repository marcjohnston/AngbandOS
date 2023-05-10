[Serializable]
internal class PriestIdentifyFolkSpell : ClassSpell
{
    private PriestIdentifyFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellIdentify);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 37;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}