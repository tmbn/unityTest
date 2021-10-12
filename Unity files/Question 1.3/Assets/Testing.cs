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
    public float reds;

    private void Start()
    {
        reds = 0;
        widthTex = Mathf.FloorToInt(sourceTex.width);
        heightText = Mathf.FloorToInt(sourceTex.height);
        
        CountReds countReds = new CountReds
        {
            width = widthTex,
            height = heightText,
            texture = sourceTex,
            red = reds,
           
        } ;

        JobHandle jobHandle = countReds.Schedule(4,1);
        jobHandle.Complete();
    }
    
    // [BurstCompile]
    public struct CountReds: IJobParallelFor
    {
        public int width, height;
        public Texture2D texture;
        public float red;
        public void Execute(int index)
        {
            float x=0,y=0;
            int i = index + 1;
            if (i==2) x = width / 2;
            else if (i==3) y = height/2;
            else if (i==4) {x = width / 2; y = height/2;}

            Color[] pix = texture.GetPixels(0, height/2, width / 2, height / 2);
            for (i = 0; i < pix.Length; i++)
            {
                red += pix[i].r;
                // print(pix[i].r);
            }

            // return reds;
        }
    }

    
}
