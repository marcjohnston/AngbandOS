[Serializable]
internal class MageDarknessStormDeathSpell : ClassSpell
{
    private MageDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 40;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 200;
}