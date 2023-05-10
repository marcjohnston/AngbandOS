internal class RangerTeleportCorporealSpell : ClassSpell
{
    private RangerTeleportCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleport);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 3;
}