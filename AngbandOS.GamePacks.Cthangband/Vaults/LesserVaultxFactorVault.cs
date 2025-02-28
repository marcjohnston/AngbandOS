// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LesserVaultxFactorVault : VaultGameConfiguration
{
    public override string Name => "Lesser vault (x-factor)";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%^^^^^^^^^^^^^^^^^^^^^^^^%%^##########++##########^%%^#XX,,,,,,,,,,,,,,,,XX#^%%^#,XX,,,,,,,,,,,,,,XX,#^%%^#,,XX,,,,,,,,,,,,XX,,#^%%^#,,,XX,,,,,,,,,,XX,,,#^%%^#,,,,XX,,,,,,,,XX,,,,#^%%^#,,,,,XX,,,,,,XX,,,,,#^%%^#,,,,,,XX,,,,XX,,,,,,#^%%^#,,,,,,,X+XX+X,,,,,,,#^%%^+,,,,,,,,X99X,,,,,,,,+^%%^+,,,,,,,,X99X,,,,,,,,+^%%^+,,,,,,,,X99X,,,,,,,,+^%%^#,,,,,,,X+XX+X,,,,,,,#^%%^#,,,,,,XX,,,,XX,,,,,,#^%%^#,,,,,XX,,,,,,XX,,,,,#^%%^#,,,,XX,,,,,,,,XX,,,,#^%%^#,,,XX,,,,,,,,,,XX,,,#^%%^#,,XX,,,,,,,,,,,,XX,,#^%%^#,XX,,,,,,,,,,,,,,XX,#^%%^#XX,,,,,,,,,,,,,,,,XX#^%%^##########++##########^%%^^^^^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 26;
}
