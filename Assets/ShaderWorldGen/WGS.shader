Shader "WorldGeneration/WGS"
{
    Properties
    {
        _SeedX("SeedX", Float) = 0
        _SeedY("SeedY", Float) = 0
        _RainScale("RainScale", Float) = 1
        _RainMult("RainMultiplier", Float)= 1
        _TempScale("TemperatureScale", Float) = 1
        _TempMult("TempMultiplier",Float) = 1
        _NutScale("NutrientScale", Float) = 1
        _NutMult("MutrientMultiplier", Float)=1
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
            #include "UnityCG.cginc"
            #include "noiseSimplex.cginc"


            float _SeedX;
            float _SeedY;
            float _RainScale;
            float _RainMult;
            float _TempScale;
            float _TempMult;
            float _NutScale;
            float _NutMult;
            int _NumOctaves;

            float4 Colorlist[4] = {
                float4(0.3f,    1,      0.3f,   1),
                float4(0.1f,    0.5f,   0.1f,   1), 
                float4(1,       1,      0.3f,   1), 
                float4(1,       0,      0,      1)
                };


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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            };

            float4 frag(v2f i) : SV_Target
            {
                float rain = 0;
                float temp = 0;
                float nut = 0;
                for (int i = 0; i< _NumOctaves;i++){
                    float2 RainSampleUV = i.uv * _RainScale * i + float2(_SeedX,_SeedY);
                    rain += (1/i)*(snoise(RainSampleUV)/2 + 0.5f);
                    float2 TempSampleUV = i.uv * _TempScale* i + float2(_SeedX, 4*_SeedY);
                    temp += (1/i)*(snoise(TempSampleUV)/2 + 0.5f);
                    float2 NutSampleUV = i.uv * _NutScale* i + float2(6*_SeedX, _SeedY);
                    nut += (1/i)*(snoise(NutSampleUV)/2 + 0.5f);
                }
                

                bool muchrain = (rain>0.3f);
                bool muchheat = (temp>0.5f);
                if (muchrain){
                    if (muchheat){
                        return float4(0.04,0.08,0.04,1); // jungle
                    }
                    return float4(0.1,0.3,0.1,1); // forest
                }
                if (muchheat){
                    return float4(1,1,0.3,1); // desert
                }
                return float4(0.3,1,0.3,1); // plains
            };

            ENDCG
        }
    }
}
