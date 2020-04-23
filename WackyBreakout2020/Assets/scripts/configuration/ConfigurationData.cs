using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    //const string ConfigurationDataFileName = "ConfigurationData.csv";

    //// configuration data
    //float paddleMoveUnitsPerSecond = 10;
    //float ballImpulseForce = 200;
    //float ballLifeSeconds = 10;
    //float minSpawnSeconds = 5;
    //float maxSpawnSeconds = 10;
    //int standardBlockPoints = 1;
    //int bonusBlockPoints = 2;
    //int pickupBlockPoints = 5;
    //float standardBlockProbability = 0.7f;
    //float bonusBlockProbability = 0.2f;
    //float freezerBlockProbability = 0.05f;
    //float speedupBlockProbability = 0.05f;
    //int ballsPerGame = 5;
    //float freezerSeconds = 2;
    //float speedupFactor = 2;
    //float speedupSeconds = 2;

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values =
        new Dictionary<ConfigurationDataValueName, float>();

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return values[ConfigurationDataValueName.paddleMoveUnitsPerSecond]; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return values[ConfigurationDataValueName.ballImpulseForce]; }
    }

    /// <summary>
    /// Gets the number of seconds the ball lives
    /// </summary>
    /// <value>ball life seconds</value>
    public float BallLifeSeconds
    {
        get { return values[ConfigurationDataValueName.ballLifeSeconds]; }
    }

    /// <summary>
    /// Gets the minimum number of seconds for a ball spawn
    /// </summary>
    /// <value>minimum spawn seconds</value>
    public float MinSpawnSeconds
    {
        get { return values[ConfigurationDataValueName.minSpawnSeconds]; }
    }

    /// <summary>
    /// Gets the maximum number of seconds for a ball spawn
    /// </summary>
    /// <value>maximum spawn seconds</value>
    public float MaxSpawnSeconds
    {
        get { return values[ConfigurationDataValueName.maxSpawnSeconds]; }
    }

    /// <summary>
    /// Gets the number of points a standard block is worth
    /// </summary>
    /// <value>standard block points</value>
    public int StandardBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.standardBlockPoints]; }
    }

    /// <summary>
    /// Gets the number of points a bonus block is worth
    /// </summary>
    /// <value>bonus block points</value>
    public int BonusBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.bonusBlockPoints]; }
    }

    /// <summary>
    /// Gets the number of points a pickup block is worth
    /// </summary>
    /// <value>pickup block points</value>
    public int PickupBlockPoints
    {
        get { return (int)values[ConfigurationDataValueName.pickupBlockPoints]; }
    }

    /// <summary>
    /// Gets the probability that a standard block
    /// will be added to the level
    /// </summary>
    /// <value>standard block probability</value>
    public float StandardBlockProbability
    {
        get { return values[ConfigurationDataValueName.standardBlockProbability]; }
    }

    /// <summary>
    /// Gets the probability that a bonus block
    /// will be added to the level
    /// </summary>
    /// <value>bonus block probability</value>
    public float BonusBlockProbability
    {
        get { return values[ConfigurationDataValueName.bonusBlockProbability]; }
    }

    /// <summary>
    /// Gets the probability that a freezer block
    /// will be added to the level
    /// </summary>
    /// <value>freezer block probability</value>
    public float FreezerBlockProbability
    {
        get { return values[ConfigurationDataValueName.freezerBlockProbability]; }
    }

    /// <summary>
    /// Gets the probability that a speedup block
    /// will be added to the level
    /// </summary>
    /// <value>speedup block probability</value>
    public float SpeedupBlockProbability
    {
        get { return values[ConfigurationDataValueName.speedupBlockProbability]; }
    }

    /// <summary>
    /// Gets the number of balls per game
    /// </summary>
    /// <value>balls per game</value>
    public int BallsPerGame
    {
        get { return (int)values[ConfigurationDataValueName.ballsPerGame]; }
    }

    /// <summary>
    /// Gets the duration of the freezer effect
    /// in seconds
    /// </summary>
    /// <value>freezer seconds</value>
    public float FreezerSeconds
    {
        get { return values[ConfigurationDataValueName.freezerSeconds]; }
    }

    /// <summary>
    /// Gets the speedup factor
    /// </summary>
    /// <value>speedup factor</value>
    public float SpeedupFactor
    {
        get { return values[ConfigurationDataValueName.speedupFactor]; }
    }

    /// <summary>
    /// Gets the duration of the speedup effect
    /// in seconds
    /// </summary>
    /// <value>speedup seconds</value>
    public float SpeedupSeconds
    {
        get { return values[ConfigurationDataValueName.speedupSeconds]; }  
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    //public ConfigurationData()
    //{
    //    // read and save configuration data from file
    //    StreamReader input = null;
    //    try
    //    {
    //        // create stream reader object
    //        input = File.OpenText(Path.Combine(
    //            Application.streamingAssetsPath, ConfigurationDataFileName));

    //        // read in names and values
    //        string names = input.ReadLine();
    //        string values = input.ReadLine();

    //        // set configuration data fields
    //        SetConfigurationDataFields(values);
    //    }
    //    catch (Exception e)
    //    {
    //    }
    //    finally
    //    {
    //        // always close input file
    //        if (input != null)
    //        {
    //            input.Close();
    //        }
    //    }
    //}

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // populate values
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(',');
                ConfigurationDataValueName valueName =
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            // set default values if something went wrong
            SetDefaultValues();
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    

    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.paddleMoveUnitsPerSecond, 10f);
        values.Add(ConfigurationDataValueName.ballImpulseForce, 200f);
        values.Add(ConfigurationDataValueName.ballLifeSeconds, 10f);
        values.Add(ConfigurationDataValueName.minSpawnSeconds, 5f);
        values.Add(ConfigurationDataValueName.maxSpawnSeconds, 10f);
        values.Add(ConfigurationDataValueName.standardBlockPoints, 1);
        values.Add(ConfigurationDataValueName.bonusBlockPoints, 2);
        values.Add(ConfigurationDataValueName.pickupBlockPoints, 5);
        values.Add(ConfigurationDataValueName.standardBlockProbability, 0.7f);
        values.Add(ConfigurationDataValueName.bonusBlockProbability, 0.2f);
        values.Add(ConfigurationDataValueName.freezerBlockProbability, 0.05f);
        values.Add(ConfigurationDataValueName.speedupBlockProbability, 0.05f);
        values.Add(ConfigurationDataValueName.freezerSeconds, 2f);
        values.Add(ConfigurationDataValueName.ballsPerGame, 5);
        values.Add(ConfigurationDataValueName.speedupFactor, 2f);
        values.Add(ConfigurationDataValueName.speedupSeconds, 4f);
    }
}
