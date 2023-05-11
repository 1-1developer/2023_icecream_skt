using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Text;
using System;
using TMPro;
using UnityEngine.UI;


namespace LKCSTest
{
    public class PrintTest : MonoBehaviour
    {

        public TextMeshProUGUI logtxt;
        public TMP_Dropdown inPort;
        public TMP_Dropdown inbaudRate;
        public TMP_InputField infont;
        private void Start()
        {
            logtxt.text = "log";
            inPort.value = 0;
            inbaudRate.value = 0;
            infont.text = "����";
        }
        public void openButton_Click()
        {
            string port;
            long lResult = 0;
            Int32 baudRate = 0;

            // connect other Interface 
            port = inPort.options[inPort.value].text;
            baudRate = Int32.Parse(inbaudRate.options[inbaudRate.value].text);
            lResult = LKPrint.OpenPort(port, baudRate);
            LKPrint.SetEncoding(51949);
            if (lResult != 0)
            {
                Debug.Log("Open Port Failed");
                logtxt.text = "Open Port Failed";
                return;
            }
            else
            {
                logtxt.text = "�����";
            }
        }

        public void exitButton_Click()
        {
            LKPrint.ClosePort();
            //this.Close();
        }


        public void printStringButton_Click()
        {
            // TODO: Add your control notification handler code here
            string TempStr;
            string strCenter = "\x1B\x61\x31"; // �߾�����
                                               //unsigned char strLeftPrintData[10] = "\x1B\x61\x00"; // ��������
                                               //string strLeftPrintData = "\x1B\x61\x00"; // ��������
                                               //            string strLeft = "\x1B\x61\x30"; // ��������
            string strRight = "\x1B\x61\x32"; // ����������

            string strDouble = "\x1B\x21\x20"; // Horizontal Double
            string strUnderline = "\x1B\x21\x80"; // underline
            string strDoubleBold = "\x1B\x21\x28"; // Emphasize
            string strNormal = "\x1B\x21\x02"; // �߾�����
            string PartialCut = "\x1D\x56\x42\x01"; // Partial Cut.


            string BarCodeHeight = "\x1D\x68\x50"; // ���ڵ� ����
            string BarCodeWidth = "\x1D\x77\x02"; // ���ڵ� ��
            string SetHRI = "\x1D\x48\x02"; // HRI���� �μ���ġ �Ʒ��μ�����
            string SetCode128B = "\x1D\x6B\x49"; // Code128
            //string SetCode = "\x1D\x6B\x49"; // Code128

            long lResult;

            TempStr = "";
            TempStr = TempStr + strDouble;
            TempStr = TempStr + strCenter;
            TempStr = TempStr + "Receipt List\r\n\r\n\r\n";
            TempStr = TempStr + strNormal;
            TempStr = TempStr + strRight;
            TempStr = TempStr + "Right Alignment\r\n";
            TempStr = TempStr + strCenter;
            TempStr = TempStr + "Thank you for coming to our shop!\r\n";
            TempStr = TempStr + "==========================================\r\n";
            TempStr = TempStr + strDoubleBold;
            TempStr = TempStr + "\x1c\x26        �����������/��       \r\n";
            TempStr = TempStr + "\x1c\x26        �����������/��       \r\n";
            TempStr = TempStr + strUnderline;
            TempStr = TempStr + strNormal;
            TempStr = TempStr + "Payment                            $200.00\r\n";
            TempStr = TempStr + "Change                              $42.50\r\n\r\n";
            TempStr = TempStr + "==========================================\r\n";
            TempStr = TempStr + strNormal + strCenter;
            TempStr = TempStr + BarCodeHeight; // ���ڵ� ����
            TempStr = TempStr + BarCodeWidth; // ���ڵ� ��
            TempStr = TempStr + SetHRI; // HRI���� �μ���ġ �Ʒ��μ�����

            TempStr = TempStr + SetCode128B + "\x0e" + "\x7B\x42"; //14 => �μ��� ���ڵ� �ڸ��� + Code128b����
            TempStr = TempStr + "abc456789012" + "\x0A"; // �μ��� ���ڵ� ����Ÿ


            logtxt.text = "go print";
            LKPrint.PrintStart();
            logtxt.text = "print start";
            LKPrint.PrintString(TempStr);
            //LKPrint.PrintBitmap(".\\Logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, 0, 5, 0);
            logtxt.text = "Logo.bmp";


            LKPrint.PrintString(PartialCut);
            logtxt.text = "PartialCut";

            LKPrint.PrintStop();

            logtxt.text = "print end";

        }
        public void printNormalButton_Click()
        {
            // TODO: Add your control notification handler code here
            long lResult;


            logtxt.text = "go print";
            LKPrint.PrintStart();
            logtxt.text = "print start";

            //LKPrint.PrintBitmap(".\\Logo.bmp", 1, 0, 5, 0); // Print Bitmap
            logtxt.text = "print 1";

            LKPrint.PrintNormal("\x1b|rATEL (123)-456-7890\n\n\n");
            LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");
            LKPrint.PrintNormal("\x1b|cADate\n\n");
            LKPrint.PrintText2Image(infont.text, 1, 24, "                �����������/��          \n",0);
            LKPrint.PrintText2Image(infont.text, 1, 24, "                �����������/��          \n",0);
            LKPrint.PrintText2Image(infont.text, 1, 24, "                �����������/��          \n",0);
            LKPrint.PrintNormal("\x1c\x26 �������� ���� �ѱ� ����� \n");
            LKPrint.PrintNormal("\x1c\x26 �������� ���� �ѱ� ����� \n");
            LKPrint.PrintNormal("==========================================\r\n");

            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
            LKPrint.PrintNormal("\x0ePizza                               $30.00\n");
            LKPrint.PrintNormal("Lemons         2                     $40.00\n");
            LKPrint.PrintNormal("\x0f Drink        2                       $50.00\n");
            LKPrint.PrintNormal("\x0a\xb0\xb1\xb0\xd4\xbc\xba\xc7\xb0\n");
            LKPrint.PrintNormal("\x1b|uCTax(5%)                              $7.50\n");
            LKPrint.PrintNormal("\x1b|bC\x1b|2CTotal         $157.50\n\n");
            LKPrint.PrintNormal("Payment                            $200.00\n");
            LKPrint.PrintNormal("Change                              $42.50\n\n");
            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // Print Barcode

            //LKPrint.PrintBitmap(".\\LUKHAN-logo.bmp", 1, 0, 5, 1); // Print Bitmap

            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

            LKPrint.PrintStop();
            logtxt.text = "print end";
        }

