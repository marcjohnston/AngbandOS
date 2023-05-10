[Serializable]
internal class RangerTerrorDeathSpell : ClassSpell
{
    private RangerTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 28;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 4;
}