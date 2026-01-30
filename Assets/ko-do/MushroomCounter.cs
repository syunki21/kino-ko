using UnityEngine;

public class MushroomCounter : MonoBehaviour
{
    public int goodCount = 0;
    public int badCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodMushroom"))
        {
            goodCount++;
            Debug.Log("いいキノコ取得！ 合計: " + goodCount);

            Destroy(other.gameObject);
        }
        else if (other.CompareTag("BadMushroom"))
        {
            badCount++;
            Debug.Log("ダメなキノコ取得！ 合計: " + badCount);

            Destroy(other.gameObject);
        }
    }
}
