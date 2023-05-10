internal class RogueDarknessStormDeathSpell : ClassSpell
{
    private RogueDarknessStormDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDarknessStorm);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 50;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}