[Serializable]
internal class WarriorMageTeleportLevelTarotSpell : ClassSpell
{
    private WarriorMageTeleportLevelTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportLevel);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 10;
}