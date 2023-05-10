[Serializable]
internal class RogueTeleportAwayTarotSpell : ClassSpell
{
    private RogueTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 20;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}