namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaulttowerVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (tower)";
    public override int Category => 7;
    public override int Height => 18;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%.............%%..XXX...XXX..%%..X&XXXXX&X..%%..XX*****XX..%%...XX***XX...%%....X#+#X....%%....X&&&X....%%....X^^^X....%%....X#+#X....%%....X,,,X....%%....X^^^X....%%...XX+#+XX...%%..XX,&,&,XX..%%..X^^^*^^^X..%%.##+#####+##.%%...&.....&...%%%%%%%%%%%%%%%%";
    public override int Width => 15;
}
