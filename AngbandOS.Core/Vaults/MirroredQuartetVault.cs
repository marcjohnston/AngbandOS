// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class MirroredQuartetVault : Vault
{
    private MirroredQuartetVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Mirrored Quartet";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X89@@@XXX,,,,XXX....^^^^^^^....XXX,,,,XXX@@@98X%%X9@@#XX....XXX**....XXX#XXX....**XXX....XX#@@9X%%X@XXX&&&&XXX**....@XX&&@&&XX@....**XXX&&&&XXX@X%%XXX....XXX**......@X**...**X@......**XXX....XXX%%X@...XXX**.......XXXXX...XXXXX.......**XXX...@X%%X@.#XX**.......9XX888XX^XX888XX9.......**XX#.@X%%XXXX&&&&&&&&&&&9#,,,,,X^X,,,,,#9&&&&&&&&&&&XXXX%%XXXXXXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXXXXXX%%#,,,,,,,,,,,,,,,,,,,,,#8#,,,,,,,,,,,,,,,,,,,,,#%%XXXXXXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXXXXXX%%XXXX&&&&&&&&&&&9#,,,,,X^X,,,,,#9&&&&&&&&&&&XXXX%%X@.#XX**.......9XX888XX^XX888XX9.......**XX#.@X%%X@...XXX**.......XXXXX...XXXXX.......**XXX...@X%%XXX....XXX**......@X**...**X@......**XXX....XXX%%X@XXX&&&&XXX**....@XX&&@&&XX@....**XXX&&&&XXX@X%%X9@@#XX....XXX**....XXX#XXX....**XXX....XX#@@9X%%X89@@@XXX,,,,XXX**..^^^^^^^..**XXX,,,,XXX@@@98X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 49;
}
