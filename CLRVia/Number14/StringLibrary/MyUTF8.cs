using System.Text;

namespace StringLibrary
{
    public class MyUTF8
    {
        public static string Decode(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder result = new StringBuilder();
            var nextIndex = 0;
            for (int i = 0; i < bytes.Length; i = nextIndex)
            {
                if (bytes[i] >= 0b11111000)
                {
                    throw new Exception("编码错误");
                }
                if (bytes[i] >= 0b00000000 && bytes[i] < 0b10000000)
                {
                    result.Append((char)bytes[i]);
                    nextIndex = i + 1;
                }
                if (bytes[i] >= 0b11000000 && bytes[i] < 0b11100000)
                {
                    nextIndex = i + 2;
                }
                if (bytes[i] >= 0b11100000 && bytes[i] < 0b11110000)
                {
                    nextIndex = i + 3;
                }
                if (bytes[i] >= 0b11110000)
                {
                    nextIndex = i + 4;
                }
            }

            return result.ToString();
        }
    }
}
