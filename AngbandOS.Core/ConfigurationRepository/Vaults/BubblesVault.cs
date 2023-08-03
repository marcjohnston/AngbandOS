// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class BubblesVault : Vault
{
    private BubblesVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Bubbles";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXX#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X8X#X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.#.9.X.9.#.9.X.9.#.9.#.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8XXX8X#X8X#X8X#X8X#X8X#X8X#X8X#X8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.X.9.#.9.X.9.#.9.X.9.X.9..X%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8X#X8XXX8X#X8XXX8XXX8XXX8XXX8XXX8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.X.9.#.9.X.9.#.9.#.9.#.9.#.9.X.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8X#X8X#X8X#X8XXX8XXX8XXX8XXX8X#X8XXX8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.#.9.#.9.#.9.#.9.#.9.X.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%##.9.#.9.#.9.#.9.#.9.#.9.#.9.#.9.X.9.XX%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 41;
}
