[Serializable]
internal class RogueTerrorDeathSpell : ClassSpell
{
    private RogueTerrorDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellTerror);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 4;
}