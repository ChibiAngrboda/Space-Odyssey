using UnityEngine;
using TMPro;

public class TextMeshProCurve : MonoBehaviour
{
    public AnimationCurve curve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1), new Keyframe(1, 0)); // Courbure
    public float curveScale = 10f;  // Intensité de la courbure

    private TMP_Text textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
        textMeshPro.havePropertiesChanged = true;  // Forcer la mise à jour
    }

    void Update()
    {
        if (textMeshPro.havePropertiesChanged)  // Si des changements ont été faits
        {
            WarpText();
        }
    }

    void WarpText()
    {
        textMeshPro.ForceMeshUpdate();  // Force la mise à jour du mesh de texte

        TMP_TextInfo textInfo = textMeshPro.textInfo;
        int characterCount = textInfo.characterCount;

        if (characterCount == 0) return;

        // Parcourt chaque caractère
        for (int i = 0; i < characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            // Récupère les vertices du caractère
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;
            Vector3[] vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;

            // Calcule la courbure en utilisant AnimationCurve
            float offset = curve.Evaluate((float)i / characterCount) * curveScale;

            // Applique l'offset vertical à chaque sommet du caractère
            vertices[vertexIndex + 0].y += offset;
            vertices[vertexIndex + 1].y += offset;
            vertices[vertexIndex + 2].y += offset;
            vertices[vertexIndex + 3].y += offset;
        }

        // Met à jour les modifications
        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }
}

