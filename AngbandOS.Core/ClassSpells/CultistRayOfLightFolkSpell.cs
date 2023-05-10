internal class CultistRayOfLightFolkSpell : ClassSpell
{
    private CultistRayOfLightFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRayOfLight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 23;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}