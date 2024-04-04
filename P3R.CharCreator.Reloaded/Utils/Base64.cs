namespace P3R.CharCreator.Reloaded.Utils;

internal static class Base64
{
    public static string Encode(string input)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(input);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Decode(string input)
    {
        var inputBytes = Convert.FromBase64String(input);
        return System.Text.Encoding.UTF8.GetString(inputBytes);
    }
}
