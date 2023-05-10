internal class RogueLightAreaSorcerySpell : ClassSpell
{
    private RogueLightAreaSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellLightArea);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 3;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 1;
}