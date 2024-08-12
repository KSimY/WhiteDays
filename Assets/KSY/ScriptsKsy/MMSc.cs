using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
// using static UnityEditor.Progress;

public class MMSc : MonoBehaviour
{
    public Canvas escC;
    public SMSSc smss;
    public GameObject icamPrefab;
    private Camera icam;
    public RawImage itemDisplay;
    public RawImage paperDisplay;
    private RenderTexture itemT;
    private RenderTexture paperT;

    private List<Item> itemInventory = new List<Item>();
    private List<Paper> paperInventory = new List<Paper>();

    public GameObject player;

    public AudioClip mnOpen;
    public AudioClip mnClose;
    public AudioClip nope;

    private bool hasMapped;

    public Canvas Ui1;
    public Canvas Ui2;
    public Canvas Ui3;
    public Canvas Ui4;

    public Image itemSelectBG;
    public Image paperSelectBG;
    private GameObject currentItemSelectBG; // ���� Ȱ��ȭ�� itemSelectBG
    private GameObject currentPaperSelectBG;

    public Transform itemIconParent;
    public Transform paperIconParent;

    private GameObject itemPrefab;
    private GameObject paperPrefab;

    public TextMeshProUGUI currentItemTitle;
    public TextMeshProUGUI currentItemInfo;
    public TextMeshProUGUI currentPaperTitle;

    private GameObject currentItem;
    private GameObject currentPaper;

    public Transform itemBg;
    public Transform paperBg;

    public Image itemIcon;
    public TextMeshProUGUI paperName;

    public Canvas currentInventory;

    private List<Item> itemOrder = new List<Item>();
    private Dictionary<Item, Image> itemIcons = new Dictionary<Item, Image>();
    private Dictionary<Item, GameObject> itemModels = new Dictionary<Item, GameObject>();
    private int currentItemIndex = -1;

    private List<Paper> paperOrder = new List<Paper>();
    private Dictionary<Paper, TextMeshProUGUI> pN = new Dictionary<Paper, TextMeshProUGUI>();
    private Dictionary<Paper, GameObject> paperModels = new Dictionary<Paper, GameObject>();
    private int currentPaperIndex = -1;

    private bool isRot = false;

    public ScrollRect itemScrollRect;
    public ScrollRect paperScrollRect;

    public RectTransform temPos;
    private const float camDis = -800f;

    private bool canMove = true;

    public void Start()
    {

        Ui1.enabled = false;
        Ui2.enabled = false;
        Ui3.enabled = false;
        Ui4.enabled = false;


    }

    //private void CreateItemCam()
    //{
    //    if(icam != null)
    //    {
    //        Destroy(gameObject);
    //        CreateItemCam();
    //    }
    //    GameObject camObj = Instantiate(icamPrefab, itemBg);
    //    icam = camObj.GetComponent<Camera>();
    //    // ī�޶� ����
    //    icam.orthographic = false; // Perspective ���� ����
    //    icam.fieldOfView = 60; // �þ߰� ����
    //}
    //private void CreatePaperCam()
    //{
    //    if(icam != null)
    //    {
    //        Destroy(gameObject);
    //        CreatePaperCam();
    //    }
    //    GameObject camObj = Instantiate(icamPrefab, paperBg);
    //    icam = camObj.GetComponent<Camera>();
    //    // ī�޶� ����
    //    icam.orthographic = false; // Perspective ���� ����
    //    icam.fieldOfView = 60; // �ʵ� ���� �並 ����
    //}




