using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Trader
{
    public static class StreamUtilities
    {
        public static T Create<T>(T obj, StreamReader streamReader) where T : ICodeable
        {
            obj.ReadFromStream(streamReader);
            return obj;
        }

        public static void PrintValue<T>(T obj, StreamWriter streamWriter)
        {
            streamWriter.WriteLine(typeof(T).Name + "=" + obj.ToString());
        }

        public static void PrintValue<T>(T obj, string name, StreamWriter streamWriter)
        {
            streamWriter.WriteLine(name + "=" + obj.ToString());
        }


        public static void Write<T>(T obj, StreamWriter streamWriter) where T : ICodeable
        {
            streamWriter.WriteLine(typeof(T).Name + ":");
            obj.WriteToStream(streamWriter);
        }


        public static void Write<T>(T obj, string name, StreamWriter streamWriter) where T : ICodeable
        {
            streamWriter.WriteLine(name + ":");
            obj.WriteToStream(streamWriter);
        }


        public static void Write<T>(T[] objects, StreamWriter streamWriter) where T : ICodeable
        {
            foreach (T obj in objects)
            {
                Write<T>(obj, streamWriter);
            }
        }
    }
}
