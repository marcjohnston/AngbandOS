[Serializable]
internal class RangerRechargingFolkSpell : ClassSpell
{
    private RangerRechargingFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRecharging);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 36;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}