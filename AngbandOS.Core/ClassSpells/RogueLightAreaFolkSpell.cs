[Serializable]
internal class RogueLightAreaFolkSpell : ClassSpell
{
    private RogueLightAreaFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellLightArea);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 6;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}