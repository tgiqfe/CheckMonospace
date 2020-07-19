# CheckMonospace

システムに登録されているフォントから、プロポーショナルフォントと等幅フォントを分けてList化。  

WindowsForm用とWPF用の2種類

| クラス名        | 用途          | List化するフォントのクラス      |
| ----------------| ------------- | ------------------------------- |
| DrawingFontInfo | WindowsForm用 | System.Drawing.Font             |
| MediaFontInfo   | WPF用         | System.Windows.Media.FontFamily |

## やってること

1. フォント(ファミリー)の一覧を取り出し。
2. 「iiii」と「wwww」の幅をチェック。  
不一致ならば「プロポーショナル」。
3. 一致ならば、さらに「ああ」の幅もチェック。
幅の差が「1」以上ならば「プロポーショナル」。
4. 幅の差が「1」未満ならば「等幅」
5. それぞれを``ProportionalList``と``MonospaceList``に格納

## 使い方

用途に合わせて``DrawingFontInfo.cs``や``MediaFontInfo.cs``の中のコードをコピー/貼り付け等で使用してください。


## サンプル

WindowsFormで使用する場合
```csharp
DrawingFontInfo dfi = new DrawingFontInfo();

Console.WriteLine("======== プロポーショナルフォント ===========");
foreach (var font in dfi.ProportionalList)
{
    Console.WriteLine(font.Name);
}

Console.WriteLine("======== 等幅フォント =======================");
foreach (var font in dfi.MonospaceList)
{
    Console.WriteLine(font.Name);
}
```

WPFで使用する場合
```csharp
MediaFontInfo mfi = new MediaFontInfo();

Console.WriteLine("プロポーショナルフォント ===================");
foreach (var font in mfi.ProportionalList)
{
    Console.WriteLine(font.Source);
}

Console.WriteLine("等幅フォント ===============================");
foreach (var font in mfi.MonospaceList)
{
    Console.WriteLine(font.Source);
}
```

## その他

「源ノ角ゴシック Code JP (Source Han Code JP)」が、

- i×2文字の幅 ＝ w×2文字の幅
- 半角×3文字の幅 ＝ 全角×2文字の幅

なので、ネット上によくある「iii」と「www」の幅チェックだけでは「源ノ角ゴシック Code JP (Source Han Code JP)」が等幅フォントとなってしまうので、日本語文字も使って幅チェック。  
今後特殊なフォントに出会い次第、判定式を追加する予定。

## License

MIT License
