[Serializable]
internal class PriestTerrorDeathSpell : ClassSpell
{
    private PriestTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 21;
    public override int ManaCost => 20;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 10;
}