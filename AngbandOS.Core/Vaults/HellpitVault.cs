namespace AngbandOS.Core.Vaults;

[Serializable]
internal class HellpitVault : Vault
{
    private HellpitVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Hellpit";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..........................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X@@&....#8.#9....^^&&&&&&&&&&&&###.^^,,......+8*9+,,,,,X.%%.X@&@.............^^................^^,,......+9*9+,,,,,X.%%.X&@@.............^^@@@@@@@@@@@###..^^,,......+9*9+,,,,,X.%%.X.....#8....#9...^^................^^,,......+9*9+,,,,,X.%%.X................^^&&&&&&&&&&&&###.^^,,.&&&&&+9*9+,,,,,X.%%.X.......@@@@.....^^................^^,,.&@@@&+9*9+,,,,,X.%%.#....#8.@@@@.#9..^^@@@@@@@@@@@###..^^,,.&@9@&+8*9+,,,,,X.%%.X.......@@@@.....^^................^^,,.&@@@&+9*9+,,,,,X.%%.X................^^&&&&&&&&&&&&###.^^,,.&&&&&+9*9+,,,,,X.%%.X.....#8....#9...^^................^^,,......+9*9+,,,,,X.%%.X&@@.............^^@@@@@@@@@@@###..^^,,......+9*9+,,,,,X.%%.X@&@.............^^................^^,,......+9*9+,,,,,X.%%.X@@&....#8.#9....^^&&&&&&&&&&&&###.^^,,......+8*9+,,,,,X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%..........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 60;
}