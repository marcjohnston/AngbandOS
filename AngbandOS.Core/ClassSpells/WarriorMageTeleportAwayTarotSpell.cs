[Serializable]
internal class WarriorMageTeleportAwayTarotSpell : ClassSpell
{
    private WarriorMageTeleportAwayTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTeleportAway);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 18;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 5;
}