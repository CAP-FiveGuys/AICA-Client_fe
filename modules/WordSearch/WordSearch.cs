
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using TextSelector;

namespace WordSearch
{
    public class Interface
    {
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
            Selector sel = new Selector();
            int idx =sel.GetCharIndexFromPoint(textBox,mousePt);

            //DB���� �ε���(idx)�� �ش��ϴ� �ܾ��� ����, �� �κ��� ������
            //Point targetPos = DBManager.GetWord(idx); //����
            Point targetPos = new Point(idx, idx + 1);

            //�ش� ����� ���� ������
            sel.ColorSelectedText(textBox.Document.ContentStart, (int)targetPos.X, (int)targetPos.Y);
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
    }
}

