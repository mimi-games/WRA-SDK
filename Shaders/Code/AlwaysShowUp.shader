Shader "Custom/AlwaysShowUp"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Always visible color", Color) = (0,0,0,0)
    }
    SubShader
    {
        Tags { "Queue"="Overlay+2" }
        LOD 100
 
        Pass{

            ZTest Always
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
           
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };
 
            float4 _Color;
 
            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
 
            fixed4 frag(v2f i) : SV_Target
            {
                return _Color;
            }
 
            ENDCG
        }
    }
}
 