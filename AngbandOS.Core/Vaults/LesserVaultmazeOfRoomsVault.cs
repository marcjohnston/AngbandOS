namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultmazeOfRoomsVault : Vault
{
    private LesserVaultmazeOfRoomsVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (maze of rooms)";
    public override int Category => 7;
    public override int Height => 16;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..............................%%.#+##########################.%%.#^#,,,+^#*#^+,,+*#^+^#*#**@#.%%.#^+,,,#^+^+^######^#^#*###+#.%%.#########+###,,,,#^#,+@#,,,#.%%.#,,,,,,+^^+,,,,,,+^#######+#.%%.###+#######,,,,,#####,,+^^^#.%%.#,,,+**#**+,,,,,#^^^+,,#^,^#.%%.#############+###^,^#+##^^^#.%%.#***#^+,,#,,,,,,+^^^#^######.%%.#+###^#,,+,,,,,,#####^+,^^^#.%%.#,,,+^#,,########,,,+^#,^^^#.%%.##########################+#.%%..............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 32;
}
