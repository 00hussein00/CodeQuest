using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using System.Runtime.Serialization.Formatters.Binary;
using Debug = UnityEngine.Debug;

public static class SaveData 
{
    public static void newAccountPlayer(PlayerData P, string filename)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // Create a new BinaryFormatter object
        string path = Application.persistentDataPath + filename + ".txt"; // Construct the path for the save file
        if (File.Exists(path)) {
            throw new Exception("this username already exist"); // If the file already exists, throw an exception
        } else {
            FileStream stream = new FileStream(path, FileMode.Create); // Create a new file stream
            PlayerObject data = new PlayerObject(P); // Create a new PlayerObject from the PlayerData
            formatter.Serialize(stream, data); // Serialize the PlayerObject to the file
            stream.Close(); // Close the file stream
        }
    }

    public static void updatePlayerInformation(PlayerData P, string filename)
    {
        BinaryFormatter formatter = new BinaryFormatter(); // Create a new BinaryFormatter object
        string path = Application.persistentDataPath + filename + ".txt"; // Construct the path for the save file
        FileStream stream = new FileStream(path, FileMode.Create); // Open a new file stream
        PlayerObject data = new PlayerObject(P); // Create a new PlayerObject from the PlayerData
        formatter.Serialize(stream, data); // Serialize the PlayerObject to the file
        stream.Close(); // Close the file stream   
    }

    public static PlayerObject loadPlayer(string filename)
    {
        try
        {
            string path = Application.persistentDataPath + filename + ".txt"; // Construct the path for the save file
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter(); // Create a new BinaryFormatter object
                FileStream stream = new FileStream(path, FileMode.Open); // Open the file stream

                PlayerObject data = formatter.Deserialize(stream) as PlayerObject; // Deserialize the data from the file
                stream.Close(); // Close the file stream
                return data; // Return the deserialized PlayerObject
            }
            else
            {
                throw new Exception("Could not load player " + filename + " from persistent data path " + path); // Throw an exception if the file does not exist
            }
        }
        catch (System.Runtime.Serialization.SerializationException e)
        {
            Debug.LogError("SerializationException Loading Save"); // Log an error if there is a SerializationException
            throw new Exception("not found user name " + filename); // Throw a new exception
        }
        catch (System.Exception e) {
            Debug.Log("another Error Loading Save " + e.Message); // Log any other exceptions
            throw new Exception("not found user name " + filename); // Throw a new exception
        }
    }
}
