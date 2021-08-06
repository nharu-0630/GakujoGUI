# GakujoGUI

![Affairs System](https://raw.githubusercontent.com/xyzyxJP/GakujoGUI/main/GakujoGUI/As_Icon.ico)

`GakujoGUI`は静岡大学の学務情報システムをGUIで操作するためのソフトウェアアプリケーション

## Documentation

### Installation

[v1.8.7888.29360](https://github.com/xyzyxJP/GakujoGUI/releases/tag/v1.8.7888.29360)

#### Recommended

1. Releaseのページから該当バージョンをダウンロード
2. ファイルを展開後、`GakujoGUI.exe`を起動
3. `静大ID`, `パスワード`, `氏名`, `学籍番号`を入力、ログイン

#### Latest

1. [Code](https://github.com/xyzyxJP/GakujoGUI/archive/refs/heads/main.zip)をダウンロード
2. ファイルを展開後、`Visual Studio 2019`でコンパイル
3. `GakujoGUI.exe`を起動
4. `静大ID`, `パスワード`, `氏名`, `学籍番号`を入力、ログイン

### Usage

#### ログイン

##### 通常ログイン

- `静大ID`, `パスワード`, `氏名`, `学籍番号`をもとに、通常の学務情報システムへのログインと同様の通信を行う
- CSSファイルや画像ファイルの通信は行わないため、ブラウザ上でのログインより高速である

##### キャッシュログイン

- `cookies`, `apacheToken`をもとに、ログイン状態を再現し、学務情報システムのホーム画面の取得を行う
- クッキーの期限が切れている場合やログイン状態が上書きされた場合などは、ログインできない

#### 保存データ

##### ログイン情報

`静大ID`, `パスワード`, `氏名`, `学籍番号`を`account.json`に保存

```
{"userId":"\l{2}\d{6}","passWord":"[\u\l\d]{1,}","studentName":"山田　太郎","studentCode":"\d{8}","apacheToken":"[\u\l\d]{32}"}
```

##### クッキー

- `httpClientHandler`の`CookieContainer`を`cookies`に保存
- `apacheToken`については`account.json`に保存

##### 授業連絡, レポート, 小テスト, 学内連絡

- 授業連絡 `classContact.json`
- レポート `report.json`
- 小テスト `quiz.json`
- 学内連絡 `schoolContact.json`

---

- 授業連絡
	- 一覧表示
		- 授業科目
		- タイトル
		- 連絡日時
	- 詳細表示
		- 内容
		- ファイル
- レポート
	- 一覧表示
		- 授業科目
		- タイトル
		- 状態
		- 提出期間
		- 最終提出日時
	- 詳細表示
		- 評価方法
		- 説明
		- ~~参考資料~~(未実装)
		- 伝達事項
		- 催促通知
		- レポート提出履歴
	- 提出開始(単一ファイルのみ, コメント不可)
	- 提出取消
- 小テスト
	- 一覧表示
		- 授業科目
		- タイトル
		- 状態
		- 提出期間
		- 提出状況
	- 提出開始
	- 提出取消
- 学内連絡
	- 一覧表示
		- カテゴリ
		- タイトル
		- 連絡日時
	- 詳細表示
		- 内容
		- ファイル

---

[@xyzyxJP](https://twitter.com/xyzyxJP)