    public void Update()
    {


        hasMapped = player.GetComponent<PlayerHealth>().hasMap;
        if (Input.GetKeyDown(KeyCode.F1))
        {

            ToggleInventory("SMS");
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {

            ToggleInventory("Item");
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {

            ToggleInventory("Paper");
        }
        else if (Input.GetKeyDown(KeyCode.F4) && hasMapped == true)
        {

            ToggleInventory("Map");
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            CloseCurrentInventory();
        }


        if (Ui2.enabled == true)
        {
            Ui2On();
        }

        if (Ui3.enabled == true)
        {
            Ui3On();
        }



    }
    void ToggleInventory(string inventoryType)
    {
        switch (inventoryType)
        {
            case "SMS":
                smss.SMSC();
                ToggleInventoryUI(Ui1);
                break;
            case "Item":
                ToggleInventoryUI(Ui2);
                break;
            case "Paper":
                ToggleInventoryUI(Ui3);
                break;
            case "Map":
                ToggleInventoryUI(Ui4);
                break;
        }


    }

    void ToggleInventoryUI(Canvas inventoryUI)
    {
        if (currentInventory == inventoryUI)
        {
            CloseCurrentInventory();
        }
        else
        {
            if (currentInventory != null)
            {
                currentInventory.enabled = false;
            }
            currentInventory = inventoryUI;
            inventoryUI.enabled = true;

        }
    }

    void CloseCurrentInventory()
    {
        if (currentInventory != null)
        {
            currentInventory.enabled = false;
        }
    }

    public void AddItemToInventory(Item item)
    {
        if (item != null)
        {
            itemInventory.Add(item);
            itemOrder.Add(item);
            if (!itemIcons.ContainsKey(item))
            {
                UpdateItemInventoryUI();
            }

        }
    }

    public void AddPaperToInventory(Paper paper)
    {
        if (paper != null)
        {
            paperInventory.Add(paper);
            paperOrder.Add(paper);
            if (!pN.ContainsKey(paper))
            {
                UpdatePaperInventoryUI();
            }

        }
    }
    private void UpdateItemInventoryUI()
    {
        // ���� ������ UI ��Ҹ� ��ü�� �� ���� UI ��Ҹ� ���� �����մϴ�.
        CleanUpItemIcons();
        foreach (Item item in itemOrder)
        {
            if (!itemIcons.ContainsKey(item))
            {
                // ���ο� ������ ������ ����
                Image iItemIcon = new GameObject("ItemIcon").AddComponent<Image>();
                iItemIcon.transform.SetParent(itemIconParent, false); // itemIconParent�� �ڽ����� ����

                // �������� ��������Ʈ�� �����մϴ�.
                iItemIcon.sprite = item.iconImage;

                // �������� ũ��� ��ġ�� ������ �ʿ䰡 ���� �� �ֽ��ϴ�.
                RectTransform rectTransform = iItemIcon.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(100, 100); // ���÷� ũ�� ����
                rectTransform.anchoredPosition = new Vector2(0, 0); // ���÷� ��ġ ����

                // Ŭ�� �̺�Ʈ �߰�
                Button iconButton = iItemIcon.gameObject.AddComponent<Button>();
                iconButton.onClick.AddListener(() => OnItemIconClicked(item));

                // �����۰� �ش� �������� ������ �����մϴ�.
                itemIcons[item] = iItemIcon;
            }
        }

        // �⺻������ ���� ���� �ִ� �������� �����մϴ�.
        if (itemOrder.Count > 0)
        {
            SelectItem(0); // ���� ���� �ִ� �������� ����
        }
    }
    private void OnItemIconClicked(Item item)
    {
        int index = itemOrder.IndexOf(item);
        if (index >= 0)
        {
            SelectItem(index);
        }
    }

    private void UpdatePaperInventoryUI()
    {
        // ���� ���� UI ��Ҹ� ��ü�� �� ���� UI ��Ҹ� ���� �����մϴ�.
        CleanUpPaperIcons();
        // �� ���� UI ��Ҹ� �����մϴ�.
        foreach (Paper paper in paperOrder)
        {
            // ���̰� �̹� UI ��Ҹ� ������ �ִ��� Ȯ���մϴ�.
            if (!pN.ContainsKey(paper))
            {
                // ���ο� ���� �ؽ�Ʈ ����
                TextMeshProUGUI paperText = new GameObject("PaperText").AddComponent<TextMeshProUGUI>();
                paperText.transform.SetParent(paperIconParent, false); // paperIconParent�� �ڽ����� ����

                // ������ �ؽ�Ʈ�� �����մϴ�.
                paperText.text = paper.paperName;

                // �ؽ�Ʈ�� ũ��� ��ġ�� ������ �ʿ䰡 ���� �� �ֽ��ϴ�.
                RectTransform rectTransform = paperText.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(200, 50); // ���÷� ũ�� ����
                rectTransform.anchoredPosition = new Vector2(0, 0); // ���÷� ��ġ ����

                // Ŭ�� �̺�Ʈ �߰�
                Button iconButton = paperText.gameObject.AddComponent<Button>();
                iconButton.onClick.AddListener(() => OnPaperIconClicked(paper));

                // ���̿� �ش� �ؽ�Ʈ�� ������ �����մϴ�.
                pN[paper] = paperText;
            }
            else
            {
                // �̹� �����ϴ� ���, �ؽ�Ʈ�� ������Ʈ�մϴ�.
                pN[paper].text = paper.paperName;
            }
        }

        // �⺻������ ���� ���� �ִ� ���̸� �����մϴ�.
        if (paperOrder.Count > 0)
        {
            SelectPaper(0); // ���� ���� �ִ� ���̸� ����
        }
    }
    private void OnPaperIconClicked(Paper paper)
    {
        int index = paperOrder.IndexOf(paper);
        if (index >= 0)
        {
            SelectPaper(index);
        }
    }

    private void CleanUpItemIcons()
    {
        foreach (var icon in itemIcons.Values)
        {
            Destroy(icon);
        }
        itemIcons.Clear();
    }

    private void CleanUpPaperIcons()
    {
        foreach (var icon in pN.Values)
        {
            Destroy(icon.gameObject);
        }
        pN.Clear();
    }


    public void Scroll(float scrollAmount)
    {
        if (Ui2 == true)
        {
            itemScrollRect.verticalNormalizedPosition += scrollAmount;
        }
        if (Ui3 == true)
        {
            paperScrollRect.verticalNormalizedPosition += scrollAmount;
        }
    }

    public void RemoveItem(Item item)
    {
        if (itemIcons.ContainsKey(item))
        {
            Destroy(itemIcons[item].gameObject);
            itemIcons.Remove(item);
            itemOrder.Remove(item);
            if (currentItemIndex >= itemOrder.Count)
            {
                currentItemIndex = itemOrder.Count - 1;
            }
            if (itemOrder.Count > 0)
            {
                SelectItem(currentItemIndex);
            }

        }
    }
    public void RemovePaper(Paper paper)
    {
        if (pN.ContainsKey(paper))
        {
            // �ؽ�Ʈ UI�� �����ϰ�
            Destroy(pN[paper].gameObject);
            pN.Remove(paper);
            paperOrder.Remove(paper);

            // ���� ���� �ε��� ������Ʈ
            if (currentPaperIndex >= paperOrder.Count)
            {
                currentPaperIndex = paperOrder.Count - 1;
            }

            // ���õ� ���� ������Ʈ
            if (paperOrder.Count > 0)
            {
                SelectPaper(currentPaperIndex);
            }
        }
    }

    void ShowItemDetail(Item item)
    {
        currentItemTitle.enabled = true;
        currentItemTitle.text = item.itemName;
        currentItemInfo.enabled = true;
        currentItemInfo.text = item.description;
        Debug.Log("Selected Item: " + item.itemName);
        Show3DItem(item);
    }

    void Show3DItem(Item item)
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }
        if (itemT != null)
        {
            itemT.Release();
            itemT = null;
        }

        //itemT = new RenderTexture(512, 512, 16);
        //itemT.Create();
        //itemDisplay.texture = itemT;

        //CreateItemCam();
        Debug.Log("Showing Item: " + item.itemName);
        if (item.itemModel != null)
        {
            // ������ ������Ʈ ���� �� ��ġ �ʱ�ȭ
            currentItem = Instantiate(item.itemModel, itemBg);
            currentItem.transform.localPosition = Vector3.zero;
            currentItem.transform.localScale = Vector3.one; // ������ ����
            currentItem.transform.localRotation = Quaternion.identity;

            //icam.transform.localPosition = new Vector3(0, camDis, 0);
            //icam.transform.LookAt(currentItem.transform.position);

            //icam.targetTexture = itemT;
        }
        else
        {
            Debug.LogWarning("�����ۿ� �Ҵ�� 3D ������Ʈ������: " + item.itemName);
        }
    }


