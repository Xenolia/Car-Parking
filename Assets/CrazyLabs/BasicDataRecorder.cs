#if CRAZY_LABS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabtale.TTPlugins;


public class BasicDataRecorder
{
    private static BasicDataRecorder _basicDataRecorderInstance;

    private Dictionary<string, object> _paramaters;
    public static BasicDataRecorder BasicDataRecorderInstance
    {
        get 
        {
            if(_basicDataRecorderInstance == null)
                _basicDataRecorderInstance = new BasicDataRecorder();
            return _basicDataRecorderInstance;
        }
    }

    public BasicDataRecorder()
    {
        _paramaters = new Dictionary<string, object>();
    }

    public void OnMissionStarted(int missionId, string missionName, object levelName)
    {
        _paramaters.Clear();
        _paramaters.Add(missionName, levelName);
        TTPGameProgression.FirebaseEvents.MissionStarted(missionId, _paramaters);
    }

    public void OnMissionFailed(string missionName, object levelName)
    {
        _paramaters.Clear();
        _paramaters.Add(missionName, levelName);
        TTPGameProgression.FirebaseEvents.MissionFailed(_paramaters);
    }

    public void OnMissionSuccess(string missionName, object levelName)
    {
        _paramaters.Clear();
        _paramaters.Add(missionName, levelName);
        TTPGameProgression.FirebaseEvents.MissionComplete(_paramaters);
    }

    public void LogEvent(string eventName, IDictionary<string, object> parameters, bool timed = false)
    {

    }

    public void OnMiniLevelStarted(int missionId, string missionName, object levelName)
    {
        _paramaters.Clear();
        _paramaters.Add(missionName, levelName);
        TTPGameProgression.MiniLevelStarted(missionId, _paramaters);
    }

    public void OnMiniLevelFailed()
    {
        TTPGameProgression.MiniLevelFailed();
    }

    public void OnMiniLevelComplated()
    {
        TTPGameProgression.MiniLevelCompleted();
    }
}

#endif