using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ResultNovelManager : MonoBehaviour
{
    [Header("カウント")]
    public int goodMushroomCount;
    public int badMushroomCount;

    [Header("UI")]
    public TMP_Text novelText;

    [Header("合計キノコ数の結果")]
    public ResultTextPages[] totalResultPages;

    [Header("ダメなキノコ数の結果")]
    public ResultTextPages[] badResultPages;

    private List<string> currentPages = new List<string>();
    private int currentPageIndex = 0;

    void Start()
    {
        int total = goodMushroomCount + badMushroomCount;

        // ① 合計値テキストをキューに追加
        AddPages(total, totalResultPages);

        // ② ダメなキノコテキストをキューに追加
        AddPages(badMushroomCount, badResultPages);

        // 最初のページ表示
        ShowCurrentPage();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            NextPage();
        }
    }

    void AddPages(int value, ResultTextPages[] pageGroups)
    {
        foreach (var group in pageGroups)
        {
            if (value >= group.min && value <= group.max)
            {
                currentPages.AddRange(group.pages);
                return;
            }
        }
    }

    void ShowCurrentPage()
    {
        if (currentPageIndex < currentPages.Count)
        {
            novelText.text = currentPages[currentPageIndex];
        }
        else
        {
            // ここでリザルト終了（次のシーンなど）
            novelText.text = "― 終わり ―";
        }
    }

    void NextPage()
    {
        currentPageIndex++;
        ShowCurrentPage();
    }
}
