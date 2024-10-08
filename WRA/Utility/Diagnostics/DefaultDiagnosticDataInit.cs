using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;
using WRA.UI.PanelsSystem;
using WRA.Utility.Diagnostics.DiagnosticsPanel;
using Zenject;

public class DefaultDiagnosticDataInit : MonoBehaviour
{
    [Inject] PanelManager panelManager;
    
    [SerializeField] private float recordFpsFromSeconds = 5f;
    
    private WraDiagnosticsPanel diagnosticsPanel;
    private WraDiagnosticsPanel.ValueRecord fpsRecord;
    private WraDiagnosticsPanel.ValueRecord averageFpsRecord;
    
    private Color fpsColorBad = Color.red;
    private Color fpsColorGood = Color.green;
    private Color fpsColorGreat = Color.cyan;
    
    private List<float> fpsList = new List<float>();
    
    private float lastFps;
    private float lastAverageFps;
    
    private void Awake()
    {
        fpsRecord = new WraDiagnosticsPanel.ValueRecord
        {
            name = "FPS",
            value = 0,
            color = Color.green
        };
        
        averageFpsRecord = new WraDiagnosticsPanel.ValueRecord
        {
            name = "Average FPS",
            value = 0,
            color = Color.green
        };
        

        diagnosticsPanel = panelManager.HidePanel("DiagnosticsPanel") as WraDiagnosticsPanel;
        diagnosticsPanel.AddRecord(fpsRecord);
        diagnosticsPanel.AddRecord(averageFpsRecord);
    }
    
    private void Update()
    {
        lastFps = 1 / Time.deltaTime;
        fpsRecord.value = lastFps.ToString("0");
        UpdateAverageFps();
        UpdateFpsColorValue();
    }
    
    private void UpdateAverageFps()
    {
        if (fpsList.Count > 60 * recordFpsFromSeconds)
        {
            fpsList.RemoveAt(0);
        }
        fpsList.Add(lastFps);
        lastAverageFps = fpsList.Average();
        averageFpsRecord.value = lastAverageFps.ToString("0");
    }

    private void UpdateFpsColorValue()
    {
        fpsRecord.color = GetColorByFps(lastFps);
        averageFpsRecord.color = GetColorByFps(lastAverageFps);
    }
    
    private Color GetColorByFps(float fps)
    {
        if (fps < 60)
        {
            return Color.Lerp(fpsColorBad, fpsColorGood, fps / 60);
        }
        else
        {
            return Color.Lerp(fpsColorGood, fpsColorGreat, fps / 144);
        }
    }
}
