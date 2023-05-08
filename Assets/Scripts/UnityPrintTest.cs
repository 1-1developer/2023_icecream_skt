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
    public class UnityPrintTest : MonoBehaviour
    {
        //private bool useprinterdriver;
        private string m_strPrinter;

        public TextMeshProUGUI logtxt;
        public TMP_InputField inPort;
        public TMP_InputField inIP;
        public TMP_InputField inbaudRate;

        [Header("driver")]
        public Toggle useprinterdriver;
        public TMP_InputField indrivername;


        // public string inPort;
        //public string inIP;
        //public string inbaudRate;

        private void Start()
        {
            logtxt.text = "log";
        }

        private void Update()
        {
            
        }
        public void openButton_Click()
        {
            string port;
            long lResult = 0;
            Int32 baudRate = 0;

            //int sIndex = int.Parse(inPort.text); 
            //if (sIndex == 8)
            //{
            //    // connect network
            //    lResult = LKPrint.OpenPort(inIP.text, 9100); //포트네임  "USB001" ??
            //}

                // connect other Interface 
                port = inPort.text;
                baudRate = Int32.Parse(inbaudRate.text);
                lResult = LKPrint.OpenPort(port, baudRate);

            if (lResult != 0)
            {
                Debug.Log("Open Port Failed");
                logtxt.text="Open Port Failed";
                return;
            }
            else
            {
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
            string strCenter = "\x1B\x61\x31"; // 중앙정렬
                                               //unsigned char strLeftPrintData[10] = "\x1B\x61\x00"; // 왼쪽정렬
                                               //string strLeftPrintData = "\x1B\x61\x00"; // 왼쪽정렬
                                               //            string strLeft = "\x1B\x61\x30"; // 왼쪽정렬
            string strRight = "\x1B\x61\x32"; // 오른쪽정렬

            string strDouble = "\x1B\x21\x20"; // Horizontal Double
            string strUnderline = "\x1B\x21\x80"; // underline
            string strDoubleBold = "\x1B\x21\x28"; // Emphasize
            string strNormal = "\x1B\x21\x02"; // 중앙정렬
            string PartialCut = "\x1D\x56\x42\x01"; // Partial Cut.


            string BarCodeHeight = "\x1D\x68\x50"; // 바코드 높이
            string BarCodeWidth = "\x1D\x77\x02"; // 바코드 폭
            string SetHRI = "\x1D\x48\x02"; // HRI문자 인쇄위치 아래인쇄지정
            string SetCode128B = "\x1D\x6B\x49"; // Code128

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
            TempStr = TempStr + "Chicken                             $10.00\r\n";
            TempStr = TempStr + "Hamburger                           $20.00\r\n";
            TempStr = TempStr + "Pizza                               $30.00\r\n";
            TempStr = TempStr + "Lemons                              $40.00\r\n";
            TempStr = TempStr + "Drink                               $50.00\r\n\r\n";
            TempStr = TempStr + "Excluded tax                       $150.00\r\n";
            TempStr = TempStr + strUnderline;
            TempStr = TempStr + "Tax(5%)                              $7.50\r\n";
            TempStr = TempStr + strDoubleBold;
            TempStr = TempStr + "Total         $157.50\r\n\r\n";
            TempStr = TempStr + strNormal;
            TempStr = TempStr + "Payment                            $200.00\r\n";
            TempStr = TempStr + "Change                              $42.50\r\n\r\n";
            TempStr = TempStr + "==========================================\r\n";
            TempStr = TempStr + strNormal + strCenter;
            TempStr = TempStr + BarCodeHeight; // 바코드 높이
            TempStr = TempStr + BarCodeWidth; // 바코드 폭
            TempStr = TempStr + SetHRI; // HRI문자 인쇄위치 아래인쇄지정

            TempStr = TempStr + SetCode128B + "\x0e" + "\x7B\x42"; //14 => 인쇄할 바코드 자리수 + Code128b선택
            TempStr = TempStr + "abc456789012" + "\x0A"; // 인쇄할 바코드 데이타


            if (useprinterdriver.isOn)
            {
                //m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    Debug.Log("OpenPrinter Failed");
                    logtxt.text = "OpenPrinter Failed";

                    return;
                }
            }

            LKPrint.PrintStart();
            LKPrint.PrintString(TempStr);
            LKPrint.PrintBitmap(".\\Logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, 0, 5, 0);

            //    PrintString(strCenter + "Test for PrintData Function\n");
            //    PrintData(strLeftPrintData, 3);
            //    PrintString("Test for PrintData Function\n");

            LKPrint.PrintString(PartialCut);

            LKPrint.PrintStop();

            if (useprinterdriver.isOn)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    Debug.Log("ClosePrinter Failed!!!");
                    logtxt.text = "ClosePrinter Failed!!!";
                }
            }
        }
        public void printNormalButton_Click()
        {
            // TODO: Add your control notification handler code here
            long lResult;

            if (useprinterdriver.isOn)
            {
                m_strPrinter = indrivername.text;
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    Debug.Log("OpenPrinter Failed");
                    logtxt.text = "OpenPrinter Failed";

                    return;
                }
            }

            LKPrint.PrintStart();

            LKPrint.PrintBitmap(".\\Logo.bmp", 1, 0, 5, 0); // Print Bitmap

            LKPrint.PrintNormal("\x1b|rATEL (123)-456-7890\n\n\n");
            LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");
            LKPrint.PrintNormal("\x1b|cADate\n\n");
            LKPrint.PrintNormal("Chicken                             $10.00\n");
            LKPrint.PrintNormal("Hamburger                           $20.00\n");
            LKPrint.PrintNormal("Pizza                               $30.00\n");
            LKPrint.PrintNormal("Lemons                              $40.00\n");
            LKPrint.PrintNormal("Drink                               $50.00\n");
            LKPrint.PrintNormal("Excluded tax                       $150.00\n");
            LKPrint.PrintNormal("\x1b|uCTax(5%)                              $7.50\n");
            LKPrint.PrintNormal("\x1b|bC\x1b|2CTotal         $157.50\n\n");
            LKPrint.PrintNormal("Payment                            $200.00\n");
            LKPrint.PrintNormal("Change                              $42.50\n\n");
            LKPrint.PrintBarCode("1234567890", 109, 40, 512, 1, 2); // Print Barcode

            LKPrint.PrintBitmap(".\\LUKHAN-logo.bmp", 1, 0, 5, 1); // Print Bitmap

            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

            LKPrint.PrintStop();

            if (useprinterdriver.isOn)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    Debug.Log("ClosePrinter Failed!!!");
                    logtxt.text = "ClosePrinter Failed!!!";

                }
            }
        }
    }
}
