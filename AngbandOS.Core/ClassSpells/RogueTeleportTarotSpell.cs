[Serializable]
internal class RogueTeleportTarotSpell : ClassSpell
{
    private RogueTeleportTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleport);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 11;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 4;
}