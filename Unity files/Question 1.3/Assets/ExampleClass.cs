using UnityEngine;
using System.Collections;
using Unity.Jobs;

public class ExampleClass : MonoBehaviour
{
    // Source texture and the rectangular area we want to extract.
    public Texture2D sourceTex;
    private int widthTex , heightText;
    void Start()
    {
        
        widthTex = Mathf.FloorToInt(sourceTex.width);
        heightText = Mathf.FloorToInt(sourceTex.height);
        
        print(countReds(3));
    }

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
    
    
 
}