Shader "Custom/ColorShader" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		//_Light ("Light", Range(0,1)) = 0.9
		//_Hue ("Hue", Range(0,360)) = 0
		//_Saturation ("Saturation", Range(0,1)) = 50
		//_Lightness ("Lightness", Range(-1,1)) = 0
	}
	SubShader {
		Tags {"RenderType"="Transparent" "IgnoreProjector"="True" "ForceNoShadowCasting"="True" "Queue"="Transparent"} 
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		
		CGPROGRAM
		#pragma surface surf CustomDiffuse

		sampler2D _MainTex;
		half4 _Color;
		//half _Light;
		//half _Hue;
		//half _Saturation;
		//half _Lightness;

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
			//亮度
			half Y = 0.299*c.r + 0.587*c.g + 0.114*c.b;
			Y=(Y<=0.1?1:Y);
			half4 newC=_Color*(1-Y*Y)+c*Y*Y;
			o.Albedo = newC.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
