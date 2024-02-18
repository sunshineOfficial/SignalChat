using System.Security.Cryptography;
using System.Text;

namespace SignalChat.Common;

/// <summary>
/// Класс для работы с хешем.
/// </summary>
public static class Hash
{
    /// <summary>
    /// Получает хеш строки.
    /// </summary>
    /// <param name="str">Строка, хеш которой нужно получить.</param>
    /// <returns>Хеш строки.</returns>
    public static string GetHash(string str)
    {
        var hash = MD5.HashData(Encoding.ASCII.GetBytes(str));
        var output = new StringBuilder(hash.Length);
        foreach (var b in hash)
        {
            output.Append(b.ToString("X2"));
        }

        return output.ToString();
    }
}