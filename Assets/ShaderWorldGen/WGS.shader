Shader "Unlit/WGS"
{
    Properties
    {
        _SeedX("SeedX", Float) = 0
        _SeedY("SeedY", Float) = 0
        _RainScale("RainScale", Float) = 1
        _TempScale("TemperatureScale", Float) = 1
        _NutScale("NutrientScale", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma target 3.0
            // make fog work
            #include "UnityCG.cginc"
            #include "noiseSimplex.cginc"


            float _SeedX;
            float _SeedY;
            float _RainScale;
            float _TempScale;
            float _NutScale;

            struct appdata
            {
                float2 uv : TEXCOORD0;
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 RainSampleUV = i.uv * _RainScale + float2(_SeedX,_SeedY);
                float rain = snoise(RainSampleUV)/2 + 0.5f;
                float2 TempSampleUV = i.uv * _TempScale + float2(_SeedX, 4*_SeedY);
                float temp = snoise(TempSampleUV) / 2 + 0.5f;
                float2 NutSampleUV = i.uv * _NutScale + float2(6*_SeedX, _SeedY);
                float nut = snoise(NutSampleUV) / 2 + 0.5f;
                float4 col = float4(temp,nut,rain,1);
                return col;
            }
            ENDCG
        }
    }
}
