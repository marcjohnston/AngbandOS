internal class CultistRechargingFolkSpell : ClassSpell
{
    private CultistRechargingFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellRecharging);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}