// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "MyShader/LODTest" {
	Properties{
		_Color("Color Tint", Color) = (1, 1, 1, 1)
	}

		CGINCLUDE
			uniform fixed4 _Color;

			struct a2v {
				float4 vertex : POSITION;
			};

			struct v2f {
				float4 pos : SV_POSITION;
			};
		ENDCG

		SubShader{
			LOD 300
			Pass {
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				v2f vert(a2v v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					return fixed4(1.0,1.0,1.0, 1.0);
				}

				ENDCG
			}
		}

		SubShader{
			LOD 200
			Pass {
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag


				v2f vert(a2v v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					return fixed4(_Color.rgb, 1.0);
				}

				ENDCG
			}
		}

		SubShader{
			LOD 100
			Pass {
				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag


				v2f vert(a2v v) {
					v2f o;
					o.pos = UnityObjectToClipPos(v.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target {
					return fixed4(0,0,0, 1.0);
				}

				ENDCG
			}
		}
}