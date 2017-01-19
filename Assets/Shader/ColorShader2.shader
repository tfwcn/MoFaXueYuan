Shader "Custom/ColorShader2" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		Tags {"RenderType"="Transparent" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "Queue"="Transparent"} 
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
		#pragma surface surf CustomDiffuse

		sampler2D _MainTex;
		half4 _Color;

		struct Input {
			float2 uv_MainTex;
		};
		
		inline half4 LightingCustomDiffuse (SurfaceOutput s, fixed3 lightDir, fixed atten) {
		    half4 col;
		    col.rgb = s.Albedo;
		    col.a = s.Alpha;
		    return col;
		}
		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = _Color*c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
