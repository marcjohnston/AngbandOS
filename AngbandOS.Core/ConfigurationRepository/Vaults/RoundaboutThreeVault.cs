// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class RoundaboutThreeVault : Vault
{
    private RoundaboutThreeVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Roundabout Three";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X,&,,,,,,,,,,,^^^^^^^^^^......XX.#X.XXX.......X.X.......XXX.X#.XX......^^^^^^^^^^,,,,,,,,,,,&,X%%X,&,,,,,,,,,,,^^^^^^^^^^.....XX.XX.XXX..XXXX..X.X..XXXX..XXX.XX.XX.....^^^^^^^^^^,,,,,,,,,,,&,X%%X,&,,,,,,,,,,,XXXXXXXXXX....XX.XX.XXX^^XX@@XX.X&X.XX@@XX^^XXX.XX.XX....XXXXXXXXXX,,,,,,,,,,,&,X%%X,&&&&&&&&&&XXX********XXX..XX.XX.XXX^^X****X.X&X.X****X^^XXX.XX.XX..XXX********XXX&&&&&&&&&&,X%%X,,,,,,,,,,XXX..XXXXXX...XX+XX.XX.XXX^^XX&&...X@X...&&XX^^XXX.XX.XX+XX...XXXXXX..XXX,,,,,,,,,,X%%X@@@@@@@@XXX..XXX****XXX.....XX.XX.XXX..XX...XX+XX...XX..XXX.XX.XX.....XXX****XXX..XXX@@@@@@@@X%%X9988899XXX..XXX.XXXX@@XXXXXX.XX.XX.XXX..XXXXX^^^XXXXX..XXX.XX.XX.XXXXXX@@XXXX.XXX..XXX9998999X%%X######XXX**X##&&@**XX&&&@98X^^^^^XX.##X^^^^^^^^^^^^^^^X##.XX^^^^^X89@&&&XX**@&&##X**XXX######X%%X######XXX**X##&&@**XX&&&@98X^^^^^XX.##X^^^^^^^^^^^^^^^X##.XX^^^^^X89@&&&XX**@&&##X**XXX######X%%X9988899XXX..XXX.XXXX@@XXXXXX.XX.XX.XXX..XXXXX^^^XXXXX..XXX.XX.XX.XXXXXX@@XXXX.XXX..XXX9998999X%%X@@@@@@@@XXX..XXX****XXX.....XX.XX.XXX..XX...XX+XX...XX..XXX.XX.XX.....XXX****XXX..XXX@@@@@@@@X%%X,,,,,,,,,,XXX..XXXXXX...XX+XX.XX.XXX^^XX&&...X@X...&&XX^^XXX.XX.XX+XX...XXXXXX..XXX,,,,,,,,,,X%%X,&&&&&&&&&&XXX********XXX..XX.XX.XXX^^X****X.X&X.X****X^^XXX.XX.XX..XXX********XXX&&&&&&&&&&,X%%X,&,,,,,,,,,,,XXXXXXXXXX....XX.XX.XXX^^XX@@XX.X&X.XX@@XX^^XXX.XX.XX....XXXXXXXXXX,,,,,,,,,,,&,X%%X,&,,,,,,,,,,,^^^^^^^^^^.....XX.XX.XXX..XXXX..X.X..XXXX..XXX.XX.XX.....^^^^^^^^^^,,,,,,,,,,,&,X%%X,&,,,,,,,,,,,^^^^^^^^^^......XX.#X.XXX.......X.X.......XXX.X#.XX......^^^^^^^^^^,,,,,,,,,,,&,X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 97;
}
