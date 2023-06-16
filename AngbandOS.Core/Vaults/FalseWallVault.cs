// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class FalseWallVault : Vault
{
    private FalseWallVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "False Wall";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%X+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%X^+^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXXXX+X##X+XXXXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+@*&*@*&*@*&*@*&*@*&*@*&*@*X@@X*@*&*@*&*@*&*@*&*@*&*@*&*@+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXXX+XX,,XX+XXXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+&.@.&.@.&.@.&.@.&.@.&.@.&X*..*X&.@.&.@.&.@.&.@.&.@.&.@.&+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXX+XX*..*XX+XXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+,,,,,,,,,,,,,,,,,,,,,,,,X,,..,,X,,,,,,,,,,,,,,,,,,,,,,,,+^X%%X^XXXXXXXXXXXXXXXXXXXXXXX+XX##99##XX+XXXXXXXXXXXXXXXXXXXXXXX^X%%X^+&.@.&.@.&.@.&.@.&.@.&.@X..####..X@.&.@.&.@.&.@.&.@.&.@.&+^X%%X^XXXXXXXXXXXXXXXXXXXXXX+XX...##...XX+XXXXXXXXXXXXXXXXXXXXXX^X%%X^+*&*@*&*@*&*@*&*@*&*@*&X&@&@88&@&@X&*@*&*@*&*@*&*@*&*@*&*+^X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 64;
}
