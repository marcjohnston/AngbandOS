[Serializable]
internal class PriestTeleportCorporealSpell : ClassSpell
{
    private PriestTeleportCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleport);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 22;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}