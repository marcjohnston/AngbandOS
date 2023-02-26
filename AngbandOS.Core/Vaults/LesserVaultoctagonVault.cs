namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultoctagonVault : Vault
{
    private LesserVaultoctagonVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (octagon)*";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "    %%%%%%%%%%%%     %%%%..........%%%%  %...###+##+###...% %%...#,,#,,#,,#...%%%.###+##+##+##+###.%%.#,,#&&#**#&&#,,#.%%.#,,#&&#**#&&#,,#.%%.###+##+##+##+###.%%%...#,,#,,#,,#...%% %...###+##+###...%  %%%%..........%%%%     %%%%%%%%%%%%    ";
    public override int Width => 20;
}
