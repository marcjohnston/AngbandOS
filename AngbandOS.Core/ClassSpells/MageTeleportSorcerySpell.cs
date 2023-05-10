[Serializable]
internal class MageTeleportSorcerySpell : ClassSpell
{
    private MageTeleportSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleport);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}