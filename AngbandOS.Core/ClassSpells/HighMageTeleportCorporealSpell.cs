[Serializable]
internal class HighMageTeleportCorporealSpell : ClassSpell
{
    private HighMageTeleportCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleport);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 8;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 8;
}