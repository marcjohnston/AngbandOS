[Serializable]
internal class CultistTeleportLevelSorcerySpell : ClassSpell
{
    private CultistTeleportLevelSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellTeleportLevel);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}