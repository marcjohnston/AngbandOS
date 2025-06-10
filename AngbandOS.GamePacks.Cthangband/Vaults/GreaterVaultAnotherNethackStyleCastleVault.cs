// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreaterVaultAnotherNethackStyleCastleVault : VaultGameConfiguration
{
    public override string Name => "Greater vault (another nethack-style castle)";
    public override int Category => 8;
    public override int Height => 18;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..................................................%%.XXXXX......................................XXXXX.%%.X9,,X......................................X,,9X.%%.XXX+XXXXXXXXXXXXXXXXXXX++XXXXXXXXXXXXXXXXXXX+XXX.%%...X^^^^^^^^^^^^^^^^^^^+..+^^^^^^^^^^^^^^^^^^^X...%%...X^XXXXXXXXXXXXXXXXXXX++XXXXXXXXXXXXXXXXXXX^X...%%...X^X,,,,,,,,,,,,,,,,,X..X,,,,,,,,,X,,@@@@,X^X...%%...X^X,,,,,,,,,,,,,,,,,+..+,,,,,,,,,+,,,,998X^X...%%...X^X,,,,,,,,,,,,,,,,,+..+,,,,,,,,,+,,,,998X^X...%%...X^X,,,,,,,,,,,,,,,,,X..X,,,,,,,,,X,,@@@@,X^X...%%...X^XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX^X...%%...X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X...%%.XXX+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXX.%%.X9,,X......................................X,,9X.%%.XXXXX......................................XXXXX.%%..................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 52;
}
