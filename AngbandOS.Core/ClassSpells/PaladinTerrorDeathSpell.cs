internal class PaladinTerrorDeathSpell : ClassSpell
{
    private PaladinTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 10;
}