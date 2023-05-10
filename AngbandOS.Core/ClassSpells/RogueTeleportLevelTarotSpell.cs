[Serializable]
internal class RogueTeleportLevelTarotSpell : ClassSpell
{
    private RogueTeleportLevelTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportLevel);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 38;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 10;
}