

Shader "Unlit/Jade's Shader'"
{
    Properties{

            _Color("Main Color", Color) = (1,1,1,1)
            _RimColor("Rim Color", Color) = (1, 1, 1, 1)
         _MainTex("Base (RGB)", 2D) = "white" {}
       //  Vertex_offSet("Vertex_offSet",float) = (0,0,0)
         _AnimatonSpeed("AnimatonSpeed", Range(0,3)) = 0
         _Offsetscale("Offsetscale",Range(0,  700)) = 0
    }

        SubShader{

                tags{ "Queue"="Transparent"  "Rendertype" = "Transparent"}
                LOD 100
                ZWrite off
                Blend SrcAlpha OneMinusSrcAlpha
            Pass {

                    
                CGPROGRAM

                  #pragma vertex vert
                    #pragma fragment frag
                    #include "UnityCG.cginc"
                    struct appdata {
                        float4 vertex : POSITION;
                        float3 normal : NORMAL;
                        float2 texcoord : TEXCOORD0;
                    };

                    struct v2f {
                        float4 pos : SV_POSITION;
                        float2 uv : TEXCOORD0;
                        float3 color : COLOR;
                    };

                    uniform float4 _MainTex_ST;
                    uniform float4 _RimColor;
                    uniform float Vertex_offSet;
                    float _AnimatonSpeed;
                    float _Offsetscale;
                    

                    v2f vert(appdata v) {
                        v2f o;
                       v.vertex.xy += v.vertex.x * sin(v.vertex.yz* _AnimatonSpeed + v.vertex.y* _Offsetscale) *_Time.xyz;
                       //  v.vertex +=Vertex_offSet;  
                        o.pos = UnityObjectToClipPos (v.vertex);
                         float3 viewDir = normalize(ObjSpaceViewDir(v.vertex));
                        float dotProduct = 1 - dot(v.normal, viewDir);
                        float rimWidth = 0.8;
                        o.color = smoothstep(1 - rimWidth, 1.0, dotProduct);

                        o.color *= _RimColor *4;
                        
                        o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

                        return o;
                    }

                    uniform sampler2D _MainTex;
                    uniform float4 _Color;

                    float4 frag(v2f i) : COLOR {
                        float4 texcol = tex2D(_MainTex, i.uv);
                        texcol *= _Color;
                        texcol.rgb += i.color;
                        return texcol;
                    }

                ENDCG
            }

    }

}
