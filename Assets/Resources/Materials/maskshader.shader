Shader "Custom/maskshader"
{
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
    }

    SubShader {
        Tags {"Queue" = "Geometry+1"}
        Stencil
        {
            Ref 1
            Comp always
            Pass replace
        }

        Pass{
            Zwrite On
            ColorMask 0
        }
    }
}