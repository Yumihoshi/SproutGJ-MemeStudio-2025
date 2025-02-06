using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveCell : MonoBehaviour
{
    public TMP_Text title;
    public TMP_Text time;
    public TMP_Text load;
    public Image load_slider;

    public void LoadData(string title,string time,float load)
    {
        this.title.text = title;
        this.time.text = time;
        this.load.text = $"����:{(load * 10f).ToString("F0")}%";
        load_slider.fillAmount = load / 10f;
    }

}
