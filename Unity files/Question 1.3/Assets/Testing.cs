using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using Unity.Jobs;
public class Testing : MonoBehaviour
{
    public Texture2D sourceTex;
    private int widthTex , heightText;

    private void Start()
    {
        widthTex = Mathf.FloorToInt(sourceTex.width);
        heightText = Mathf.FloorToInt(sourceTex.height);
        
        print(countReds(3));
    }
    
    //Gets a specific quadrant for an specific thread
    public float countReds(int quadrant)
    {
        float reds = 0,x=0,y=0;

        if (quadrant==2) x = widthTex / 2;
        else if (quadrant==3) y = heightText/2;
        else if (quadrant==4) {x = widthTex / 2; y = heightText/2;}

        Color[] pix = sourceTex.GetPixels(0, heightText/2, widthTex / 2, heightText / 2);
        for (int i=0; i < pix.Length; i++)
        {
            reds += pix[i].r;
            // print(pix[i].r);
        }

        return reds;
    }


    [SerializeField] private bool useJobs;
    private void Update()
    {
        float starTime = Time.realtimeSinceStartup;
        if (useJobs)
        {
            NativeList<JobHandle> jobHandleList = new NativeList<JobHandle>(Allocator.Temp);
            for (int i = 0; i < 10; i++)
            {
                JobHandle jobHandle = ReallyTougTaskJob();
                jobHandleList.Add(jobHandle);
            }
            JobHandle.CompleteAll(jobHandleList);
            jobHandleList.Dispose();

        }
        // else
        // {
        //     for (int i = 0; i < 10; i++)
        //     {
        //         ReallyToughTask();
        //     }
        // }

        
        Debug.Log(((Time.realtimeSinceStartup - starTime) * 1000f) + " ms");
    }

    // private void ReallyToughTask()
    // {
    //     float value = 0f;
    //     for (int i = 0; i < 50000; i++)
    //     {
    //         value = math.exp10(math.sqrt(value));
    //     }
    // }


    private JobHandle ReallyTougTaskJob()
    {
        ReallyToughJob job = new ReallyToughJob();
        return job.Schedule();
    }
    [BurstCompile]
    public struct ReallyToughJob : IJob
    {
        // public float something;
        
        public void Execute()
        {
            float value = 0f;
            for (int i = 0; i < 50000; i++)
            {
                value = math.exp10(math.sqrt(value));
            }
        }
    }
}
