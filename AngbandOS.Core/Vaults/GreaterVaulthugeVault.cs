// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaulthugeVault : Vault
{
    private GreaterVaulthugeVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (huge)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 45;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%+&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#88888888888#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#&+%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
