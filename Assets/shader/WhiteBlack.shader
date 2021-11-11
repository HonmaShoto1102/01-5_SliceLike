Shader "Unlit/WhiteBlack"
{
    Properties
    {

        _Num("Num",Range(2,50)) = 30
    }
        SubShader
    {
        Pass
        {
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
            float _Num;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv * _Num;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed2 c = floor(i.uv) / 2.0;
                float checker = frac(c.x + c.y) * 2;
               
                return checker;
            }
            ENDCG
        }
    }
}
