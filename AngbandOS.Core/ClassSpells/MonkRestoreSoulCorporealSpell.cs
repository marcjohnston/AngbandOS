[Serializable]
internal class MonkRestoreSoulCorporealSpell : ClassSpell
{
    private MonkRestoreSoulCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreSoul);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 55;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}