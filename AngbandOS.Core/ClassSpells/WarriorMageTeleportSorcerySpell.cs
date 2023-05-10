[Serializable]
internal class WarriorMageTeleportSorcerySpell : ClassSpell
{
    private WarriorMageTeleportSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleport);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}