    void ShowPaperDetail(Paper paper)
    {
        currentPaperTitle.enabled = true;
        currentPaperTitle.text = paper.paperName;
        Debug.Log("����� ����: " + paper.paperName);
        Show3DPaper(paper);
    }

    void Show3DPaper(Paper paper)
    {
        if (currentPaper != null)
        {
            Destroy(currentPaper);
        }

        if (paperT != null)
        {
            paperT.Release();
            paperT = null;
        }

        //paperT = new RenderTexture(512, 512, 0);
        //paperT.Create();
        //paperDisplay.texture = paperT;

        //CreatePaperCam();
        Debug.Log("���� �������� ����: " + paper.paperName);
        if (paper.paperModel != null)
        {
            // ���� ������Ʈ ���� �� ��ġ �ʱ�ȭ
            currentPaper = Instantiate(paper.paperModel, paperBg);
            currentPaper.transform.localPosition = Vector3.zero;
            currentPaper.transform.localScale = Vector3.one; // ������ ����
            currentItem.transform.localRotation = Quaternion.identity;

            //icam.transform.localPosition = new Vector3(0, camDis, 0);
            //icam.transform.LookAt(currentPaper.transform.position);

            //icam.targetTexture = paperT;
        }
        else
        {
            Debug.LogWarning("�Ҵ�� 3D ���� �����ϴ�: " + paper.paperName);
        }
    }


    private void OnMouseDown()
    {
        isRot = true;
    }

    private void OnMouseUp()
    {
        isRot = false;
    }

    void UseItem()
    {
        if (currentItemIndex >= 0 && currentItemIndex < itemOrder.Count)
        {
            Item item = itemOrder[currentItemIndex];
            item.Use(); // �������� Use �޼��� ȣ��
            if (item.hasFun)
            {
                RemoveItem(item);
            }
        }
        else
        {
            Debug.LogError("���� ������ �ε����� ��ȿ���� �����Ű���..??����??");
        }
    }

