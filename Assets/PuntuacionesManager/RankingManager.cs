using UnityEngine;
using UnityEngine.UI;

public class RankingManager : MonoBehaviour
{
    public Text[] rankingTextos;

    private void Start()
    {
        for (int i = 1; i <= rankingTextos.Length; i++)
        {
            int puntuacion = PlayerPrefs.GetInt($"Ranking{i}", 0);
            rankingTextos[i - 1].text = $"{i}. {puntuacion} puntos";
        }
    }
}
