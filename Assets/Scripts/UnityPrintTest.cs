using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Text;
using System;

namespace LKCSTest
{
    public class UnityPrintTest : MonoBehaviour
    {
        private bool useprinterdriver;
        private string m_strPrinter;
        public void Print()
        {

        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            LKPrint.ClosePort();
            //this.Close();
        }

        private void printStringButton_Click(object sender, EventArgs e)
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


            if (useprinterdriver)
            {
                //m_strPrinter = pDriverNameTextBox.Text.ToString();
                lResult = LKPrint.OpenPort(m_strPrinter, 1);
                if (lResult != 0)
                {
                    //MessageBox.Show("OpenPrinter Failed", "Error", MessageBoxButtons.OK);
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

            if (useprinterdriver)
            {
                lResult = LKPrint.ClosePort();
                if (lResult != 0)
                {
                    //MessageBox.Show("ClosePrinter Failed!!!", "Error", MessageBoxButtons.OK);
                }
            }
        }
    }
}