    public void SelectPrevItem()
    {
        if (itemOrder.Count == 1 || currentItemIndex <= 0)
        {
            return;
        }

        currentItemIndex--;
        SelectItem(currentItemIndex);
    }

    public void SelectPrevPaper()
    {
        if (paperOrder.Count == 1 || currentPaperIndex <= 0)
        {
            return;
        }

        currentPaperIndex--;
        SelectPaper(currentPaperIndex);
    }

    public void SelectNextItem()
    {
        if (currentItemIndex >= itemOrder.Count)
        {
            return;
        }

        currentItemIndex++;
        SelectItem(currentItemIndex);
    }

    public void SelectNextPaper()
    {
        if (currentPaperIndex >= paperOrder.Count)
        {
            return;
        }

        currentPaperIndex++;
        SelectPaper(currentPaperIndex);
    }

    void SelectItem(int index)
    {
        // ���� ���� ���¿��� ���� ����� ������ �����մϴ�.
        if (currentItemSelectBG != null)
        {
            Destroy(currentItemSelectBG);
            if (itemIcons.TryGetValue(itemOrder[currentItemIndex], out var icon))
            {
                // �������� ���� �θ�� �����ϰ�, ��ġ�� �߾����� ����
                icon.transform.SetParent(itemIconParent, false);
                icon.rectTransform.anchoredPosition = Vector2.zero;
            }
        }

        Item item = itemOrder[index];
        ShowItemDetail(item);

        // ���� ���õ� �������� ������ ��������
        Image selectedItemIcon = itemIcons[item];

        // ���� ����� content�� �ڽ����� ����
        //itemSelectBG.transform.SetParent(itemIconParent.transform, false);
       // RectTransform selectBGRectTransform = itemSelectBG.GetComponent<RectTransform>();
        // ���� ��� Ȱ��ȭ
        //itemSelectBG.enabled = true;
        // ���� ����� �������� �ڽ����� ����� ���� ��ġ ����
        //selectBGRectTransform.anchoredPosition = Vector2.zero;

        // ���� ����� �������� ���� ��ġ��Ű�� ���� �������� ���� ����� �ڽ����� ����
        selectedItemIcon.transform.SetParent(itemSelectBG.transform, false);

        // �������� ��ġ�� ���� ����� �߾����� ����
        selectedItemIcon.rectTransform.anchoredPosition = Vector2.zero;



        // ���� ���õ� ������ �ε��� ������Ʈ
        currentItemIndex = index;
    }

    void SelectPaper(int index)
    {
        // ���� ���� ���¿��� ���� ����� ������ �����մϴ�.
        if (currentPaperSelectBG != null)
        {
            Destroy(currentPaperSelectBG);
            if (pN.TryGetValue(paperOrder[currentPaperIndex], out var text))
            {
                // �ؽ�Ʈ�� ���� �θ�� �����ϰ�, ��ġ�� �߾����� ����
                text.transform.SetParent(paperIconParent, false);
                text.rectTransform.anchoredPosition = Vector2.zero;
            }
        }

        Paper paper = paperOrder[index];
        ShowPaperDetail(paper);

        // ���� ���õ� ������ �ؽ�Ʈ ��������
        TextMeshProUGUI selectedPaperN = pN[paper];

        // ���� ����� content�� �ڽ����� ����
        currentPaperSelectBG = Instantiate(paperSelectBG.gameObject, paperIconParent);
        RectTransform selectBGRectTransform = currentPaperSelectBG.GetComponent<RectTransform>();
        // ���� ����� �ؽ�Ʈ�� �ڽ����� ����� ���� ��ġ ����
        selectBGRectTransform.anchoredPosition = Vector2.zero;

        // ���� ��� Ȱ��ȭ
        currentPaperSelectBG.SetActive(true);

        // ���� ����� �ؽ�Ʈ�� ���� ��ġ��Ű�� ���� �ؽ�Ʈ�� ���� ����� �ڽ����� ����
        selectedPaperN.transform.SetParent(currentPaperSelectBG.transform, false);

        // �ؽ�Ʈ�� ��ġ�� ���� ����� �߾����� ����
        selectedPaperN.rectTransform.anchoredPosition = Vector2.zero;



        // ���� ���õ� ���� �ε��� ������Ʈ
        currentPaperIndex = index;
    }

    public void Ui2On()
    {
        if (isRot == true)
        {
            float rotSpeed = 100f * Time.unscaledDeltaTime;
            float rotX = Input.GetAxis("Mouse X") * rotSpeed;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed;
            currentItem.transform.Rotate(Vector3.up * rotX);
            currentItem.transform.Rotate(Vector3.left * rotY);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseItem();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectPrevItem();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectNextItem();
        }
    }

    public void Ui3On()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectPrevPaper();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SelectNextPaper();
        }

    }

}
