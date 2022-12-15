namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultoctagonVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (octagon)*";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "    %%%%%%%%%%%%     %%%%..........%%%%  %...###+##+###...% %%...#,,#,,#,,#...%%%.###+##+##+##+###.%%.#,,#&&#**#&&#,,#.%%.#,,#&&#**#&&#,,#.%%.###+##+##+##+###.%%%...#,,#,,#,,#...%% %...###+##+###...%  %%%%..........%%%%     %%%%%%%%%%%%    ";
    public override int Width => 20;
}
