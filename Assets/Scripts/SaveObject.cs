using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SaveObject
{
    public string level;
    public int restarts;
    public Stopwatch attemptStopwatch;
    public int singleFlag;
    public int powerup;
    public int obstacle;
    public string powerupname;

    public SaveObject()
    {
        this.level = "";
        this.restarts = 0;
        this.attemptStopwatch = Stopwatch.StartNew();
        this.singleFlag = 0;
        this.powerup = 0;
        this.obstacle = 0;
        this.powerupname = " ";
    }
}