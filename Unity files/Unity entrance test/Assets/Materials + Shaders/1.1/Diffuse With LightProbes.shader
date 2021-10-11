Shader "MyShader/Diffuse With LightProbes"
{
    //I was not sure if you needed to include shadow emission and reception. So I included that shader in another file called Diffuse With Full LightProbes
    Properties { [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}}
    SubShader{
        Pass{
            Tags {
                "LightMode"="ForwardBase"
            }
            CGPROGRAM
                #pragma vertex v
                #pragma fragment f
                #include "UnityCG.cginc"
                #include "UnityLightingCommon.cginc"
                sampler2D _MainTex;
            
                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                    fixed4 diff : COLOR0;
                };

                v2f v (appdata_base vertex_data){
                    v2f o;
                    o.vertex = UnityObjectToClipPos(vertex_data.vertex);
                    o.uv = vertex_data.texcoord;
                    
                    half3 worldNormal = UnityObjectToWorldNormal(vertex_data.normal);
                    half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                    o.diff = nl * _LightColor0;
                    o.diff.rgb += ShadeSH9(half4(worldNormal,1));
                    return o;
                }
            

                fixed4 f (v2f input_fragment) : SV_Target{
                    fixed4 col = tex2D(_MainTex, input_fragment.uv) * input_fragment.diff;
                    return col;
                }
            ENDCG
        }
    }
}