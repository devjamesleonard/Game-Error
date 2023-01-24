using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class BinaryFormatt{ 

    public static void saveVolumeData(MenuHandler manager)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/Volume.sav", FileMode.Create);
        VolumeData Data = new VolumeData(manager);
        bf.Serialize(stream, Data);
        stream.Close();
    }
    public static float[] loadVolumeData()
    {

        if (File.Exists(Application.persistentDataPath + "/Volume.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/Volume.sav", FileMode.Open);
            VolumeData data = bf.Deserialize(stream) as VolumeData;
            stream.Close();
            float[] a = new float[2];
            a[0] = data.sfxvol;
            a[1] = data.bgvol;
            return a;
        }
        else
        {
            float[] a = new float[2];
            a[0] = .5f;
            a[1] = .15f;
            return a;
        }
    }
    
    public static void saveLastScoreData(GameManager Game)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/LastScore.sav", FileMode.Create);
        lastScoreData Data = new lastScoreData(Game);
        bf.Serialize(stream, Data);
        stream.Close();
    }
    public static float[] loadLastScoreData()
    {

        if (File.Exists(Application.persistentDataPath + "/LastScore.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/LastScore.sav", FileMode.Open);
            lastScoreData data = bf.Deserialize(stream) as lastScoreData;
            stream.Close();

            return data.lastScores;
        }
        else
        {
            float[] a = new float[10];
            for(int  i =0; i<a.Length; i++)
            {
                a[i] = -1;
            }
            return new float[10];
        }
    }
    public static void saveBestScoreData(GameManager Game)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/BestScore.sav", FileMode.Create);
        bestScoreData Data = new bestScoreData(Game);
        bf.Serialize(stream, Data);
        stream.Close();
    }
    public static float[] loadBestScoreData()
    {

        if (File.Exists(Application.persistentDataPath + "/BestScore.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/BestScore.sav", FileMode.Open);
            bestScoreData data = bf.Deserialize(stream) as bestScoreData;
            stream.Close();
            float[] a = new float[2];
            a[0] = data.bestScore;
            a[1] = data.bestLevel;
            return a;
        }
        else
        {
            float[] a = new float[2];
            a[0] = 0f;
            a[1] = 1f;
            return a;
        }
    }
    [Serializable]
    public class lastScoreData
    {
        public float[] lastScores;
        public lastScoreData(GameManager Game)
        {
          
            lastScores = new float[10];
            lastScores = Game.last10;
        }

    }
    [Serializable]
    public class bestScoreData
    {
        public float bestScore, bestLevel;
        public bestScoreData(GameManager Game)
        {
            bestScore = (float)System.Math.Round(Game.Score, 1);
            bestLevel = Game.Level;


        }

    }
    
   
    [Serializable]
    public class VolumeData
    {
        public float bgvol,sfxvol;
        public VolumeData(MenuHandler Volume)
        {
            bgvol = Volume.bgvolume;
            sfxvol = Volume.sfxvolume;

        }

    }

}
