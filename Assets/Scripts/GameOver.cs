using UnityEngine;
using TMPro;


//Game over class settings...
//Working DONT CHANGE!.
public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalHats; //New Change, change legacy text for TMP.
    [SerializeField] private TextMeshProUGUI totalKm; 

    public void Setup(int hats, float km)
    {
        gameObject.SetActive(true);

        totalKm.text = "Total Meters: " + km.ToString();
        totalHats.text = "Total Hats " + hats.ToString();
    }
}


