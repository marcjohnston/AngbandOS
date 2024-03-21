// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class TargetPracticeVault : Vault
{
    private TargetPracticeVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "Target Practice";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X@........................................................#%%X@XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.#%%X@#89XXXXX...9&..@.9....&....##..........#....#@,,,,,,,,X.#%%X@X9XX,,,XX......@..........XX..........XX....X@....XXX.X.#%%X@XXX,XXX,XX....*.,.&....*.XX***********X.....X@..XXX&+.X.#%%X@XX,XX@XX,X.........,9...XX&&&&&&&&&&&&X@@@@@X@XXX**&+.X.#%%X@XX,X999X,X&.@..,.......XXXXXXXXXXXXXXXXXX+XXXXXX*XXXX.X.#%%X@XX,#989X,#.....9......XX99,,,,,,,,,,#,,,,,,,XXX&*&@@X.#.#%%X@XX,#989X,#.......&..@.XX99,,,,,,,,,,#,,,,,,,XXX&*&@@X.#.#%%X@XX,X999X,X...&.&.......XXXXXXXXXXXXXXXXXX+XXXXXX*XXXX.X.#%%X@XX,XX@XX,X..,...........XX&&&&&&&&&&&&X@@@@@X@XXX**&+.X.#%%X@XXX,XXX,XX......@..@.....XX***********X.....X@..XXX&+.X.#%%X@X9XX,,,XX.....9...........XX..........XX....X@....XXX.X.#%%X@#89XXXXX..&..........9.,...##..........#....#@,,,,,,,,X.#%%X@XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.#%%X@........................................................#%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 61;
}
