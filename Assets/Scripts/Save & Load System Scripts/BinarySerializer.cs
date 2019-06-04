using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializer
{

    private static readonly string _path = Application.persistentDataPath + "/GameData.dat";

    public static Stats LoadStats()
    {

        if (File.Exists(_path))
        {

            FileStream file = File.Open(_path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            Stats stats = (Stats)formatter.Deserialize(file);

            file.Close();

            return stats;

        }

        return new Stats();

    }

    public static void SaveStats(Stats stats)
    {

        FileStream file = File.Create(_path);

        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, stats);

        file.Close();

    }

}
