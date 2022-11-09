using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ModifiedGreaterVaultHugeVault : Vault
{
    public override char Character => '#';
    public override string Name => "Modified Greater Vault (Huge)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 45;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X%%X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X8X%%X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X#X%%X8X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X8X%%X#X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X%%X8X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X%%X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
