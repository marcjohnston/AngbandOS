[Serializable]
internal class PaladinDarknessStormDeathSpell : ClassSpell
{
    private PaladinDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 50;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}