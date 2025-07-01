
// 게임에 저장할 데이터의 키를 상수로 보관함
public static class MBPlayerPrefKeys
{
    //
    // PlayerStats
    //
    public const string Energy = "Energy";


    //
    // Off Game Time Section
    //
    public static string GetTimeKey()
    {
        return $"Time";
    }
}
