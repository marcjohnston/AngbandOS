// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HellpitVault : VaultGameConfiguration
{
    public override string Name => "Hellpit";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..........................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X@@&....#8.#9....^^&&&&&&&&&&&&###.^^,,......+8*9+,,,,,X.%%.X@&@.............^^................^^,,......+9*9+,,,,,X.%%.X&@@.............^^@@@@@@@@@@@###..^^,,......+9*9+,,,,,X.%%.X.....#8....#9...^^................^^,,......+9*9+,,,,,X.%%.X................^^&&&&&&&&&&&&###.^^,,.&&&&&+9*9+,,,,,X.%%.X.......@@@@.....^^................^^,,.&@@@&+9*9+,,,,,X.%%.#....#8.@@@@.#9..^^@@@@@@@@@@@###..^^,,.&@9@&+8*9+,,,,,X.%%.X.......@@@@.....^^................^^,,.&@@@&+9*9+,,,,,X.%%.X................^^&&&&&&&&&&&&###.^^,,.&&&&&+9*9+,,,,,X.%%.X.....#8....#9...^^................^^,,......+9*9+,,,,,X.%%.X&@@.............^^@@@@@@@@@@@###..^^,,......+9*9+,,,,,X.%%.X@&@.............^^................^^,,......+9*9+,,,,,X.%%.X@@&....#8.#9....^^&&&&&&&&&&&&###.^^,,......+8*9+,,,,,X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%..........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 60;
}
