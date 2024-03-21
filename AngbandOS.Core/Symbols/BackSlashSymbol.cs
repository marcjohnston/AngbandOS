[Serializable]
internal class BackSlashSymbol : Symbol
{
    private BackSlashSymbol(SaveGame saveGame) : base(saveGame) { }
    public override char Character => '\\';
    public override string Name => "A hafted weapon (mace/whip/etc)";
}