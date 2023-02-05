namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaultmazeOfRoomsVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (maze of rooms)";
    public override int Category => 7;
    public override int Height => 16;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..............................%%.#+##########################.%%.#^#,,,+^#*#^+,,+*#^+^#*#**@#.%%.#^+,,,#^+^+^######^#^#*###+#.%%.#########+###,,,,#^#,+@#,,,#.%%.#,,,,,,+^^+,,,,,,+^#######+#.%%.###+#######,,,,,#####,,+^^^#.%%.#,,,+**#**+,,,,,#^^^+,,#^,^#.%%.#############+###^,^#+##^^^#.%%.#***#^+,,#,,,,,,+^^^#^######.%%.#+###^#,,+,,,,,,#####^+,^^^#.%%.#,,,+^#,,########,,,+^#,^^^#.%%.##########################+#.%%..............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 32;
}
