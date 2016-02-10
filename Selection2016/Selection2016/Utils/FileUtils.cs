using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Selection2016.Utils
{
  public static class FileUtils
  {
    private static List<string> _input;

    private static StreamWriter _output;

    public static string FileIn { get { return "input.txt"; } }

    public static string FileOut { get { return "output.txt"; } }

    public static string NewLine { get { return Environment.NewLine; } }

    public static List<string> In
    {
      get
      {
        if (FileUtils._input == null)
        {
          string line;
          FileUtils._input = new List<string>();
          StreamReader input = new StreamReader(FileUtils.FileIn);

          while ((line = input.ReadLine()) != null)
          {
            FileUtils._input.Add(line);
          }
        }

        return FileUtils._input;
      }
    }

    public static StreamWriter Output
    {
      get
      {
        if(FileUtils._output == null)
        {
          FileUtils._output = new StreamWriter(FileUtils.FileOut);
        }

        return FileUtils._output;
      }
    }

    public static List<T> Split<T>(this string input, params char[] separator) where T: IConvertible
    {
      List<T> result = new List<T>();
      Type itemType = typeof (T);
      T defaultValue = default(T);
      TypeCode type = defaultValue.GetTypeCode();
      List<string> temp = input.Split(separator).ToList();

      temp.ForEach(item => result.Add((T)Convert.ChangeType(item, type)));

      return result;
    }
  }
}
