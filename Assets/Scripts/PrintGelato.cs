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
    public class PrintGelato : MonoBehaviour
    {
        public TextMeshProUGUI logtxt;
        public TMP_Dropdown inPort;
        public TMP_Dropdown inbaudRate;

        public GameObject warningwindow;
        public TextMeshProUGUI warningtxt;
        public QuestionData data;
        public GelatoVideoManager gelatoVideoManager;

        static int orderNum = 1;

        string root1 = "PC";
        string root2 = "TECHMAX";
        string root;

        string root3 = "C:\\images";

        string iceImage;
        string adot;
        string cup;
        bool seleccup =false;
        bool selecice =false;

        string A = "A-";
        string B = "B-";
        string order = "";
        private void Start()
        {
            warningwindow.SetActive(false);
            
            logtxt.text = "log";

            portOpen();
            setkiosk();
            inPort.value = 0;
            inbaudRate.value = 0;
        }

        public void setkiosk()
        {
            order = B;
            root = root1;
        }
        public void FEED()
        {
            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
            LKPrint.PrintNormal("\n\n");
            LKPrint.PrintNormal("\n\n");
            LKPrint.PrintNormal("\n\n");
            LKPrint.PrintNormal("\n\n");
            LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

        }
        public void portOpen()
        {
            string port;
            long lResult = 0;
            Int32 baudRate = 0;

            // connect other Interface 
            port = "COM3";
            baudRate = 115200;
            lResult = LKPrint.OpenPort(port, baudRate);
            // 51949

            if (lResult != 0)
            {
                Debug.Log("Open Port Failed");
                logtxt.text = "Open Port Failed";
                return;
            }
            else
            {
                logtxt.text = "연결됨";
            }
        }
        public void openButton_Click_debug()
        {
            string port;
            long lResult = 0;
            Int32 baudRate = 0;

            // connect other Interface 
            port = inPort.options[inPort.value].text;
            baudRate = Int32.Parse(inbaudRate.options[inbaudRate.value].text);
            lResult = LKPrint.OpenPort(port, baudRate);
            // 51949

            if (lResult != 0)
            {
                Debug.Log("Open Port Failed");
                logtxt.text = "Open Port Failed";
                return;
            }
            else
            {
                logtxt.text = "연결됨";
            }
        }
        public void exitButton_Click()
        {
            LKPrint.ClosePort();
            //this.Close();
        }
        private void OnApplicationQuit()
        {
            exitButton_Click();
        }
        public void SetGelato(TextMeshProUGUI tx)
        {
            switch (tx.text)
            {
                case "스위스초코":
                    SetGelatoResault(0, 1);
                    break;
                case "리조(쌀)":
                    SetGelatoResault(0, 2);
                    break;
                case "교토우지말차":
                    SetGelatoResault(0, 3);
                    break;
                case "패션후르츠소르베":
                    SetGelatoResault(1, 4);
                    break;
                case "베리베리요거트":
                    SetGelatoResault(1, 5);
                    break;
                case "수박":
                    SetGelatoResault(1, 6);
                    break;
                case "구운피스타치오":
                    SetGelatoResault(2, 7);
                    break;
                case "프렌치바닐라":
                    SetGelatoResault(2, 8);
                    break;
                case "흑임자":
                    SetGelatoResault(3, 9);
                    break;
                case "돼지또":
                    SetGelatoResault(3, 10);
                    break;
                default:
                    break;
            }
            selecice = true;
        }

        public void SetCup(int c)
        {
            if(c == 0)
            {
                cup = "cone";
            }
            else
            {
                cup = "cup";
            }
            seleccup = true;
        }
        public void SetGelatoResault(int adotint, int ice)
        {
            iceImage = ice.ToString();
            adot = "adot"+adotint.ToString();
        } 
        public void printimage()
        {
            if (!selecice)
            {
                warningwindow.SetActive(true);
                warningtxt.text = "아이스크림을 선택해주세요 !";
                return;
            }
            else if (!seleccup)
            {
                warningwindow.SetActive(true);
                warningtxt.text = "컵, 콘을 선택해주세요 !";
                return;
            }
            Debug.Log($"ice:{iceImage}/adot{adot}/ cup{cup}");
            #region MyRegion
            
           try
           {
               // TODO: Add your control notification handler code here
               long lResult;


               LKPrint.PrintStart();
               // PrintBitmap(directory, alignment, options, brightness, imagemod)
               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\{adot}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\t_order.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap
               LKPrint.PrintText($"{order+orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);
               LKPrint.PrintNormal("============================================\r\n");
               LKPrint.PrintNormal("\n\n");
               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\{iceImage+cup}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
               LKPrint.PrintNormal("\n\n");
               LKPrint.PrintNormal("============================================\r\n");

               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

               LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
               //---------------

               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\{adot}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap adot
               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\t_keep.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print keep

               LKPrint.PrintText($"{order + orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);

               LKPrint.PrintNormal("==========================================\r\n");
               LKPrint.PrintNormal("\n\n");
               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\{iceImage + cup}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
               LKPrint.PrintNormal("\n\n");
               LKPrint.PrintNormal("==========================================\r\n");

               LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

               LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

               LKPrint.PrintStop();
               logtxt.text = "print image end";
               orderNum++;
               seleccup = false;
               selecice = false;
               gelatoVideoManager.initializeGelato();
           }
           catch
           {
               LKPrint.PrintStop();
               logtxt.text = "image print Failed";
           }
               
            #endregion

            /*
            try
            {
                // TODO: Add your control notification handler code here
                long lResult;


                LKPrint.PrintStart();
                // PrintBitmap(directory, alignment, options, brightness, imagemod)
                LKPrint.PrintBitmap($"{root3}\\{adot}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintBitmap($"{root3}\\t_order.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap
                LKPrint.PrintText($"{order + orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);
                LKPrint.PrintNormal("============================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"{root3}\\{iceImage + cup}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("============================================\r\n");

                LKPrint.PrintBitmap($"{root3}\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
                                                //---------------

                LKPrint.PrintBitmap($"{root3}\\{adot}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap adot
                LKPrint.PrintBitmap($"{root3}\\t_keep.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print keep

                LKPrint.PrintText($"{order + orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);

                LKPrint.PrintNormal("==========================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"{root3}\\{iceImage + cup}.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("==========================================\r\n");

                LKPrint.PrintBitmap($"{root3}\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

                LKPrint.PrintStop();
                logtxt.text = "print image end";
                orderNum++;
                seleccup = false;
                selecice = false;
                gelatoVideoManager.initializeGelato();
            }
            catch
            {
                LKPrint.PrintStop();
                logtxt.text = "image print Failed";
            }
            */
        }
        public void printimage2()
        {
            
            try
            {
                // TODO: Add your control notification handler code here
                long lResult;

                LKPrint.PrintStart();
                // PrintBitmap(directory, alignment, options, brightness, imagemod)
                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\adot.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\t_order.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal(order + orderNum.ToString() + "\n");
                // LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");
                LKPrint.PrintNormal("============================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\1cup.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("============================================\r\n");

                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\t_keep.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print keep
                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\adot.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal(order + orderNum.ToString() + "\n");
                //LKPrint.PrintNormal("\x1b|cAThank you for coming to our shop!\n");

                LKPrint.PrintNormal("==========================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\1cup.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("==========================================\r\n");

                LKPrint.PrintBitmap($"C:\\Users\\{root}\\Desktop\\images\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

                LKPrint.PrintStop();
                logtxt.text = "print image test end";
                gelatoVideoManager.initializeGelato();
            }
            catch
            {
                LKPrint.PrintStop();
                logtxt.text = "image print Failed";
            }
            
            /*
            try
            {
                // TODO: Add your control notification handler code here
                long lResult;


                LKPrint.PrintStart();
                // PrintBitmap(directory, alignment, options, brightness, imagemod)
                LKPrint.PrintBitmap($"{root3}\\adot.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintBitmap($"{root3}\\t_order.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap
                LKPrint.PrintText($"{order + orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);
                LKPrint.PrintNormal("============================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"{root3}\\1cup.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("============================================\r\n");

                LKPrint.PrintBitmap($"{root3}\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.
                                                //---------------

                LKPrint.PrintBitmap($"{root3}\\adot.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap adot
                LKPrint.PrintBitmap($"{root3}\\t_keep.bmp", LKPrint.LK_ALIGNMENT_RIGHT, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print keep

                LKPrint.PrintText($"{order + orderNum.ToString()}\r\n\r\n", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_FNT_DEFAULT, LKPrint.LK_TXT_2WIDTH);

                LKPrint.PrintNormal("==========================================\r\n");
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintBitmap($"{root3}\\1cup.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_HEIGHT_DOUBLE, 5, 0); // Print Bitmap
                LKPrint.PrintNormal("\n\n");
                LKPrint.PrintNormal("==========================================\r\n");

                LKPrint.PrintBitmap($"{root3}\\logo.bmp", LKPrint.LK_ALIGNMENT_CENTER, LKPrint.LK_BITMAP_NORMAL, 5, 0); // Print Bitmap

                LKPrint.PrintNormal("\x1b|fP"); // Partial Cut.

                LKPrint.PrintStop();
                logtxt.text = "print test image end";
            }
            catch
            {
                LKPrint.PrintStop();
                logtxt.text = "image test print Failed";
            }
            */
        }
    }
}
