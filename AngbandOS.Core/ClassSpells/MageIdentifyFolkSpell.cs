[Serializable]
internal class MageIdentifyFolkSpell : ClassSpell
{
    private MageIdentifyFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellIdentify);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}