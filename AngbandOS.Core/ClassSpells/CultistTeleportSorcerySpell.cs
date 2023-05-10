[Serializable]
internal class CultistTeleportSorcerySpell : ClassSpell
{
    private CultistTeleportSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleport);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}