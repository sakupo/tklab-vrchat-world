
using TMPro;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ItemController : UdonSharpBehaviour
{
    [SerializeField] TextMeshProUGUI _displayText; //[SerializeField]を冒頭につけることでUnity inspectorから編集できる
    [UdonSynced(UdonSyncMode.None)]
    string _content = "Item Generator2";  //  [UdonSynced(UdonSyncMode.None)] 後から来た人にも同様な値を見せる


    //Start()はワールド起動時に実行されるメソッド
    void Start()
    {

    }

    public void Pressed()
    {
        _displayText.text = _content;
    }

    //操作対象とするオブジェクトの所有者が別のユーザーだった場合、所有者をオブジェクト操作者に移動させる。
    public void ChangeOwner()
    {
        if (!Networking.IsOwner(Networking.LocalPlayer, this.gameObject)) Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
    }


    //OnDeserialization 変数の同期が行われると呼び出されるメソッド 全員に同じdataを表示させるために必要なコマンドである。
    public override void OnDeserialization()
    {
        _displayText.text = _content;
    }
}
