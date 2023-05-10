[Serializable]
internal class CultistResistLightningFolkSpell : ClassSpell
{
    private CultistResistLightningFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistLightning);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 16;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}