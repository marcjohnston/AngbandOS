[Serializable]
internal class RogueRayOfLightFolkSpell : ClassSpell
{
    private RogueRayOfLightFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRayOfLight);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 26;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}