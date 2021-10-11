Shader "MyShader/Diffuse With Full LightProbes"
{
    Properties{ [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}}
    SubShader{
        Pass{
            Tags {
                "LightMode"="ForwardBase"
            }
            CGPROGRAM
                #pragma vertex v
                #pragma fragment f
                #include "UnityCG.cginc"
                #include "Lighting.cginc"
                sampler2D _MainTex;


            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
            #include "AutoLight.cginc"

            struct v2f{
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                fixed3 diff : COLOR0;
                fixed3 ambient : COLOR1;
                SHADOW_COORDS(1)
            };
            
            v2f v (appdata_base vertex_data){
                v2f o;
                o.pos = UnityObjectToClipPos(vertex_data.vertex);
                o.uv = vertex_data.texcoord;
                
                half3 worldNormal = UnityObjectToWorldNormal(vertex_data.normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                o.diff = nl * _LightColor0.rgb;
                o.ambient = ShadeSH9(half4(worldNormal,1));
                TRANSFER_SHADOW(o)
                return o;
            }
            
            fixed4 f (v2f input_fragment) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, input_fragment.uv);
                fixed shadow = SHADOW_ATTENUATION(input_fragment);
                fixed3 lighting = input_fragment.diff * shadow + input_fragment.ambient;
                col.rgb *= lighting;
                return col;
            }
            ENDCG
        }

        // shadow casting support
        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}