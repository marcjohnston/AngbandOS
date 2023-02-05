namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class TargetPracticeVault : Vault
{
    public override char Character => '#';
    public override string Name => "Target Practice";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X@........................................................#%%X@XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.#%%X@#89XXXXX...9&..@.9....&....##..........#....#@,,,,,,,,X.#%%X@X9XX,,,XX......@..........XX..........XX....X@....XXX.X.#%%X@XXX,XXX,XX....*.,.&....*.XX***********X.....X@..XXX&+.X.#%%X@XX,XX@XX,X.........,9...XX&&&&&&&&&&&&X@@@@@X@XXX**&+.X.#%%X@XX,X999X,X&.@..,.......XXXXXXXXXXXXXXXXXX+XXXXXX*XXXX.X.#%%X@XX,#989X,#.....9......XX99,,,,,,,,,,#,,,,,,,XXX&*&@@X.#.#%%X@XX,#989X,#.......&..@.XX99,,,,,,,,,,#,,,,,,,XXX&*&@@X.#.#%%X@XX,X999X,X...&.&.......XXXXXXXXXXXXXXXXXX+XXXXXX*XXXX.X.#%%X@XX,XX@XX,X..,...........XX&&&&&&&&&&&&X@@@@@X@XXX**&+.X.#%%X@XXX,XXX,XX......@..@.....XX***********X.....X@..XXX&+.X.#%%X@X9XX,,,XX.....9...........XX..........XX....X@....XXX.X.#%%X@#89XXXXX..&..........9.,...##..........#....#@,,,,,,,,X.#%%X@XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.#%%X@........................................................#%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 61;
}
