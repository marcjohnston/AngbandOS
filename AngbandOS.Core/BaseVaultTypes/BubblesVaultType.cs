using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BubblesVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Bubbles";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXX#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X8X#X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.#.9.X.9.#.9.X.9.#.9.#.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8XXX8X#X8X#X8X#X8X#X8X#X8X#X8X#X8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.X.9.#.9.X.9.#.9.X.9.X.9..X%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8X#X8XXX8X#X8XXX8XXX8XXX8XXX8XXX8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.X.9.#.9.X.9.#.9.#.9.#.9.#.9.X.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8X#X8X#X8X#X8XXX8XXX8XXX8XXX8X#X8XXX8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%XX.9.#.9.X.9.#.9.#.9.#.9.#.9.#.9.X.9.XX%%XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX.XXX%%X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X#X8X%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%##.9.#.9.#.9.#.9.#.9.#.9.#.9.#.9.X.9.XX%%XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.XX#.#XX%%X8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8XXX8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 41;
}
