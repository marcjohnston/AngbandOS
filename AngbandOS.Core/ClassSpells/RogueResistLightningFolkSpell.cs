[Serializable]
internal class RogueResistLightningFolkSpell : ClassSpell
{
    private RogueResistLightningFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistLightning);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}