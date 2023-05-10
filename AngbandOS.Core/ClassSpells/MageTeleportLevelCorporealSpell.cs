[Serializable]
internal class MageTeleportLevelCorporealSpell : ClassSpell
{
    private MageTeleportLevelCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleportLevel);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 18;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}