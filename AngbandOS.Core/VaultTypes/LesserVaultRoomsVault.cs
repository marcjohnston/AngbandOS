using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultRoomsVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser Vault (Rooms)";
    public override int Category => 7;
    public override int Height => 13;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%.................%%.###############.%%.#^+,&&#*,*+&&&#.%%.#^#,,&#,@,#***#.%%.#^#9,,+*,*#,,,+.%%.#^#############.%%.#^#9,,+*,*#,,,+.%%.#^#,,&#,@,#***#.%%.#^+,&&#*,*+&&&#.%%.###############.%%.................%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 19;
}
