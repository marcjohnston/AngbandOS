using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultoverlapVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (overlap)";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%................%%.##########.....%%.#,,,^^^^^+&....%%.#,,,##########.%%.#,,,#****+,,,#.%%.#,,,+****#,,,#.%%.##########,,,#.%%....&+^^^^^,,,#.%%.....##########.%%................%%%%%%%%%%%%%%%%%%%";
    public override int Width => 18;
}
