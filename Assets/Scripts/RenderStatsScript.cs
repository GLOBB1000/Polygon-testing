using System.Text;
using Unity.Profiling;
using UnityEngine;

public class RenderStatsScript : MonoBehaviour
{
    string statsText;
    ProfilerRecorder setPassCallsRecorder;
    ProfilerRecorder drawCallsRecorder;
    ProfilerRecorder verticesRecorder;
    ProfilerRecorder staticBatchingDrawCalls;
    ProfilerRecorder dynamicBatchingDrawCalls;
    ProfilerRecorder staticBatchesCount;

    ProfilerRecorder test;

    private float fps;

    void OnEnable()
    {
        setPassCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "SetPass Calls Count");
        drawCallsRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count");
        verticesRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count");
        staticBatchingDrawCalls = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Static Batched Draw Calls Count");
        dynamicBatchingDrawCalls = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Dynamic Batched Draw Calls Count");
        staticBatchesCount = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Total Batches Count");
    }

    void OnDisable()
    {
        setPassCallsRecorder.Dispose();
        drawCallsRecorder.Dispose();
        verticesRecorder.Dispose();
        staticBatchingDrawCalls.Dispose();
        dynamicBatchingDrawCalls.Dispose();
        staticBatchesCount.Dispose();
    }

    void Update()
    {
        var sb = new StringBuilder(500);
        if (drawCallsRecorder.Valid)
            sb.AppendLine($"Draw Calls: {drawCallsRecorder.LastValue}");
        if (verticesRecorder.Valid)
            sb.AppendLine($"Triangles: {verticesRecorder.LastValue}");
        if (staticBatchingDrawCalls.Valid)
            sb.AppendLine($"Static draw calls:  {staticBatchingDrawCalls.LastValue}");
        if (dynamicBatchingDrawCalls.Valid)
            sb.AppendLine($"Dynamic draw calls:  {dynamicBatchingDrawCalls.LastValue}");
        if (staticBatchesCount.Valid)
            sb.AppendLine($"Batches count:  {staticBatchesCount.LastValue}");

        fps = 1.0f / Time.deltaTime;
        sb.AppendLine($"FPS: {fps}");

        statsText = sb.ToString();
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(1450, 500, 450, 240), statsText);
        GUI.skin.textArea.fontSize = 35;
    }
}