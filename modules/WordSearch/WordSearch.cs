
using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Utiliy.TextSelector;

namespace WordSearch
{
    public class Interface
    {
        private static Selector selector = new Selector();
        /// <summary>
        /// ���õ� ���ڿ� ǥ�� �޼��� 
        /// <para>
        /// ��� ����)
        /// </para>
        /// Point mousePos = e.GetPosition(richTextBox);<br/>
        /// WordSearch.Interface.SelectRange(richTextBox, mousePos);
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="mousePt"></param>
        static public void SelectRange(RichTextBox textBox, Point mousePt)
        {

            //���콺 ��ġ�� �ִ� ������ ��ġ(�ε���)�� ������
            //Selector sel = new Selector();
            int idx = selector.GetCharIndexFromPoint(textBox,mousePt);

            //DB���� �ε���(idx)�� �ش��ϴ� �ܾ��� ����, �� �κ��� ������
            //Point targetPos = DBManager.GetWord(idx); //����
            Point targetPos = new Point(idx, idx + 3);

            //�ش� ����� ���� ������
            TextRange selectedText = selector.GetSelectedTextRange(textBox.Document.ContentStart, (int)targetPos.X, (int)targetPos.Y);

            if (selectedText != null)
            {
                selector.ColorSelectedText(selectedText);
            }

        }
        /// <summary>
        /// �ؽ�Ʈ �ڽ� ��Ÿ�� �ʱ�ȭ<br/>
        /// Ŀ�� ����, ĳ�� ����
        /// </summary>
        /// <param name="textBox"></param>
        static public void InitStyle(RichTextBox textBox)
        {
            textBox.Cursor = Cursors.Hand;
        }
        static public async Task RequestDictionary(TextBox outputBox)
        {
            HttpRequest req = new("https://api.dictionaryapi.dev/api/v2/entries/en");
            string word = selector.GetText();

            string result = await req.GetDictionaryResult(word); // �ؼ� �޾ƿ���
            outputBox.Text = result;                             // ȭ�鿡 ����
        }

    }
}

