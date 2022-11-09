using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultCamouflagedVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser Vault (Camouflaged)";
    public override int Category => 7;
    public override int Height => 9;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%XXXXXXXXXX%%#,,,,,,,,X%%XXXXXXXXXX%%X,,,,,,,,#%%XXXXXXXXXX%%#,,,,,,,,X%%XXXXXXXXXX%%%%%%%%%%%%%";
    public override int Width => 12;
}
