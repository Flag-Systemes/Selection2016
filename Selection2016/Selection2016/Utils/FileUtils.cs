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

    public static string FileIn1 { get { return "busy_day.in"; } }

    public static string FileOut1 { get { return "busy_day.out"; } }

    public static string FileIn2 { get { return "mother_of_all_warehouses.in"; } }

    public static string FileOut2 { get { return "mother_of_all_warehouses.out"; } }

    public static string FileIn3 { get { return "redundancy.in"; } }

    public static string FileOut3 { get { return "redundancy.out"; } }

    public static string NewLine { get { return Environment.NewLine; } }

    public static List<string> In1
    {
      get
      {
        if (FileUtils._input == null)
        {
          string line;
          FileUtils._input = new List<string>();
          StreamReader input = new StreamReader(FileUtils.FileIn1);

          while ((line = input.ReadLine()) != null)
          {
            FileUtils._input.Add(line);
          }
        }

        return FileUtils._input;
      }
    }

    public static StreamWriter Output1
    {
      get
      {
        if (FileUtils._output == null)
        {
          FileUtils._output = new StreamWriter(FileUtils.FileOut1);
        }

        return FileUtils._output;
      }
    }

    public static List<string> In2
    {
      get
      {
        if (FileUtils._input == null)
        {
          string line;
          FileUtils._input = new List<string>();
          StreamReader input = new StreamReader(FileUtils.FileIn2);

          while ((line = input.ReadLine()) != null)
          {
            FileUtils._input.Add(line);
          }
        }

        return FileUtils._input;
      }
    }

    public static StreamWriter Output2
    {
      get
      {
        if (FileUtils._output == null)
        {
          FileUtils._output = new StreamWriter(FileUtils.FileOut2);
        }

        return FileUtils._output;
      }
    }

    public static List<string> In3
    {
      get
      {
        if (FileUtils._input == null)
        {
          string line;
          FileUtils._input = new List<string>();
          StreamReader input = new StreamReader(FileUtils.FileIn3);

          while ((line = input.ReadLine()) != null)
          {
            FileUtils._input.Add(line);
          }
        }

        return FileUtils._input;
      }
    }

    public static StreamWriter Output3
    {
      get
      {
        if (FileUtils._output == null)
        {
          FileUtils._output = new StreamWriter(FileUtils.FileOut3);
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
