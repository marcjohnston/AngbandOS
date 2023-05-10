[Serializable]
internal class MageRayOfLightFolkSpell : ClassSpell
{
    private MageRayOfLightFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRayOfLight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 18;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 9;
}