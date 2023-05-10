[Serializable]
internal class HighMageRayOfLightFolkSpell : ClassSpell
{
    private HighMageRayOfLightFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRayOfLight);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 9;
}