[Serializable]
internal class MageResistLightningFolkSpell : ClassSpell
{
    private MageResistLightningFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistLightning);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}