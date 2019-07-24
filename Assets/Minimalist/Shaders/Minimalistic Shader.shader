Shader "Scrollbie/Minimalistic Shader" {
    Properties {
        _MainTexture ("MainTexture", 2D) = "white" {}
        _ColorForward ("Color Forward", Color) = (0.8823529,0,0,1)
        [MaterialToggle] _UseGradient_F ("Use Gradient_copy", Float ) = 0
        _YPosHigh_F ("YPos High", Float ) = 1
        _YPosLow_F ("YPos Low", Float ) = -1
        _ColorHigh_F ("Color High", Color) = (0.9254903,0,0.3255173,1)
        _ColorLow_F ("Color Low", Color) = (0.7573529,0.2060446,0.7421446,1)
        _ColorBack ("Color Back", Color) = (0.8676471,0.843712,0,1)
        [MaterialToggle] _UseGradient_B ("Use Gradient", Float ) = 0
        _YPosHigh_B ("YPos High", Float ) = 1
        _YPosLow_B ("YPos Low", Float ) = -1
        _ColorHigh_B ("Color High", Color) = (0.9254903,0.7449358,0,1)
        _ColorLow_B ("Color Low", Color) = (0.9485294,0.8395352,0.2301579,1)
        _ColorRight ("Color Right", Color) = (0,0.7573529,0.2245943,1)
        [MaterialToggle] _UseGradient_R ("Use Gradient", Float ) = 0
        _YPosHigh_R ("YPos High", Float ) = 1
        _YPosLow_R ("YPos Low", Float ) = -1
        _ColorHigh_R ("Color High", Color) = (0,0.7132353,0.1524847,1)
        _ColorLow_R ("Color Low", Color) = (0.2588668,0.8382353,0.3108101,1)
        _ColorLeft ("Color Left", Color) = (0,0.8093306,0.8823529,1)
        [MaterialToggle] _UseGradient_L ("Use Gradient", Float ) = 0
        _YPosLow_L ("YPos Low", Float ) = -1
        _YPosHigh_L ("YPos High", Float ) = 1
        _ColorHigh_L ("Color High", Color) = (0,0.9254903,0.8470589,1)
        _ColorLow_L ("Color Low", Color) = (0,0.6245942,0.8308824,1)
        _ColorTop ("Color Top", Color) = (0.4338235,0.4338235,0.4338235,1)
        _ColorBottom ("Color Bottom", Color) = (0.4338235,0.4338235,0.4338235,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu 
            #pragma target 3.0
            uniform fixed _UseGradient_R;
            uniform float _YPosLow_R;
            uniform float _YPosHigh_R;
            uniform float4 _ColorLow_R;
            uniform float4 _ColorHigh_R;
            uniform float4 _ColorForward;
            uniform fixed _UseGradient_F;
            uniform float _YPosLow_F;
            uniform float _YPosHigh_F;
            uniform float4 _ColorLow_F;
            uniform float4 _ColorHigh_F;
            uniform float4 _ColorBack;
            uniform float _YPosLow_B;
            uniform float _YPosHigh_B;
            uniform float4 _ColorLow_B;
            uniform float4 _ColorHigh_B;
            uniform float4 _ColorLeft;
            uniform fixed _UseGradient_L;
            uniform float _YPosLow_L;
            uniform float _YPosHigh_L;
            uniform float4 _ColorLow_L;
            uniform float4 _ColorHigh_L;
            uniform float4 _ColorRight;
            uniform fixed _UseGradient_B;
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform float4 _ColorTop;
            uniform float4 _ColorBottom;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:


////// Emissive:
                float4 _MainTexture_var = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float Max_F = max(dot(i.normalDir,float3(0,0,1)),0.0);
                float Max_R = max(dot(i.normalDir,float3(1,0,0)),0.0);
                float Max_B = max(dot(i.normalDir,float3(0,0,-1)),0.0);
                float Max_L = max(dot(i.normalDir,float3(-1,0,0)),0.0);
                float3 emissive = (_MainTexture_var.rgb*((lerp( (_ColorForward.rgb*Max_F), (lerp(_ColorHigh_F.rgb,_ColorLow_F.rgb,smoothstep( _YPosHigh_F, _YPosLow_F, i.posWorld.g ))*Max_F), _UseGradient_F )+lerp( (_ColorRight.rgb*Max_R), (lerp(_ColorHigh_R.rgb,_ColorLow_R.rgb,smoothstep( _YPosHigh_R, _YPosLow_R, i.posWorld.g ))*Max_R), _UseGradient_R )+lerp( (_ColorBack.rgb*Max_B), (lerp(_ColorHigh_B.rgb,_ColorLow_B.rgb,smoothstep( _YPosHigh_B, _YPosLow_B, i.posWorld.g ))*Max_B), _UseGradient_B )+lerp( (_ColorLeft.rgb*Max_L), (lerp(_ColorLow_L.rgb,_ColorHigh_L.rgb,smoothstep( _YPosHigh_L, _YPosLow_L, i.posWorld.g ))*Max_L), _UseGradient_L )+(_ColorBottom.rgb*max(dot(i.normalDir,float3(0,-1,0)),0.0)))+(_ColorTop.rgb*max(dot(i.normalDir,float3(0,1,0)),0.0))));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ColozMatInspector"
}
