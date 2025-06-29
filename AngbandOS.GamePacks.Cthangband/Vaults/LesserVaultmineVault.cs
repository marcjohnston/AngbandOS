// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LesserVaultmineVault : VaultGameConfiguration
{
    public override string Name => "Lesser vault (mine)";
    public override int Category => 7;
    public override int Height => 9;
    public override int Rating => 7;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.XXXXXXXXXXXXXXXXXX%%.XX##XXXX*,,XX,*,XX%%.*#XX,*##X*#XX***XX%%.XXXX*,XXXXX##,*,XX%%.XXXXXXXXXXXXXXXXXX%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
