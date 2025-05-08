Shader "Skybox/WobblyPanoramic"
{
    Properties
    {
        _MainTex ("Skybox Texture", 2D) = "white" {}
        _Frequency ("Wobble Frequency", Float) = 5
        _Amplitude ("Wobble Amplitude", Float) = 0.02
        _Speed ("Wobble Speed", Float) = 1
    }

    SubShader
    {
        Tags { "Queue"="Background" }
        Cull Off ZWrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Frequency;
            float _Amplitude;
            float _Speed;

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 dir : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.dir = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float3 dir = normalize(i.dir);
                float2 uv = float2(atan2(dir.x, dir.z) / (2 * UNITY_PI) + 0.5, asin(dir.y) / UNITY_PI + 0.5);

                // Wobble distortion on Y axis of UV
                uv.y += sin(uv.x * _Frequency + _Time.y * _Speed) * _Amplitude;

                return tex2D(_MainTex, uv);
            }
            ENDCG
        }
    }
}
