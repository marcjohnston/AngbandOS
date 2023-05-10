internal class MageRechargingFolkSpell : ClassSpell
{
    private MageRechargingFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRecharging);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}