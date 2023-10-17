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

    public SaveObject()
    {
        this.level = "";
        this.restarts = 0;
        this.attemptStopwatch = Stopwatch.StartNew();
        this.singleFlag = 0;
    }
}