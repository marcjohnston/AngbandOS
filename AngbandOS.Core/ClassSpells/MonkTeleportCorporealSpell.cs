[Serializable]
internal class MonkTeleportCorporealSpell : ClassSpell
{
    private MonkTeleportCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellTeleport);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}