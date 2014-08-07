using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiTextMaker
{
    public partial class WinMidiTextMaker : Form
    {

        public WinMidiTextMaker()
        {
            InitializeComponent();
        }

        private void WinMidiTextMaker_Load(object sender, EventArgs e)
        {
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //文字コードを指定する
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding("shift_jis");

            //POST送信する文字列を作成
            string postData =
                "inlang=ja&miditext=" +
                    System.Web.HttpUtility.UrlEncode(txtMidiText.Text, enc);
            //バイト型配列に変換
            byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);

            //WebRequestの作成
            System.Net.WebRequest req =
                System.Net.WebRequest.Create("http://comiclo.jp/nanikatsukurouka/phpmidi/GetMidiText.php");
            //メソッドにPOSTを指定
            req.Method = "POST";
            //ContentTypeを"application/x-www-form-urlencoded"にする
            req.ContentType = "application/x-www-form-urlencoded";
            //POST送信するデータの長さを指定
            req.ContentLength = postDataBytes.Length;

            //データをPOST送信するためのStreamを取得
            System.IO.Stream reqStream = req.GetRequestStream();
            //送信するデータを書き込む
            reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            reqStream.Close();

            //サーバーからの応答を受信するためのWebResponseを取得
            System.Net.WebResponse res = req.GetResponse();
            //応答データを受信するためのStreamを取得
            System.IO.Stream resStream = res.GetResponseStream();
            //受信して表示
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream, enc);
            //Console.WriteLine(sr.ReadToEnd());
            txtURL.Text = sr.ReadToEnd();
            //閉じる
            sr.Close();
        }

        private void txtMidiText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
