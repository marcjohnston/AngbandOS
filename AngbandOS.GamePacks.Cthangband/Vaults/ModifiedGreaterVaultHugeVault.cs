// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ModifiedGreaterVaultHugeVault : VaultGameConfiguration
{
    public override string Name => "Modified Greater Vault (Huge)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 45;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X%%X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X8X%%X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X#X%%X8X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X8X%%X#X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXX#X#X%%X8X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X8X%%X#X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#8#%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
