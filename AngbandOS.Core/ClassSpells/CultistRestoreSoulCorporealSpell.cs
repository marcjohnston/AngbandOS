[Serializable]
internal class CultistRestoreSoulCorporealSpell : ClassSpell
{
    private CultistRestoreSoulCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellRestoreSoul);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 55;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 175;
}