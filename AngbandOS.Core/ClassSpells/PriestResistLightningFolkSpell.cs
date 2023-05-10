internal class PriestResistLightningFolkSpell : ClassSpell
{
    private PriestResistLightningFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellResistLightning);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}