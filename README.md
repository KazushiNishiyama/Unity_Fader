# Unity_Fader

Unityでフェードアウト、フェードインが行えるクラスです。<br>
Unity5で作成しました。<br><br>


ヒエラルキーでフェード用のImageを作成し、インスペクターからスクリプトに貼り付けるといった作業が必要がないので使いやすいと思います。<br>
フェードインとフェードアウトを分けて呼び出せるので、その間に処理を挟む事ができます。<br>
暗転状態を任意の秒数維持するための関数も用意してあります。<br><br>

フェードの色が黒色にしか対応していない点と、シーンをまたいで使うことができない点に注意してください。<br><br><br>



パラメータ説明<br>

  span : フェードが完了するまでにかかる時間です<br>
