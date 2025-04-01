
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
        private static int textId = 23;
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
            //Debug.WriteLine("idx "+ idx);
            
            Point targetPos = selector.GetWordFromDB(textId, idx); //new Point(idx, idx + 3);

            //�ش� ����� ���� ������
            TextRange selectedText = selector.GetSelectedTextRange(textBox.Document.ContentStart, (int)targetPos.X, (int)targetPos.Y);

            if (selectedText != null)
            {
                selector.SetTextColorToSelectedText(selectedText);
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
        static public void RequestDictionary()
        {
            HttpRequest req = new("https://api.dictionaryapi.dev/api/v2/entries/en");
            string word=selector.GetText();
            req.RequestDictionary(word);
        }
        static public void HighlightPOS(RichTextBox textBox)
        {
            string word=selector.GetText();
            //DB���� ��� �ܾ ã�´�
            List<WordData> targets = new List<WordData>();
            targets=selector.GetWordsFromDB(textId, word);

            //�� �ܾ��� ǰ�翡 �´� ������ �����Ѵ�
            targets.ForEach(data =>
            {
                TextRange selectedText = selector.GetSelectedTextRange(textBox.Document.ContentStart, data.start, data.end);
                if (selectedText != null)
                {
                    selector.SetBackgroundColorToSelectedText(selectedText, Brushes.Cyan);
                }
            });
        }
    }
}

