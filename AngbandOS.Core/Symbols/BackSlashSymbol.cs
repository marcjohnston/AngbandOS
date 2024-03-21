[Serializable]
internal class BackSlashSymbol : Symbol
{
    private BackSlashSymbol(Game game) : base(game) { }
    public override char Character => '\\';
    public override string Name => "A hafted weapon (mace/whip/etc)";
}