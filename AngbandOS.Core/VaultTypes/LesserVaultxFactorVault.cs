using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultxFactorVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (x-factor)";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%^^^^^^^^^^^^^^^^^^^^^^^^%%^##########++##########^%%^#XX,,,,,,,,,,,,,,,,XX#^%%^#,XX,,,,,,,,,,,,,,XX,#^%%^#,,XX,,,,,,,,,,,,XX,,#^%%^#,,,XX,,,,,,,,,,XX,,,#^%%^#,,,,XX,,,,,,,,XX,,,,#^%%^#,,,,,XX,,,,,,XX,,,,,#^%%^#,,,,,,XX,,,,XX,,,,,,#^%%^#,,,,,,,X+XX+X,,,,,,,#^%%^+,,,,,,,,X99X,,,,,,,,+^%%^+,,,,,,,,X99X,,,,,,,,+^%%^+,,,,,,,,X99X,,,,,,,,+^%%^#,,,,,,,X+XX+X,,,,,,,#^%%^#,,,,,,XX,,,,XX,,,,,,#^%%^#,,,,,XX,,,,,,XX,,,,,#^%%^#,,,,XX,,,,,,,,XX,,,,#^%%^#,,,XX,,,,,,,,,,XX,,,#^%%^#,,XX,,,,,,,,,,,,XX,,#^%%^#,XX,,,,,,,,,,,,,,XX,#^%%^#XX,,,,,,,,,,,,,,,,XX#^%%^##########++##########^%%^^^^^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 26;
}
