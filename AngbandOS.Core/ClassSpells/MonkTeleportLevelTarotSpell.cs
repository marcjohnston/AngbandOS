[Serializable]
internal class MonkTeleportLevelTarotSpell : ClassSpell
{
    private MonkTeleportLevelTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportLevel);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 38;
    public override int ManaCost => 35;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 10;
}