[Serializable]
internal class WarriorMageTeleportLevelCorporealSpell : ClassSpell
{
    private WarriorMageTeleportLevelCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleportLevel);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}