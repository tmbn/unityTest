using UnityEngine;
using System.Collections;
using Unity.Jobs;
//I know it's not what I was asked for, but its the best I'm being able to do so far.
public class CountWithJobs : MonoBehaviour
{
    // Source texture and the rectangular area we want to extract.
    public Texture2D sourceTex;
    private int widthTex , heightText;
    private float redcount;
    void Start()
    {
        redcount = 0;
        widthTex = Mathf.FloorToInt(sourceTex.width);
        heightText = Mathf.FloorToInt(sourceTex.height);
        for (int i = 1; i <= 4; i++)
        {
            redcount += countReds(i);
        }
        print("There is a total of " +redcount+ " red-values in this texture");
    }

    public float countReds(int quadrant)
    {
        float reds = 0;
        int x=0,y=0;

         if (quadrant==2) x = widthTex / 2;
         else if (quadrant==3) y = heightText/2;
         else if (quadrant==4) {x = widthTex / 2; y = heightText/2;}

        Color[] pix = sourceTex.GetPixels(x, y, widthTex / 2, heightText / 2);
        for (int i=0; i < pix.Length; i++)
        {
            reds += pix[i].r;
        }

        
        print("Control test: On quadrant "+ quadrant+ "there are " +reds +" red values.");
        
        return reds;
    }
    
    
 
}