        public void printimage()
        {
            try
            {
                // TODO: Add your control notification handler code here
                long lResult;

                logtxt.text = "go print";
                LKPrint.PrintStart();
                logtxt.text = "print start";
                string imagePath = Application.dataPath + "/Resources/mm.bmp";
                LKPrint.PrintBitmap(imagePath, 1, 0, 5, 0); // Print Bitmap
                logtxt.text = "print logo";

                LKPrint.PrintNormal("\x1b|rATEL (123)-456-7890\n\n\n");
                LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");
                LKPrint.PrintNormal("\x1b|cADate\n\n");
                LKPrint.PrintNormal("\x1b$}C" +"Drink                               $50.00\n");
                LKPrint.PrintNormal("Excluded tax                       $150.00\n");
                LKPrint.PrintNormal("\x1b|uCTax(5%)                              $7.50\n");
                LKPrint.PrintNormal("\x1b|bC\x1b|2CTotal         $157.50\n\n");
                LKPrint.PrintNormal("Payment                            $200.00\n");
                LKPrint.PrintBitmap(imagePath, 1, 0, 5, 1); // Print Bitmap

                LKPrint.PrintNormal("Change                              $42.50\n\n");
                LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // Print Barcode

                //LKPrint.PrintBitmap(".\\LUKHAN-logo.bmp", 1, 0, 5, 1); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

                LKPrint.PrintStop();
                logtxt.text = "print end";

            }
            catch
            {
                LKPrint.PrintStop();
                logtxt.text = "image print Failed";
            }
          
        }
    }
}
