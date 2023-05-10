internal class RogueRechargingFolkSpell : ClassSpell
{
    private RogueRechargingFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRecharging);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 36;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}