# tklab-vrchat-world
研究室ワールド

## 環境
- Unity 2019.4.31f1 
- VRChat3 2022.06.03.00.03 
- UdonSharp v0.20.3

## 構成
よく編集するものは``で囲ってハイライトしています
```markdown
├ .idea/ Riderエディタの設定ファイル群(基本直接編集しない)  
├ Assets/　各種アセット
  ├ Chair and Worn Sofa 椅子とソファー
  ├ CyanTrigger VRChat3のイベント処理に使用するアセット
  ├ CyanTriggerExamples CyanTriggerの例
  ├ CyanTriggerSerialized　CyanTriggerのUdon形式
  ├ Esperecyan　．fbx/．blend形式の3DモデルをVRMプレハブに変換するアセットUniVRMの拡張アセット
  ├ Gizmos　UdonSharpアセットを格納
  ├ Kinel Videoプレイヤーアセット
  ├ `Models 各種3Dモデル(建物自体に使用するプレハブを格納)`
  ├ Plugins Dotween(アニメーションをスクリプトで書くためのアセット)を格納
  ├ `Prefabs 各種3Dモデル(建物内で使用するプレハブを格納)`
  ├ ProBuilder Data ProBuilder（Unity内で3Dモデルを成形するためのアセット）に関するデータ
  ├ `Resources マテリアルやサウンドなどのリソースを格納`
  ├ Scenes Unityのシーン群 
  ├ `Scripts　カスタムC#/U#スクリプト`
  ├ SerializedUdonPrograms　U#スクリプトをUdon形式に変換されたバイナリ
  ├ TextMesh Pro Unityでテキストを扱うためのアセット
  ├ `UI　2Dアセット`
  ├ Udon
  ├ UdonSharp　
  ├ UniGLTF UniVRMが依存するフォーマットを扱うアセット
  ├ UrbanNightSky 夜をイメージしたskyboxアセット
  ├ VRCSDK VRChatのSDK
  ├ VRChat Examples VRChat　World作成の例
  ├ VRM　VRM形式の3Dアセットを扱うアセット
  ├ VRMShade VRMで使うシェーダー
├ Packages/ 各種パッケージ(基本直接編集しない)  
├ ProjectSettings/　プロジェクト設定ファイル群(基本直接編集しない)  
├ .gitignore   
├ LICENSE  
├ README.md  
```

## Reference
- [CyanTrigger wiki](https://github.com/CyanLaser/CyanTrigger/wiki)
- [VRChat World wiki](https://vrcworld.wiki.fc2.com/wiki/%E3%83%AF%E3%83%BC%E3%83%AB%E3%83%89%E4%BD%9C%E6%88%90%E3%83%92%E3%83%B3%E3%83%88%E9%9B%86)
- [KineLVideoPlayer wiki](https://github.com/niwaniwa/KineLVideoPlayer/wiki)
